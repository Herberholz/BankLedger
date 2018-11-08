using System;
using System.Collections.Generic;

//If mulitple accounts are wanted for the customer than a Base Class can be created 
//with derived classes acting as different types of accounts, such as Checking and 
//Savings

namespace BankLedger
{
    //Account class gives functionality to deposit, withdraw, display balance,
    //display transaction history, and account menu
    //also holds the transaction history in a generic collection and customer 
    //data within a class
    class Account
    {
        private List<string> transactionHistory; //holds a list of strings giving a complete history of transactions
        private double balance;  //Balance of Account



        //Constructor
        public Account()
        {
            transactionHistory = new List<string>(); 
            balance = 0.0;
        }



        //Gives the menu options for the account
        private int Menu()
        {
            int MenuChoice = 0;

            //only exits menu when logout is chosen
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



        //When verification is successful then this function lets the customer choose
        //different functionality within the account. Such as Deposit, Withdrawal, 
        //Checking the balance, Checking the transaction history, and logging out
        public void AccountWorkflow()
        {
            int choice = 0;
            double amount = 0.0;

            do
            {
                Console.Clear();
                choice = Menu();

                switch(choice)
                {
                    case 1:
                        Console.Write("Deposit Amount: ");
                        amount = Convert.ToDouble(Console.ReadLine());
                        Deposit(amount);
                        break;
                    case 2:
                        Console.Write("Withdraw Amount: ");
                        amount = Convert.ToDouble(Console.ReadLine());
                        Withdraw(amount);
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
                        Console.WriteLine("Command Not Recognized\n");
                        break;
                }
            }while(choice != 5);
        }



        //Takes deposit amount from user, updates balance, and then updates 
        //transaction history
        private void Deposit(double amountToAdd)
        {
            balance += amountToAdd;
            transactionHistory.Add("Deposit " + amountToAdd);
        }



        //Takes withdrawal amount from user, updates balance, and then updates
        //transaction history
        private void Withdraw(double amountToTake)
        {
            //Can only withdraw if balance > 0
            if (balance >= amountToTake)
            {
                balance -= amountToTake;
                transactionHistory.Add("Withdraw " + amountToTake);
            }
            else
            {
                Console.WriteLine("Balance Too Low");
            }
        }



        //Displays total balance
        private void CheckBalance()
        {
            Console.Clear();
            Console.WriteLine("Balance: " + balance);

            Console.Write("\n\nPress any key to continue... ");
            Console.ReadKey();
            Console.Clear();
        }



        //Displays customers transaction history
        private void CheckTransactions()
        {
            int length = transactionHistory.Count;

            Console.WriteLine("---Transaction History---");

            for(int i = 0; i < length; ++i)
            {
                Console.WriteLine(transactionHistory[i]);
            }

            Console.WriteLine("-------------------------");

            Console.Write("\n\nPress any key to continue... ");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
