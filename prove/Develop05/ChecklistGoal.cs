using System;
namespace Develop05{
class ChecklistGoal : Goal
{
    private string _goalType;
    private int _counter;
    private int _target = 0; 
 public ChecklistGoal(string goalName, string goalDescription, int totalPoints, int bonusPoints, int counter, int target): base(goalName, goalDescription, totalPoints)
    {     
     _goalName = goalName; 
     _goalDescription = goalDescription;                                                                       // the base ,takes the defines the variables in the parent that we want the child to inherrit
     _bonusPoints = bonusPoints;
     _counter = counter; 
     _target = target;
    }
     public ChecklistGoal()
    {
    }
    public override string GoalType()
    {
        _goalType = "Checklist";
        return _goalType;
    }
    public int GetCounter()
    {
       return _counter;
    }
    public override string Display()
    {
        if (_compleation == true)
        {
        return ($"(X) {_goalName} ({_goalDescription}) -- you have completed {_counter}/{_target}");
        }
        else
        {
        return ($"( ) {_goalName} ({_goalDescription}) -- you have completed {_counter}/{_target}"); 
        }
    }
     public override string GetStringRepresentation()
    {
        
        return($"Checklist,{_goalName},{_goalDescription},{_totalPoints},{_bonusPoints},{_counter},{_target}");
    }  
    public override bool TaskCompleation(int points)
    {
        if (_counter >= _target)
        {
            Console.WriteLine();
            Console.WriteLine("YOU FINISHED THE MAX checkpoints!");
            return false;
        }
        else{
        Console.WriteLine("Did you complete your goal? (y/n)");
        string userInput = Console.ReadLine();
        _counter = GetCounter() + 1;
        _target = GetTarget();
        _bonusPoints = getBonus();
        if (userInput == "y" && _counter  == _target )
        {
            _verify = UpdateVerify();
            _compleation = true;
            points += _bonusPoints;
            if (_counter > _target)
            {
                return false;
            }
            
             // Update and store the userScore
            Console.WriteLine($"(X) {_goalName} ({_goalDescription}) -- currently completed {_counter}/{_target}");
             return true;
        }
        else if (userInput == "y")
        {
            if (_counter > _target)
            {
                return false;
            }
            Console.WriteLine( $"( ) {_goalName} ({_goalDescription}) -- currently completed {_counter}/{_target}");
            return true;
        }
        else
        {
            Console.WriteLine($"( ) {_goalName} ({_goalDescription}) -- currently completed {_counter}/{_target}");
            return false;
        }
    }
    }
    public int AchieveChecklistBonus()
     {
        Console.WriteLine("How many bonus points do you recieve for acheiving the set goal?");
        string Points = Console.ReadLine();
        int BonusPoints = int.Parse(Points);
        _bonusPoints = BonusPoints;
        return _bonusPoints;
    }
    public int getBonus()
    {
        return _bonusPoints;
    }
    
     public int PromptCompletionCount() 
     {
        Console.WriteLine("how many times can you complete it? ");
        string UserInput = Console.ReadLine();
        _target = int.Parse(UserInput);
        return _target;
     }
     public int GetTarget()
     {
        return _target;
     }
     }

}
