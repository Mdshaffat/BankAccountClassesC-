using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programm
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount("shaffat", 1000);
            //BankAccount account2 = new BankAccount("parves", 100);
            //Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");
            //Console.WriteLine($"Account {account2.Number} was created for {account2.Owner} with {account2.Balance} initial balance.");


            //account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
            //Console.WriteLine(account.Balance);
            //account.MakeDeposit(100, DateTime.Now, "riend paid me back");
            //Console.WriteLine(account.Balance);
            try
            {
                var invalidAccount = new BankAccount("invalid", -55);
            }
            catch(ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Exception caught creating accont with negative balance");
                Console.WriteLine(e.ToString());
                
            }
            try
            {
                account.MakeWithdrawal(750, DateTime.Now, "Attempt to overdraw");
            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine("Exception caught trying to overdraw");
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine(account.GetAccountHistory());


            Console.Read();
        }
    }
}
