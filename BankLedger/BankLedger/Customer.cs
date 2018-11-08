using System;
using System.Security.Cryptography;
using System.Text;

namespace BankLedger
{
    //XXX Need to store secure password for Customer
    
    //Customer Class holds personal information about owner of the account and 
    //is kept private to prevent sensitive information from leaking to other
    //parts of the program
    class Customer
    {
        private byte[] salt;
        private string userName;
        private string password;
        private string firstName;
        private string lastName;
        private string address;      
        private string phoneNumber;
        private string dob;
        Account checking;


        //Constructor
        public Customer()
        {
            string name = "username";
            string pass = "password";
            checking = new Account();
            GatherPersonalInfo(name, pass);
            Console.Clear();
            Display();
        }



        //Password and Username are passed into this constructor
        public Customer(string name, string tempPass)
        {
            checking = new Account();
            GatherPersonalInfo(name, tempPass);
            Console.Clear();
            EncryptPassword(password);
            Display();
        }



        //Gathers personal information from user and stores the data
        private void GatherPersonalInfo(string name, string TempPass)
        {
            Console.WriteLine("\n---Please Enter Personal Information---");
            userName = name;
            password = TempPass;
            Console.Write("Enter First Name: ");
            firstName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            lastName = Console.ReadLine();
            Console.Write("Enter Address: ");
            address = Console.ReadLine(); 
            Console.Write("Enter Phone Number: ");
            phoneNumber = Console.ReadLine(); 
            Console.Write("Enter Date Of Birth (EX: mm/dd/yyyy): ");
            dob = Console.ReadLine();
            Console.Clear();
        }

  

        //The Password-Based Key Derivation Function is used in order to securely 
        //encrypt the password so it can be stored safely
        private void EncryptPassword(string pass)
        {
            salt = new byte[32];

            RNGCryptoServiceProvider cryptoProvider = new RNGCryptoServiceProvider();
            cryptoProvider.GetBytes(salt);

            Rfc2898DeriveBytes encrypt = new Rfc2898DeriveBytes(pass, salt, 1000);
            password = Encoding.Default.GetString(encrypt.GetBytes(32)); //Converts bytes to string
        }



        //Uses same salt and encryption as associated user to be able to compare passwords
        public bool VerifyPassword(string name, string pass)
        {
            bool match = false;

            Rfc2898DeriveBytes encrypt = new Rfc2898DeriveBytes(pass, salt, 1000);
            var incomingPassword = Encoding.Default.GetString(encrypt.GetBytes(32));

            if(incomingPassword == password)
            {
                match = true;
            }

            return match;
        }



        //When verification is successful then this function lets the customer into their account
        //Can be expanded upon if multiple accounts are added
        public void AccessAccount()
        {
            //XXX add menu here when more than one account is necessary to choose from

            checking.AccountWorkflow();
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
