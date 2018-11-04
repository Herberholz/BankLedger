using System;

namespace BankLedger
{
    class Program
    {
        //
        static void Main(string[] args)
        {
            int choice = 0;
            Ledger book = new Ledger();

            do
            {
                choice = book.Menu();

                //if login fails kick back and let try again or create new account
                switch(choice)
                {
                    case 1:
                        book.Login();
                        break;
                    case 2:
                        book.CreateAccount();
                        break;
                    case 3:
                        Console.WriteLine("Bank Ledger Closing\n");
                        break;
                    default:
                        Console.WriteLine("Command Not Recognized\n");
                        break;
                }
            } while(choice != 3);
        }
    }
}
