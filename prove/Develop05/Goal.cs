using System;
namespace Develop05{
    // this is the parent function that holds the main functionalities of goals like 
    // type name, description, it also contains a abstract that marks the goals
    
public abstract class Goal
{
    // these are the main variables of the goal functions
    //---------------------------------------------------------
    // goalType holds wheter the goal is simple, eternal, or a
    // Goal name defines the name useded to decribe a goal
    protected string _goalName;
    // goal description_ describes what a goal is and how 
    // you can achevie the goal
    protected string _goalDescription;
    // this will store the point and will be used to determine the point that
    // a user can update and keep track of
    protected int _totalPoints = 0;
    protected bool _compleation = false;
    protected bool _verify = false;
    protected int _bonusPoints;
    // the first construct for goal

    // this function is designed to determine wheter or not
    // a user gains point for their scores
    //displays the goals  for record event
    public virtual string Display()
    {
        if (_compleation == true)
        {
        return $"(x) {_goalName} ({_goalDescription})";
        }
        else
        {
            return $"( ) {_goalName} ({_goalDescription})";
        }
    }
    public bool GetVerify()
     {
        return _verify;
     }
      public bool UpdateVerify()
     {
        _verify = true;
        return _verify;
     }
    public abstract string GoalType();
// the first construct for goal
    public Goal()
    {
    }
    // a second construct used to hold all the values 

    public Goal(string GoalName, string GoalDescription, int TotalPoints)
    {
    _goalName = GoalName;
    _goalDescription = GoalDescription;
    _totalPoints = TotalPoints;
    }
    public virtual string GetStringRepresentation()
    {
        System.Console.WriteLine("it broke here");
        return("");
    }

    //------------------------------------------------------------------------------------------------
    //this is the task that will be altered or overrided
    public virtual bool TaskCompleation(int points)
    {
    return false;
    }
    //------------------------------------------------------------------------------------------------
    //This returns the goal name 
    public string GoalName()
    {
     Console.Write("What is the name of your goal? ");
     _goalName = Console.ReadLine();
     return _goalName;
    }
    public string GetGoalName()
    {
    return _goalName;
    }
    public string SetGoalName(string goalName)
    {
        _goalName = goalName;
        return _goalName;
    }
    // this will find the discription of a user
    public string GoalDescription()
    {
     Console.Write("What is the description of the goal? ");
     _goalDescription = Console.ReadLine();
     return _goalDescription;
    }
     public string GetGoalDescription()
    {
    return _goalDescription;
    }
    public string SetGoalDescription(string goalDescription)
    {
        _goalDescription = goalDescription;
        return _goalDescription;
    }
       // this will assign points for a goal depnding on users desire.
     public int GetUserActivityPoints()
    {
        Console.WriteLine("How many points is this activity?");
        string Points = Console.ReadLine();
        _totalPoints = int.Parse(Points);
        return _totalPoints;
    }
    public int GetTotalPoints()
    {
        return _totalPoints;
    }
    public int GetBonusPoints()
    {
        return _bonusPoints;
    }
    
}
}