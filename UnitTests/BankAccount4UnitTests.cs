using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection.Emit;
using System.Text;
using ImpromptuInterface;
using NUnit.Framework;

namespace UnitTests
{
    public interface ILog
    {
        bool Write(string msg);
    }

    public class ConsoleLog : ILog
    {
        public bool Write(string msg)
        {
            Console.WriteLine(msg);
            return true;
        }
    }
    public class NullLog : ILog
    {
        public bool Write(string msg)
        {
            return true;
        }
    }

    public class Null<T> : DynamicObject where T : class
    {
        public static T Instance => new Null<T>().ActLike<T>();

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            result = Activator.CreateInstance(typeof(T).GetMethod(binder.Name).ReturnType);
            return true;
        }
    }

    public class NullLogWithResult : ILog
    {
        private bool expectedResult;

        public NullLogWithResult(bool expectedResult)
        {
            this.expectedResult = expectedResult;
        }

        public bool Write(string msg)
        {
            return expectedResult;
        }
    }

    public class BankAccount
    {
        private readonly ILog log;
        public int Balance { get;  set; }

        public BankAccount(ILog log)
        {
            this.log = log;
        }
        public void Deposit(int amount)
        {
            //if (amount < 0)
            //    throw new ArgumentException("Deposit amounts should be positive", nameof(amount));
            log.Write($"Depositing {amount}");

            Balance += amount;
        }
        public bool Withdraw(int amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                return true;
            }
            else
                return false;
        }
    }
   
    public class BankAccount4UnitTests
    {
        private readonly ILog log;
        public int Balance { get; private set; }

        public BankAccount4UnitTests(int startingBalance)
        {
            Balance = startingBalance;
        }

        public BankAccount4UnitTests(ILog log)
        {
            this.log = log;
        }

        public void Deposit(int amount)
        {
            if (amount < 0)
                throw  new ArgumentException("Deposit amounts should be positive", nameof(amount));

            Balance += amount;
        }
        public bool Withdraw(int amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                return true;
            }
            else
                return false;
        }
    }

   
}
