using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using BankLedger;

namespace BankLedgerTests
{

    [TestClass]
    public class CustomerTests
    {

        [TestMethod]
        public void VerifyPassword_ValidInput_ReturnsTrue()
        {
            //Arrange
            Ledger book = new Ledger();
            string input = "username{0}password{0}cody{0}herberholz{0}2833SECOLT{0}9712223333{0}10/06/1989{0}"; //Each part of the string represents user input and the {0} represent newlines

            using (var sw = new StringWriter())
            {
                using (var sr = new StringReader(string.Format(input, Environment.NewLine)))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);

                    //Act
                    book.CreateAccount();
                    bool result = book.personalData["username"].VerifyPassword("username", "password");

                    //Assert
                    Assert.IsTrue(result);
                }
            }
        }



        [TestMethod]
        public void VerifyPassword_InvalidInput_ReturnsFalse()
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
                    bool result = book.personalData["username"].VerifyPassword("username", "pass");

                    //Assert
                    Assert.IsFalse(result);
                }
            }
        }
    }
}
