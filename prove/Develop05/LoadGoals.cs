using System;
using System.Collections.Generic;
using System.IO;

namespace Develop05
{
    class LoadGoal
    {
        public void LoadGoals(List<Goal> GoalList)
        {
            string filePath = "text.txt";
            if (File.Exists(filePath))
            {
                GoalList.Clear(); // Clear the existing goals list before loading new goals

                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] goalData = line.Split(',');
                        string goalType = goalData[0];
                        string goalName = goalData[1];
                        string goalDescription = goalData[2];
                        int totalPoints = int.Parse(goalData[3]);

                        if (goalType == "Simple")
                        {
                            SimpleGoal simpleGoal = new SimpleGoal(goalName, goalDescription, totalPoints);
                            GoalList.Add(simpleGoal);
                        }
                        else if (goalType == "Eternal")
                        {
                            EternalGoal eternalGoal = new EternalGoal(goalName, goalDescription, totalPoints);
                            GoalList.Add(eternalGoal);
                        }
                        else if (goalType == "Checklist")
                        {
                           if (goalData.Length >= 7)
                            {
                                int bonusPoints = int.Parse(goalData[4]);
                                int counter = int.Parse(goalData[5]);
                                int target = int.Parse(goalData[6]);

                                ChecklistGoal checklistGoal = new ChecklistGoal(goalName, goalDescription, totalPoints, bonusPoints, counter, target);
                                GoalList.Add(checklistGoal);
                            }
                            else
                            {
                                // Handle the case when goalData doesn't have enough elements for ChecklistGoal
                                // You could display an error message or take appropriate action based on your requirements.
                            }
                        }
                    }
                }

                Console.WriteLine("Goals loaded successfully.");
            }
            else
            {
                Console.WriteLine("No goals file found.");
            }
        }
        public void SaveGoals(List<Goal> GoalList)
        {
            string filePath = "text.txt";
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (Goal goal in GoalList)
                {
                    writer.WriteLine(goal.GetStringRepresentation());
                }
            }
        }
    }
}