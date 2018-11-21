using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generics.Entities
{
    public class Box<T>
    {
        private List<T> value;


        public Box()
        {
            Value = new List<T>();
        }

        public void Swap(int swapA, int swapB)
        {
            T valueA = value[swapA];
            T valueB = value[swapB];

            value[swapA] = valueB;
            value[swapB] = valueA;
        }

        public void Add(T element)
        {
            value.Add(element);
        }

        public T Remove()
        {
            T lastElement = value[value.Count - 1];
            value.Remove(lastElement);

            return lastElement;
        }

        public int Count()
        {
            return value.Count;
        }

        public override string ToString()
        {
            string output ="";

            foreach (var item in value)
            {
                output += $"{item.GetType()}: {item}\r\n";
            }
            return output.TrimEnd();
        }

        public List<T> Value { get => value; set => this.value = value; }
    }
}
