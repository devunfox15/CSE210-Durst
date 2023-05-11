using System;
// The responisbilty of entry is to hold a response
namespace Develop02
{
public class Entry
    {
        public string Prompt;
        public string Response;
        public string Date;
        // Convert the Entry to a string representation
        public string ConvertToString ()
            {
                return $"{Date}\n{Prompt}\n{Response}\n";
            }
            //for creating an Entry object with the provided date, response, and prompt
        public Entry(string date, string response, string prompt)
            {
                this.Date = date;
                this.Prompt = prompt; // for the instance of the class. when someone creates an instance they go to this one
                this.Response = response;
                
            }
       
    }
}