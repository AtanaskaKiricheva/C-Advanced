using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public class Ferrari
    {
        string name;

        public Ferrari(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"488-Spider/Brakes!/Zadu6avam sA!/{name}";
        }

        public string Name { get => name; set => name = value; }
    }
}
