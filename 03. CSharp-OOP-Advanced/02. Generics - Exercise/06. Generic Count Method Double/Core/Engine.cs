using Generics.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generics.Core
{
    public class Engine
    {

        public void Run()
        {
            Box<double> box = new Box<double>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = double.Parse(Console.ReadLine());
                box.Add(input);
            }
            double comparator = double.Parse(Console.ReadLine());

            Console.WriteLine(box.CompareTo(comparator));
        }
    }
}
