using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercicio_146.Entities.Exceptions;

namespace exercicio_146.Entities
{
    internal class Account {
        public int Number { get; set; }
        public string Holder { get; set; }
        public double Balance { get; set; }
        public double WithdrawLimit { get; set; }

        public Account() { }

        public Account(int number, string holder, double initialBalance, double withdrawLimit) { 
            Number = number;
            Holder = holder;
            WithdrawLimit = withdrawLimit;

            Deposit(initialBalance);
        }

        public void Deposit(double amount) { 
            Balance += amount;
        }

        public void Withdraw(double amount) {
            if (amount > WithdrawLimit) {
                throw new DomainException("The amount exceeds withdraw limit");
            }
            if (amount > Balance) {
                throw new DomainException("Not enough balance");
            }

            Balance -= amount;
        }
    }
}
