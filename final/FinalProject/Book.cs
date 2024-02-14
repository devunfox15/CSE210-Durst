using System;

namespace final
{
        class Book : LibraryItem
    {
        private string _author;
        private string _iSBN;

        public Book(string title, string author) : base(title)
        {
            _author = author;
        }

        public string SetAuthor(string userAuthor)
        {
            _author = userAuthor;
            return _author;
        }

        public string GetAuthor()
        {
            return _author;
        }
        public string GetISBN(){
            return _iSBN;
        }
        public string SetISBN(string userISBN){
            _iSBN = userISBN;
            return _iSBN;
        }
        public override string GetCheckout()
        {
            _checkOutDate = DateTime.Now.ToString("M/d/yyyy");
            _dueDate = DateTime.Now.AddDays(21).ToString("M/d/yyyy");
            return _checkOutDate;
        }

        public override string GetDueDate()
        {
            return _dueDate;
        }

        public override string ReturnDate()
        {
            return $"Your book is due on {_dueDate}.";
        }
        public override int GetFine(){
            _fines = 5;
            return _fines;
        }
    }
}