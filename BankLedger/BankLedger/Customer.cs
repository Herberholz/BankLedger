using System;



namespace BankLedger
{
    //XXX Need to store secure password for Customer
    
    //Customer Class holds personal information about owner of the account and 
    //is kept private to prevent sensitive information from leaking to other
    //parts of the program
    class Customer
    {
        public string UserName { get; private set; } //Property that returns username
        private string firstName;
        private string lastName;
        private string address;      
        private string phoneNumber;
        private string dob;
        Account checking;


        //Constructor
        public Customer()
        {
            checking = new Account();
            GatherPersonalInfo();
            Console.Clear();
            Display();
        }



        //Gathers personal information from user and stores the data
        private void GatherPersonalInfo()
        {
            Console.WriteLine("\n---Please Enter Personal Information---");
            Console.Write("Enter Username: ");
            UserName = Console.ReadLine();
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
            Console.WriteLine("Username: " + UserName);
            Console.WriteLine("First Name: " + firstName);
            Console.WriteLine("Last Name: " + lastName);
            Console.WriteLine("Address: " + address);
            Console.WriteLine("Phone Number: " + phoneNumber);
            Console.WriteLine("DOB: " + dob);
            Console.WriteLine("----------------------------");
        }
    }
}
