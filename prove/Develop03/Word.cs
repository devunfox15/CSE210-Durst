using System;

namespace Develop03
{

class Word
{
            //This program need to call the get function then hide certain words
    Scripture scriptText1 = new Scripture();

        // a list of 25 false if the statement is true
    private bool [] _hiddenWord = {false , false , false, false, false, false, false, false, false, false,
                          false , false , false, false, false, false, false, false, false, false,
                          false , false , false, false, false};
   public string HideWord()
{
    // splits the scripture string into an array of words
    string scriptText = scriptText1.GetScriptText();
    string[] words = scriptText.Split(' ', StringSplitOptions.RemoveEmptyEntries);

    Random random = new Random();
    // generates 5 random indexes
    for (int i = 0; i < 4; i++)
    {
        bool Loop = true;
        while(Loop)
        {
        int randomIndex = random.Next(0, words.Length);

        // Get random word and hidden status from arrays
        string randomWord = words[randomIndex];
        bool hidden = _hiddenWord[randomIndex];

        if (!_hiddenWord[randomIndex])
        {
            _hiddenWord[randomIndex] = true;
            Loop = false;
        }
        bool allHidden = true;
            for(int j = 0; j < 25; j++)
            {
                if (!_hiddenWord[j])
                {
                    allHidden = false;
                     break;
                }
            }
                if (allHidden)
                {
                    Environment.Exit(0);
                }
        }
    }
    

    string results = " ";
    // counter += 1;
    for (int i = 0; i < words.Length; i++)
    {
        if (_hiddenWord[i] == true)
        {
            results += GetDashed(words[i]) + " ";
        }
        else
        {
            results += words[i] + " ";
        }

    }

    return results;
}

        public string GetDashed(string word)
    {
        int length = word.Length;
        string dashes = new string('-', length);
        return dashes;
    }

}
}


