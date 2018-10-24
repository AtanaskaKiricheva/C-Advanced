using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            string pizzaName = Console.ReadLine().Split()[1];
            string[] flourBakingAndWeight = Console.ReadLine().Split();
            Dough dough = new Dough(flourBakingAndWeight[1],flourBakingAndWeight[2], double.Parse(flourBakingAndWeight[3]));

            Pizza pizza = new Pizza(pizzaName, dough);
            string command = Console.ReadLine();

            while (command!="END")
            {
                string type = command.Split()[1];
                double weight = double.Parse(command.Split()[2]);

                pizza.Toppings.Add(new Topping(type, weight));
                if (pizza.Toppings.Count > 10)
                {
                    Console.WriteLine("Number of toppings should be in range [0..10].");
                    return;
                }

                command = Console.ReadLine();
            }
            Console.WriteLine(pizza);
        }
    }
}