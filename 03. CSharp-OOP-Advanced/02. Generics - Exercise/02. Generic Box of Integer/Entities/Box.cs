using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generics.Entities
{
    public class Box<T>
    {
        private Stack<T> value;


        public Box()
        {
            Value = new Stack<T>();
        }

        public void Add(T element)
        {
            value.Push(element);
        }

        public T Remove()
        {
            return value.Pop();
        }

        public int Count()
        {
            return value.Count;
        }

        public override string ToString()
        {
            string output ="";

            foreach (var item in value.Reverse())
            {
                output += $"{item.GetType()}: {item}\r\n";
            }
            return output.TrimEnd();
        }

        public Stack<T> Value { get => value; set => this.value = value; }
    }
}
