

class Breathing : Activity
{
    public override void Intro()
    {
        Console.WriteLine("Welcome to the breathing activity!");
        Console.WriteLine("This activity will guide you through a breathing exercise.");
    }

    public override void Execute()
    {
        int repetitions;
        if (_duration % 10 == 0)
        { repetitions = _duration / 10; }
        else
        { repetitions = _duration / 10 + 1; }

        for (int i = 0; i < repetitions; i++)
        {
            Console.Write("Inhale...");
            Loading.LoadingBar(time: _duration / repetitions / 2.5f, percent: false, inline: true);
            Console.WriteLine();

            Console.Write("Hold...");
            Loading.LoadingBar(time: _duration / repetitions / 5f, percent: false, inline: true);
            Console.WriteLine();

            Console.Write("Exhale...");
            Loading.LoadingBar(time: _duration / repetitions / 2.5f, percent: false, inline: true);
            Console.WriteLine();
        }
    }
}