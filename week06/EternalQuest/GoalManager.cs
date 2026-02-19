using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    // Exceeding requirements: Level + Badges
    private int _level = 1;
    private HashSet<string> _badges = new HashSet<string>();

    private readonly (int threshold, string badgeName)[] _badgeMilestones =
    {
        (1000,  "Bronze Beginner"),
        (5000,  "Silver Striver"),
        (10000, "Gold Grinder"),
        (20000, "Legendary Disciple")
    };

    public void Start()
    {
        Console.WriteLine("Welcome to Eternal Quest!");
        RecalculateLevelFromScore();
        CheckBadges();

        bool running = true;
        while (running)
        {
            Console.WriteLine();
            DisplayPlayerInfo();
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Show Score / Level / Badges");
            Console.WriteLine("  7. Quit");

            int choice = ReadInt("Select a choice from the menu: ", 1, 7);
            Console.WriteLine();

            switch (choice)
            {
                case 1: CreateGoal(); break;
                case 2: ListGoals(); break;
                case 3: SaveGoals(); break;
                case 4: LoadGoals(); break;
                case 5: RecordEvent(); break;
                case 6: ShowProgress(); break;
                case 7: running = false; break;
            }
        }

        Console.WriteLine("Goodbye! Keep going on your Eternal Quest!");
    }

    private void DisplayPlayerInfo()
    {
        Console.WriteLine($"Score: {_score} | Level: {_level} ({GetTitleForLevel(_level)}) | Next Level At: {(_level * 1000)}");
    }

    private void ShowProgress()
    {
        Console.WriteLine($"Score: {_score}");
        Console.WriteLine($"Level: {_level} - {GetTitleForLevel(_level)}");
        Console.WriteLine("Badges:");
        if (_badges.Count == 0)
        {
            Console.WriteLine("  (none yet)");
        }
        else
        {
            foreach (string b in _badges.OrderBy(x => x))
                Console.WriteLine($"  - {b}");
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");

        int type = ReadInt("Which type of goal would you like to create? ", 1, 3);

        string name = ReadString("What is the name of your goal? ");
        string desc = ReadString("What is a short description of it? ");
        int points = ReadInt("What is the amount of points associated with this goal? ", 1, 1_000_000);

        if (type == 1)
        {
            _goals.Add(new SimpleGoal(name, desc, points));
        }
        else if (type == 2)
        {
            _goals.Add(new EternalGoal(name, desc, points));
        }
        else
        {
            int target = ReadInt("How many times does this goal need to be accomplished for completion? ", 1, 1_000_000);
            int bonus = ReadInt("What is the bonus for accomplishing it that many times? ", 0, 1_000_000);
            _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
        }

        Console.WriteLine("Goal created!");
    }

    private void ListGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals yet. Create one first!");
            return;
        }

        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    private void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to record. Create one first!");
            return;
        }

        Console.WriteLine("Which goal did you accomplish?");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goals[i].GetName()}");
        }

        int index = ReadInt("Enter the number of the goal: ", 1, _goals.Count) - 1;

        int beforeScore = _score;
        int earned = _goals[index].RecordEvent();

        if (earned <= 0)
        {
            Console.WriteLine("No points awarded (this goal may already be completed).");
            return;
        }

        _score += earned;

        Console.WriteLine($"Congratulations! You have earned {earned} points.");
        Console.WriteLine($"You now have {_score} points.");

        CheckLevelUps(beforeScore, _score);
        CheckBadges();
    }

    private void SaveGoals()
    {
        string filename = ReadString("What is the filename for the goal file? ");
        try
        {
            List<string> lines = new List<string>();

            // Header lines
            lines.Add(_score.ToString());
            lines.Add(_badges.Count == 0 ? "" : string.Join(";", _badges));

            foreach (Goal g in _goals)
            {
                lines.Add(g.GetStringRepresentation());
            }

            File.WriteAllLines(filename, lines);
            Console.WriteLine("Goals saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}");
        }
    }

    private void LoadGoals()
    {
        string filename = ReadString("What is the filename for the goal file? ");
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(filename);
            if (lines.Length < 1)
            {
                Console.WriteLine("File is empty or invalid.");
                return;
            }

            _goals.Clear();
            _badges.Clear();

            _score = int.Parse(lines[0]);

            // badges (optional)
            if (lines.Length >= 2 && !string.IsNullOrWhiteSpace(lines[1]))
            {
                foreach (string badge in lines[1].Split(';', StringSplitOptions.RemoveEmptyEntries))
                {
                    _badges.Add(badge.Trim());
                }
            }

            // goals start at line 3
            for (int i = 2; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i])) continue;

                string[] parts = lines[i].Split('|');
                if (parts.Length == 0) continue;

                string type = parts[0];

                if (type == "SimpleGoal" && parts.Length >= 5)
                {
                    string name = parts[1];
                    string desc = parts[2];
                    int points = int.Parse(parts[3]);
                    bool isComplete = bool.Parse(parts[4]);
                    _goals.Add(new SimpleGoal(name, desc, points, isComplete));
                }
                else if (type == "EternalGoal" && parts.Length >= 4)
                {
                    string name = parts[1];
                    string desc = parts[2];
                    int points = int.Parse(parts[3]);
                    _goals.Add(new EternalGoal(name, desc, points));
                }
                else if (type == "ChecklistGoal" && parts.Length >= 8)
                {
                    string name = parts[1];
                    string desc = parts[2];
                    int points = int.Parse(parts[3]);
                    int bonus = int.Parse(parts[4]);
                    int target = int.Parse(parts[5]);
                    int amountCompleted = int.Parse(parts[6]);
                    bool isComplete = bool.Parse(parts[7]);
                    _goals.Add(new ChecklistGoal(name, desc, points, target, bonus, amountCompleted, isComplete));
                }
            }

            RecalculateLevelFromScore();
            CheckBadges();

            Console.WriteLine("Goals loaded successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading file: {ex.Message}");
        }
    }

    private void RecalculateLevelFromScore()
    {
        _level = Math.Max(1, (_score / 1000) + 1);
    }

    private void CheckLevelUps(int oldScore, int newScore)
    {
        int oldLevel = Math.Max(1, (oldScore / 1000) + 1);
        int newLevel = Math.Max(1, (newScore / 1000) + 1);

        if (newLevel > oldLevel)
        {
            _level = newLevel;
            Console.WriteLine();
            Console.WriteLine("====================================");
            Console.WriteLine($"LEVEL UP! You reached Level {_level}!");
            Console.WriteLine($"New Title: {GetTitleForLevel(_level)}");
            Console.WriteLine("====================================");
        }
        else
        {
            _level = newLevel;
        }
    }

    private void CheckBadges()
    {
        foreach (var item in _badgeMilestones)
        {
            int threshold = item.threshold;
            string badgeName = item.badgeName;

            if (_score >= threshold && !_badges.Contains(badgeName))
            {
                _badges.Add(badgeName);
                Console.WriteLine();
                Console.WriteLine("********** BADGE EARNED! **********");
                Console.WriteLine($"{badgeName} (Reached {threshold} points)");
                Console.WriteLine("***********************************");
            }
        }
    }

    private string GetTitleForLevel(int level)
    {
        if (level >= 20) return "Level 20+ Ninja Unicorn";
        if (level >= 15) return "Celestial Champion";
        if (level >= 10) return "Covenant Keeper";
        if (level >= 7) return "Temple Tracker";
        if (level >= 4) return "Steady Disciple";
        return "Novice Seeker";
    }

    // OPTION B FIX: no string? and safe null handling with ?? ""
    private static int ReadInt(string prompt, int min, int max)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine() ?? "";

            int value;
            if (int.TryParse(input, out value) && value >= min && value <= max)
                return value;

            Console.WriteLine($"Please enter a valid number between {min} and {max}.");
        }
    }

    private static string ReadString(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine() ?? "";

            if (!string.IsNullOrWhiteSpace(input))
                return input.Trim();

            Console.WriteLine("Please enter a non-empty value.");
        }
    }
}
