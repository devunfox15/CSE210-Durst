using System;

class Program
{
    //uses static until we start writing with classes
    static void Main(string[] args)
    {
        DisplayWelcome();
        string UserName1 = PromptUserName();
        int UserNumber1 = PromptUserNumber();
        int UserNumberSquared = SquareNumber(UserNumber1);
        DisplayResults(UserName1, UserNumberSquared);
    }
    static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the program!");
        }
    static string PromptUserName()
    {
        Console.WriteLine("Please enter your name here: ");
        string userName = Console.ReadLine();
        return userName;
    }
    static int PromptUserNumber()
    {
        Console.WriteLine("What is your favorite Number: ");
        string UserNumberEntry = Console.ReadLine();
        int UserNumber = int.Parse(UserNumberEntry);
        return UserNumber; 
    }
    static int SquareNumber(int UserNumber1)
    {
        int SquareValue = UserNumber1 * UserNumber1;
        return SquareValue;
    }
    static void DisplayResults(string UserName1, int UserNumberSquared)
    {
        Console.WriteLine($"{UserName1} the square of your number is {UserNumberSquared}");
        
    }
}