using System;
namespace sandbox
{

class Program
{
    static void Main(string[] args)
    {
        Scripture scripture = new Scripture("John 3:16", "For God so loved the world, that he gave his only Son, that whoever believes in him should not perish but have eternal life.");

        while (scripture.HasHiddenWords())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetVisibleText());

            Console.WriteLine("\nPress enter to hide more words or type 'quit' to exit.");
            string input = Console.ReadLine().ToLower();

            if (input == "quit")
                break;

            scripture.HideRandomWord();
        }
    }
}
}