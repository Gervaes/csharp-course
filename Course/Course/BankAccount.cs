using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Course {
    internal class BankAccount {

        public int AccountNumber { get; private set; }
        public string Name { get; set; }
        public double Balance { get; private set; }

        public BankAccount(int accNumber, string name) { 
            AccountNumber = accNumber;
            Name = name;
        }

        public BankAccount(int accNumber, string name, double initialDeposit) : this(accNumber, name) {
            Deposit(initialDeposit);
        }

        override public string ToString() {
            return $"Conta {AccountNumber}, Titular: {Name}, Saldo: ${Balance.ToString("F2",CultureInfo.InvariantCulture)}";
        }

        public void Deposit(double amount) {
            Balance += amount;
        }

        public void Withdraw(double amount) {
            if(Balance > amount)
                Balance -= amount;
            else
                Balance = 0;

            Balance -= 5.00;
        }
    }
}

/*
 
 BankAccount acc1;

            Console.Write("Entre o número da conta: ");
            int accNumber = int.Parse(Console.ReadLine());
            Console.Write("Entre o titular da conta: ");
            string name = Console.ReadLine();
            Console.Write("Haverá depósito inicial (s/n)? ");
            char option = char.Parse(Console.ReadLine());

            if(option == 's') {
                Console.Write("Entre o valor do depósito inicial: ");
                double initialDeposit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                acc1 = new BankAccount(accNumber, name, initialDeposit);
            } else
                acc1 = new BankAccount(accNumber, name);

            Console.WriteLine("");
            Console.WriteLine("Dados da conta: ");
            Console.WriteLine(acc1);

            Console.WriteLine("");
            Console.Write("Entre um valor para depósito: ");
            double amount = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            acc1.Deposit(amount);

            Console.WriteLine("Dados da conta atualizados:");
            Console.WriteLine(acc1);

            Console.WriteLine("");
            Console.Write("Entre um valor para saque: ");
            amount = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            acc1.Withdraw(amount);

            Console.WriteLine("Dados da conta atualizados:");
            Console.WriteLine(acc1);*/