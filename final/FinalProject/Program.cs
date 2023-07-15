using System;
using System.Collections.Generic;
using System.IO;

namespace final
{
    class Program
    {
        // these static list can be acessed by all the programs
        static List<Member> Membership = new List<Member>();
        static List<ReservationManager> reservations = new List<ReservationManager>();
        static void Main(string[] args)
        {
            // calls a new instance of library
            Library library = new Library();
            // calls a new instance of files and share library to files
            Files fileHandler = new Files(library);
            // loads the file for membership and library items
            fileHandler.LoadMembers(Membership);
            fileHandler.LoadLibraryItems();
            //calls the library borrowing manager and returns 3 values to it 
            BorrowingManager borrowingManager = new BorrowingManager(library, fileHandler, Membership);
            string MemberResponse = " ";
            // this displays the users account when they gain acesses
            void AccountDisplay(string person)
            {
                Console.WriteLine($"Welcome to {person}'s Account:");
                Console.WriteLine("1. Check-Out");
                Console.WriteLine("2. Check-In");
                Console.WriteLine("3. Reserve");
                Console.WriteLine("4. Status");
                Console.WriteLine("x. Exit");
            }
            // this is the general message added
            void OpeningModel()
            {
                Console.WriteLine("Welcome to the library: ");
                Console.WriteLine("('add') new item to library ");
                Console.WriteLine("1. Create an Account ");
                Console.WriteLine("2. Log In with an account ");
                Console.WriteLine("3. Type 'q' to quit ");
            }
            // this is a create your account  display
            void CreateAccount()
            {
                Console.Clear();
                Console.WriteLine("Please fill in the following information:");
            }

            OpeningModel();
            string choice = Console.ReadLine();// choice decides the user input
//---------------------------------{ Whie loop for choice starts here }-------------------------------------------------------------------
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
//----------------------------------------------------------------------------------------------------
                else if (choice == "add")
                {
                    Console.Clear();
                    Console.WriteLine("What item would you like to add to the library? (book/video) ");
                    string itemType = Console.ReadLine();

                    if (itemType == "book")
                    {
                        Console.WriteLine("What is the title of the book?");
                        string bookTitle = Console.ReadLine();
                        Console.WriteLine("What is the author's name?");
                        string bookAuthor = Console.ReadLine();

                        LibraryItem book = new Book(bookTitle, bookAuthor);
                        library.AddItem(book);
                        Console.WriteLine("Book added to the library.");
                    }
                    else if (itemType == "video")
                    {
                        Console.WriteLine("What is the title of the video?");
                        string videoTitle = Console.ReadLine();
                        Console.WriteLine("What is the director's name?");
                        string videoDirector = Console.ReadLine();

                        LibraryItem video = new Video(videoTitle, videoDirector);
                        library.AddItem(video);
                        Console.WriteLine("Video added to the library.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid item type. Please try again.");
                    }

                    fileHandler.SaveLibraryItems(); // Save the updated library items to the file
                }
//-----------------------------------------------------------------------------------------------------------------------------------
                else if (choice == "q")
                {
                Console.Clear();
                Console.WriteLine("Program has been quit.");
                }
//---------------------------------------------------------------------------------------------------------------------------------
        else if (choice == "2")
        {
            Console.Clear();
            Console.WriteLine("What is your library card number?");
            int account = int.Parse(Console.ReadLine());
            //assigns a value to the loggedInMember variable using the Find method of the Membership list. 
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
//-----------------------------------{ This is the start of the member response while loop}-------------------------------------------------------
                        while (MemberResponse != "x")
                        {
                            AccountDisplay(loggedInMember.GetName());
                            Console.WriteLine("Which option would you like to do?");
                            MemberResponse = Console.ReadLine();
                                if (MemberResponse == "1")
                                {
                                    Console.Clear();
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
                                    Thread.Sleep(3000);
                                    Console.Clear();
                                    
                                }
                                else
                                {
                                Console.WriteLine("Invalid option");
                                }

                        }
                        //-----------------------------------{ This is the start of the member response while loop}-------------------------------------------------------
                        } // end if statement
                    else{
                        Console.WriteLine("Invalid library card number.");
                        }
            }// end of if logged in
        }// end of else if
//-----------------------------------------------------------------------------------------------------------------------------------
        else
        {
        Console.Clear();
        Console.WriteLine("Invalid option. Please try again.");
        }
//-----------------------------------------------------------------------------------------------------------------------------------
      
        Console.WriteLine();
        OpeningModel();
        MemberResponse = ""; // resets member reponse to do it again
        choice = Console.ReadLine();
        }
        //---------------------------------{ Whie loop for choice ends here }-------------------------------------------------------------------    

            fileHandler.SaveMembers(Membership);
            fileHandler.SaveLibraryItems();
        }
    }
}
