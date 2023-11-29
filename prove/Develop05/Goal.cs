using System.Text.Json;
using System.Text.Json.Serialization;
[JsonDerivedType(typeof(FiniteGoal))]
[JsonDerivedType(typeof(InfiniteGoal))]
abstract class Goal
{
    public string Name { get; set; }
    public  string Description { get; set;}
    public  bool _isComplete { get; set;}
    public  int _pointValue { get; set;}

    public  int _timesCompleted { get; set;}
    public string GoalType { get;}



    public Goal()
    {
        // Name = name;
        // _description = description;
        _isComplete = false;
        GoalType = this.GetType().Name;
    }

    abstract public int AddCompletion();

    public bool IsComplete()
    {
        return _isComplete;
    }
    
    virtual public string Serialize()
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true, // this will make the JSON output more readable
        };
        // serialize the goal into JSON
        var json = JsonSerializer.Serialize(this);
        return json;
    }
    

    abstract public string GetCompletion(string format);



}
