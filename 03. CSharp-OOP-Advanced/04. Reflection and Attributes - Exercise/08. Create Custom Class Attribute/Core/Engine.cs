using Exercise.Entities;
using Exercise.Entities.Weapons;
using System;
using System.Linq;
using System.Reflection;

namespace Exercise.Core
{
    public class Engine
    {
        public void Run()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Type type = typeof(Weapon);
            var attr = type.GetCustomAttribute<CustomAttribute>();

            string command = Console.ReadLine();

            while (command != "END")
            {
                Print(command, attr);
                command = Console.ReadLine();
            }
        }

        public void Print(string command, CustomAttribute attr)
        {
            switch (command)
            {
                case "Author":
                    Console.WriteLine($"Author: {attr.Author}");
                    break;
                case "Revision":
                    Console.WriteLine($"Revision: {attr.Revision}");
                    break;
                case "Description":
                    Console.WriteLine($"Class description: {attr.Description}");
                    break;
                case "Reviewers":
                    Console.WriteLine($"Reviewers: {string.Join(", ",attr.Reviewers)}");
                    break;
            }
        }
    }
}
