using System;
namespace Develop04
{
class ReflectionActivity : Activities
    {
        private string _response;
        public ReflectionActivity(string activity, string description, int activityTime, string response)
        :base(activity, description)
        {
            _response = response;
        }
        Animations animation = new Animations();
        public string GetRandReflectQs()
        {
            List<string> RandomReflectionQuestion = new List<string>() 
            {
             "Why was this experience meaningful to you?", "Have you ever done anything like this before?",
             "How did you get started?", "How did you feel when it was complete?",
             "What made this time different than other times when you were not as successful?", "What is your favorite thing about this experience?",
             "What could you learn from this experience that applies to other situations?","What did you learn about yourself through this experience?",
             "How can you keep this experience in mind in the future?"
            };
            // Create a new instance of the Random class
                Random random = new Random();
            // Get a random index within the range of the list
                int randomIndex = random.Next(RandomReflectionQuestion.Count);
            // Retrieve the random question
                string randomPrompt = RandomReflectionQuestion[randomIndex];
                return randomPrompt;
        }
        public void UserInput()
        {
            int TimeChosen = GetDuration();
            Console.Clear();
            string randomPrompt = GetRandPrompts();
            string randomReflectionQuestion = GetRandReflectQs();
            Console.WriteLine(randomPrompt);
            Thread.Sleep(5000);
            DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(TimeChosen);
        while (DateTime.Now < endTime)
        {
            for(int i = 0; i < 10; i++ )
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(GetRandReflectQs());
                Thread.Sleep(5000);
                if (DateTime.Now > endTime)
                {
                    break;
                }
            }

        }
        Console.Clear();
        Console.WriteLine($"{EndingMessage()}\nReflection activity.");
        Thread.Sleep(5000);

        }
        public string GetRandPrompts()
        {
            List<string> RandomPrompts = new List<string>() 
            {
             "Think of a time when you stood up for someone else.", "Think of a time when you did something really difficult.",
             "Think of a time when you helped someone in need.", "Think of a time when you did something truly selfless."
            };
            // Create a new instance of the Random class
                Random random = new Random();
            // Get a random index within the range of the list
                int randomIndex = random.Next(RandomPrompts.Count);
            // Retrieve the random question
                string randomPrompt = RandomPrompts[randomIndex];
                return randomPrompt;
        }

    }
}