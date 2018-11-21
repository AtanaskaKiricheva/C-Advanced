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
            Box<object> box = new Box<object>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string ints = Console.ReadLine();
                box.Add(ints);
            }
            int[] swapCommand = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int swapA = swapCommand[0];
            int swapB = swapCommand[1];

            box.Swap(swapA, swapB);

            Console.WriteLine(box);
        }
    }
}
