﻿using System;
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
            if (amount < 0)
                throw  new ArgumentException("Deposit amounts should be positive", nameof(amount));

            Balance += amount;
        }
        public void Withdraw(int amount)
        {
            if (Balance > 0)
                Balance -= amount;
            else
            {
                throw new Exception("Not enough funds!");
            }
        }
    }
}
