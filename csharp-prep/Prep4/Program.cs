using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int input;
        
        // Prompt the user to enter numbers until they enter 0
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        
        do
        {
            Console.Write("Enter number: ");
            input = int.Parse(Console.ReadLine());
            
            // Add the number to the list if it's not 0
            if (input != 0)
            {
                numbers.Add(input);
            }
        }
        while (input != 0);

        // Compute the sum of the numbers
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        // Compute the average
        double average = sum / (double)numbers.Count;

        // Find the largest number
        int largest = int.MinValue;
        foreach (int number in numbers)
        {
            if (number > largest)
            {
                largest = number;
            }
        }

        // Display the results
        Console.WriteLine("The sum is: " + sum);
        Console.WriteLine("The average is: " + average);
        Console.WriteLine("The largest number is: " + largest);
    }
}