namespace sandbox 
{
    class Scripture
{
    private string reference;
    private string fullText;
    private List<Word> words;

    public Scripture(string reference, string fullText)
    {
        this.reference = reference;
        this.fullText = fullText;
        words = new List<Word>();

        // Split the full text into words and create Word objects
        string[] wordArray = fullText.Split(' ');
        foreach (string word in wordArray)
        {
            words.Add(new Word(word));
        }
    }

    public string GetVisibleText()
    {
        string visibleText = reference + " ";

        foreach (Word word in words)
        {
            visibleText += word.IsHidden ? "____ " : word.Text + " ";
        }

        return visibleText.TrimEnd();
    }

    public void HideRandomWord()
    {
        Random random = new Random();
        List<Word> visibleWords = GetVisibleWords();
        
        if (visibleWords.Count > 0)
        {
            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
        }
    }

    public bool HasHiddenWords()
    {
        foreach (Word word in words)
        {
            if (!word.IsHidden)
                return true;
        }

        return false;
    }

    private List<Word> GetVisibleWords()
    {
        List<Word> visibleWords = new List<Word>();

        foreach (Word word in words)
        {
            if (!word.IsHidden)
                visibleWords.Add(word);
        }

        return visibleWords;
    }
}
}