using Exercise.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise.Core
{
    public class Engine
    {
        List<Person<object>> people = new List<Person<object>>();
        public void Run()
        {
            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] args = command.Split();
                string name = args[0];
                int age = int.Parse(args[1]);
                string town = args[2];

                people.Add(new Person<object>(name,age,town));

                command = Console.ReadLine();
            }

            int n = int.Parse(Console.ReadLine());
            Person<object> man = people[n-1];
            people.Remove(man);

            Console.WriteLine(Print(man));
        }

        private string Print( Person<object> man)
        {
            bool noMatches = true;
            int equalsCount = 0;
            int notEqualCount = 0;

            foreach (var person in people)
            {
                if (person.CompareTo(man) == 0)
                {
                    noMatches = false;
                    equalsCount++;
                }
                else
                {
                    notEqualCount++;
                }
            }

            if (noMatches)
            {
                return "No matches";
            }
            return $"{equalsCount+1} {notEqualCount} {people.Count+1}";
        }
    }
}
