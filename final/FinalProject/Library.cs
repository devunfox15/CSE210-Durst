using System;
using System.Collections.Generic;
using System.Linq;

namespace final
{
 
    class Library
    {
        private List<LibraryItem> items;

        public Library()
        {
            items = new List<LibraryItem>();
        }

        public void AddItem(LibraryItem item)
        {
            items.Add(item);
        }

        public LibraryItem FindItem(string title)
        {
            return items.Find(item => item.GetTitle() == title);
        }

        public List<LibraryItem> GetItems()
        {
            return items;
        }

        public void ClearItems()
        {
            items.Clear();
        }
    }
}