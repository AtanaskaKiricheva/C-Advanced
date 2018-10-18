using System;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();
            DateModifier date = new DateModifier();

            Console.WriteLine(date.Difference(firstDate,secondDate));
        }
    }
}
