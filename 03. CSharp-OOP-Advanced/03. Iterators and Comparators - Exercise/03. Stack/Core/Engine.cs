using Exercise.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Exercise.Core
{
    public class Engine
    {
        CustomStack<object> stack;

        public void Run()
        {
            string command = Console.ReadLine();

            stack = new CustomStack<object>();

            while (command != "END")
            {
                string[] args = command.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    switch (args[0])
                    {
                        case "Pop":
                            stack.Pop();
                            break;
                        case "Push":
                            stack.Push(args.Skip(1).ToArray());
                            break;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                command = Console.ReadLine();
            }
            Print();
            Print();

        }
        private void Print()
        {
            foreach (var element in stack)
            {
                Console.WriteLine(element);
            }
        }
    }
}
