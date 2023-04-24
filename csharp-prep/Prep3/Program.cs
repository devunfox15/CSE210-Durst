using System;

//the entry point of our program
class Program //Describes what this class is
// 
{
    static void Main(string[] args)
    //the entry point into the program
    {
        string Play = "";
        while (Play != "N")
        {
            Random randomGenerator = new Random();
            int number = randomGenerator.Next(1,100);
            Console.WriteLine($"What is the magic number? {number}");
            int userGuess = 0;
            int count = 0;
            while (number != userGuess)
            {
                Console.Write("What is your guess? ");
                string answer = Console.ReadLine();
                userGuess = int.Parse(answer);
                count += 1;

                if (number > userGuess) 
                {
                        Console.WriteLine("higher");
                }
                else if (number < userGuess)
                {
                    Console.WriteLine("lower");
                }
                else if (number == userGuess)
                {
                    Console.WriteLine($"You guessed it! It took you {count} tries.");
                }
                
            }
            Console.WriteLine(" ");
            Console.WriteLine("Would you like to play again? (Y/N)");
            Play = Console.ReadLine();
        }
    }
}
//end of the program