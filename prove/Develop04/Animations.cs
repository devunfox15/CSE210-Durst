using System;

namespace Develop04
{
    class Animations
    {          
    public void Spinner()
        { // i need to connect the data from the user to this spinner
            int TimeChosen = 3;
            List<string> animationStrings = new List<string>();
            animationStrings.Add("|");
            animationStrings.Add("/");
            animationStrings.Add("-");
            animationStrings.Add("\\");
            animationStrings.Add("|");
            animationStrings.Add("/");
            animationStrings.Add("-");
            animationStrings.Add("\\");        
            // this next section recieves the current date and time
            DateTime startTime = DateTime.Now;
            // this takes the current time and adds the chosen time from the user
            DateTime endTime = startTime.AddSeconds(TimeChosen);
            int i = 0;
            while (DateTime.Now < endTime)
            {                    
                string s = animationStrings[i];
                Console.Write(s);
                Thread.Sleep(100);
                Console.Write("\b \b");
                i++;
                if (i >= animationStrings.Count)
                {
                    i = 0;
                }
            }
            Console.Clear();
        }
    public void counter()
    {
        for(int j = 5; j >= 0; j--)
        {
            Console.Write(j);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
    }
}