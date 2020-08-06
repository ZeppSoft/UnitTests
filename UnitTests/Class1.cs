using NUnit.Framework;
using System;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using Moq;

namespace UnitTests
{
    [TestFixture]
    public class BankAccountTests
    {
        private BankAccount ba;
        [Test]
        public void DepositTest()
        {
            var log = new Mock<ILog>();
            ba = new BankAccount(log.Object){Balance =  100};
            ba.Deposit(100);

            Assert.That(ba.Balance,Is.EqualTo(200));
        }

    }
    [TestFixture]
    public class FooTests
    {
        [Test]
        public void DoSomethingTest()
        {
            var mock = new Mock<IFoo>();
            mock.Setup(foo => foo.DoSomething("ping")).Returns(true);
            //mock.Setup(foo => foo.DoSomething("pong")).Returns(false);
            mock.Setup(foo => foo.DoSomething(It.IsIn("pong", "foo"))).Returns(false);

            Assert.Multiple(() =>
            {
                Assert.IsTrue(mock.Object.DoSomething("ping"));
                Assert.IsFalse(mock.Object.DoSomething("foo"));

            });
        }

    }


    //[TestFixture]
    //public class BankAccountUnitTests
    //{
    //    private BankAccount4UnitTests ba;

    //    [SetUp]
    //    public void Setup()
    //    {
    //        ba = new BankAccount4UnitTests(100);
    //    }
    //    [Test]
    //    public void BankAccountShouldIncreaseOnPositiveDeposit()
    //    {
    //        //AAA(arrange+act+assert) approach

    //        //arrange (init)
    //        //var ba = new BankAccount4UnitTests(100);

    //        //act
    //        ba.Deposit(100);

    //        //assert
    //        Assert.That(ba.Balance,Is.EqualTo(200));

    //        //Assert.That(2 + 2, Is.EqualTo(5));
    //        //Warn.If(2 + 3, Is.Not.EqualTo(6));
    //        //Warn.If(() => 2 + 2, Is.Not.EqualTo(5).After(2000));
    //    }
    //    [Test]
    //    public void TryingToWithdrawal()
    //    {
    //        ba.Withdraw(100);
             

    //        Assert.Multiple(() =>
    //        {
    //            Assert.That(ba.Balance, Is.EqualTo(0));
    //            Assert.That(ba.Balance, Is.LessThan(1));
    //        });
    //    }
    //    [Test]
    //    public void BankAccountShouldThrowOnNonPositiveAmount()
    //    {
    //       var ex = Assert.Throws<ArgumentException>(()=>
    //        ba.Deposit(-1)
    //        );

    //       StringAssert.StartsWith("Deposit amounts should be positive",ex.Message);
    //    }

       

    //    //public void DepositIntegrationTest()
    //    //{

    //    //}
    //}

    //[TestFixture]
    //public class BankAccountTests
    //{
    //    private BankAccount ba;
    //    [Test]
    //    public void DepositIntegrationTest()
    //    {
    //        ba = new BankAccount(new ConsoleLog()){Balance =  100};
    //        ba.Deposit(100);
    //        Assert.That(ba.Balance,Is.EqualTo(200));
    //    }
    //    [Test]
    //    public void DepositIntegratedTestWithFake()
    //    {
    //        var log = new NullLog();
    //        ba = new BankAccount(log){Balance =  100};
    //        ba.Deposit(100);
    //        Assert.That(ba.Balance, Is.EqualTo(200));

    //    }
    //    [Test]
    //    public void DepositIntegratedTestWithFakeNull()
    //    {
    //        var log = Null<ILog>.Instance;
    //        ba = new BankAccount(log) { Balance = 100 };
    //        ba.Deposit(100);
    //        Assert.That(ba.Balance, Is.EqualTo(200));

    //    }

    //    [Test]
    //    public void DepositIntegratedTestWithFakeNullStub()
    //    {
    //        var log = new NullLogWithResult(true);
    //        ba = new BankAccount(log) { Balance = 100 };
    //        ba.Deposit(100);
    //        Assert.That(ba.Balance, Is.EqualTo(200));
    //    }

    //    [Test]
    //    public void DepositTestWithMock()
    //    {
    //        var log = new LogMock(true);
    //        ba = new BankAccount(log){Balance =  100};
    //        ba.Deposit(100);

    //        Assert.Multiple(() =>
    //        {
    //            Assert.That(ba.Balance,Is.EqualTo(200));
    //            Assert.That(log.MethodCallCount[nameof(LogMock.Write)],Is.EqualTo(1));
    //        });

    //    }

    //}


    //[TestFixture]
    //public class DataDrivenTest
    //{
    //    private BankAccount4UnitTests ba;
    //    [SetUp]
    //    public void SetUp()
    //    {
    //        ba = new BankAccount4UnitTests(100);
    //    }
    //    [Test]
    //    [TestCase(50,true,50)]
    //    [TestCase(100,true,0)]
    //    [TestCase(1000,false,100)]
    //    public void TestMultipleWithdrawalScenarios(int amountToWithdraw, bool shouldSucceed, int expectedBalance)
    //    {
    //        var result = ba.Withdraw(amountToWithdraw);
    //        //Warn.If(!result,"Failed for some reason");

    //        Assert.Multiple(() =>
    //        {
    //            Assert.That(result,Is.EqualTo(shouldSucceed));
    //            Assert.That(ba.Balance,Is.EqualTo(expectedBalance));
    //        });
    //    }
    //}
}
