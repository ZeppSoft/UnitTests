using NUnit.Framework;
using System;
using System.Net.Sockets;

namespace UnitTests
{
    [TestFixture]
    public class BankAccountTest
    {
        private BankAccount ba;

        [SetUp]
        public void Setup()
        {
            ba = new BankAccount(100);
        }
        [Test]
        public void BankAccountShouldIncreaseOnPositiveDeposit()
        {
            //AAA(arrange+act+assert) approach

            //arrange (init)
            //var ba = new BankAccount(100);

            //act
            ba.Deposit(100);

            //assert
            Assert.That(ba.Balance,Is.EqualTo(200));

            //Assert.That(2 + 2, Is.EqualTo(5));
            //Warn.If(2 + 3, Is.Not.EqualTo(6));
            //Warn.If(() => 2 + 2, Is.Not.EqualTo(5).After(2000));
        }
        [Test]
        public void TryingToWithdrawal()
        {
            ba.Withdraw(100);
             

            Assert.Multiple(() =>
            {
                Assert.That(ba.Balance, Is.EqualTo(0));
                Assert.That(ba.Balance, Is.LessThan(1));
            });
        }
        [Test]
        public void BankAccountShouldThrowOnNonPositiveAmount()
        {
           var ex = Assert.Throws<ArgumentException>(()=>
            ba.Deposit(-1)
            );

           StringAssert.StartsWith("Deposit amounts should be positive",ex.Message);
        }
    }
    [TestFixture]
    public class DataDrivenTest
    {
        private BankAccount ba;
        [SetUp]
        public void SetUp()
        {
            ba = new BankAccount(100);
        }
        [Test]
        [TestCase(50,true,50)]
        [TestCase(100,true,0)]
        [TestCase(1000,false,100)]
        public void TestMultipleWithdrawalScenarios(int amountToWithdraw, bool shouldSucceed, int expectedBalance)
        {
            var result = ba.Withdraw(amountToWithdraw);
            //Warn.If(!result,"Failed for some reason");

            Assert.Multiple(() =>
            {
                Assert.That(result,Is.EqualTo(shouldSucceed));
                Assert.That(ba.Balance,Is.EqualTo(expectedBalance));
            });
        }
    }
}
