using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // step 1 make a list for the numbers
        List<int> numbers = new List<int>();

        int userNumber = -1;
        while (userNumber != 0)
        {
            Console.WriteLine("This is an sum, average, and max number calculator: ");
            Console.Write("Enter a number (0 to quit): ");
            //adds a number as a string so we need to convert it to a number value for calculations
            string userResponse = Console.ReadLine();
            userNumber = int.Parse(userResponse);
            // an if statement that is used to determine if a number should be added to the list
            //all number but zero function due to this statement
            // if the statement passes you can add the number to the list
            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }
        // now we will uses a for each loop to total the sum of all the numbers entered into the list
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        // this will write the total sum
        Console.WriteLine($"The sum is: {sum}");
        // this will calculate the average and print it out 
        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");
        // this starts the list at the first data point
        int max = numbers[0];

        // this loop will determine which number is the maximum number and then saves it as Max.
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }

        Console.WriteLine($"The max is: {max}");
    }
}