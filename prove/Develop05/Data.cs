using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

class Data
{
    public Data()
    {

    }
    
    // Save goals as JSON to a specified location
    static public void SaveJSON(string location, List<Goal> goals)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true, // this will make the JSON output more readable
            
        };
        
        // Serialize the goals into JSON
        var json = "[\n";
        foreach (Goal goal in goals)
        {
            json += JsonSerializer.Serialize(goal, options) + "," + "\n";
        }
        json = json.Substring(0, json.Length - 2) + "\n";
        json += "]";
        
        // Write the JSON to the specified location
        File.WriteAllText(location, json);
    }

    // Load goals from a JSON file at a specified location
    static public List<Goal> LoadJSON(string location)
    {
        string json = File.ReadAllText(location);

        var settings = new JsonSerializerOptions
        {
            Converters = { new GoalJsonConverter() }
        };

        // Deserialize the JSON into a list of goals
        List<Goal> goals = JsonSerializer.Deserialize<List<Goal>>(json, settings);
        return goals;
    }
    
    // Custom JSON converter for the Goal class
    public class GoalJsonConverter : JsonConverter<Goal>
    {
        public override Goal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
            {
                JsonElement root = doc.RootElement;

                string goalType = root.GetProperty("GoalType").GetString();
                
                // Deserialize the JSON based on the goal type
                Goal goal = goalType switch
                {
                    "FiniteGoal" => JsonSerializer.Deserialize<FiniteGoal>(root.GetRawText(), options),
                    "InfiniteGoal" => JsonSerializer.Deserialize<InfiniteGoal>(root.GetRawText(), options),
                    _ => throw new JsonException("Unknown goal type.")
                };

                return goal;
            }
        }

        public override void Write(Utf8JsonWriter writer, Goal value, JsonSerializerOptions options)
        {
            // Serialize the goal to JSON
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
        }
    }
    
    // Find the JSON file containing the goals
    static public string FindJSON()
    {
        string location = null;
        do
        {
            Console.WriteLine("Where are your files stored? If you would like to create a new goal, type 'new'");
            location = Console.ReadLine();
            
            if (location == "new") { return null; }
            else if (File.Exists("goals.json")) { return location; }
            else
            {
                Console.WriteLine($"No goals found at \n {location} \n please check the location and try again.");
            }
        } while (location == null);
        
        return null; // Not sure why I need this, the code shouldn't ever reach this point
    }
}