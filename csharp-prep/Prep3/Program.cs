using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask for the magic number from the user
        Console.Write("What is the magic number? ");
        int magicNumber = int.Parse(Console.ReadLine());

        int guess = 0;

        // Loop for guesses until the correct number is guessed
        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            // Provide feedback based on the guess
            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }

        // Generate a random number between 1 and 100 for the magic number
        Random random = new Random();
        magicNumber = random.Next(1, 101); // Generates a number between 1 and 100

        // Loop again with the random magic number
        Console.WriteLine("\nNow let's play with a random magic number!");

        guess = 0;
        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            // Provide feedback based on the guess
            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }
    }
}