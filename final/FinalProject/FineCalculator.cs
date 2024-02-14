using System;

namespace final
{
    class FineCalculator
    {
        public void CalculateFine(string title, string checkoutDate, string dueDate, int fineAmount, int daysLate)
        {
            Console.WriteLine($"Did they check the {title} in late?('yes/no')");
            Console.WriteLine($"Check out date: {checkoutDate}");
            Console.WriteLine($"Due date: {dueDate}");
            Console.WriteLine($"Number of days late: {daysLate}");
            Console.WriteLine($"Today is the: {DateTime.Now}");
            string lateReturn = Console.ReadLine();

            if (lateReturn == "yes")
            {
                Console.Clear();
                ReceiveFine(title, fineAmount);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Not subject to a fine.");
            }
        }

        private void ReceiveFine(string title, int fineAmount)
        {
            Console.WriteLine($"You received a fine for {title}. Please pay the fine of ${fineAmount} to continue.");
            string paidFine = " ";

            while (paidFine != "yes")
            {
                Console.WriteLine("Did they pay the fine? (yes/no)");
                paidFine = Console.ReadLine();
            }
        }
    }
}