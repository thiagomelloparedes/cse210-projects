using System;

class Program
{
    static void Main(string[] args)
    {
        // EXCEEDING REQUIREMENTS:
        // Added a Mood (1-5) rating for each journal entry.
        // The mood is displayed with the entry and is also saved to / loaded from the file.

        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        while (true)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine() ?? "";
            Console.WriteLine();

            if (choice == "1")
            {
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine(prompt);
                Console.Write("> ");
                string response = Console.ReadLine() ?? "";

                int mood = ReadMood(); // EXTRA

                Entry entry = new Entry();
                entry._date = DateTime.Now.ToShortDateString();
                entry._promptText = prompt;
                entry._entryText = response;
                entry._mood = mood; // EXTRA

                journal.AddEntry(entry);
                Console.WriteLine("✅ Entry added.\n");
            }
            else if (choice == "2")
            {
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine() ?? "";
                journal.SaveToFile(filename);
                Console.WriteLine("✅ Journal saved.\n");
            }
            else if (choice == "4")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine() ?? "";
                journal.LoadFromFile(filename);
                Console.WriteLine("✅ Journal loaded.\n");
            }
            else if (choice == "5")
            {
                break;
            }
            else
            {
                Console.WriteLine("❌ Invalid option.\n");
            }
        }
    }

    // EXTRA: ask for mood 1-5 with validation
    static int ReadMood()
    {
        while (true)
        {
            Console.Write("Mood (1-5): ");
            string input = Console.ReadLine() ?? "";

            if (int.TryParse(input, out int mood) && mood >= 1 && mood <= 5)
            {
                Console.WriteLine();
                return mood;
            }

            Console.WriteLine("❌ Please enter a number from 1 to 5.\n");
        }
    }
}
