using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using BankLedger;



namespace BankLedgerTests
{
    [TestClass]
    public class AccountTests
    {

        [TestMethod]
        public void Menu_NumberInput_ValidNumberOutput()
        {
            //Arrange
            Account test = new Account();
            string input = "0{0}-5{0}100{0}6{0}5{0}";  //Each part of the string represents user input and the {0} represent newlines

            using (var sw = new StringWriter())
            {
                using (var sr = new StringReader(string.Format(input, Environment.NewLine)))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);

                    //Act
                    int result = test.Menu();

                    //Assert
                    Assert.IsTrue(result == 5);
                }
            }
        }



        [TestMethod]
        public void TransactionHistory_ValidInput_CountChanges()
        {
            //Arrange
            Account test = new Account();
            string input = "1{0}100{0}1{0}400{0}2{0}100{0}2{0}200{0}5{0}";

            using (var sw = new StringWriter())
            {
                using (var sr = new StringReader(string.Format(input, Environment.NewLine)))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);

                    //Act
                    test.AccountWorkflow();

                    //Assert
                    Assert.IsTrue(test.TransactionHistory.Count == 4);
                }
            }
        }



        [TestMethod]
        public void Deposit_ValidInput_BalanceChanges()
        {
            //Arrange
            Account test = new Account();
            string input = "1{0}100{0}5{0}";

            using (var sw = new StringWriter())
            {
                using (var sr = new StringReader(string.Format(input, Environment.NewLine)))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);

                    //Act
                    test.AccountWorkflow();

                    //Assert
                    Assert.IsTrue(test.Balance == 100);
                }
            }
        }



        [TestMethod]
        public void Withdraw_ValidInput_BalanceChanges()
        {
            //Arrange
            Account test = new Account();
            string input = "1{0}200{0}2{0}100{0}5{0}";

            using (var sw = new StringWriter())
            {
                using (var sr = new StringReader(string.Format(input, Environment.NewLine)))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);

                    //Act
                    test.AccountWorkflow();

                    //Assert
                    Assert.IsTrue(test.Balance == 100);
                }
            }
        }



        [TestMethod]
        public void Withdraw_InvalidOverdraft_NoBalanceChange()
        {
            //Arrange
            Account test = new Account();
            string input = "1{0}100{0}2{0}200{0}5{0}";

            using (var sw = new StringWriter())
            {
                using (var sr = new StringReader(string.Format(input, Environment.NewLine)))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);

                    //Act
                    test.AccountWorkflow();

                    //Assert
                    Assert.IsTrue(test.Balance == 100);
                }
            }
        }
    }
}
