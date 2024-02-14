using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace final
{
    class BorrowingManager
    {
        private Library _library;
        private Files _fileHandler;
        private List<Member> _membership;
        private List<(Member member, LibraryItem item)> _checkedOutItems = new List<(Member, LibraryItem)>(); // Track checked out items
        private string _checkoutFilePath = "checkedout.txt";

        public BorrowingManager(Library library, Files fileHandler, List<Member> membership)
        {
            _library = library;
            _fileHandler = fileHandler;
            _membership = membership;
        }

        public string CheckOutItem(string title, int libraryCardNumber)
        {
            LibraryItem item = _library.FindItem(title);

            if (item == null)
            {
                return "The item is not found in the library.";
            }

            if (!item.IsAvailable())
            {
                return $"The {item.GetType().Name.ToLower()} is currently unavailable.";
            }

            bool hasExistingCheckout = _checkedOutItems.Any(c => c.member.GetLibraryCardNumber() == libraryCardNumber && c.item.GetTitle() == title);
            if (hasExistingCheckout)
            {
                return $"The {item.GetType().Name.ToLower()} is already checked out by you.";
            }

            Member member = _fileHandler.FindMemberByLibraryCardNumber(_membership, libraryCardNumber);
            if (member == null)
            {
                return "Invalid library card number.";
            }

            item.SetAvailability(false); // Set item availability to false (Checked Out)
            item.GetCheckout(); // Set checkout date

            _fileHandler.SaveLibraryItems(); // Save library items

            _checkedOutItems.Add((member, item)); // Add the checked-out item to the list

            SaveCheckedOutItems(); // Save checked-out items

            return $"You have checked out a {item.GetType().Name.ToLower()} called {title}.";
        }

        public string CheckAvailability(string title)
        {
            LibraryItem item = _library.FindItem(title);

            if (item != null)
            {
                if (item.IsAvailable())
                {
                    return "The item is available.";
                }
                else
                {
                    return "The item is currently checked out.";
                }
            }
            else
            {
                return "The item is not found in the library.";
            }
        }

        public bool CheckInItem(LibraryItem item, Files fileHandler)
        {
            (Member member, LibraryItem checkedOutItem) existingCheckout = _checkedOutItems.Find(c => c.item == item);

            if (existingCheckout != default((Member, LibraryItem)))
            {
                _checkedOutItems.Remove(existingCheckout);
                item.SetAvailability(true);
                fileHandler.SaveLibraryItems(); // Save library items
                SaveCheckedOutItems(); // Save checked-out items

                // Calculate fines using the FineCalculator
                FineCalculator fineCalculator = new FineCalculator();
                int fineAmount = item.GetFine();
                fineCalculator.CalculateFine(item.GetTitle(), item.GetCheckout(), item.GetDueDate(), fineAmount, item.GetDaysLate());

                return true;
            }
            else
            {
                return false;
            }
        }
        public void SaveCheckedOutItems()
        {
            using (StreamWriter writer = new StreamWriter(_checkoutFilePath))
            {
                foreach ((Member member, LibraryItem item) in _checkedOutItems)
                {
                    string checkoutData = $"{member.GetLibraryCardNumber()},{item.GetTitle()},{item.GetDueDate()}";
                    writer.WriteLine(checkoutData);
                }
            }
        }

        public void LoadCheckedOutItems()
{
    if (File.Exists(_checkoutFilePath))
    {
        _checkedOutItems.Clear();
        using (StreamReader reader = new StreamReader(_checkoutFilePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] checkoutData = line.Split(',');

                if (checkoutData.Length >= 3) // Ensure array has enough elements
                {
                    int libraryCard;
                    if (int.TryParse(checkoutData[0], out libraryCard))
                    {
                        string title = checkoutData[1];
                        string dueDate = checkoutData[2];

                        Member member = _fileHandler.FindMemberByLibraryCardNumber(_membership, libraryCard);
                        LibraryItem item = _library.FindItem(title);

                        if (member != null && item != null)
                        {
                            _checkedOutItems.Add((member, item));
                        }
                    }
                }
            }
        }
    }
}
    }
}