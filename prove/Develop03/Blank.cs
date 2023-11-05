using System.Diagnostics;

public class Blank
{

    private int _maxGuesses;
    public Scripture currentScripture;
    private int _currentGuess;
    private Dictionary<int, bool[]> _blankDictionary;
    private Dictionary<int, string[]> _content;
    Random random = new Random();

    public Blank(Scripture scripture)
    {
        _currentGuess = 0;
        currentScripture = scripture;
        _content = currentScripture.GetContent();
        _blankDictionary = _generateBlankDictionary(_content);
    }
    private Dictionary<int,bool[]> _generateBlankDictionary(Dictionary<int, string[]> content)
    {
        Dictionary<int,bool[]> blankDictionary = new Dictionary<int, bool[]>();
        foreach (var verse in content)
        {
            bool[] blank = new bool[verse.Value.Length];
            for (int i = 0; i < verse.Value.Length; i++)
            {
                blank[i] = false;
            }
            blankDictionary.Add(verse.Key, blank);
        }
        return blankDictionary;
    }

    public void SetGuesses(int guesses)
    {
        _maxGuesses = guesses;
    }
    private int _findAmountToBlank(Dictionary<int, bool[]> blankDictionary, int currentGuess)
    {
        int totalWords = currentScripture.GetTotalWords();

        // find percentage of words to blank
        float blankPercentage = ((float)currentGuess/_maxGuesses)+(1/(float)_maxGuesses);
        // find amount of 'true's that are already in the dictionary
        int currentBlanks = 0;
        foreach (var verse in blankDictionary)
        {
            for (int i = 0; i < verse.Value.Length; i++)
            {
                if (verse.Value[i])
                {
                    currentBlanks++;
                }
            }
        }
        int amountToBlank = (int)(totalWords * blankPercentage) - currentBlanks;

        return amountToBlank;
    }
    public void UpdateBlankDictionary()
    {
        int amountToBlank = _findAmountToBlank(_blankDictionary, _currentGuess);
        while (amountToBlank > 0 && _currentGuess < _maxGuesses)
        {
            foreach (var verse in _blankDictionary )
            {
                int word = random.Next(verse.Value.Length);
                if (!verse.Value[word])
                {
                    verse.Value[word] = true;
                    amountToBlank--;
                }
            }
        }
        _currentGuess++;
    }

    public Dictionary<int, bool[]> GetBlankDictionary()
    {
        return _blankDictionary;
    }
    



}
