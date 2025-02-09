using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a fraction using the no-parameter constructor (defaults to 1/1)
        Fraction fraction1 = new Fraction();
        Console.WriteLine($"Fraction 1 (default constructor): {fraction1.GetFractionString()}");
        Console.WriteLine($"Decimal Value of Fraction 1: {fraction1.GetDecimalValue()}");

        // Create a fraction using the one-parameter constructor (6/1)
        Fraction fraction2 = new Fraction(6);
        Console.WriteLine($"Fraction 2 (one-parameter constructor): {fraction2.GetFractionString()}");
        Console.WriteLine($"Decimal Value of Fraction 2: {fraction2.GetDecimalValue()}");

        // Create a fraction using the two-parameter constructor (6/7)
        Fraction fraction3 = new Fraction(6, 7);
        Console.WriteLine($"Fraction 3 (two-parameter constructor): {fraction3.GetFractionString()}");
        Console.WriteLine($"Decimal Value of Fraction 3: {fraction3.GetDecimalValue()}");

        // Now, change the values using setters and display the updated fractions
        fraction1.SetNumerator(3);
        fraction1.SetDenominator(4);
        Console.WriteLine($"Updated Fraction 1 (after setter changes): {fraction1.GetFractionString()}");
        Console.WriteLine($"Updated Decimal Value of Fraction 1: {fraction1.GetDecimalValue()}");

        fraction2.SetNumerator(9);
        fraction2.SetDenominator(2);
        Console.WriteLine($"Updated Fraction 2 (after setter changes): {fraction2.GetFractionString()}");
        Console.WriteLine($"Updated Decimal Value of Fraction 2: {fraction2.GetDecimalValue()}");

        fraction3.SetNumerator(15);
        fraction3.SetDenominator(10);
        Console.WriteLine($"Updated Fraction 3 (after setter changes): {fraction3.GetFractionString()}");
        Console.WriteLine($"Updated Decimal Value of Fraction 3: {fraction3.GetDecimalValue()}");
    }
}