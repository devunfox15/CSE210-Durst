using System;
namespace Develop05{
class EternalGoal : Goal
{
private string _goalType;
 public EternalGoal(string GoalName, string GoalDescription, int TotalPoints):base ( GoalName, GoalDescription, TotalPoints)
{     
    _goalName = GoalName; 
    _goalDescription = GoalDescription; 
    _totalPoints = TotalPoints;                                                                     // the base takes the defines the variables in the parent that we want the child to inherrit
}
 public EternalGoal()
    {
    }
    public override string GoalType()
    {
        _goalType = "Eternal";
        return _goalType;
    }
 public override string GetStringRepresentation()
    {
        return($"Eternal,{_goalName},{_goalDescription},{_totalPoints}");
    }  
     public override string Display()
    {
       return $"( ) {_goalName} ({_goalDescription})";
    }
public override bool TaskCompleation(int points)
{
    Console.WriteLine("Did you complete your goal? (y/n)");
    string userInput = Console.ReadLine();
    if (userInput == "y")
    {
        Console.WriteLine($"( ) {_goalName} ({_goalDescription})");
        return true;
    }
    else
    {
        Console.WriteLine($"( ) {_goalName} ({_goalDescription})");
        return false;
    }
}
}
}