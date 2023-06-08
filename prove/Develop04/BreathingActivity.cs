using System;
namespace Develop04
{
class BreathingActivity : Activities
    {
      private string _response1;
        public BreathingActivity(string activity, string description, int activityTime, string response)
        :base(activity, description)
        {
            _response1 = response;
        }
        Animations animation = new Animations();
        public void BreathingInterval()
        {
            Console.Write("Breath in... ");
            counterBreathIn();
            Console.WriteLine();
            Console.Write("Breath out... ");
            counterBreathOut();
            Console.WriteLine();
        } 
        public void UserBreathingoutput()
        {
            int TimeChosen = GetDuration();
            Console.Clear();
            GetReady();
            Console.Clear();
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(TimeChosen);
            while (DateTime.Now < endTime)
            {
                BreathingInterval();
                Console.WriteLine();

            if (DateTime.Now > endTime)
            {
                break;
            }
            }
            Console.Clear();
            Console.WriteLine($"{EndingMessage()}\nBreathing activity.");
            Thread.Sleep(5000);  
    }
    void counterBreathIn()
    {
        for(int j = 4; j >= 0; j--)
        {
            Console.Write(j);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
    void counterBreathOut()
    {
        for(int j = 6; j >= 0; j--)
        {
            Console.Write(j);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
    void GetReady()
    {
        Console.Write("Get Ready to begin in: ");
        animation.counter();
    }
}
}