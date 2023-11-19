using System;
using System.Security.Cryptography.X509Certificates;
using Terminal.Gui;

class Program
{
    static void Main()
    {
        // Create a list to store all goals
        var goals = new List<Goal>();
        // Make dummy goals for testing; give each a name
        for (int i = 1; i <= 10; i++)
        {
            Random rnd = new Random();

            var goal = new FiniteGoal(rnd.Next(50, 60), rnd.Next(1, 100), rnd.Next(1, 49));
            goal.Name = "Goal " + i;
            goals.Add(goal);
            
        }
        var GoalsLength = goals.Count;

        Console.WriteLine("Welcome to the goal tracker!");
        GuiHandler gui = new GuiHandler(goals);
    }
}
