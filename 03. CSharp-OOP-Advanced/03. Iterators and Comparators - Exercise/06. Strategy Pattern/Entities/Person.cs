using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Entities
{
    public class Person 
    {
        string name;
        int age;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get => name; private set => name = value; }
        public int Age { get => age; private set => age = value; }

    }
}
