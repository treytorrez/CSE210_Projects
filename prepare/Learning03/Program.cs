using System;

class Program
{
    static void Main()
    {
        // Creating instances of Fraction using different constructors
        Fraction fraction1 = new Fraction();          // 1/1
        Fraction fraction2 = new Fraction(6);         // 6/1
        Fraction fraction3 = new Fraction(6, 7);     // 6/7

        // Using getters to retrieve and display the fractions
        Console.WriteLine(fraction1.GetFractionString()); // 1/1
        Console.WriteLine(fraction2.GetFractionString()); // 6/1
        Console.WriteLine(fraction3.GetFractionString()); // 6/7

        // Using getters to retrieve and display the decimal representations
        Console.WriteLine(fraction1.GetDecimalValue());  // 1.0
        Console.WriteLine(fraction2.GetDecimalValue());  // 6.0
        Console.WriteLine(fraction3.GetDecimalValue());  // 0.8571428571428571

        // Using setters to change the values and getters to retrieve and display the updated values
        fraction1.SetNumerator(5);
        fraction1.SetDenominator(3);

        Console.WriteLine(fraction1.GetFractionString()); // 5/3
        Console.WriteLine(fraction1.GetDecimalValue());  // 1.6666666666666667
    }
}
