using System;

class Program
{
    static void Main(string[] args)
    {
            Console.WriteLine("What is your grade?");
            Console.Write("Grade: ");
            int grade = Convert.ToInt16(Console.ReadLine());
            switch (grade)
            {
                case int n when grade >= 90:
                    Console.WriteLine("A");
                    break;
                case int n when grade >= 80:
                    Console.WriteLine("B");
                    break;
                case int n when grade >= 70:
                    Console.WriteLine("C");
                    break;
                case int n when grade >= 60:
                    Console.WriteLine("F");
                    break;
                default:
                    Console.WriteLine("Not a Valid Grade");
                    break;
            
            }
    }
}