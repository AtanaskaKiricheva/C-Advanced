using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Entities
{
    public class CustomStack<T> : IEnumerable<T>
    {
        T[] stack;

        public CustomStack()
        {
            stack = new T[0];
        }

        public void Push(T[] items)
        {
            int nextIndex = 0;

            if (stack.Length < stack.Length + items.Length)
            {
                T[] newStack = new T[stack.Length + items.Length];

                for (int i = 0; i < stack.Length; i++)
                {
                    newStack[i] = stack[i];
                    nextIndex++;
                }

                for (int i = 0; i < items.Length; i++)
                {
                    newStack[nextIndex + i] = items[i];
                }

                stack = newStack;
            }
        }
        public void Pop()
        {
            if (stack.Length==0)
            {
                throw new InvalidOperationException("No elements");
            }
            T[] newStack = new T[stack.Length - 1];

            for (int i = 0; i < newStack.Length; i++)
            {
                newStack[i] = stack[i];
            }
            stack = newStack;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var element in stack)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
