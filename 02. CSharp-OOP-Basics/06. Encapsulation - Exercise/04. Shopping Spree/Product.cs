using System;
using System.Collections.Generic;

namespace Exercise
{
    class Product
    {
        private string name;
        private double cost;

        public Product(string name, double cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value == "")
                {
                    Console.WriteLine("Name cannot be empty");
                    Environment.Exit(1);
                }
                name = value;
            }
        }
        public double Cost
        {
            get
            {
                return cost;
            }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Money cannot be negative");
                    Environment.Exit(1);
                }
                cost = value;
            }
        }
    }
}
