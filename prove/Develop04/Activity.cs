class Activity
{
    protected string _introMessage;
    protected string _exitMessage;
    protected int _duration;

    public void SetDuration()
    {
        System.Console.WriteLine("Please enter the duration of the activity in seconds.");
        while (true)
        {
            // Check if input is an integer; if not, ask again
            string input = Console.ReadLine();
            // Try to parse input as an integer and assign to _duration
            if (int.TryParse(input, out _duration))
                {break;}
            else    
                {Console.WriteLine("Invalid input. Please try again.");}
        }
    }




    public virtual void Intro()
    {Console.WriteLine("If you're seeing this you're either the developer or something has gone horribly wrong!");}
    public virtual void Execute()
    {Console.WriteLine("If you're seeing this you're either the developer or something has gone horribly wrong!");}
    public virtual void Stats()
    {
        string className = GetType().Name;
        System.Console.WriteLine($"You have completed the {className} activity for {_duration} seconds.");
    }

}