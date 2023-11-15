using System;

class Program
{
    static void Main()
    {
        // Create a list to store all goals
        var goals = new List<Goal>();

        // Print welcome message
        Console.WriteLine("Welcome to the goal tracker!");
        StartMenu();

    }

    static void StartMenu()
    {
        string CurrentPage = "main";
        while (CurrentPage != "exit")
        {
            switch (CurrentPage)
            {
                case "main":
                    // make important text bold; \x1b[1m{content}\x1b[22m
                    Console.WriteLine("\x1b[1mWhat would you like to do?\x1b[22m");
                    Console.WriteLine("  Create a new goal (\x1b[1mcreate\x1b[22m)");//create
                    Console.WriteLine("  View existing goals (\x1b[1mview\x1b[22m)");//view
                    Console.WriteLine("  Exit (\x1b[1mexit\x1b[22m)");//exit
                    CurrentPage = Console.ReadLine().ToLower();
                    break;
                case "create":
                    Console.WriteLine("What type of goal would you like to create?");
                    Console.WriteLine("Infinite (inf) or Finite (fin)");
                    Console.WriteLine("Return to main menu (main)");
                    string goalType = Console.ReadLine().ToLower();
                    //Add filler for now
                    Console.WriteLine("Functionality not yet implemented.");
                    Console.WriteLine("press enter to continue");
                    Console.ReadLine();
                    //TODO: Complete create goal functionality
                    break;
                case "view":
                    //TODO: ViewGoals();
                    // Same bold styling as above
                    Console.WriteLine("\x1b[1mWhat would you like to do?\x1b[22m");
                    Console.WriteLine();
                    Console.WriteLine("Mark a goal as complete (\x1b[1mmark\x1b[22m])");//mark
                    Console.WriteLine("Remove a goal (\x1b[1mremove\x1b[22m)");//remove
                    Console.WriteLine("Return to main menu (\x1b[1mmain\x1b[22m)");//main
                    Console.WriteLine("Clear completed goals (\x1b[1mclear\x1b[22m)");//clear

                    CurrentPage = Console.ReadLine().ToLower();
                    break;
                case "mark":
                    Console.WriteLine("Functionality not yet implemented.");
                    System.Console.WriteLine("press enter to continue");
                    Console.ReadLine();
                    CurrentPage = "view";
                    break;
                case "remove":
                    Console.WriteLine("Functionality not yet implemented.");
                    Console.WriteLine("press enter to continue");
                    Console.ReadLine();
                    CurrentPage = "view";
                    break;
                case "clear":
                    // TODO: ClearCompletedGoals();
                    Console.WriteLine("Functionality not yet implemented.");
                    Console.WriteLine("press enter to continue");
                    Console.ReadLine();
                    CurrentPage = "view";
                    break;
                case "exit":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    break;
            }
        }
    }

    void _compactIntTryParse(string input, out int type)
    {
        if (int.TryParse(input, out type)) { }
        else { Console.WriteLine("Invalid input. Please enter a number."); }
    }
}
