using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Entities
{
    public class Person
    {
        long id;
        string username;

        public Person(string name, long id)
        {
            Username = name;
            Id = id;
        }

        public long Id { get => id;
            private set => id = value; }

        public string Username { get => username;
            private set => username = value; }
    }
}
