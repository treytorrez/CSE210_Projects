using System.Text.Json;

class InfiniteGoal : Goal
{
    
    public InfiniteGoal(string name, string description) 
    {
        name = Name;
        description = Description;   
    }
    public InfiniteGoal()
    {
        
    }
    public override int AddCompletion()
    {
        return _pointValue;
    }
    override public string GetCompletion(string format)
    {
        return "Infinite";
    }
}