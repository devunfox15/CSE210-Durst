using System;

//the entry point of our program
class Program //Describes what this class is
// 
{
    static void Main(string[] args)
    //the entry point into the program
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1,11);
        Console.WriteLine(number);
    }
}
//end of the program