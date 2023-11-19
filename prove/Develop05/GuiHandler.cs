using Terminal.Gui;

class GuiHandler
{
    public GuiHandler(List<Goal> goals)
    {
        // Initialize the library
        Application.Init();

        // Creates the top-level window to show
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
            ContentSize = new Size(100, goals.Count()),
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

        // Create a new window for displaying points
        var pointsWindow = new Window("Points")
        {
            X = 0,
            Y = 1,
            Width = Dim.Fill(),
            Height = Dim.Fill() - 1
        };
        top.Add(pointsWindow);  // Add the window to the top level view
        pointsWindow.Visible = false;  // Initially, make the window invisible

        // Create a new label for the points window
        // TODO: Implement a way to display the current level
        var pointsLabel = new Label("Level")
        {
            X = 0,
            Y = 0,
            Width = Dim.Fill(),
            Height = 1
        };
        pointsWindow.Add(pointsLabel);  // Add the label to the points window

        // Create a new progress bar for the points window
        var pointsGraph = new ProgressBar()
        {
            X = 0,
            Y = 1,
            Width = Dim.Fill(10),
            Height = 3
        };
        pointsWindow.Add(pointsGraph);  // Add the progress bar to the points window

    
        var menu = new MenuBar(new MenuBarItem[]
        {
            new MenuBarItem("_Exit", "", () => { Environment.Exit(0); }),
            new MenuBarItem("_Main", "", () => { win.Visible = true; pointsWindow.Visible = false;}),
            new MenuBarItem("_Points", "", () => { pointsWindow.Visible = true; win.Visible = false; }),
        });
        top.Add(menu);


        Application.Run();

        
    }

}