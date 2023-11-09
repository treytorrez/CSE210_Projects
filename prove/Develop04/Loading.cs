using System;


class Loading
{
    public static void LoadingBar(int len = 15, float time = 3, bool percent = true, bool inline = false)
    {
        // len is the length of the loading bar
        // time is the time for the loading bar to complete
        // percent is whether or not to display the percent
        float updateTime = (float)time / len;
        // updateTime = 

        float currentPercent = 0;
        int currentUnitsFilled = 0;

        if (!inline) { Console.WriteLine("Loading..."); }
        Console.Write("[");
        for (int i = 0; i < len; i++) { Console.Write("."); }
        Console.Write("]");
        if (percent) { Console.Write("  0%"); }


        while (currentPercent <= 100)
        {
            //sleep for updateTime seconds
            // the '910' gets the timer more accurate too many moving parts to really hone it in
            Thread.Sleep((int)(updateTime * 910)); 
            // Move cursor to start of loading bar to print over it
            SetCursorToLoadingBarStart();
            // print loading bar
            Console.Write("[");
            currentUnitsFilled = (int)(currentPercent / (100 / len));
            if (currentUnitsFilled > len) { currentUnitsFilled = len; }
            for (int i = 0; i < currentUnitsFilled; i++) { Console.Write("#"); }
            for (int i = 0; i < len - currentUnitsFilled; i++) { Console.Write("."); }
            Console.Write("]");
            currentPercent += (100 / len);
            if (currentPercent > 100 && percent)
            {
                Console.Write($"100%");
                break;
            } // yes I am aware that proper structuring would make this if statement
                // unnecessary... but I'm lazy and its 12:30am so heres a hacky solution
            if (currentUnitsFilled == len && percent)
            {
                Console.Write($"100%");
                break;
            }           // same as above
            if (percent) { Console.Write($"{currentPercent,3}%"); }
        }

        if (!inline)
        {
            Console.WriteLine(" Done!");
        }

        void SetCursorToLoadingBarStart()
        {
            // Old code; Deletes the whole line
            // TODO: Make this only delete the characters that were occupied by the loading bar
            // int currentLineCursor = Console.CursorTop;
            // Console.SetCursorPosition(0, Console.CursorTop);
            // Console.Write(new string(' ', Console.WindowWidth));
            // Console.SetCursorPosition(0, currentLineCursor);

            // New code; Deletes only the characters that were occupied by the loading bar
            if (!percent)
            {
            Console.SetCursorPosition(Console.CursorLeft-len-2, Console.CursorTop);
            }
            else if (percent)
            {
                Console.SetCursorPosition(Console.CursorLeft-len-6, Console.CursorTop);
            }
        }
    }

    static public void Spinner(float time=3)
    {
        float repetitions = time * 10;

        
        string[] spinner = new string[]{"▲", "►", "▼", "◄"};
        int i = 0;
        
        while (repetitions > 0)
        {
            Console.Write(spinner[i]);
            Thread.Sleep(91);// This would typically be 100 but since the loop takes about 9ms to run, I had to adjust it for accuracy
            Console.Write("\b");
            i++;
            repetitions--;
            if (i == spinner.Length){i = 0;}
        }

    }
}