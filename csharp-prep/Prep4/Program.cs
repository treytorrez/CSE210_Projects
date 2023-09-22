using System;

class Program
{
    static void Main(string[] args)
    {
        // Initialize List
        List<int> numbers = new();
        // Add numbers to list
        int entry = 1;
        while (entry != 0)
        {
            Console.WriteLine("Enter a number");
            entry = Convert.ToInt16(Console.ReadLine());
            if (entry != 0)
            {
                numbers.Add(entry);
            }
        }
        Console.WriteLine("The sum of the numbers is: " + numbers.Sum());
        Console.WriteLine("The average of the numbers is: " + numbers.Average());
        Console.WriteLine("The largest number is: " + numbers.Max());
    }
}