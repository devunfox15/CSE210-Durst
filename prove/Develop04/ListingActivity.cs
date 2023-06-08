using System;
namespace Develop04
{
    class ListingActivity : Activities
    {
        private string _response;
        public ListingActivity(string activity, string description, int activityTime, string response)
        :base(activity, description)
        {
            _response = response;
        }
        // This program is designed to find a random promt
        Animations animation = new Animations();
    public string GetRandPrompt()
    {
            List<string> RandomPrompt1 = new List<string>() 
            {
                "Who are people that you appreciate?", "What are personal strengths of yours?",
                "Who are people that you have helped this week?", "When have you felt the Holy Ghost this month?",
                "Who are some of your personal heroes?"
            };
            // Create a new instance of the Random class
                Random random = new Random();
            // Get a random index within the range of the list
                int randomIndex = random.Next(RandomPrompt1.Count);
            // Retrieve the random question
                string randomPrompt = RandomPrompt1[randomIndex];
                return randomPrompt;
    }
    public void UserListInput()
    {   
        string prompt = GetRandPrompt();
        int TimeChosen = GetDuration();
        Console.Clear();
        Console.WriteLine("List as many responses you can to the following prompt: ");
        Console.WriteLine($"-- {prompt} --");
        Console.Write("You may begin in :");
        animation.counter();
        Console.WriteLine();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(TimeChosen);
        while (DateTime.Now < endTime)
        {
            Console.ReadLine();
            if (DateTime.Now > endTime)
            {
                break;
            }
        }
        Console.Clear();
        Console.WriteLine($"{EndingMessage()}\nListing activity.");
        Thread.Sleep(5000);
    }
    }
}
