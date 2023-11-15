abstract class Goal
{
    public string Name { get; set; }
    protected string _description;
    protected bool _isComplete;
    protected int _pointValue;



    public Goal()
    {
        // Name = name;
        // _description = description;
        _isComplete = false;
    }

    abstract public int MarkDone();

    public bool IsComplete()
    {
        return _isComplete;
    }

    abstract public string GetCompletion(string format);

}