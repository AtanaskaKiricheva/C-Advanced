using Exercise.Entities;
using System;
using System.Linq;
using System.Reflection;

namespace Exercise.Core
{
    public class Engine
    {
        public void Run()
        {
            Database database = new Database(new int[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16 });

            database.Remove();
            database.Add(333);
        }
    }
}
