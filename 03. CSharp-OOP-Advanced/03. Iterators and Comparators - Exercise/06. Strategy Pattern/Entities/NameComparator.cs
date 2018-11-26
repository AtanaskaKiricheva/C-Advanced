using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Entities
{
    public class NameComparator : IComparer<Person>
    {


        public int Compare(Person x, Person y)
        {
            if (x.Name.Length > y.Name.Length)
            {
                return 1;
            }
            else if (x.Name.Length < y.Name.Length)
            {
                return -1;
            }
            else
            {
                if (x.Name[0].ToString().ToLower().ToCharArray()[0] > y.Name[0].ToString().ToLower().ToCharArray()[0])
                {
                    return 1;
                }
                else if (x.Name[0].ToString().ToLower().ToCharArray()[0] < y.Name[0].ToString().ToLower().ToCharArray()[0])
                {
                    return -1;
                }

                return 0;
            }
        }
    }
}
