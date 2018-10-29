using System;
using System.Linq;

namespace Exercise.Core
{
    public class Engine
    {
        public void Run()
        {
            string[] food = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int totalHappiness = 0;
            Happines happines = new Happines();

            for (int i = 0; i < food.Length; i++)
            {
                happines = new Happines(food[i]);
                totalHappiness += happines.GetHappiness();
            }

            Console.WriteLine(happines.CheckHappiness(totalHappiness));
        }
    }
}
