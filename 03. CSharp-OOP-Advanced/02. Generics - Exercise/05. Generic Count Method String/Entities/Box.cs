using System;
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

        public void Swap(int swapA, int swapB)
        {
            T valueA = elements[swapA];
            T valueB = elements[swapB];

            elements[swapA] = valueB;
            elements[swapB] = valueA;
        }

        public void Add(T element)
        {
            elements.Add(element);
        }

        public T Remove()
        {
            T lastElement = elements[elements.Count - 1];
            elements.Remove(lastElement);

            return lastElement;
        }

        public override string ToString()
        {
            string output = "";

            foreach (var item in elements)
            {
                output += $"{item.GetType()}: {item}\r\n";
            }
            return output.TrimEnd();
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

        public List<T> Value { get => elements; set => this.elements = value; }
    }
}
