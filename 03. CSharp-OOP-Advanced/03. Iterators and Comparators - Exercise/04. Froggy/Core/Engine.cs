using Exercise.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise.Core
{
    public class Engine
    {

        public void Run()
        {
            Console.WriteLine(new Lake(Console.ReadLine().Split(", ").Select(int.Parse).ToArray()));
        }
    }
}
