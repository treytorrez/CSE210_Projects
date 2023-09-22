using System;
using System.Reflection.Metadata.Ecma335;

class Program
{
    static void Main(string[] args)
    {
//         write a C# program that has several simple functions:

// DisplayWelcome - Displays the message, "Welcome to the Program!"
// PromptUserName - Asks for and returns the user's name (as a string)
// PromptUserNumber - Asks for and returns the user's favorite number (as an integer)
// SquareNumber - Accepts an integer as a parameter and returns that number squared (as an integer)
// DisplayResult - Accepts the user's name and the squared number and displays them.
// Your Main function should then call each of these functions saving the return values and passing data to them as necessary.

// Sample output of the program could look as follows:


// Welcome to the program!
// Please enter your name: Brother Burton
// Please enter your favorite number: 42
// Brother Burton, the square of your number is 1764
        void DisplayWelcome(){
            Console.WriteLine("Welcome to the program!");
        }
        string PromptUserName(){
            Console.WriteLine("Please enter your name:");
            string name = Console.ReadLine();
            return name;
        }
        int PromptUserNumber(){
            Console.WriteLine("Please enter your favorite number:");
            int number = Convert.ToInt32(Console.ReadLine());
            return number;
        }
        int SquareNumber(int number){
            return number * number;
        }
        void DisplayResult(string name, int squaredNumber){
            Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
        }
        DisplayWelcome();
        string name = PromptUserName();
        int number = PromptUserNumber();
        int squaredNumber = SquareNumber(number);
        DisplayResult(name, squaredNumber);
        
    }
}