using System;
using System.Collections.Generic;
using System.Text;



namespace BankLedger
{
    //XXX Need to store secure password for Customer
    
    //Customer Class holds personal information about owner of the account and 
    //is kept private to prevent sensitive information from leaking to other
    //parts of the program
    class Customer
    {
        private string userName;
        private string firstName;
        private string lastName;
        private string address;
        //private string streetName;
        //private string cityName;
        //private string stateName;
        //private int    zipcode;
        private string phoneNumber;
        private string dob;



        //Constructor
        public Customer()
        {
            GatherPersonalInfo();
            Console.Clear();
            Display();
        }



        //Destructor
        ~Customer()
        {

        }



        //Gathers personal information from user and stores the data
        private void GatherPersonalInfo()
        {
            Console.WriteLine("\n---Please Enter Personal Information---");
            Console.Write("Enter Username: ");
            userName = Console.ReadLine();
            Console.Write("Enter First Name: ");
            firstName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            lastName = Console.ReadLine();
            Console.Write("Enter Address: ");
            address = Console.ReadLine(); 
            Console.Write("Enter Phone Number: ");
            phoneNumber = Console.ReadLine(); 
            Console.Write("Enter Date Of Birth (EX: m/d/y): ");
            dob = Console.ReadLine();
            Console.Clear();
        }



        //Takes username from user and then compares with current username to 
        //see if account is a match 
        public bool VerifyCustomer(string nameToCheck)
        {
            bool match = false;

            if(string.Compare(userName, nameToCheck, false) == 0)
            {
                match = true;
            }
        
            return match;
        }



        //Displays all Customer data
        private void Display()
        {
            Console.WriteLine("\n---Personal Information---");
            Console.WriteLine("Username: " + userName);
            Console.WriteLine("First Name: " + firstName);
            Console.WriteLine("Last Name: " + lastName);
            Console.WriteLine("Address: " + address);
            Console.WriteLine("Phone Number: " + phoneNumber);
            Console.WriteLine("DOB: " + dob);
            Console.WriteLine("----------------------------");
        }
    }
}
