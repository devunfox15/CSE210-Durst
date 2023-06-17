using System;
namespace Develop04
{
    class Program
    {
        static void Main(string[] args)
        {
            void DisplayMenu()
            {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity ");
            Console.WriteLine("  2. Start reflecting activity ");
            Console.WriteLine("  3. Start listing activity ");
            Console.WriteLine("  4. Start timer activity ");
            Console.WriteLine("  5. Quit ");
            }
            int UserInput()
            {
            Console.WriteLine("Select a choice from the menu: ");
            string Option1 = Console.ReadLine();
            int Option = int.Parse(Option1);
            return Option;
            }
            DisplayMenu();
            int Option = UserInput();
            Console.Clear();
            // Here is where I will call all of the classes
            Animations animation = new Animations();
            while(Option != 5)
            {
            if (Option == 1)
                {
                    // Breathing activity
                    Console.Clear();
                    Console.WriteLine(" ");
                    animation.Spinner();
                    Console.Clear();
                    BreathingActivity Breathing = new BreathingActivity("Activity", "Description", 0, "Response");
                    Console.WriteLine(Breathing.OpeningMessage("Breathing", "relax by walking your through breathing in and out slowly. \nClear your mind and focus on your breathing."));
                    Console.WriteLine();
                    Breathing.UserBreathingoutput();
                    Console.Clear();
                    animation.Spinner();
                }
            else if (Option == 2)
                {
                    //Reflection activity
                    // ReflectionActivity.GetActivityName("Reflection");
                    Console.Clear();
                    Console.WriteLine(" ");
                    animation.Spinner();
                    Console.Clear();
                    ReflectionActivity reflection = new ReflectionActivity("Activity", "Description", 0, "Response");
                    Console.WriteLine(reflection.OpeningMessage("Reflection", "reflect on times in your life when you have shown strength and resilience. \nThis will help you recognize the power you have and how you can use it in other aspects of your life."));
                    Console.WriteLine();
                    reflection.UserInput();
                    Console.Clear();
                    animation.Spinner();
                }
            else if (Option == 3)
                {
                    //Listing Activity
                Console.Clear();
                animation.Spinner();
                Console.WriteLine(" ");
                ListingActivity listingActivity = new ListingActivity("Activity", "Description", 0, "Response");
                Console.WriteLine(listingActivity.OpeningMessage("Listing", "reflect on times in your life when you have shown strength and resilience. \nThis will help you recognize the power you have and how you can use it in other aspects of your life.")); 
                Console.WriteLine();
                listingActivity.UserListInput();
                Console.Clear();
                listingActivity.EndingMessage();
                animation.Spinner();
                }
                else if (Option == 4) 
                {
                Console.Clear();
                animation.Spinner();
                Console.WriteLine(" ");
                Console.WriteLine("Welcome to the physical activity:");
                Console.WriteLine("In this activity you can participate in an exercise while watch a timer counter for 30s.");
                Thread.Sleep(5000);
                Console.Clear();
                Console.WriteLine("Ready??? Get comfortable! (you have 5 seconds till you begin)");
                Thread.Sleep(5000);
                Console.WriteLine("Begin your exercise!");
                animation.HourGlass();
                Console.Clear();
                Console.WriteLine("Congrats on finish 30 seconds of your exercise. Hope to see you again soon!");
                Thread.Sleep(3000);
                Console.Clear();
                animation.Spinner();
                }
            else
                {
                Console.WriteLine("You returned an Invalid Option. Please try again.");
                Thread.Sleep(1000);
                }
            Console.Clear();
            DisplayMenu();
            Option = UserInput();
            }
        }
    }
}