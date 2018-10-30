using System;
using System.Linq;

namespace PersonInfo.Core
{
    public class Engine
    {
        public void Run()
        {
            string name = Console.ReadLine();

            Console.WriteLine(new Ferrari(name));
        }
    }
}
