using System;

namespace BankAccount
{
    public class StartUp
    {
        public static void Main()
        {
            BankAccount acc = new BankAccount();

            acc.Id = 1;
            acc.Balance = 15;

            Console.WriteLine($"{acc.Id} {acc.Balance}");
        }
    }
}