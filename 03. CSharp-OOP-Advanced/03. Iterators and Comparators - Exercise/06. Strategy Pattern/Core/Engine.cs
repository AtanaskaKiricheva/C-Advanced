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
            SortedSet<Person> byName = new SortedSet<Person>(new NameComparator());
            SortedSet<Person> byAge = new SortedSet<Person>(new AgeComparator());

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] args = Console.ReadLine().Split();
                string name = args[0];
                int age = int.Parse(args[1]);

                Person person = new Person(name, age);

                byName.Add(person);
                byAge.Add(person);
            }

            foreach (var person in byName)
            {
                Console.WriteLine($"{person.Name} {person.Age}");
            }

            foreach (var person in byAge)
            {
                Console.WriteLine($"{person.Name} {person.Age}");
            }
        }
    }
}
