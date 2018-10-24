using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            string[] peopleData = Console.ReadLine().Split(new char[] { '=', ';' },StringSplitOptions.RemoveEmptyEntries);
            string[] productsData = Console.ReadLine().Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < peopleData.Length; i+=2)
            {
                string person = peopleData[i];
                double money = double.Parse(peopleData[i + 1]);

                people.Add(new Person(person, money));
            }

            for (int i = 0; i < productsData.Length; i+=2)
            {
                string product = productsData[i];
                double cost = double.Parse(productsData[i + 1]);

                products.Add(new Product(product, cost));
            }

            string command = Console.ReadLine();

            while (command!="END")
            {
                string person = command.Split()[0];
                string product = command.Split()[1];

                Person man = people.Where(x => x.Name == person).FirstOrDefault();
                Product prod = products.Where(x => x.Name == product).FirstOrDefault();

                if (man.Money < prod.Cost)
                {
                    Console.WriteLine(person+" can't afford "+product);
                }
                else
                {
                    Console.WriteLine(person+" bought "+product);
                    man.ProductsBag.Add(product);
                    man.Money -= prod.Cost;
                }

                command = Console.ReadLine();
            }

            people.ForEach(x => Console.WriteLine(x));
        }
    }
}