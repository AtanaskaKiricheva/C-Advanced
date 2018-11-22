using System;
using System.Collections.Generic;
using System.Text;

namespace Generics.Entities
{
    public class Tuple<T, U>
    {
        private T item1;
        private U item2;

        public Tuple(T item1, U item2)
        {
            Item1 = item1;
            Item2 = item2;
        }

        //public override string ToString()
        //{
        //    return $"{Item1} -> {Item2}";
        //}

        public T Item1 { get => item1; private set => item1 = value; }
        public U Item2 { get => item2; private set => item2 = value; }
    }
}
