//Bank Ledger Program
//By: Cody Herberholz

using System;



namespace BankLedger
{
    class Program
    {
        //Main creates the Ledger class and provides the ability to login
        //to an account or create a new account
        static void Main(string[] args)
        {
            int choice = 0;
            Ledger book = new Ledger();

            do
            {
                choice = book.Menu();

                //if login fails then bring back main menu
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
