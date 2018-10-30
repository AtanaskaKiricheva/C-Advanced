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
            List<string> birthdates = new List<string>();

            while (command[0] != "End")
            {
                if (command[0] == "Citizen")
                {
                    string birthdate = command[4];
                    birthdates.Add(birthdate);
                }
                else if (command[0] == "Pet")
                {
                    string birthdate = command[2];
                    birthdates.Add(birthdate);
                }

                command = Console.ReadLine().Split();
            }
            string year = Console.ReadLine();

            foreach (var date in birthdates)
            {
                if (date.Contains(year))
                {
                    Console.WriteLine(date);
                }
            }
        }
    }
}
