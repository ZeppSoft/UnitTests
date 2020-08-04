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

    } 
}
