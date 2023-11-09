class Reflection: Activity
{
    private string[] _questions = new string[]
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private string[] _reflections = new string[]
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"   
    };

    public override void Intro()
    {
        Console.WriteLine("Welcome to the Reflection activity!");
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilliance. This will help you recognize the power you have and how you can use it in other aspects of your life.");

    }
    public override void Execute()
    {
        System.Console.WriteLine("Consider the following question:");
        Random rnd = new Random();
        System.Console.WriteLine(_questions[rnd.Next(_questions.Length)]);
        System.Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
    
        System.Console.Write("Think about the following questions as they realate to your answer...");
        Loading.LoadingBar( percent: false,inline: true);
        System.Console.WriteLine("");
        System.Console.WriteLine(">> " + _reflections[rnd.Next(_reflections.Length)]);
        Loading.Spinner(_duration/3);
        System.Console.WriteLine(">> " + _reflections[rnd.Next(_reflections.Length)]);
        Loading.Spinner(_duration/3);
        System.Console.WriteLine(">> " + _reflections[rnd.Next(_reflections.Length)]);
        Loading.Spinner(_duration/3);

    }
}