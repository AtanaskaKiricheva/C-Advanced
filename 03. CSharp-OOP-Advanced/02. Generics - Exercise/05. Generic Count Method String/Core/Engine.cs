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
            Box<string> box = new Box<string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                box.Add(input);
            }
            string comparator = Console.ReadLine();

            Console.WriteLine(box.CompareTo(comparator));
        }
    }
}
