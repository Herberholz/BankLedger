using System;
using System.Collections.Generic;
using System.Text;

//When creating account store in a Hash table with password as key

namespace BankLedger
{
    class Ledger
    {
        Account person; //TEST

        public Ledger()
        {

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
            //Create new account and store in hash table
        }

        public int Login()
        {
            bool match = false;

            //Validate Credentials
            //If match login and show account menu
            //otherwise kick back to main screen
            match = ValidateCredentials();

            if(match)
            {
                person = new Account(); //TEST
                person.Menu();
            }
            else
                Console.WriteLine("Account Not Found");

            return 0;
        }

        public bool ValidateCredentials()
        {

            return true;
        }
    }
}
