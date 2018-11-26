using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Entities
{
    public class AgeComparator : IComparer<Person>
    {

        public int Compare(Person x, Person y)
        {
            if (x.Age > y.Age)
            {
                return 1;
            }
            else if(x.Age < y.Age)
            {
                return -1;
            }
            return 0;
        }
    }
}
