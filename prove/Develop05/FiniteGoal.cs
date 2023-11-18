class FiniteGoal : Goal
{
    private int _timesToComplete;
    private int _timesCompleted;
    private int _bonusAmount;

    public FiniteGoal()
    {
        
    }
    public FiniteGoal(int timesToComplete, int bonusAmount, int timesCompleted=0)
    {
        _timesToComplete = timesToComplete;
        _bonusAmount = bonusAmount;
        _timesCompleted = timesCompleted;
    } 
   
    public override int MarkDone()
    {
        int pointsEarned = 0;
        if (_timesCompleted < _timesToComplete)
        {
            _timesCompleted++;
            
        }
        if (_timesCompleted >= _timesToComplete)
        {
            _isComplete = true;
            pointsEarned = _pointValue + _bonusAmount;
        }
        return pointsEarned;
    }

   // I don't think this will have any use outside of testing but it was easy to make so I did
    public void MarkDone(bool DontAddPoints)
    {
        if (_timesCompleted < _timesToComplete)
        {
            _timesCompleted++;
            
        }
        if (_timesCompleted >= _timesToComplete)
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
                completion = $"{_timesCompleted}/{_timesToComplete}";
                break;
            case "percent":
                completion = $"{_timesCompleted/_timesToComplete * 100}%";
                break;
            // case "bar":
            //     completion = $"[{new string('#', _timesCompleted)}{new string(' ', _timesToComplete - _timesCompleted)}]";
            //     break;
            default:
                completion = $"{_timesCompleted}/{_timesToComplete}";
                break;
        }
        return completion;

    }

}