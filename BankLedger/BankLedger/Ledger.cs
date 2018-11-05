using System;
using System.Collections.Generic;
using System.Text;

//When creating account store in a Hash table with password as key

namespace BankLedger
{
    class Ledger
    {
        List<Account> accounts;

        public Ledger()
        {
            accounts = new List<Account>();
        }
        
        ~Ledger()
        {

        }

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

        public void CreateAccount()
        {
            Console.WriteLine("Creating New Account");
            
            //XXX Possibly use Hash Table
            Account person = new Account();
            accounts.Add(person);
        }

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
                    //accounts[i].Menu();
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
