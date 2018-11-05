using System;
using System.Collections.Generic;
using System.Text;

//When creating account store in a Hash table with password as key

//Dictionary<TKey, TValue> is a generic type which provides type safety

namespace BankLedger
{
    //The purpose of the Ledger class is to provide the initial functionality
    //of account creation and login of supplied account. 
    class Ledger
    {
        List<Account> accounts; //Switch to dictionary



        //Constructor
        public Ledger()
        {
            accounts = new List<Account>();
        }
        


        //Destructor
        ~Ledger()
        {

        }



        //Provides the initial main menu to login, create account, or exit
        public int Menu()
        {
            int MenuChoice = 0;

            do
            {
                Console.WriteLine("\n---Bank Ledger---");
                Console.WriteLine("1) Login");
                Console.WriteLine("2) Create Account");
                Console.WriteLine("3) Exit");
                Console.WriteLine("-----------------\n");

                Console.Write("Please Select a Number: ");
                MenuChoice = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
            } while(MenuChoice > 3 || MenuChoice <= 0);

            return MenuChoice;
        }



        //Creates a new account and then adds it to the collection of created 
        //accounts stored locally
        public void CreateAccount()
        {
            Console.WriteLine("Creating New Account");
            
            Account person = new Account();
            accounts.Add(person);
        }



        //Takes user data and compares with each account to find a match in order
        //to login. If no match is found then it returns to main menu
        public int Login()
        {
            bool match = false;
            string name;

            Console.Write("Please Enter Username: ");
            name = Console.ReadLine();

            //Validate Credentials
            //If match login and show account menu
            //otherwise kick back to main screen
            for(int i = 0; i < accounts.Count && !match; ++i)
            {
                
                match = accounts[i].VerifyAccount(name);

                if(match)
                {
                    accounts[i].AccessAccount();
                }
            }
            
            if(!match)
            {
                Console.WriteLine("Account Not Found");
            }

            return 0;
        }
    }
}
