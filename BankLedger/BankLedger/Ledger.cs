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
        Dictionary<string, Customer> personalData;

        //Constructor
        public Ledger()
        {
            personalData = new Dictionary<string, Customer>();
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
            string key;
            Console.WriteLine("Creating New Account");

            Customer person = new Customer();
            key = person.UserName;
            personalData.Add(key, person);
        }



        //Takes user data and compares with each account to find a match in order
        //to login. If no match is found then it returns to main menu
        public int Login()
        {
            string name;

            Console.Write("Please Enter Username: ");
            name = Console.ReadLine();

            //Validate Credentials
            if(personalData.ContainsKey(name))
            {
                personalData[name].AccessAccount();
            }
            else
            {
                Console.WriteLine("Account Not Found");
            }

            return 0;
        }
    }
}
