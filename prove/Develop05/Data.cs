using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
// NOTE: I am using 2 different JSON libraries this is NOT a good idea and I should probably fix it
//HOWEVER, functions should(mostly) use one or the other so it shouldn't be a *huge* issue 

static class Data
{


    // Save goals as JSON to a specified location
    static public void SaveJSON(string location, List<Goal> goals, int points)
    {
        var jsonObj = new JObject
        {
            ["points"] = points,
            ["goals"] = JArray.FromObject(goals)
        };

        File.WriteAllText(location, jsonObj.ToString());
    }
    // Load goals from a JSON file at a specified location
    static public (List<Goal>, int) LoadJSON(string location)
    {
        // Read the JSON, parse it, and get the root element
        string json = File.ReadAllText(location);
        JsonDocument doc = JsonDocument.Parse(json);
        JsonElement root = doc.RootElement;

        // Get the points value from the JSON
        int points = root.GetProperty("points").GetInt32();

        // Set array to the list of JSON goal objects and convert to string
        JsonElement array = root.GetProperty("goals");
        string arrayJson = array.GetRawText();

        // Create a custom JSON converter and deserialize the JSON
        var settings = new JsonSerializerOptions
        { Converters = { new GoalJsonConverter() } };

        List<Goal> goals = JsonSerializer
            .Deserialize<List<Goal>>(arrayJson, settings);
        return (goals, points);
    }

    // Custom JSON converter for the Goal class
    public class GoalJsonConverter : JsonConverter<Goal>
    {
        public override Goal Read
        (
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
        )
        {
            using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
            {
                JsonElement root = doc.RootElement;

                string goalType = root.GetProperty("GoalType").GetString();

                // Deserialize the JSON based on the goal type
                Goal goal = goalType switch
                {
                    "FiniteGoal" => JsonSerializer
                    .Deserialize<FiniteGoal>(root.GetRawText(), options),

                    "InfiniteGoal" => JsonSerializer
                    .Deserialize<InfiniteGoal>(root.GetRawText(), options),

                    "SingleGoal" => JsonSerializer
                    .Deserialize<SingleGoal>(root.GetRawText(), options),

                    _ => throw new JsonException("Unknown goal type.")
                };

                return goal;
            }
        }

        public override void Write
        (
        Utf8JsonWriter writer,
        Goal value,
        JsonSerializerOptions options
        )
        {
            // Serialize the goal to JSON
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
        }
    }

    // Find the JSON file containing the goals
    static public string FindJSON()
    {
        var defaultLocation = @"..\..\..\goals.json";
        // this is mostly for me, `dotnet run` and running with the debugger/vscode run button have different working directories
        //TODO: Remove this at the end of development
        if (!Debugger.IsAttached) { defaultLocation = @"goals.json"; };


        Console.WriteLine("Where are your goals stored? (default for default location)");
        while (true)
        {
            // I have absolutely zero clue why but whenever I run `Console.ReadLine()` I have to press enter twice for the input to actiually be read.
            var location = Console.ReadLine();
            // after pressing enter the first time it moves the cursor to the next line and then I have to press enter again for it to actually read the input. 
            Debug.WriteLine($"You entered :{location}");
            if (location == "default")
            {
                return Path.GetFullPath(defaultLocation);
            }

            if (File.Exists(location)) { return Path.GetFullPath(location); }

            else
            {
                Console.WriteLine($"No goals found at \n {location} \n please check the location and enter the name again.");
            }

        }
    }
    static public int FetchProfilePoints(string location)
    {
        // Read the current points value from the goals.json file
        var jsonRawText = File.ReadAllText(location);
        var jsonObj = JObject.Parse(jsonRawText);
        int points = (int)jsonObj["points"];
        return points;
    }
    // TODO: This is depreceated because it does not fit the assignment requrements. remove at subission
    // static public void UpdateExternalPointValue(int points, string location)
    // {
    //     // Read the current points value from the goals.json file
    //     var jsonRawText = File.ReadAllText(location);
    //     // I could leave it in the file and add a direct file path but I'd rather not
    //     var jsonObj = JObject.Parse(jsonRawText);
    //     int filePoints = (int)jsonObj["points"];

    //     // Add the points amount to the current points value
    //     int updatedPoints = filePoints + points;

    //     // Update the points value in the goals.json file
    //     jsonObj["points"] = updatedPoints;
    //     File.WriteAllText(location, jsonObj.ToString());
    // }
    static public (int, int, float) CalcLevelAndPoints(float points)
    {

        // Find the level that the user is at
        var level = Math.Ceiling(100 / 32f * Math.Sqrt(points));

        // Find how many points this level has
        var maxPointsInLevel = (int)Math.Floor(Math.Pow(level * 32f / 100, 2));
        var maxPointsInPrevLevel =
            (int)Math.Pow(Math.Floor((double)level - 1) * (32f / 100), 2);
        var currentLevelPointSpan = maxPointsInLevel - maxPointsInPrevLevel;

        // Find the number of points in the current level
        var pointsLeftInLevel = maxPointsInLevel - points;

        // Find the percentage of the current level that the user has completed
        var percentOfLevel =
            (points - maxPointsInPrevLevel) / currentLevelPointSpan;

        return ((int)level, (int)pointsLeftInLevel, percentOfLevel);
    }
    static public void AddGoal(
        string name,
        string description,
        int goalTypeChoice,
        int timesToComplete,
        int pointValue,
        int bonusAmount)
    {
        var goalType = "";

        JObject goalJson = new JObject();
        goalJson["Name"] = name;
        goalJson["Description"] = description;
        goalJson["IsComplete"] = false;
        goalJson["_timesCompleted"] = 0;
        switch (goalTypeChoice)
        {
            case 0:
                goalType = "FiniteGoal";
                goalJson["GoalType"] = goalType;
                goalJson["TimesToComplete"] = timesToComplete;
                goalJson["_pointValue"] = pointValue;
                goalJson["_bonusAmount"] = bonusAmount;

                break;
            case 1:
                goalType = "SingleGoal";
                goalJson["GoalType"] = goalType;
                goalJson["TimesToComplete"] = 1;
                break;
            case 2:
                goalType = "InfiniteGoal";
                goalJson["GoalType"] = goalType;
                break;
        }
        var jsonRawText = File.ReadAllText("goals.json");
        var jsonObj = JObject.Parse(jsonRawText);
        var goalsArray = jsonObj["goals"] as JArray;
        goalsArray.Add(goalJson);
        File.WriteAllText("goals.json", jsonObj.ToString());
    }

}