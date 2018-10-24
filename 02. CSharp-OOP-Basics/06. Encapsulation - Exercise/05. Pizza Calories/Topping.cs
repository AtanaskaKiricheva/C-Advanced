using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise
{
    class Topping
    {
        private string type;
        private double weight;
        public double totalCalories = 0;

        public Topping(string type, double weight)
        {
            Type = type;
            Weight = weight;

            int basee = 2;
            double typeModifier = 0;

            switch (type.ToLower())
            {
                case "meat": typeModifier = 1.2; break;
                case "veggies": typeModifier = 0.8; break;
                case "cheese": typeModifier = 1.1; break;
                case "sauce": typeModifier = 0.9; break;
            }
            totalCalories = (basee * weight) * typeModifier;
        }


        public string Type
        {
            get => type;
            set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    Console.WriteLine($"Cannot place {value} on top of your pizza.");
                    Environment.Exit(1);
                }
                type = value;
            }
        }
        public double Weight
        {
            get => weight;
            set
            {
                if (value < 1 || value > 50)
                {
                    Console.WriteLine($"{this.type} weight should be in the range [1..50].");
                    Environment.Exit(1);
                }
                weight = value;
            }
        }
    }
}
