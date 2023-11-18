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

        Application.Init();
        var top = Application.Top;

        var win = new Window()
        {
            X = 0,
            Y = 0,
            Width = Dim.Fill(),
            Height = Dim.Fill() - 1
        };
        top.Add(win);

        // Create a scroll view to hold the list of goals
        var scrollView = new ScrollView()
        {
            X = 0,
            Y = 0,
            Width = Dim.Fill() - 2,
            Height = Dim.Fill(),
            ContentSize = new Size(100, countGoals()),
            ShowVerticalScrollIndicator = true,
            ShowHorizontalScrollIndicator = true
        };
        win.Add(scrollView);

        // create a list to hold the goal buttons
        var goalButtons = new List<Button>();
        for (int i = 0; i < goals.Count; i++)
        {
            int index = i;
            var button = new Button()
            {
                X = 0,
                Y = i,
                Width = Dim.Fill(),
                Height = 1,
                Text = $"{goals[i].Name} {goals[i].GetCompletion("fraction")}"
            };
            // Add marker to indicate completion
            // if(goals[i].IsComplete()) {button.Text = "[x]" + button.Text;}
            // else {button.Text = "[ ]" + button.Text;}
            // Add button to list of buttons
            button.Clicked += () => 
            { 
                goals[index].MarkDone(); 
                button.Text = $"{goals[index].Name} {goals[index].GetCompletion("fraction")}";
            };
            goalButtons.Add(button);
            scrollView.Add(button);
        }


        var menu = new MenuBar(new MenuBarItem[]
        {
            new MenuBarItem("_Exit", "", () => { Environment.Exit(0); })
        });
        top.Add(menu);

        Application.Run();

        int countGoals()
        {
            GoalsLength = goals.Count;
            return goals.Count;
        }

        // DEPRECATED
        // This function is to make a string that the Terminal.Gui Label can use
        // string MakeContentString(List <Goal> goals)
        // {
        //     string contentString = "";
        //     foreach (Goal goal in goals)
        //     {
        //         contentString += goal.Name + "\n";
        //     }
        //     return contentString;
        // }
    }
}
