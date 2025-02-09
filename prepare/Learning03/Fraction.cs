using System;

public class Fraction
{
    // Private attributes for the numerator and denominator
    private int numerator;
    private int denominator;

    // Constructor with no parameters, initializes to 1/1
    public Fraction()
    {
        numerator = 1;
        denominator = 1;
    }

    // Constructor with one parameter, initializes to numerator/1
    public Fraction(int numerator)
    {
        this.numerator = numerator;
        denominator = 1;  // Default denominator is 1
    }

    // Constructor with two parameters, initializes to numerator/denominator
    public Fraction(int numerator, int denominator)
    {
        this.numerator = numerator;
        if (denominator == 0)
        {
            throw new ArgumentException("Denominator cannot be zero.");
        }
        this.denominator = denominator;
    }

    // Getter for the numerator
    public int GetNumerator()
    {
        return numerator;
    }

    // Setter for the numerator
    public void SetNumerator(int numerator)
    {
        this.numerator = numerator;
    }

    // Getter for the denominator
    public int GetDenominator()
    {
        return denominator;
    }

    // Setter for the denominator
    public void SetDenominator(int denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Denominator cannot be zero.");
        }
        this.denominator = denominator;
    }

    // Method to return the fraction as a string in the form "numerator/denominator"
    public string GetFractionString()
    {
        return $"{numerator}/{denominator}";
    }

    // Method to return the decimal value of the fraction (numerator / denominator)
    public double GetDecimalValue()
    {
        return (double)numerator / denominator;
    }
}