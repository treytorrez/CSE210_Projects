using Terminal.Gui;
using System.Text.Json;
using System.Diagnostics;
using System.Runtime.CompilerServices;

class GuiHandler
{
    public GuiHandler(List<Goal> goals, string location)
    {
        // Initialize the library
        Application.Init();

        // Creates the top-level window to show
        var top = Application.Top;

        // ------------------------------------------------------------
        // MAIN WINDOW
        // ------------------------------------------------------------

        // Creates a new window for the Main screen
        var GoalsWindow = new Window("Goals")
        {
            X = 0,
            Y = 0,
            Width = Dim.Fill(),
            Height = Dim.Fill() - 1
        };
        top.Add(GoalsWindow);

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
        GoalsWindow.Add(scrollView);

        // create a list to hold the goal buttons
        var goalButtons = new List<Button>();
        // Create a button for each goal in ScrollView
        CreateButtonsFromList(goalButtons, goals, scrollView);
        // Create method to reload the buttons
        void reloadButtons()
        {
            // Remove all the buttons from the scroll view
            foreach (Button button in goalButtons)
            {
                scrollView.Remove(button);
            }
            goalButtons.Clear();  // Clear the list of buttons
            // Create a button for each goal in ScrollView
            CreateButtonsFromList(goalButtons, goals, scrollView);
        }
        // ------------------------------------------------------------
        // POINTS WINDOW
        // ------------------------------------------------------------

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
        pointsWindow.Add(pointsLabel);

        // Create a new progress bar for the points window
        var pointsGraph = new ProgressBar()
        {
            X = 0,
            Y = 1,
            Width = Dim.Fill(10),
            Height = 3
        };
        pointsWindow.Add(pointsGraph);  // Add the progress bar to the points window

        // ------------------------------------------------------------
        // LOAD WINDOW
        // ------------------------------------------------------------
        var dataWindow = new Window("Save/Load")
        {
            X = 0,
            Y = 1,
            Width = Dim.Fill(),
            Height = Dim.Fill() - 1
        };
        top.Add(dataWindow);
        dataWindow.Visible = false;

        // Create a new label for the window to show where the current data is
        // TODO: make way to show where current data is
        var dataLocaton = new Label($"Current data location:\"{location}\"")
        {
            X = 0,
            Y = 0,
            Width = Dim.Fill(),
            Height = 1
        };
        dataWindow.Add(dataLocaton);

        var loadButton = new Button("Load")
        {
            X = 0,
            Y = 4,
            Width = Dim.Fill(),
            Height = 1
        };
        loadButton.Clicked += () =>
        {
            goals = Data.LoadJSON(location);
            // Reload everything to show the new goals
            reloadButtons();
            scrollView.ContentSize = new Size(100, goals.Count());
            scrollView.SetNeedsDisplay();
        };
        dataWindow.Add(loadButton);

        var textField = new TextField()
        {
            X = 0,
            Y = 2,
            Width = 50,
            Height = 1
        };
        dataWindow.Add(textField);

        var changeLocationButton = new Button("Change Location")
        {
            X = 51,
            Y = 2,
            Width = Dim.Fill(),
            Height = 1
        };
        changeLocationButton.Clicked += () =>
        {
            try
            {
                // Check for file existence
                string fullPath = Path.GetFullPath(textField.Text.ToString());
                Debug.WriteLine($"Set location attempt to {fullPath}");
                if (!File.Exists(fullPath)) { throw new Exception(); }
                location = textField.Text.ToString();
                dataLocaton.Text = $"Current data location:\"{location}\"";

            }
            catch (Exception)
            {// If the file doesn't exist, show an error dialog
                var ok = new Button(3, 2, "Ok");
                ok.Clicked += () => Application.RequestStop();
                var dialog = new Dialog("Error", 30, 10, ok);
                var label = new Label("This is not a valid path")
                {
                    X = 1,
                    Y = 1,
                    Width = Dim.Fill(),
                    Height = 1
                };
                dialog.Add(label);
                Application.Run(dialog);
            }
        };
        dataWindow.Add(changeLocationButton);

        // ------------------------------------------------------------
        // MENU BAR
        // ------------------------------------------------------------

        var menu = new MenuBar(new MenuBarItem[]
        {
            new MenuBarItem("_Exit", "", () => { Environment.Exit(0); }),
            new MenuBarItem("_Goals", "", () =>
            {
                GoalsWindow.Visible = true;
                pointsWindow.Visible = false;
                dataWindow.Visible = false;

            }),
            new MenuBarItem("_Points", "", () =>
            {
                pointsWindow.Visible = true;
                GoalsWindow.Visible = false;
                dataWindow.Visible = false;

            }),
            new MenuBarItem("_Load", "", () =>
            {
                dataWindow.Visible = true;
                GoalsWindow.Visible = false;
                pointsWindow.Visible = false;

            }),
            new MenuBarItem("_Save", "", () =>
            {
                if (location != null) {Data.SaveJSON(location, goals);}// save if location is set
                else
                {
                    // TODO: alert user that location is not set and file is not saved
                }

            })
        });
        top.Add(menu);


        Application.Run();


    }
    private void CreateButtonsFromList(List<Button> ButtonList, List<Goal> list, ScrollView scrollView)
    {

            for (int i = 0; i < list.Count; i++)
            {
                int index = i;
                var button = new Button()
                {
                    X = 0,
                    Y = i,
                    Width = Dim.Fill(),
                    Height = 1,
                    Text = $"{list[i].Name} {list[i].GetCompletion("fraction")}"
                };
                // When the button is clicked, mark the the goal as  and update the button text
                button.Clicked += () =>
                {
                    list[index].AddCompletion();
                    button.Text = $"{list[index].Name} {list[index].GetCompletion("fraction")}";
                };
                ButtonList.Add(button);
                scrollView.Add(button);
            }
        }

}