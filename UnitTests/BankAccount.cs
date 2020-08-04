using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests
{
    public class BankAccount
    {
        public int Balance { get; private set; }

        public BankAccount(int startingBalance)
        {
            Balance = startingBalance;
        }

        public void Deposit(int amount)
        {

        }
        public void Withdraw(int amount)
        {

        }
    }
}
