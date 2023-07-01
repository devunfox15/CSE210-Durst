using System;
using System.Collections.Generic;

namespace Develop02
{
    class Program
    {
        static void Main(string[] args)
        {
            //greeting and run the jorunal file early
            Console.WriteLine("Welcome to the journal Prompt");
            Journal journal = new Journal();

            while (true)
            {
                // Prompt the user with menu options
                Console.WriteLine("Please select one of the following choices:");
                Console.WriteLine("1) Add a new entry");
                Console.WriteLine("2) Display journal entries");
                Console.WriteLine("3) Save the journal to a file");
                Console.WriteLine("4) load the journal from a file");
                Console.WriteLine("5) Exit");

                // Read user input
                string input = Console.ReadLine();

                // Perform actions based on user input
                if (input == "1")
                {
                    // Prompt the user with a random prompt and add their response to the journal
                    Console.WriteLine(GetRandomPrompt());
                    string response = Console.ReadLine();
                    Entry entry1 = new Entry(DateTime.Now.ToString(), GetRandomPrompt(), response);
                    // this has the current time of a created list, the string 
                    journal.AddEntry(entry1);
                }
                else if (input == "2")
                {
                    // Display all entries in the journal
                    journal.DisplayEntries();
                }
                else if (input == "3")
                {
                    // Prompt the user for a filename and save the journal to a file
                    Console.Write("Enter a file name to save the journal to: ");
                    string fileName = Console.ReadLine();
                    journal.SaveToFile(fileName);
                }
                else if (input == "4")
                {
                    // Prompt the user for a filename and load the journal from a file
                    Console.Write("Enter a file name to load the journal from: ");
                    string fileName = Console.ReadLine();
                    journal.LoadFromFile(fileName);
                }
                else if (input == "5")
                {
                    // Exit the program
                    break;
                }
                else
                {
                    // Handle invalid input
                    Console.WriteLine("Invalid input");
                }
            }

            // Generate a random prompt
            string GetRandomPrompt()
            {
                string[] prompts = {
                    "Who was the most interesting person I interacted with today?",
                    "What was the best part of my day?",
                    "How did I see the hand of the Lord in my life today?",
                    "What was the strongest emotion I felt today?",
                    "If I had one thing I could do over today, what would it be?",
                    "What was your your biggest worry?",
                    "What was something fun or strange that happened today?",
                    "What was something cool that you did today?",
                    "Did you study the scriptures today?"

                };

                Random rand = new Random();
                int index = rand.Next(prompts.Length);
                string currentPrompt = prompts[index];

                return currentPrompt;
            }
        }
    }
}


