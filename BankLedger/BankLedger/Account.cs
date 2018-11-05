using System;
using System.Collections.Generic;
using System.Text;

//each person should have private class instance to keep password secret

//each account should have their own transaction history, 
//   each account has own data structure

//transaction history example
//Deposit 30
//withdraw 20
//withdraw 10

namespace BankLedger
{

    class Account
    {
        Customer personalData;
        List<string> transactionHistory;
        private int balance;

        public Account()
        {
            personalData = new Customer();
            transactionHistory = new List<string>(); 
            balance = 0;
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

        public void AccessAccount()
        {
            int choice = 0;

            do
            {
                choice = Menu();

                switch(choice)
                {
                    case 1:
                        Deposit();
                        break;
                    case 2:
                        Withdraw();
                        break;
                    case 3:
                        CheckBalance();
                        break;
                    case 4:
                        CheckTransactions();
                        break;
                    case 5:
                        Console.WriteLine("Logging Out");
                        break;
                    default:
                        break;
                }
            }while(choice != 5);
        }

        public bool VerifyAccount(string nameToCheck)
        {
            return personalData.VerifyCustomer(nameToCheck);
        }

        public void Deposit()
        {
            int amount = 0;
            Console.Write("Deposit Amount: ");
            amount = Convert.ToInt32(Console.ReadLine());
            balance += amount;
            transactionHistory.Add("Deposit " + amount);
        }

        public void Withdraw()
        {
            int amount = 0;
            Console.Write("Withdraw Amount: ");
            amount = Convert.ToInt32(Console.ReadLine());

            //Can only withdraw a certain amount past 0
            balance -= amount;
            transactionHistory.Add("Withdraw " + amount);
        }

        public void CheckBalance()
        {
            Console.Clear();
            Console.WriteLine("Balance: " + balance);
        }

        public void CheckTransactions()
        {
            int length = transactionHistory.Count;

            Console.WriteLine("---Transaction History---");

            for(int i = 0; i < length; ++i)
            {
                Console.WriteLine(transactionHistory[i]);
            }

            Console.WriteLine("-------------------------");
        }
    }
}
