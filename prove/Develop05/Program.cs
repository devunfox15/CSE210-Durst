using System;
using System.Collections.Generic;
using System.IO;

namespace Develop05
{
class Program
{
    static int UserPoints = 0;
    static int prizes = 0;
    static int durstBuck = 0;
    static void Main(string[] args)
    {
        // declaring a list to store values
        List<Goal> GoalList = new List<Goal>();
        // declaring a new instance of simle goals to be able to display
        SimpleGoal sGoals = new SimpleGoal();
        LoadGoal loadGoal = new LoadGoal();
        // a void menu that writes the goals down
        void Menu()
        {
            Console.WriteLine("Menu Options: ");
            Console.WriteLine("  1. Create New Goal ");
            Console.WriteLine("  2. List Goals ");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Buy A prize");
            Console.WriteLine("  7. Quit");
        }
        int UserInput()
        {
        Console.Write("Select a choice from the menu: ");
        string Option1 = Console.ReadLine();
        int Option = int.Parse(Option1);
        return Option;
        }
        LoadUserScore();
        LoadUserprizes();
        Console.WriteLine($"You have earned {UserPoints} points");
        Console.WriteLine($"You have earned {prizes} prizes");
        Console.WriteLine();
        Menu();
        int option = UserInput();
        while (option != 7)
            {
            if (option == 1)
                {   
                    Console.WriteLine("The Types of goals are:");
                    Console.WriteLine("  1. Simple Goal");
                    Console.WriteLine("  2. Eternal Goal");
                    Console.WriteLine("  3. Checklist Goals");
                    Console.WriteLine("Select a choice from the menu: ");
                    Console.Write("Which type of goal would you like to create? ");
                    string GoalChoice1 = Console.ReadLine();
                    int GoalChoice = int.Parse(GoalChoice1);
                    if (GoalChoice == 1)
                    {
                        SimpleGoal sGoal = new SimpleGoal();
                        string Name = sGoal.GoalName();
                        string Description = sGoal.GoalDescription();
                        int points = sGoal.GetUserActivityPoints();
                        GoalList.Add(sGoal);
                    }
                    else if (GoalChoice == 2)
                    {
                        EternalGoal eGoal = new EternalGoal();
                        string Name = eGoal.GoalName();
                        string Description = eGoal.GoalDescription();
                        int points = eGoal.GetUserActivityPoints();
                        GoalList.Add(eGoal);
                    }
                    else if (GoalChoice == 3)
                    {
                        ChecklistGoal cGoal1 = new ChecklistGoal();
                        string Name = cGoal1.GoalName();
                        string Description = cGoal1.GoalDescription();
                        int points = cGoal1.GetUserActivityPoints();
                        int bonus = cGoal1.AchieveChecklistBonus();
                        int counter = cGoal1.GetCounter();
                        int target = cGoal1.PromptCompletionCount();
                        GoalList.Add(cGoal1);
                    }
                }

            else if (option == 2)
            {
                int counterI = 0;
                foreach (Goal goal in GoalList)
                {
                    counterI ++;
                    string goalName = goal.GetGoalName();
                    string goalDescription = goal.GetGoalDescription();
                    string goalType = goal.GoalType();
                    string display = goal.Display();
                    Console.WriteLine($"{counterI}.) {display}");  
                }
            }

            else if (option == 3)
            {

                loadGoal.SaveGoals(GoalList);
            }
            else if (option == 4)
            {
                loadGoal.LoadGoals(GoalList);
            }
            else if (option == 5)
            {
                Console.Clear();
               RecordEvent(GoalList);
            }
            else if (option == 6)
            {
                if (UserPoints >= 100)
                {
                UserPoints -= 100;
                prizes ++;
                durstBuck++;
                SaveUserprizes();
                SaveUserScore();
                Console.WriteLine();
                Console.WriteLine("You got a virtual prize! yayyyyyy");
                Console.WriteLine("________________________");
                Console.WriteLine("|                      |");
                Console.WriteLine($"| {durstBuck}   DURST BUCK   {durstBuck}   |");
                Console.WriteLine("|                      |");
                Console.WriteLine("````````````````````````");
                }
                else {
                Console.WriteLine("sorry not enough points");           
                }           
            }
        Console.WriteLine($"You have earned {UserPoints} points");
        Console.WriteLine();
        Menu();
        option = UserInput();
    }

    void RecordEvent(List<Goal> GoalList)
    {
        Console.WriteLine("Select a goal to record an event:");
        for (int i = 0; i < GoalList.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {GoalList[i].GetGoalName()}");
        }
        Console.Write("Enter the goal number: ");
        string goalNumberInput = Console.ReadLine();
        int goalNumber = int.Parse(goalNumberInput);
        // this if statement dtermines wheter you selected a valid goal and then records the event to happen
        if (goalNumber >= 1 && goalNumber <= GoalList.Count)
        {
            Goal selectedGoal = GoalList[goalNumber - 1];
            Console.WriteLine($"Recording event for goal: {selectedGoal.GetGoalName()}");
            // here we get the points form the goal
            int points = selectedGoal.GetTotalPoints();
            int bonusPoints = selectedGoal.GetBonusPoints();
            // here we determine if the change happened
            bool completionStatus = selectedGoal.TaskCompleation(points);
            bool verify = selectedGoal.GetVerify();
                if (completionStatus == true)
                {
                    UserPoints += points;
                    if (verify == true)
                    {
                        UserPoints += bonusPoints;
                    }
                    SaveUserScore();
                }
            
        }
            else
            {
                Console.WriteLine("Invalid goal number.");
            }
    }
    
    }
    static void SaveUserScore()
{
    File.WriteAllText("userscore.txt", UserPoints.ToString());
}

static void LoadUserScore()
{
    if (File.Exists("userscore.txt"))
    {
        string score = File.ReadAllText("userscore.txt");
        UserPoints = int.Parse(score);
    }
}
static void LoadUserprizes()
{
    if (File.Exists("prizes.txt"))
    {
        string score = File.ReadAllText("prizes.txt");
        prizes = int.Parse(score);
    }
}
   static void SaveUserprizes()
{
    File.WriteAllText("prizes.txt", prizes.ToString());
}
}
}