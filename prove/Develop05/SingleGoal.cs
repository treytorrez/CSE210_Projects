class SingleGoal : Goal
{
    public override int AddCompletion()
    {
        if (_timesCompleted == 0)
        {
            _timesCompleted++;
            _isComplete = true;
            return _pointValue;
        }
        else
        {
            return 0;
        }
    }

    public override string GetCompletion(string format)
    {
        if (_isComplete){ return "[X]";}
        else {return "[]";}
    }
}