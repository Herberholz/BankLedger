using System;
using System.Collections.Generic;
using System.Text;

//each person should have private class instance to keep password secret

//each account should have their own transaction history, 
//   each account has own data structure

namespace BankLedger
{
    class Account
    {
        //private string name;
        //private int balance;

        //Need to record transaction history

        public Account()
        {
            //name = null;
            //balance = 0;
        }
        
        ~Account()
        {

        }

        public int Menu()
        {
            int MenuChoice = 0;

            do
            {
                Console.WriteLine("\n---Account----------------");
                Console.WriteLine("1) Deposit");
                Console.WriteLine("2) Withdraw");
                Console.WriteLine("3) Check Balance");
                Console.WriteLine("4) Check Transaction History");
                Console.WriteLine("5) Logout");
                Console.WriteLine("----------------------------\n");

                Console.Write("Please Select a Number: ");
                MenuChoice = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
            } while(MenuChoice > 5 || MenuChoice <= 0);
            
            return MenuChoice;
        }

        public void Deposit()
        {

        }

        public void Withdraw()
        {

        }

        public void CheckBalance()
        {

        }

        public void CheckTransactions()
        {

        }
    }
}
