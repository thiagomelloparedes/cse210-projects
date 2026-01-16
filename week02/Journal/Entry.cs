using System;

public class Entry
{
    public string _date = "";
    public string _promptText = "";
    public string _entryText = "";

    // EXTRA: Save your mood (1-5) on each entry
    public int _mood = 0;

    public void Display()
    {
        Console.WriteLine($"Date: {_date}  Mood: {_mood}/5");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine(_entryText);
        Console.WriteLine();
    }
}
