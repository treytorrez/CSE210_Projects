class Listing: Activity
{

    private string[] _questions = new string[]
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public override void Intro()
    {
        System.Console.WriteLine("Welcome to the Listing activity!");
        System.Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
    }
    public override void Execute()
    {

        System.Console.WriteLine("Consider the following question:");
        Random rnd = new Random();
        System.Console.WriteLine(_questions[rnd.Next(_questions.Length)]);
        System.Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
    
        System.Console.WriteLine("Now, list as many things as you can:");

        DateTime start = DateTime.Now;
        while (DateTime.Now.Subtract(start).TotalSeconds < _duration)
        {
            System.Console.Write(">> ");
            Console.ReadLine();
        }
        
    }
}