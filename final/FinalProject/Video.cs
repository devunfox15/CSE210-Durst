using System;
// Book Class:
namespace final{
// Responsibilities: Represents a book in the library, stores its details (title, author, ISBN, etc.).
// Abstraction: Encapsulates book-related information and provides methods to access and modify the book's details.
// Encapsulation: Private fields store book details, and public methods allow accessing and modifying them.
 class Video : LibraryItem
    {
        private string _director;

        public Video(string title, string videoDirector) : base(title)
        {
            _director = videoDirector;
        }

        public string SetDirector(string userDirector)
        {
            _director = userDirector;
            return _director;
        }

        public string GetDirector()
        {
            return _director;
        }

        public override string GetCheckout()
        {
            _checkOutDate = DateTime.Now.ToString("M/d/yyyy");
            _dueDate = DateTime.Now.AddDays(7).ToString("M/d/yyyy");
            return _checkOutDate;
        }

        public override string GetDueDate()
        {
            return _dueDate;
        }

        public override string ReturnDate()
        {
            return $"Your video is due on {_dueDate}.";
        }
         public override int GetFine(){
            return 3;
        }
    }
}