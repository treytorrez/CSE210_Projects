using Terminal.Gui;
using System.Text.Json;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using static System.Math;
using Newtonsoft.Json.Linq;
using NStack;
class GuiHandler
{
    //TODO: fix capitalization and naming conventions
    // Yes I am aware that many other variables should be out here and many of the methods should be outside of the constructor but I inadvertantly put them all in the contructor and this project is already late


    private Window GoalsWindow;
    private Window pointsWindow;
    private Label pointsLabel;
    private ProgressBar pointsGraph;
    private Label pointsLeftLabel;
    public string Location { get; set; }
    public GuiHandler(List<Goal> goals, string goalsLocation)
    {
        // Set the location
        Location = goalsLocation;
        // Initialize the library
        Application.Init();

        // Creates the top-level window to show
        var top = Application.Top;

        // ------------------------------------------------------------
        // MAIN WINDOW
        // ------------------------------------------------------------

        // Creates a new window for the Main screen
        // var GoalsWindow = new Window("Goals")
        GoalsWindow = new Window("Goals")
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
        pointsWindow = new Window("Points")
        {
            X = 0,
            Y = 1,
            Width = Dim.Fill(),
            Height = Dim.Fill() - 1
        };
        top.Add(pointsWindow);  // Add the window to the top level view
        pointsWindow.Visible = false;  // Initially, make the window invisible

        // Load points from the embedded JSON resource file 
        int points = Data.FetchProfilePoints(Location);
        // Find the level that the user is at and how many points they have in the current level
        var (level, pointsInLevel, percentOfLevel) = Data.CalcLevelAndPoints(points);

        // Create a new label for the points window
        pointsLabel = new Label($"Level {level}")
        {
            X = 0,
            Y = 0,
            Width = Dim.Fill(),
            Height = 1
        };
        pointsWindow.Add(pointsLabel);


        // Create a new progress bar for the points window
        pointsGraph = new ProgressBar()
        {
            X = 0,
            Y = 1,
            Width = Dim.Fill(),
            Height = 3,
            Fraction = percentOfLevel

        };
        pointsWindow.Add(pointsGraph);  // Add the progress bar to the points window

        // Label to show how many points are left over
        pointsLeftLabel = new Label($"{pointsInLevel} points left until next level")
        {
            X = 0,
            Y = 2,
            Height = 1,
            Width = Dim.Fill()
        };
        pointsWindow.Add(pointsLeftLabel);
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
        var dataLocaton = new Label($"Current data location:\"{Location}\"")
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
        // TODO: i have no clue why this crashes when clicked twice consecutively
        // something about an onject reference not being set to the reference of an object
        {
            goals = Data.LoadJSON(Location);
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
            Width = 70,
            Height = 1
        };
        dataWindow.Add(textField);

        var changeLocationButton = new Button("Change Location")
        {
            X = 71,
            Y = 2,
            Width = 20,
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
                Location = textField.Text.ToString();
                dataLocaton.Text = $"Current data location:\"{Location}\"";

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
            new MenuBarItem("_Main", "", () =>
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
                if (Location != null) {Data.SaveJSON(Location, goals);}// save if location is set
                else
                {
                    // TODO: alert user that location is not set and file is not saved
                }

            })
        });
        top.Add(menu);

        // ------------------------------------------------------------
        // ADD GOALS STATUS BAR
        // ------------------------------------------------------------

        var addGoalBar = new StatusBar(new StatusItem[]
        {
            new StatusItem( (Key)72 , "Add Goal", () =>
            {
                // Buttons for the dialog
                var add = new Button("Add");
                var cancel = new Button("Cancel");
                cancel.Clicked += () => Application.RequestStop();

                // Fields for the dialog
                var nameField =
                    new TextField(0,0, 45, "Goal Name");
                var descriptionField =
                    new TextField(0, 1, 45, "Description");
                var timesToCompleteField =
                    new TextField(0, 2, 45, "Times to Complete");
                var pointsPerCompletionField =
                    new TextField(0, 3, 45, "Points per Completion");
                var bonusAmountField =
                    new TextField(0, 4, 45, "Bonus for completion");
                var notice =
                    new Label(0, 5, "Fields that are not applicable to the selected goal type\nwill be ignored");
                var goalTypeChoice =
                     new RadioGroup(46 , 1, new ustring[] {"_Finite", "_Checklist", "_Infinite"});
                goalTypeChoice.SelectedItemChanged += (args) =>
                {
                    // Get the index of the selected item
                    int selectedIndex = goalTypeChoice.SelectedItem;

                    switch (selectedIndex)
                    {
                        case 0: // "_Finite" is selected
                            nameField.Visible = true;
                            descriptionField.Visible = true;
                            timesToCompleteField.Visible = true;
                            timesToCompleteField.Text = "Times to Complete";
                            pointsPerCompletionField.Visible = true;
                            bonusAmountField.Visible = true;
                            bonusAmountField.Text = "Bonus For Completion";
                            break;

                        case 1: // "_Checklist" is selected
                            nameField.Visible = true;
                            descriptionField.Visible = true;
                            timesToCompleteField.Visible = false;
                            timesToCompleteField.Text = "0"; //Set text to 0 so it'll parse later on; value gets ignored
                            pointsPerCompletionField.Visible = true;
                            bonusAmountField.Visible = false;
                            bonusAmountField.Text = "0"; //Set text to 0 so it'll parse later on; value gets ignored
                            break;

                        case 2: // "_Infinite" is selected
                            nameField.Visible = true;
                            descriptionField.Visible = true;
                            timesToCompleteField.Visible = false;
                            timesToCompleteField.Text = "0"; //Set text to 0 so it'll parse later on; value gets ignored
                            pointsPerCompletionField.Visible = true;
                            bonusAmountField.Visible = false;
                            bonusAmountField.Text = "0"; //Set text to 0 so it'll parse later on; value gets ignored

                            break;

                        default:
                            //if the code has gotten down here something has gone horribly wrong
                            break;
                    }
                };
                // Add button functionality
                add.Clicked += () =>
                {
                    Data.AddGoal(
                        nameField.Text.ToString(),
                        descriptionField.Text.ToString(),
                        goalTypeChoice.SelectedItem,
                        int.Parse((string)timesToCompleteField.Text),
                        int.Parse((string)pointsPerCompletionField.Text),
                        int.Parse((string)bonusAmountField.Text)
                    );
                    Application.RequestStop();
                };
                // Create the dialog
                var goalDialog = new Dialog("Add Goal", 60, 20, add, cancel);
                goalDialog.Add(
                    nameField,
                    descriptionField,
                    timesToCompleteField,
                    pointsPerCompletionField,
                    bonusAmountField,
                    goalTypeChoice,
                    notice );

                Application.Run(goalDialog);

            })
        });
        top.Add(addGoalBar);

        // Run the application
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
                Height = 1
            };

            if (list[i].GoalType == "FiniteGoal")
            {
                button.Text = $"{list[i].Name} {list[i].GetCompletion("fraction")}";
            }
            else if (list[i].GoalType == "InfiniteGoal")
            {
                button.Text = $"{list[i].Name} {list[i]._timesCompleted}";
            }
            else if (list[i].GoalType == "SingleGoal")
            {
                
                button.Text = $"{list[i].Name} {list[i].GetCompletion(null)}"; // SingleGoal only has 1 format option
            }
            else { throw new Exception("Invalid goal type"); }


            // When the button is clicked, mark the the goal as  and update the button text
            button.Clicked += () =>
            {
                // this also increases the goal counter
                int pointsEarned = list[index].AddCompletion();
                // Update the points
                Data.UpdateExternalPointValue(pointsEarned, Location);
                // Update the points window
                UpdatePointsWindow();
                // Update the button text
                button.Text = $"{list[index].Name} {list[index].GetCompletion("fraction")}";
            };
            ButtonList.Add(button);
            scrollView.Add(button);
        }
    }
    public void UpdatePointsWindow()
    {
        // Fetch the latest points
        int points = Data.FetchProfilePoints(Location);
        // Calculate the new level and points
        var (level, pointsInLevel, percentOfLevel) = Data.CalcLevelAndPoints(points);

        // Update the pointsLabel and pointsGraph
        pointsLabel.Text = $"Level: {level}";
        pointsGraph.Fraction = percentOfLevel;
        pointsLeftLabel.Text = $"{pointsInLevel} points left until next level";
    }

}