using System;
// LibraryItem Class:

// Responsibilities: Represents a generic library item, which can be a book, DVD, etc.
// Abstraction: Provides a base class for specific library item types.
// Encapsulation: Stores common properties like title, author, etc., and provides methods for accessing them.

namespace final{
abstract class LibraryItem
    {
        protected string _title;
        protected bool _available = true;
        protected string _checkOutDate;
        protected string _dueDate;
        protected int _fines;

        public LibraryItem()
        {
        }
        public LibraryItem(string title)
        {
            _title = title;
        }

        public string SetTitle(string userTitle)
        {
            _title = userTitle;
            return _title;
        }

        public string GetTitle()
        {
            return _title;
        }
        public bool IsAvailable(){
            return _available;
        }
         public bool SetAvailability(bool isAvailable){
            _available = isAvailable;
            return _available;
        }
        public virtual string GetCheckout()
        {
            _checkOutDate = DateTime.Now.ToString("M/d/yyyy");
            return _checkOutDate;
        }
        public string SetCheckout(string checkoutDate)
        {
            _checkOutDate = checkoutDate;
            return _checkOutDate;
        }

        public virtual string GetDueDate()
        {
            return _dueDate;
        }
        public string SetDueDate(string dueDate)
        {
            _dueDate = dueDate;
            return _dueDate;
        }

        public virtual string ReturnDate()
        {
            return "You cannot check out this item.";
        }
        public virtual int GetFine(){
            return _fines;
        }
        
    }
}