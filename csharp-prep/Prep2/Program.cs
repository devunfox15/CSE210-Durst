using System;

class Program
{
    static void Main(string[] args)
    {
    Console.Write("what is your grade? ");
    string letter = Console.ReadLine();
    int number = int.Parse(letter);
        if (number >= 90)
        {
            Console.WriteLine("Your grade is an A");
        }
        else if (number > 80 || number < 90)
        {
           Console.WriteLine("Your grade is a B"); 
        }
         else if (number >= 70 || number < 80)
        {
           Console.WriteLine("Your grade is a C"); 
        }
         else if (number >= 60 || number < 70)
        {
           Console.WriteLine("Your grade is a D"); 
        }
        else
        {
            Console.WriteLine("your grade is a F");
        }
    }
}