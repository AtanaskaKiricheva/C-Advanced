using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Entities
{
    public class Database
    {
        int[] integers = new int[16];

        public Database(int[] integers)
        {
            Integers = integers;
        }

        //add
        public void Add(int element)
        {
            int length = integers.Length;
            int[] newInt = new int[length + 1];

            for (int i = 0; i < newInt.Length - 1; i++)
            {
                newInt[i] = integers[i];
            }
            newInt[newInt.Length - 1] = element;

            integers = newInt;
        }

        //remove
        public void Remove()
        {
            if (integers.Length == 0)
            {
                throw new InvalidOperationException();
            }
            int length = integers.Length;
            int[] newInt = new int[length - 1];

            for (int i = 0; i < newInt.Length; i++)
            {
                newInt[i] = integers[i];
            }

            integers = newInt;
        }

        //fetch
        public int[] Fetch()
        {
            return integers;
        }


        public int[] Integers
        {
            get => integers;
            private set
            {
                if (value.Length != 16)
                {
                    throw new InvalidOperationException();
                }
                integers = value;
            }
        }
    }
}
