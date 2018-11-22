using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generics.Core
{
    public class Engine
    {
        Tuple<object, object> tuple;
        
        public void Run()
        {
            string[] line1 = Console.ReadLine().Split();

            string fullName = line1[0] + " " + line1[1];
            string adress = line1[2];

            PrintTuple(fullName, adress);

            string[] line2 = Console.ReadLine().Split();
            string name = line2[0];
            int beers = int.Parse(line2[1]);

            PrintTuple(name, beers);

            string[] line3 = Console.ReadLine().Split();
            int someInteger = int.Parse(line3[0]);
            double someDouble = double.Parse(line3[1]);

            PrintTuple(someInteger, someDouble);
        }

        private void PrintTuple(object item1, object item2)
        {
            tuple = new Tuple<object,object>(item1,item2);

            Console.WriteLine($"{tuple.Item1} -> {tuple.Item2}");
        }
    }
}
