using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("what is your grade percentage? ");
        string answer = Console.ReadLine();
        int number = int.Parse(answer);
        string letter = " ";

        if (number >= 90)
        { 
            if (number < 93)
            {
                letter = "A-";
            }
            else
           {
            letter = "A";
           }
        }
        else if (number >= 80)
        { 
            if (number > 87)
            {
                letter = "B+";
            }
            else if(number < 84)
            {
                letter = "B-";
            } 
            else
            {
                letter = "B";
            }
        }
         else if (number >= 70)
        {
            if (number > 76)
            {
                letter = "C+";
            }
            else if(number < 74)
            {
                letter = "C-";
            } 
            else
            {
                letter = "C";
            }
        }
         else if (number >= 60)
        {
            if (number > 66)
            {
                letter = "D+";
            }
            else if(number < 64)
            {
                letter = "D-";
            } 
            else
            {
                letter = "D";
            }
        }
        else
        {
           letter = "F";
        }
         Console.WriteLine($"Your grade is: {letter}");
        
        if (number >= 70)
        {
            Console.WriteLine("You passed!");
        }
        else
        {
            Console.WriteLine("Better luck next time!");
        }
    }
}