using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Programm
{
    class BankAccount
    {
        public static int accountNumberSeed = 1234567890;
        //Propertie
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance 
        { 
            get 
            {
                decimal balance = 0;
                foreach(var item in allTransaction) 
                {
                    balance += item.Amount;
                }
                return balance;

            } 
        }
        //Constructor
        public BankAccount(string name, decimal initialBalance)
        {
           // this.Balance = initialBalance;
            this.Number = accountNumberSeed.ToString();
                accountNumberSeed++;

            this.Owner = name;
            MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
        }
        //add a list<T> of transaction object to the BankAccount
        private List<Transaction> allTransaction = new List<Transaction>();
        //Method

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            if (Balance - amount < 0)
            {
                //throw new InvalidOperationException("Not sufficient fund for this withdrawals");
                try
                {
                    var invalidAccount = new BankAccount("invalid", -55);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine("Exception caught creating account with negative balance");
                    Console.WriteLine(e.ToString());
                }
            }
            var withdrawal = new Transaction(-amount, date, note);
            allTransaction.Add(withdrawal);
        }
        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            
        }
        public string GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();

            decimal balance = 0;
            report.AppendLine("Date\t\tAmount\tBalance\tNote");
            foreach (var item in allTransaction)
            {
                balance += item.Amount;
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
            }

            return report.ToString();
        }
    }
}
