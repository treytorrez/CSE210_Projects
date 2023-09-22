using System;

class Program
{
    static void Main(string[] args)
    {
        // Initialize variables
        int magicNum;
        int guess;

        Console.WriteLine("What is the Magic Number?");
        magicNum = Convert.ToInt16(Console.ReadLine());
        do{
        Console.WriteLine("What is your guess?");
        guess = Convert.ToInt16(Console.ReadLine());

        if (guess > magicNum){
            Console.WriteLine("Too High!");
        }
        else if (guess < magicNum){
            Console.WriteLine("Too Low!");
        }
        else{
            Console.WriteLine("You guessed the magic number!");
        }
        

        } while( guess != magicNum);
    }
}