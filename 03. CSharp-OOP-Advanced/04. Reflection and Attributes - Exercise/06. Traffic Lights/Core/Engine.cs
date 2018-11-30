using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise.Core
{
    public class Engine
    {
        public void Run()
        {
            List<string> lights = new List<string>(Console.ReadLine().Split());
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                for (int light = 0; light < lights.Count; light++)
                {
                    switch (lights[light])
                    {
                        case "Red": lights[light] = "Green"; break;
                        case "Green": lights[light] = "Yellow"; break;
                        case "Yellow": lights[light] = "Red"; break;
                    }
                }

                Console.WriteLine(string.Join(" ",lights));
            }
        }
    }
}
