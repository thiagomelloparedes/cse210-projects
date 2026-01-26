using System;
using System.Collections.Generic;

class Program
{
    /*
     * Exceeding Requirements (Creativity):
     * - The program uses a small library of scriptures and selects one at random each run.
     * - When hiding words, it selects only from words that are not already hidden (stretch challenge).
     */

    static void Main()
    {
        List<Scripture> library = BuildScriptureLibrary();

        Random rng = new Random();
        Scripture scripture = library[rng.Next(library.Count)];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.Write("Press Enter to hide words or type 'quit' to end: ");

            string? input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input) &&
                input.Trim().Equals("quit", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }

            // Hide a few random words each round.
            scripture.HideRandomWords(3);

            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine();
                Console.WriteLine("All words are hidden. Program ended.");
                break;
            }
        }
    }

    private static List<Scripture> BuildScriptureLibrary()
    {
        return new List<Scripture>
        {
            new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world, that he gave his only begotten Son, " +
                "that whosoever believeth in him should not perish, but have everlasting life."
            ),

            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart; and lean not unto thine own understanding. " +
                "In all thy ways acknowledge him, and he shall direct thy paths."
            ),

            new Scripture(
                new Reference("2 Nephi", 2, 25),
                "Adam fell that men might be; and men are, that they might have joy."
            )
        };
    }
}
