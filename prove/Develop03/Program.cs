using System;

namespace Develop03
{

class Program
{
    static void Main(string[] args)
    {

    Word word = new Word();
    Scripture scriptureHeader1 = new Scripture();
    DisplayManager display1 = new DisplayManager();

        // calls the original scripture
      Scripture scripture1 = new Scripture();
      Console.WriteLine(scripture1.GetScripture());
    // determine the user response and loop untill program ends
         while (true)
        {
            // calls the display manager class and gets the users input
      DisplayManager UserInput1 = new DisplayManager();
      string UserResponse = UserInput1.UserInput();
    
       if (UserResponse == "quit")
        {
            return;
        }

        else 
        {
            
         Console.Clear();
         // this will call the word function
        //  Scripture scriptureHeader1 = new Scripture();
        string scriptureHeader = scriptureHeader1.GetVerseHeader();
        
        // Console.WriteLine(scriptureHeader);
        Console.WriteLine($"{scriptureHeader}{display1.ModifiedScript(word)}");
        }
    }
    
    }
}
}