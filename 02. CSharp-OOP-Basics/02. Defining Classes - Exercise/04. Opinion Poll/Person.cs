using System.Collections.Generic;

namespace DefiningClasses
{
    public class Person
    {
        SortedSet<string> people = new SortedSet<string>();

        private int age;
        private string name;

        public void AddPerson(string name, int age)
        {
            if (age > 30)
            {
                people.Add(name + " - " + age);
            }
        }
        public SortedSet<string> Print()
        {
            return people;
        }

        public int Age { get; set; }
        public string Name { get; set; }

    }
}