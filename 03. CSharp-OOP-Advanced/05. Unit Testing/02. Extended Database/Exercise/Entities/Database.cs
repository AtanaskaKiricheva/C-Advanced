using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise.Entities
{
    public class Database
    {
        HashSet<Person> people;


        public Database()
        {
            People = new HashSet<Person>();
        }

        //add
        public void Add(Person person)
        {
            if (people.Contains(person))
            {
                throw new InvalidOperationException();
            }
            people.Add(person);
        }

        //remove
        public void Remove(Person person)
        {
            people.Remove(person);
        }

        //by username
        public Person FindByUsername(Person person)
        {
            if (people.FirstOrDefault(x => x.Username == person.Username) == null)
            {
                throw new InvalidOperationException();
            }
            if (people.First(x => x == person).Username == null)
            {
                throw new ArgumentException();
            }

            return people.First(x => x == person);
        }

        //by id
        public Person FindById(Person person)
        {
            if (people.FirstOrDefault(x => x.Id == person.Id) == null)
            {
                throw new InvalidOperationException();
            }
            if (people.First(x => x == person).Id < 0)
            {
                throw new ArgumentException();
            }

            return people.First(x => x == person);
        }


        public HashSet<Person> People
        {
            get => people;
            private set => people = value;
        }
    }
}
