using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101); // Generates a number between

        int userGuess = -1;

        while (userGuess != magicNumber)
        {
            Console.Write("Enter your guess (1-100): ");
            string userInput = Console.ReadLine();

            // Validate input
            if (int.TryParse(userInput, out userGuess))
            {
                if (userGuess < magicNumber)
                {
                    Console.WriteLine("Too low! Try again.");
                }
                else if (userGuess > magicNumber)
                {
                    Console.WriteLine("Too high! Try again.");
                }
                else
                {
                    Console.WriteLine("Congratulations! You've guessed the magic number!");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 100.");
            }
        }


    }
}