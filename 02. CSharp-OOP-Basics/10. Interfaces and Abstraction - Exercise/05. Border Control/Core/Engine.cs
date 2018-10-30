using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonInfo.Core
{
    public class Engine
    {
        public void Run()
        {
            string[] command = Console.ReadLine().Split();
            List<string> ids = new List<string>();

            while (command[0] != "End")
            {
                if (command.Length == 3)
                {
                    string id = command[2];
                    ids.Add(id);
                }
                else if(command.Length ==2)
                {
                    string id = command[1];
                    ids.Add(id);
                }

                command = Console.ReadLine().Split();
            }
            string fakeID = Console.ReadLine();

            foreach (var id in ids)
            {
                if (id.EndsWith(fakeID))
                {
                    Console.WriteLine(id);
                }
            }
        }
    }
}
