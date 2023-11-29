using System.Text.Json;

class FiniteGoal : Goal
{
    public int TimesToComplete { get; set;}
    private int _bonusAmount;

    public FiniteGoal()
    {
        
    }
    public FiniteGoal(int timesToComplete, int bonusAmount, int timesCompleted=0)
    {
        TimesToComplete = timesToComplete;
        _bonusAmount = bonusAmount;
        _timesCompleted = timesCompleted;
    } 
   
    public override int AddCompletion()
    {
        int pointsEarned = 0;
        if (_timesCompleted < TimesToComplete)
        {
            _timesCompleted++;
            
        }
        if (_timesCompleted >= TimesToComplete)
        {
            _isComplete = true;
            pointsEarned = _pointValue + _bonusAmount;
        }
        return pointsEarned;
    }

   // I don't think this will have any use outside of testing but it was easy to make so I did
    public void MarkDone(bool DontAddPoints)
    {
        if (_timesCompleted < TimesToComplete)
        {
            _timesCompleted++;
            
        }
        if (_timesCompleted >= TimesToComplete)
        {
            _isComplete = true;
        }
    }

    override public string GetCompletion(string format)
    {
        string completion = "";
        switch (format)
        {
            case "fraction":
                completion = $"{_timesCompleted}/{TimesToComplete}";
                break;
            case "percent":
                completion = $"{_timesCompleted/TimesToComplete * 100}%";
                break;
            // case "bar":
            //     completion = $"[{new string('#', _timesCompleted)}{new string(' ', _timesToComplete - _timesCompleted)}]";
            //     break;
            default:
                completion = $"{_timesCompleted}/{TimesToComplete}";
                break;
        }
        return completion;

    }
    // override public string Serialize()
    // {
    //     // serialize the goal into JSON
    //     var json = JsonSerializer.Serialize(this);
    //     return json;
    // }

}