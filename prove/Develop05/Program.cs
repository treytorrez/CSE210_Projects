
class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the goal tracker!");
    
        
        // Create a list to store all goals
        var goals = new List<Goal>();
        string location = @"C:\Users\treyt\OneDrive\Documents\CSE210\CSE210_Projects\prove\Develop05\goals.json";

        // make dummy goals and append them to the list
        // for (int i = 0; i < 10; i++)
        // {
        //     FiniteGoal goal = new FiniteGoal(5, 10)
        //     {
        //         Name = $"Goal {i}",
        //     };
        //     goals.Add(goal);

        // }

        
        GuiHandler gui = new(goals, location);
    }
}
