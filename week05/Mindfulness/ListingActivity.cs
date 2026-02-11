using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private int _count = 0;

    private List<string> _prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    // EXTRA (minimal): pool para NO repetir prompts hasta agotar lista en la sesión
    private PromptPool _promptPool;

    public ListingActivity()
        : base(
            "Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."
          )
    {
        _promptPool = new PromptPool(_prompts);
    }

    public void Run()
    {
        DisplayStartingMessage();

        string prompt = _promptPool.Next();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine();
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();
        Console.WriteLine("Start listing items (press Enter after each one):");

        List<string> items = GetListFromUser();

        Console.WriteLine();
        Console.WriteLine($"You listed {items.Count} items!");
        DisplayEndingMessage();
    }

    public List<string> GetListFromUser()
    {
        _count = 0;
        List<string> items = new List<string>();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
            {
                items.Add(input.Trim());
                _count++;
            }
        }

        return items;
    }
}
