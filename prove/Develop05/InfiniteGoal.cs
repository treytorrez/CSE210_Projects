
class InfiniteGoal : Goal
{
    private int _count;
    private int _amountDone;
    
    public InfiniteGoal(string name, string description) 
    {
        name = Name;
        description = _description;   
    }
    public InfiniteGoal()
    {
        
    }
    public override int MarkDone()
    {
        return _pointValue;
    }
    override public string GetCompletion(string format)
    {
        return "Infinite";
    }
}