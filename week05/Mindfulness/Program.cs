using System;

class Program
{
    static void Main(string[] args)
    {
        /*
        EXCEED REQUIREMENTS: 
        - Implemented a simple PromptPool so prompts/questions do not repeat until all have been used during the session
        */

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                var act = new BreathingActivity();
                act.Run();
            }
            else if (choice == "2")
            {
                var act = new ReflectingActivity();
                act.Run();
            }
            else if (choice == "3")
            {
                var act = new ListingActivity();
                act.Run();
            }
            else if (choice == "4")
            {
                Console.WriteLine("Goodbye!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid option. Press Enter to continue...");
                Console.ReadLine();
            }
        }
    }
}
