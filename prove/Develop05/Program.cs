class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the goal tracker!");
        // Create a list to store all goals
        var goals = new List<Goal>();

        // string location = Data.FindJSON();
        // GuiHandler gui = new(goals, location);
        GuiHandler gui = new();
    }
}
