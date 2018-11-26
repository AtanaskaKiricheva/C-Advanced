using Exercise.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Exercise.Core
{
    public class Engine
    {
        public void Run()
        {
            string command = Console.ReadLine();
            ListyIterator<string> iterator = new ListyIterator<string>(command.Split().Skip(1));
            command = Console.ReadLine();

            while (command != "END")
            {
                try
                {
                    switch (command)
                    {
                        case "Print":
                            iterator.Print();
                            break;
                        case "Move":
                            Console.WriteLine(iterator.Move());
                            break;
                        case "HasNext":
                            Console.WriteLine(iterator.HasNext());
                            break;
                        case "PrintAll":
                            iterator.PrintAll();
                            break;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                command = Console.ReadLine();
            }
        }
    }
}
