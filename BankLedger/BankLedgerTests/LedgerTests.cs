using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankLedger;
using System.IO;
using System;


namespace BankLedgerTests
{

    [TestClass]
    public class LedgerTests
    {

        [TestMethod]
        public void Menu_NumberInput_ValidNumberOutput()
        {
            //Arrange
            Ledger book = new Ledger();
            string input = "0{0}-5{0}100{0}4{0}3{0}"; //Each part of the string represents user input and the {0} represent newlines

            using (var sw = new StringWriter())
            {
                using (var sr = new StringReader(string.Format(input, Environment.NewLine)))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);

                    //Act
                    int result = book.Menu();

                    //Assert
                    Assert.IsTrue(result == 3);
                }
            }
        }



        [TestMethod]
        public void CreateAccount_ValidAccount_AddedToDictionary()
        {
            //Arrange
            Ledger book = new Ledger();
            string input = "username{0}password{0}cody{0}herberholz{0}2833SECOLT{0}9712223333{0}10/06/1989{0}";

            using (var sw = new StringWriter())
            {
                using (var sr = new StringReader(string.Format(input, Environment.NewLine)))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);

                    //Act
                    book.CreateAccount();

                    //Assert
                    Assert.IsTrue(book.personalData.ContainsKey("username"));
                }
            }  
        }



        [TestMethod]
        public void CreateAccount_InvalidAccount_AccountAlreadyExists()
        {
            //Arrange
            Ledger book = new Ledger();
            string firstInput = "username{0}password{0}cody{0}herberholz{0}2833SECOLT{0}9712223333{0}10/06/1989{0}";
            string secondInput = "username{0}password{0}cody{0}herberholz{0}2833SECOLT{0}9712223333{0}10/06/1989{0}";
            using (var sw = new StringWriter())
            {
                using (var sr = new StringReader(string.Format(firstInput + secondInput, Environment.NewLine)))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);

                    //Act
                    book.CreateAccount();  //added two accounts of the same data
                    book.CreateAccount();

                    //Assert
                    Assert.IsTrue(book.personalData.Count == 1);
                }
            }
        }



        [TestMethod]
        public void Login_InvalidLogin_AccountNotFound()
        {
            //Arrange
            Ledger book = new Ledger();
            string createInput = "username{0}password{0}cody{0}herberholz{0}2833SECOLT{0}9712223333{0}10/06/1989{0}";
            string loginInput = "name{0}password{0}"; //Incorrect Username

            using (var sw = new StringWriter())
            {
                using (var sr = new StringReader(string.Format(createInput + loginInput, Environment.NewLine)))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);

                    //Act
                    book.CreateAccount();
                    book.Login();
                    string result = sw.ToString();
                    //Assert
                    Assert.IsTrue( result.Contains("Account Not Found"));
                }
            }
        }



        [TestMethod]
        public void Login_InvalidLogin_IncorrectPassword()
        {
            //Arrange
            Ledger book = new Ledger();
            string createInput = "username{0}password{0}cody{0}herberholz{0}2833SECOLT{0}9712223333{0}10/06/1989{0}";
            string loginInput = "username{0}pass{0}"; //Incorrect password

            using (var sw = new StringWriter())
            {
                using (var sr = new StringReader(string.Format(createInput + loginInput, Environment.NewLine)))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);

                    //Act
                    book.CreateAccount();
                    book.Login();
                    string result = sw.ToString();
                    //Assert
                    Assert.IsTrue(result.Contains("Password Incorrect"));
                }
            }
        }
    }
}
