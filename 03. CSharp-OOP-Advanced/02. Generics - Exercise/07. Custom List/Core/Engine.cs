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
            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] args = command.Split();

                switch (args[0])
                {
                    case "Add":
                        box.Add(args[1]);
                        break;
                    case "Remove":
                        box.Remove(int.Parse(args[1]));
                        break;
                    case "Contains":
                        Console.WriteLine(box.Contains(args[1]));
                        break;
                    case "Swap":
                        box.Swap(int.Parse(args[1]), int.Parse(args[2]));
                        break;
                    case "Greater":
                        Console.WriteLine(box.CountGreaterThan(args[1]));
                        break;
                    case "Max":
                        Console.WriteLine(box.Max());
                        break;
                    case "Min":
                        Console.WriteLine(box.Min());
                        break;
                    case "Print":
                        Console.WriteLine(box);
                        break;
                    case "Sort":
                        box.Sort();
                        break;
                }

                command = Console.ReadLine();
            }
        }
    }
}
