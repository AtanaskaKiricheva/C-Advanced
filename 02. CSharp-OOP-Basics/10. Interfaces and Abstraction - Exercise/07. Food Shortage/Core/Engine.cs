using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonInfo.Core
{
    public class Engine
    {
        public void Run()
        {
            int n = int.Parse(Console.ReadLine());
            List<string> citizens = new List<string>();
            List<string> rebels = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split();
                string name = info[0];

                if (info.Length == 4)
                {
                    citizens.Add(name);
                }
                else if (info.Length == 3)
                {
                    rebels.Add(name);
                }
            }
            string command = Console.ReadLine();
            int food = 0;

            while (command != "End")
            {
                if (citizens.Contains(command))
                {
                    food += 10;
                }
                else if (rebels.Contains(command))
                {
                    food += 5;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(food);
        }
    }
}
