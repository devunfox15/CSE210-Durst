using System;
namespace Develop05
{
// this is a goal that can be marked compleated once for points
//simpeGoal() base, recordEvent()

public class SimpleGoal : Goal
{
    private string _goalType;
    private int regulator = 0;
    public SimpleGoal(string goalName, string goalDescription, int totalPoints):base ( goalName, goalDescription, totalPoints)
    {
        _goalName = goalName; 
        _goalDescription = goalDescription; 
        _totalPoints = totalPoints;

    }
    public SimpleGoal()
    {
    }
    public override string GoalType()
    {
        _goalType = "Simple";
        return _goalType;
    }
    
    public override string GetStringRepresentation()
    {
        return($"Simple,{_goalName},{_goalDescription},{_totalPoints}");
    }                                                                          // the base takes the defines the variables in the parent that we want the child to inherrit
     public override bool TaskCompleation(int points)
    {   
        Console.WriteLine("Did you complete your goal? (y/n)");
        string userInput = Console.ReadLine();
        if (userInput == "y")
        {
            if (regulator < 1)
            {
            _compleation = true;
            Console.WriteLine( $"(X) {_goalName} ({_goalDescription})");
            regulator++;
            return true;
            }
            else 
            {
                Console.WriteLine();
                Console.WriteLine("YOU HAVE COMPLETED THIS GOAL TO THE MAX");
                return false;
            }
        }
        else
        {
            Console.WriteLine($"( ) {_goalName} ({_goalDescription})");
            return false;
        }
    }
    
}
}