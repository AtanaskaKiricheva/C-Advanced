using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise
{
    public class Person
    {
        private string name;
        private double money;
        private List<string> productsBag;

        public Person(string name, double money)
        {
            this.Name = name;
            this.Money = money;
            ProductsBag = new List<string>();
        }

        public override string ToString()
        {
            if (productsBag.Count > 0)
                return $"{name} - {string.Join(", ", productsBag)}";
            else
                return $"{name} - Nothing bought";
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value == "" || value == " ")
                {
                    Console.WriteLine("Name cannot be empty");
                    Environment.Exit(1);
                }
                name = value;
            }
        }
        public double Money
        {
            get
            {
                return money;
            }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Money cannot be negative");
                    Environment.Exit(1);
                }
                money = value;
            }
        }
        internal List<string> ProductsBag { get => productsBag; set => productsBag = value; }
    }
}
