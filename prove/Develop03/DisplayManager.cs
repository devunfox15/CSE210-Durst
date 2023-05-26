using System;

namespace Develop03
{

// This is the code used to display the random verse modified
class DisplayManager
{
    public string UserInput()
    {
        Console.WriteLine("Press enter to continue or press 'quit' to finish: ");
        string Response = Console.ReadLine();
        return Response;
    }
    //this function will take the modified scripture and add the finishing touches
    public string ModifiedScript(Word word)
    {
        string SecretFunction = word.HideWord();
        return SecretFunction; 
    }



}
}