using System;

namespace Develop04
{
    // this class is designed to be a parent funtion that hold 
    // the common functionality of the other activities 
    class Activities
    {
    // the type of activity that is called: Breathing, Reflection, Listing
        private string _activityType;
        // this stores the users time designated for activites
        protected int _activityTime;
        // this hold the description of the activity
        private string _activityDescription;
        
        // this will store the values of the private attributes
        // and convert them into usable variables.
        public Activities (String activity, string description)
        {
            _activityType = activity;
            _activityDescription = description;
        }
        int lengthOfTime()
                {
                    Console.WriteLine("How long, in seconds, would you like for your session?");
                    string timeInput1 = Console.ReadLine();
                    int timeInput = int.Parse(timeInput1);
                    return timeInput;
                }
        // this is a getter for the activity type
        public string GetActivityName()
        {   
            return _activityType;
        }
        // this is a getter for the activity description
        public String GetActivityDescription()
        {
            return _activityDescription;
        }
        // this is a getter for the activity duration and how long it takes
        public int GetDuration()
        {
            _activityTime = lengthOfTime();
            return _activityTime;
        }
        // This construct takes the private attributes of the type and 
        // description of the activity and makes a starting message
        public String OpeningMessage(string activity, string description)
        {
            _activityType = activity;
            _activityDescription = description;
            return $"Welcome to the {_activityType} activity.\n\nThis will help you {_activityDescription}";
        }
        // This construct takes the private attributes of the type and description
        //  of the activity and makes a end message.
        public string EndingMessage()
        {
            return $"Well Done!! \n \nYou have completed another {_activityTime} seconds of the ";
        }
    }
}
