using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Entities
{
    public class Person<T> : IComparable<T>
    {
        string name;
        int age;
        string town;

        public Person(string name, int age, string town)
        {
            Name = name;
            Age = age;
            Town = town;
        }

        public string Name { get => name; private set => name = value; }
        public int Age { get => age; private set => age = value; }
        public string Town { get => town; private set => town = value; }

        public int CompareTo(T other)
        {
            Person<T> man = (Person<T>)(object)other;

            if (this.name == man.name && this.age == man.age && this.town == man.town)
            {
                return 0;
            }
            return -1;
        }
    }
}
