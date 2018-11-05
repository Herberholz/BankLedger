using System;
using System.Collections.Generic;
using System.Text;



namespace BankLedger
{
    //Account class gives functionality to deposit, withdraw, display balance,
    //display transaction history, and account menu
    //also holds the transaction history in a generic collection and customer 
    //data within a class
    class Account
    {
        Customer personalData;
        List<string> transactionHistory;
        private int balance;



        //Constructor
        public Account()
        {
            personalData = new Customer();
            transactionHistory = new List<string>(); 
            balance = 0;
        }
        


        //Destructor
        ~Account()
        {

        }



        //Gives the menu options for the account
        public int Menu()
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



        //When verification is successful then this function controls the workflow
        //when customer is within the account choosing whether to deposit, withdraw,
        //check balance, check transactions, or logout
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



        //Takes in username from user and checks with the account's customer
        //data to see if there is a match
        public bool VerifyAccount(string nameToCheck)
        {
            return personalData.VerifyCustomer(nameToCheck);
        }



        //Takes deposit amount from user, updates balance, and then updates 
        //transaction history
        public void Deposit()
        {
            int amount = 0;
            Console.Write("Deposit Amount: ");
            amount = Convert.ToInt32(Console.ReadLine());
            balance += amount;
            transactionHistory.Add("Deposit " + amount);
        }



        //Takes withdrawal amount from user, updates balance, and then updates
        //transaction history
        public void Withdraw()
        {
            int amount = 0;
            Console.Write("Withdraw Amount: ");
            amount = Convert.ToInt32(Console.ReadLine());

            //Can only withdraw a certain amount past 0
            balance -= amount;
            transactionHistory.Add("Withdraw " + amount);
        }



        //Displays total balance
        public void CheckBalance()
        {
            Console.Clear();
            Console.WriteLine("Balance: " + balance);

            Console.Write("\n\nPress any key to continue... ");
            Console.ReadKey();
            Console.Clear();
        }



        //Displays customers transaction history
        public void CheckTransactions()
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
