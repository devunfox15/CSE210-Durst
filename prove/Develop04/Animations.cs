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
    public void BreathingIn()
        { // i need to connect the data from the user to this spinner
            Console.Write("__");
            Thread.Sleep(1000);
            
            Console.Write("_/\\");
            Thread.Sleep(1000);
            
            Console.Write("__/VV\\");
            Thread.Sleep(1000);
            
            Console.Write("__/\\_/\\");
            Thread.Sleep(1000);
            
            Console.Write("__/VV\\___");
            Thread.Sleep(1000);
            
        }
    public void BreathingOut()
    {
            Console.Write("_/\\/\\/\\/");
            Thread.Sleep(1000);
            Console.Clear();
            Console.Write("_/\\/\\/");
            Thread.Sleep(1000);
            Console.Clear();
            Console.Write("_/\\/");
            Thread.Sleep(1000);
            Console.Clear();
            Console.Write("_/\\");
            Thread.Sleep(1000);
            Console.Clear();
            Console.Write("_/");
            Thread.Sleep(1000);
            Console.Clear();
            Console.Write("_");
            Thread.Sleep(1000);
    }
    public void HourGlass()
    {
        Console.Clear();
        Console.WriteLine("  _________");
        Console.WriteLine("  \\-------/");
        Console.WriteLine("   \\-----/");
        Console.WriteLine("    \\---/");
        Console.WriteLine("    /   \\");
        Console.WriteLine("   /     \\");
        Console.WriteLine("  /_______\\");
        Thread.Sleep(750);
        for(int i = 0; i < 4; i++)
        {
        Console.Clear();
        Console.WriteLine("  _________");
        Console.WriteLine("  \\-------/");
        Console.WriteLine("   \\-----/");
        Console.WriteLine("    \\---/");
        Console.WriteLine("    / * \\");
        Console.WriteLine("   /     \\");
        Console.WriteLine("  /_______\\");

        Thread.Sleep(750);
        Console.Clear();
        Console.WriteLine("  _________");
        Console.WriteLine("  \\-------/");
        Console.WriteLine("   \\-----/");
        Console.WriteLine("    \\---/");
        Console.WriteLine("    /   \\");
        Console.WriteLine("   /  *  \\");
        Console.WriteLine("  /_______\\");
      
        Thread.Sleep(750);
        Console.Clear();
        Console.WriteLine("  _________");
        Console.WriteLine("  \\-------/");
        Console.WriteLine("   \\-----/");
        Console.WriteLine("    \\---/");
        Console.WriteLine("    /   \\");
        Console.WriteLine("   /     \\");
        Console.WriteLine("  /___*___\\");
        if (i == 3)
        {
            Console.WriteLine("20s left");
            Thread.Sleep(250);
        }
        Thread.Sleep(750);
    }
    for(int i = 0; i < 4; i++)
    {
        Console.Clear();
       Console.WriteLine("  _________");
        Console.WriteLine("  \\       /");
        Console.WriteLine("   \\-----/");
        Console.WriteLine("    \\---/");
        Console.WriteLine("    /   \\");
        Console.WriteLine("   /     \\");
        Console.WriteLine("  /-------\\");
        Thread.Sleep(700);
        Console.Clear();

        Console.WriteLine("  _________");
        Console.WriteLine("  \\       /");
        Console.WriteLine("   \\-----/");
        Console.WriteLine("    \\---/");
        Console.WriteLine("    / * \\");
        Console.WriteLine("   /     \\");
        Console.WriteLine("  /-------\\");
        Thread.Sleep(700);
        Console.Clear();

        Console.WriteLine("  _________");
        Console.WriteLine("  \\       /");
        Console.WriteLine("   \\-----/");
        Console.WriteLine("    \\---/");
        Console.WriteLine("    /   \\");
        Console.WriteLine("   /  *  \\");
        Console.WriteLine("  /-------\\");
        Thread.Sleep(700);
        Console.Clear();

        Console.WriteLine("  _________");
        Console.WriteLine("  \\       /");
        Console.WriteLine("   \\-----/");
        Console.WriteLine("    \\---/");
        Console.WriteLine("    /   \\");
        Console.WriteLine("   /     \\");
        Console.WriteLine("  /---*---\\");
        if (i == 3)
        {
            Console.WriteLine("10s left");
            Thread.Sleep(250);
        }
        Thread.Sleep(700);
        Console.Clear();
    }
     for(int i = 0; i < 3; i++)
    {
        Console.Clear();
       Console.WriteLine("  _________");
        Console.WriteLine("  \\       /");
        Console.WriteLine("   \\     /");
        Console.WriteLine("    \\---/");
        Console.WriteLine("    /   \\");
        Console.WriteLine("   /-----\\");
        Console.WriteLine("  /-------\\");
        Thread.Sleep(700);
        Console.Clear();

        Console.WriteLine("  _________");
        Console.WriteLine("  \\       /");
        Console.WriteLine("   \\     /");
        Console.WriteLine("    \\---/");
        Console.WriteLine("    / * \\");
        Console.WriteLine("   /-----\\");
        Console.WriteLine("  /-------\\");
        Thread.Sleep(700);
        Console.Clear();

        Console.WriteLine("  _________");
        Console.WriteLine("  \\       /");
        Console.WriteLine("   \\     /");
        Console.WriteLine("    \\---/");
        Console.WriteLine("    /   \\");
        Console.WriteLine("   /--*--\\");
        Console.WriteLine("  /-------\\");
      
        Thread.Sleep(700);
        Console.Clear();

        Console.WriteLine("  _________");
        Console.WriteLine("  \\       /");
        Console.WriteLine("   \\     /");
        Console.WriteLine("    \\---/");
        Console.WriteLine("    /   \\");
        Console.WriteLine("   /-----\\");
        Console.WriteLine("  /---*---\\");
        Thread.Sleep(700);
        Console.Clear();

       Console.WriteLine("  _________");
        Console.WriteLine("  \\       /");
        Console.WriteLine("   \\     /");
        Console.WriteLine("    \\   /");
        Console.WriteLine("    /---\\");
        Console.WriteLine("   /-----\\");
        Console.WriteLine("  /-------\\");

    } 
    }
    }   
}