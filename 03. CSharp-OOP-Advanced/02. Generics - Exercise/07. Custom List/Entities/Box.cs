using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generics.Entities
{
    public class Box<T> : IComparable<T> where T : IComparable<T>
    {
        private List<T> elements;

        public Box()
        {
            Value = new List<T>();
        }


        public void Add(T element)
        {
            elements.Add(element);
        }

        public T Remove(int index)
        {
            var currentElement = elements[index];
            elements.Remove(currentElement);

            return currentElement;
        }

        public bool Contains(T element)
        {
            if (elements.Contains(element))
            {
                return true;
            }
            return false;
        }

        public void Swap(int swapA, int swapB)
        {
            var valueA = elements[swapA];
            var valueB = elements[swapB];

            elements[swapA] = valueB;
            elements[swapB] = valueA;
        }

        public int CountGreaterThan(T element)
        {
            int count = 0;

            foreach (var e in elements)
            {
                if (e.CompareTo(element) > 0)
                {
                    count++;
                }
            }

            return count;
        }

        public T Max()
        {
            var element = elements[0];

            foreach (var e in elements)
            {
                if (e.CompareTo(element) > 0)
                {
                    element = e;
                }
            }
            return element;
        }

        public T Min()
        {
            var element = elements[0];

            foreach (var e in elements)
            {
                var result = e.CompareTo(element);
                if (e.CompareTo(element) < 0)
                {
                    element = e;
                }
            }
            return element;
        }

        public int CompareTo(T comparator)
        {
            int count = 0;

            foreach (var element in elements)
            {
                if (element.CompareTo(comparator) > 0)
                {
                    count++;
                }
            }

            return count;
        }
        public string Print()
        {
            string output = "";

            foreach (var item in elements)
            {
                output += $"{item}\r\n";
            }
            return output.TrimEnd();
        }


        public List<T> Value { get => elements; set => this.elements = value; }
    }
}
