using System;
using System.Collections.Generic;

// The responisbilty of entry is to hold a response
namespace Develop02
{
    public class Journal 
    {
            public List<Entry> entries;
             public Journal()
        {
            entries = new List<Entry>();
        }

        // Add an entry to the list of entries if it's not already in the list
        public void AddEntry(Entry entry)
        {
            if (!entries.Contains(entry))
            {
                entries.Add(entry);
            }
        }

        // Return all entries in the list
        public List<Entry> GetAllEntries()
        {
            return this.entries;
        }

        // Display all entries in the list
        public void DisplayEntries()
        {
            foreach (Entry entry in entries)
            {
                Console.WriteLine($"Date: {entry.Date}");
                Console.WriteLine($"Prompt: {entry.Prompt}");
                Console.WriteLine($"Entry: {entry.Response}\n");
            }
        }

        // Save entries to a file
        public void SaveToFile(string fileName)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileName))
            {
                foreach (Entry entry in entries)
                {
                    file.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
                }
            }
        }

        // Load entries from a file
        public void LoadFromFile(string fileName)
        {
            entries.Clear();
            using (System.IO.StreamReader file = new System.IO.StreamReader(fileName))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    entries.Add(new Entry(parts[0], parts[1], parts[2]));
                }
            }
        }
    }
}
