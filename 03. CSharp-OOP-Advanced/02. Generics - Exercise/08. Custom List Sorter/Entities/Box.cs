using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generics.Entities
{
    public class Box<T> where T : IComparable<T>
    {
        private List<T> customList;

        public Box()
        {
            Value = new List<T>();
        }


        public void Add(T element)
        {
            customList.Add(element);
        }

        public void Remove(int index)
        {
            var currentElement = customList[index];
            customList.Remove(currentElement);

            //return currentElement;
        }

        public bool Contains(T element)
        {
            if (customList.Contains(element))
            {
                return true;
            }
            return false;
        }

        public void Swap(int swapA, int swapB)
        {
            var valueA = customList[swapA];
            var valueB = customList[swapB];

            customList[swapA] = valueB;
            customList[swapB] = valueA;
        }

        public int CountGreaterThan(T element)
        {
            int count = 0;

            foreach (var e in customList)
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
            var element = customList[0];

            foreach (var e in customList)
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
            var element = customList[0];

            foreach (var e in customList)
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

            foreach (var element in customList)
            {
                if (element.CompareTo(comparator) > 0)
                {
                    count++;
                }
            }

            return count;
        }

        public void Sort()
        {
            customList = customList.OrderBy(x => x).ToList();   
        }

        public override string ToString()
        {
            string output = "";

            foreach (var item in customList)
            {
                output += $"{item}\r\n";
            }
            return output.TrimEnd();
        }


        public List<T> Value { get => customList; private set => this.customList = value; }
    }
}
