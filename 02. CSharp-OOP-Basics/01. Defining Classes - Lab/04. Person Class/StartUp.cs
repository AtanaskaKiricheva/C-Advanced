using System;
using System.Collections.Generic;

namespace BankAccount
{
    public class StartUp
    {
        public static void Main()
        {

            Dictionary<int, BankAccount> accounts = new Dictionary<int, BankAccount>();

            var commands = Console.ReadLine().Split();

            while (commands[0] != "End")
            {
                var id = int.Parse(commands[1]);

                switch (commands[0])
                {
                    case "Create": Create(commands, accounts, id); break;
                    case "Deposit": Deposit(commands, accounts, id); break;
                    case "Withdraw": Withdraw(commands, accounts, id); break;
                    case "Print": Print(commands, accounts, id); break;
                }
                commands = Console.ReadLine().Split();
            }
        }

        private static void Print(string[] commands, Dictionary<int, BankAccount> accounts, int id)
        {
            if (accounts.ContainsKey(id))
            {
                BankAccount acc = accounts[id];
                Console.WriteLine(acc.ToString());
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }
        }

        private static void Withdraw(string[] commands, Dictionary<int, BankAccount> accounts, int id)
        {
            if (accounts.ContainsKey(id))
            {
                BankAccount acc = accounts[id];

                if (accounts[id].Balance < decimal.Parse(commands[2]))
                {
                    Console.WriteLine("Insufficient balance");
                }
                else
                {
                    acc.Id = id;
                    accounts[id].Balance = acc.Withdraw(int.Parse(commands[2]));
                }
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }
        }

        private static void Deposit(string[] commands, Dictionary<int, BankAccount> accounts, int id)
        {
            if (accounts.ContainsKey(id))
            {
                BankAccount acc = accounts[id];
                acc.Id = id;
                accounts[id].Balance = acc.Deposit(int.Parse(commands[2]));
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }
        }

        private static void Create(string[] commands, Dictionary<int, BankAccount> accounts, int id)
        {
            BankAccount acc = new BankAccount();

            if (accounts.ContainsKey(id))
            {
                Console.WriteLine("Account already exists");
            }
            else
            {
                acc.Id = id;
                accounts.Add(id, acc);
            }
        }
    }
}