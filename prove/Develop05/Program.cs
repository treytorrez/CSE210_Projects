
class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the goal tracker!");
        // Create a list to store all goals
        var goals = new List<Goal>();

        // Load data or create new goal
        switch (Data.FindJSON().GetType().Name)
        {
            case "string":
                goals = Data.LoadJSON(Data.FindJSON());
                break;
            case "null":
                System.Console.WriteLine("What kind of goal would you like to create? ");
                var response = Console.ReadLine().ToLower();
                while (true)
                {
                    if (response == "inf") {goals.Add(new InfiniteGoal()); break;}
                    else if (response == "fin") {goals.Add(new FiniteGoal()); break;}
                    else {Console.WriteLine("Invalid input. Please try again");}
                }
                break;
            default:
                Console.WriteLine("Something went wrong, please try again.");
                break;
        }

        GuiHandler gui = new GuiHandler(goals);
    }
}
