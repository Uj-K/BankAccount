using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Tests
{
    [TestClass()]
    public class AccountTests
    {
        [TestMethod()] // parameter 넘겨줄때만 () 필요하고 없어도 된다. 옵셔널
        public void Deposit_APositiveAmount_AddToBalance()
        {
            Account acc = new("J. Doe");
            acc.Deposit(100);

            Assert.AreEqual(100, acc.Balance);
        }

        // Each unit test will test one specific behavior 
        // Unit test has AAA pattern : Arrange, Act and Assert

        [TestMethod]
        public void Deposit_APositiveAmount_ReturnsUpdatedBalance()
        {
            //Arrange (Set up)
            Account acc = new("J. Doe");
            double depositAmount = 100;
            double expectedReturn = 100;

            //Act (Calling the method)
            double returnValue = acc.Deposit(depositAmount);

            //Assert (Test)
            Assert.AreEqual(expectedReturn, returnValue);
        }
    }
}