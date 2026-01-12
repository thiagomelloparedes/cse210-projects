using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter numbers one by one. Type '0' when you are finished:");

        while (true)
        {
            Console.Write("Enter a number");
            int value = int.Parse(Console.ReadLine());

            if (value == 0)
            {
                break;
            }
            numbers.Add(value);

        }

        int sum = 0;
        int largest = numbers[0];

        foreach (int number in numbers)
        {
            sum += number;
            if (number > largest)
            {
                largest = number;
            }
        }

        double average = (double)sum / numbers.Count;
        Console.WriteLine($"Sum: {sum}");
        Console.WriteLine($"Average: {average}");   
        Console.WriteLine($"Largest: {largest}");
    }
}