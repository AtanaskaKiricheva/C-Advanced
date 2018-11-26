using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise.Entities
{
    public class ListyIterator<T>
    {
        List<T> elements;
        int internalIndex = 0;

        public ListyIterator(IEnumerable<T> collection)
        {
            elements = new List<T>();
            FillList(collection);
        }

        private void FillList(IEnumerable<T> collection)
        {
            foreach (var element in collection)
                elements.Add(element);
        }

        public bool Move()
        {
            if (elements.Count == internalIndex + 1)
            {
                return false;
            }
            internalIndex++;
            return true;
        }

        public bool HasNext()
        {
            if (elements.Count == internalIndex + 1)
            {
                return false;
            }

            return true;
        }

        public void Print()
        {
            if (elements.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            Console.WriteLine(elements[internalIndex]);
        }

        public List<T> Elements { get => elements; set => elements = value; }
    }
}
