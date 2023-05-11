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

            public void AddEntry(Entry entry)
            {
                if (!entries.Contains(entry))
                {
                    entries.Add(entry);
                }
            }
            public List<Entry> GetAllEntries()
            {
                return this.entries;
            }
             public void DisplayEntries()
        {
            foreach (Entry entry in entries)
            {
                Console.WriteLine($"Date: {entry.Date}");
                Console.WriteLine($"Prompt: {entry.Prompt}");
                Console.WriteLine($"Entry: {entry.Response}\n");
            }
        }
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