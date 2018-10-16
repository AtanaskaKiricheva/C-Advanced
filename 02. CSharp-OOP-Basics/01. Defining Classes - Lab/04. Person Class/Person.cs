using System.Collections.Generic;
using System.Linq;

namespace BankAccount
{
    internal class Person
    {
        private string name;
        private int age;
        private List<BankAccount> accounts;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
            this.accounts = new List<BankAccount>();
        }
        public Person(string name, int age, List<BankAccount> accounts)
        {
            this.name = name;
            this.age = age;
            this.accounts = accounts;
        }

        public decimal GetBalance()
        {
            return this.accounts.Select(a => a.Balance).Sum();
        }
    }
}