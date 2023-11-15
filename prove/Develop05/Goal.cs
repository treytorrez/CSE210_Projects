abstract class Goal
{
    public string Name { get; set; }
    protected string _description;
    protected bool _isComplete { get; set;}



    public Goal()
    {
        // Name = name;
        // _description = description;
        // _isComplete = false;
    }

    abstract public void MarkDone();

    


}