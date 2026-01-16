using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    private const string Separator = "~|~";

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                // date~|~prompt~|~text~|~mood
                outputFile.WriteLine(
                    $"{entry._date}{Separator}{entry._promptText}{Separator}{entry._entryText}{Separator}{entry._mood}"
                );
            }
        }
    }

    public void LoadFromFile(string file)
    {
        // Replaces whatever was loaded before
        _entries.Clear();

        if (!File.Exists(file))
        {
            Console.WriteLine("❌ File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(file);

        foreach (string line in lines)
        {
            string[] parts = line.Split(new string[] { Separator }, StringSplitOptions.None);

            // We'll wait 4 parts for the mood (extra)
            if (parts.Length >= 3)
            {
                Entry entry = new Entry();
                entry._date = parts[0];
                entry._promptText = parts[1];
                entry._entryText = parts[2];

                // Mood (if exists)
                if (parts.Length >= 4 && int.TryParse(parts[3], out int mood))
                    entry._mood = mood;
                else
                    entry._mood = 0;

                _entries.Add(entry);
            }
        }
    }
}
