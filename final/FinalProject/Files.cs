using System;
using System.Collections.Generic;
using System.IO;

namespace final
{
    class Files
    {
        private Library _library;

        public Files(Library library)
        {
            _library = library;
        }
    public void LoadLibraryItems()
    {
        string filePath = "library.txt";
        if (File.Exists(filePath)){
            _library.ClearItems();
            using (StreamReader reader = new StreamReader(filePath)){
            string line;
            while ((line = reader.ReadLine()) != null){
                string[] itemData = line.Split(',');
                if (itemData.Length < 3){
                    // Skip lines with insufficient data
                    continue;
                    }
                    string itemTitle = itemData[0];
                    string itemType = itemData[1];
                    bool isAvailable = itemData[2] == "Available";

                        LibraryItem item;

                if (itemType == "Book"){
                    if (itemData.Length < 4){
                    // Skip lines with insufficient book data
                        continue;
                    }
                    string bookAuthor = itemData[3];
                        item = new Book(itemTitle, bookAuthor);
                    }
                else if (itemType == "Video"){
                        if (itemData.Length < 4){
                            // Skip lines with insufficient video data
                            continue;
                        }
                        string videoDirector = itemData[3];
                        item = new Video(itemTitle, videoDirector);
                    }
                else{
                    // Handle other item types if needed
                        continue; // Skip this line and move to the next line in the file
                    }
                        item.SetAvailability(isAvailable);
                        _library.AddItem(item);
                    }
                }
            }
        }
        public void SaveLibraryItems()
        {
            string filePath = "library.txt";
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (LibraryItem item in _library.GetItems())
                {
                    string itemData;
                    if (item is Book book)
                    {
                        itemData = $"{item.GetTitle()},Book,{(item.IsAvailable() ? "Available" : "Checked Out")},{book.GetAuthor()}";
                    }
                    else if (item is Video video)
                    {
                        itemData = $"{item.GetTitle()},Video,{(item.IsAvailable() ? "Available" : "Checked Out")},{video.GetDirector()}";
                    }
                    else
                    {
                        itemData = $"{item.GetTitle()},Unknown,{(item.IsAvailable() ? "Available" : "Checked Out")}";
                    }

                    writer.WriteLine(itemData);
                }
            }
        }
    public void SaveMembers(List<Member> membership)
    {
        string filePath = "membership.txt";
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (Member member in membership)
            {
                writer.WriteLine(member.GetStringRepresentation());
            }
        }
    }
     public Member FindMemberByLibraryCardNumber(List<Member> membership, int libraryCardNumber)
    {
        foreach (Member member in membership)
        {
            if (member.GetLibraryCardNumber() == libraryCardNumber)
            {
                return member;
            }
        }
        return null;
    }
    public void LoadMembers(List<Member> membership)
    {
        string filePath = "membership.txt";
        if (File.Exists(filePath))
        {
            membership.Clear(); // Clear the existing members list before loading new members
             using (StreamReader reader = new StreamReader(filePath))
            {
            string line;
            while ((line = reader.ReadLine()) != null)
                {
                 string[] memberData = line.Split(',');
                 int libraryCard = int.Parse(memberData[0]);
                 string name = memberData[1];
                 string address = memberData[2];
                 string phoneNumber = memberData[3];

                 Member member = new Member(name, address, phoneNumber, libraryCard);
                 membership.Add(member);
                }
            }
        }
    }
  }
}