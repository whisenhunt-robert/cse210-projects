using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep1 World!");

        // Ask the user for their first name
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();

        // Ask the user for their last name
        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();

        // Prints the users name in a James Bond style (i.e. Bond, James Bond)
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
    }
}