using System;
using System.Collections.Generic;

public class Scripture
{
    public string Book;
    public int Chapter;
    public Dictionary<int, string[]> Content = new Dictionary<int, string[]>();
    public bool HasMultipleVerses;
    public int StartingVerse;
    public int EndVerse;
    public int NumVerses;
    public Scripture()
    {
    }
    public int GetTotalWords()
    {
        int totalWords = 0;
        foreach ( var verse in Content)
        {
            totalWords += verse.Value.Length;
        }

        return totalWords;
    }


    public Dictionary<int, string[]> GetContent()
    {
        return Content;
    }

};  
