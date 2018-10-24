using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise
{
    class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings = new List<Topping>();

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            List<Topping> Toppings = new List<Topping>();
        }

        public override string ToString()
        {
            
            return $"{name} - {(toppings.Sum(x => x.totalCalories) + dough.DoughCalories()):f2} Calories.";
        }

        public string Name
        {
            get => name;
            set
            {
                if (value == "" || value == " " || value.Length > 15)
                {
                    Console.WriteLine("Pizza name should be between 1 and 15 symbols.");
                    Environment.Exit(1);
                }
                name = value;
            }
        }
        public Dough Dough { get => dough; set => dough = value; }

        internal List<Topping> Toppings
        {
            get => toppings;
            set
            {
                if (value.Count > 10)
                {
                    Console.WriteLine("Number of toppings should be in range [0..10].");
                    Environment.Exit(1);
                }
                toppings = value;
            }
        }
    }
}
