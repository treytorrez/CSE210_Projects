using System.Text.Json;

class Data
{
    public Data()
    {

    }
    static public void SaveJSON(string location, List<Goal> goals)
    {
        string json = JsonSerializer.Serialize(goals);
        File.WriteAllText(location, json);
    }
    static public List<Goal> LoadJSON(string location)
    {
        string json = File.ReadAllText(location);
        List<Goal> goals = JsonSerializer.Deserialize<List<Goal>>(json);
        return goals;
    }
    static public string FindJSON()
    {
        string location = null;
        do
        {
            System.Console.WriteLine("Where are your files stored? If you would like to create a new goal, type 'new'");
            location = Console.ReadLine();
            if (location == "new") {return null;}
            else if (File.Exists("goals.json")) {return location;}
            else 
            {
                Console.WriteLine($"No goals found at \n {location} \n please check the location and try again.");
            }
        } while (location == null);
        return null; // Not sure why I need this, the code shouldn't ever reach this point

        
    }
}