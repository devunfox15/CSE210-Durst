using System;
using System.Collections.Generic;

namespace final
{
    class Member
    {
        private string _name;
        private string _address;
        private string _phoneNumber;
        private int _libraryCardNumber;
        private List<LibraryItem> _checkedOutItems = new List<LibraryItem>(); // Track checked out items
        private List<(LibraryItem item, DateTime dueDate)> _checkedOutStatus = new List<(LibraryItem, DateTime)>();

        public void AddCheckedOutItem(LibraryItem item)
        {
            _checkedOutItems.Add(item);
        }

        public Member()
        {
        }

        public Member(string name, string address, string phoneNumber, int libraryCardNumber)
        {
            _name = name;
            _address = address;
            _phoneNumber = phoneNumber;
            _libraryCardNumber = libraryCardNumber;
        }

        public string SetName()
        {
            Console.Write("Name: ");
            _name = Console.ReadLine();
            return _name;
        }

        public string GetName()
        {
            return _name;
        }

        public string SetAddress()
        {
            Console.Write("Address: ");
            _address = Console.ReadLine();
            return _address;
        }

        public string GetAddress()
        {
            return _address;
        }

        public string SetPhoneNumber()
        {
            Console.Write("Phone Number: ");
            _phoneNumber = Console.ReadLine();
            return _phoneNumber;
        }

        public string GetPhoneNumber()
        {
            return _phoneNumber;
        }

        public int ReceiveLibCardNum()
        {
            Random random = new Random();
            _libraryCardNumber = random.Next(1000, 9999);
            return _libraryCardNumber;
        }

        public int GetLibraryCardNumber()
        {
            return _libraryCardNumber;
        }
         public void DisplayCheckedOutStatus()
        {
            Console.WriteLine("Checked Out Items:");
            foreach (LibraryItem item in _checkedOutItems)
            {
                Console.WriteLine($"Title: {item.GetTitle()}");
                Console.WriteLine($"Due Date: {item.GetDueDate()}");
                Console.WriteLine();
            }
        }
        
        public string GetStringRepresentation()
        {
            return $"{_libraryCardNumber},{_name},{_address},{_phoneNumber}";
        }
    }
}