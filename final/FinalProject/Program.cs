using System;
using System.Collections.Generic;
using System.IO;

namespace final
{
    class Program
    {
        static List<Member> Membership = new List<Member>();
        static List<ReservationManager> reservations = new List<ReservationManager>();
        static void Main(string[] args)
        {
            Library library = new Library();
            Files fileHandler = new Files(library);
            fileHandler.LoadMembers(Membership);
            fileHandler.LoadLibraryItems();
            BorrowingManager borrowingManager = new BorrowingManager(library, fileHandler, Membership);
            string MemberResponse = " ";

            void AccountDisplay(string person)
            {
                Console.WriteLine($"Welcome to {person}'s Account:");
                Console.WriteLine("1. Check-Out");
                Console.WriteLine("2. Check-In");
                Console.WriteLine("3. Reserve");
                Console.WriteLine("4. Status");
                Console.WriteLine("x. Exit");
            }

            void OpeningModel()
            {
                Console.WriteLine("Welcome to the library:");
                Console.WriteLine("1. Create an Account");
                Console.WriteLine("2. Log In with an account");
                Console.WriteLine("3. Type 'q' to quit");
            }

            void CreateAccount()
            {
                Console.Clear();
                Console.WriteLine("Please fill in the following information:");
            }

            OpeningModel();
            string choice = Console.ReadLine();
            while (choice != "q")
            {
                if (choice == "1")
                {
                    Console.Clear();
                    CreateAccount();
                    Member newMember = new Member();
                    string name = newMember.SetName();
                    string address = newMember.SetAddress();
                    string phoneNumber = newMember.SetPhoneNumber();
                    int libraryCard = newMember.ReceiveLibCardNum();
                    Member member = new Member(name, address, phoneNumber, libraryCard);
                    Membership.Add(member);
                    fileHandler.SaveMembers(Membership);
                    Console.WriteLine($"Your library card is: {libraryCard}");
                }
                else if (choice == "2")
                {
                    Console.Clear();
                    Console.WriteLine("What is your library card number?");
                    int account = int.Parse(Console.ReadLine());

                    Member loggedInMember = Membership.Find(member => member.GetLibraryCardNumber() == account);

                    if (loggedInMember != null)
                    {
                        Console.WriteLine("Logged in successfully!");
                        Console.WriteLine($"Name: {loggedInMember.GetName()}");
                        Console.WriteLine($"Address: {loggedInMember.GetAddress()}");
                        Console.WriteLine($"Phone Number: {loggedInMember.GetPhoneNumber()}");
                        Console.WriteLine("Did the member confirm any account info? (y/n)");
                        string confirmation = Console.ReadLine();
                        Console.Clear();
                        if (confirmation == "y")
                        {
                            Console.Clear();
                            while (MemberResponse != "x")
                            {
                                AccountDisplay(loggedInMember.GetName());
                                Console.WriteLine("Which option would you like to do?");
                                MemberResponse = Console.ReadLine();

                                if (MemberResponse == "1")
                                {
                                    Console.WriteLine("Enter the title of the item to check out:");
                                    string title = Console.ReadLine();

                                    string availabilityResult = borrowingManager.CheckAvailability(title);
                                    Console.WriteLine(availabilityResult.ToString());

                                    if (availabilityResult == "The item is available.")
                                    {
                                        Console.WriteLine("Enter your library card number:");
                                        int libraryCardNumber = int.Parse(Console.ReadLine());

                                        string checkoutResult = borrowingManager.CheckOutItem(title, libraryCardNumber);
                                        Console.WriteLine(checkoutResult);

                                        if (checkoutResult.StartsWith("You have checked out"))
                                        {
                                            LibraryItem item = library.FindItem(title);
                                            loggedInMember.AddCheckedOutItem(item);
                                        }
                                    }
                                }
                                else if (MemberResponse == "2")
                                {
                                    Console.Clear();
                                   Console.WriteLine("Enter the title of the item to check in:");
                                    string title = Console.ReadLine();
                                    FineCalculator fine = new FineCalculator();
                                    LibraryItem item = library.FindItem(title);

                                    if (item != null)
                                    {
                                        borrowingManager.LoadCheckedOutItems(); // Load checked-out items from the file

                                        bool success = borrowingManager.CheckInItem(item, fileHandler);

                                        if (success)
                                        {
                                            Console.WriteLine("Item checked in successfully.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Item is not checked out by the member.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Item not found in the library.");
                                    }
                                }
                        
                                else if (MemberResponse == "3")
                                {
                                    Console.Clear();
                                    Console.WriteLine("What item would you like to reserve?");
                                    string itemReserved = Console.ReadLine();

                                    ReservationManager reservationManager = new ReservationManager(itemReserved);
                                    bool reserveResult = reservationManager.ReserveItem();

                                    if (reserveResult)
                                    {
                                        reservations.Add(reservationManager); // Add reservation to the list
                                        Console.WriteLine("we will reach out to you in when its checked in.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("The book is already reserved.");
                                    }
                                }
                               else if (MemberResponse == "4")
                                {
                                        Console.Clear();
                                        borrowingManager.LoadCheckedOutItems(); // Load checked-out items from the file
                                        loggedInMember.DisplayCheckedOutStatus(); // Display checked-out status
                                }
                                else if (MemberResponse == "x")
                                {
                                    Console.Clear();
                                    Console.WriteLine("Exiting...");
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Invalid option. Please try again.");
                                }

                                Console.WriteLine();
                            }
                        }
                    
                    else
                    {
                        Console.WriteLine("Invalid library card number.");
                    }
                }
            
                else if (choice == "add")
                {
                    Console.Clear();
                    Console.WriteLine("What item would you like to add to the library? (book/video) ");
                    string results = Console.ReadLine();
                    if (results == "book")
                    {
                        Console.WriteLine("What is the title of the book?");
                        string BookTitle = Console.ReadLine();
                        Console.WriteLine("What is the authors name?");
                        string bookAuthor = Console.ReadLine();

                        LibraryItem item = new Book(BookTitle, bookAuthor);
                        library.AddItem(item);
                        fileHandler.SaveLibraryItems();
                        Console.WriteLine("Book Item added to the library.");
                    }
                    else if (results == "video")
                    {
                        Console.WriteLine("What is the title of the movie?");
                        string videoTitle = Console.ReadLine();
                        Console.WriteLine("What is the directors name?");
                        string videoDirector = Console.ReadLine();

                        LibraryItem item = new Video(videoTitle, videoDirector);
                        library.AddItem(item);
                        fileHandler.SaveLibraryItems();
                        Console.WriteLine("Video Item added to the library.");
                    }
                }
                else if (choice == "q")
                {
                    Console.Clear();
                    Console.WriteLine("Program has been quit.");
                }

                Console.WriteLine();
                Console.WriteLine();
                OpeningModel();
                choice = Console.ReadLine();
            }

            fileHandler.SaveMembers(Membership);
            fileHandler.SaveLibraryItems();
        }
    }
}
}