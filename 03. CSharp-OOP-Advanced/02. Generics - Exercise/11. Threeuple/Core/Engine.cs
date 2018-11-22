using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generics.Core
{
    public class Engine
    {
        Tuple<object, object, object> tuple;
        
        public void Run()
        {
            string[] line1 = Console.ReadLine().Split();

            string name = line1[0] + " " + line1[1];
            string adress = line1[2];
            string town = line1[3];

            PrintTuple(name, adress, town);

            string[] line2 = Console.ReadLine().Split();
            name = line2[0];
            int beers = int.Parse(line2[1]);
            bool isDrunk = line2[2] == "drunk" ? true : false;

            PrintTuple(name, beers, isDrunk);

            string[] line3 = Console.ReadLine().Split();
            name = line3[0];
            double accoundBalance = double.Parse(line3[1]);
            string bankName = line3[2];

            PrintTuple(name, accoundBalance, bankName);
        }

        private void PrintTuple(object item1, object item2, object item3)
        {
            tuple = new Tuple<object,object, object>(item1,item2,item3);

            Console.WriteLine($"{tuple.Item1} -> {tuple.Item2} -> {tuple.Item3}");
        }
    }
}
