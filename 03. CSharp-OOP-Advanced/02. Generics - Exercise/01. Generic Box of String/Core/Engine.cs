using Generics.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Generics.Core
{
    public class Engine
    {

        public void Run()
        {
            Box<object> box = new Box<object>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string str = Console.ReadLine();
                box.Add(str);
            }
            Console.WriteLine(box);
        }
    }
}
