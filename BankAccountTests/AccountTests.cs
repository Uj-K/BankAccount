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
        private Account acc;

        [TestInitialize] // 테스트 될때 한번만 실행됨
        public void CreateDefaultAccount() 
        {
            acc = new Account("J. Doe");
        }

        [TestMethod()] // parameter 넘겨줄때만 () 필요하고 없어도 된다. 옵셔널
        [DataRow(100)]
        [DataRow(.01)]
        [DataRow(1.999)]
        [DataRow(9999.99)]
        public void Deposit_APositiveAmount_AddToBalance(double depositAmount)
        {
            acc.Deposit(depositAmount);

            Assert.AreEqual(depositAmount, acc.Balance);
        }

        // Each unit test will test one specific behavior 
        // Unit test has AAA pattern : Arrange, Act and Assert

        [TestMethod]
        public void Deposit_APositiveAmount_ReturnsUpdatedBalance()
        {
            //Arrange (Set up)
            double depositAmount = 100;
            double expectedReturn = 100;

            //Act (Calling the method)
            double returnValue = acc.Deposit(depositAmount);

            //Assert (Test)
            Assert.AreEqual(expectedReturn, returnValue);
        }

        [TestMethod]
        [DataRow(-1)] // 테스트할 데이터 넘기는 곳
        [DataRow(0)] // 여러개 넘길수 있어서 같은 코드 여려번 안쓰고 좋음 그리고 이게 저 파라미터 invalidDepositAmount로 넘어감
        public void Deposit_ZeroOrLess_ThrowsArgumentException(double invalidDepositAmount)
        {
            //Arrange
            //Nothing to add

            //Assert => Act
            Assert.ThrowsException<ArgumentOutOfRangeException>
                (() => acc.Deposit(invalidDepositAmount));
            // 여기 괄호는 funtion 에 이름이 없을때 쓴다.

            
        }

        // Test Driven Development - 테스트를 먼저 하는 방식으로 코드를 적는것
        // 여기서 예를 들면 Withdraw 에서 발생할수있는 모든 시나리오를 대비해 먼저 적는다
        // 그리고 테스트를 먼저 적고 go to definition 등을 통해 코드를 적는다.

        [TestMethod]
        public void Withdraw_PositiveAmount_DecreasesBalance()
        {
            //arrange
            double initialDeposit = 100;
            double withdrawalAount = 50;
            double expectedBalance = initialDeposit - withdrawalAount;

            //act
            acc.Deposit(initialDeposit);
            acc.Withdraw(withdrawalAount);

            double actualBalance = acc.Balance;

            //assert
            Assert.AreEqual (expectedBalance, actualBalance);
        }
    }


}