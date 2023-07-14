using System;
using System.Collections.Generic;

namespace final
{
    class ReservationManager
    {
        private string _bookTitle;
        private List<string> _reservedBooks = new List<string>();

        public ReservationManager(string bookTitle)
        {
            _bookTitle = bookTitle;
        }

        public bool ReserveItem()
        {
            if (_reservedBooks.Contains(_bookTitle))
            {
                Console.WriteLine("The book is already reserved.");
                return false;
            }

            _reservedBooks.Add(_bookTitle);
            return true;
        }
    }
}