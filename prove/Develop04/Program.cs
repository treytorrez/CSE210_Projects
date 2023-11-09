using System;
using System.ComponentModel.Design;


class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            System.Console.WriteLine("Welcome to the Mindfulness App!");
            Activity currentActivity = Menu();
            Console.Clear();
            currentActivity.Intro();
            currentActivity.SetDuration();
            Console.WriteLine("Get ready to begin the activity.");
            Loading.LoadingBar(30, 1, true, true);
            Console.WriteLine("");
            currentActivity.Execute();
            currentActivity.Stats();
            Console.WriteLine("Exiting activity...");
            Loading.LoadingBar(30, 1, true, true);
            Console.WriteLine("");
        }
    }

    static Activity Menu()
    {

        // Unfortunately, I have to use this because this function needs to return an activity
        // object and breaking out of a loop is the only way I know to circumvent this
        while (true)
        {
            Console.WriteLine(@"Please select an option:
            1. Breathing
            2. Reflection
            3. Listing
            4. Exit");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1": return new Breathing();
                case "2": return new Reflection();
                case "3": return new Listing();
                case "4":
                    Console.WriteLine("Exiting program...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    break;
            }
        }
    }

    

    
}