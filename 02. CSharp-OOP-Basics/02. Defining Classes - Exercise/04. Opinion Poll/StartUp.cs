using System;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Person person = new Person();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();
                string name = data[0];
                int age = int.Parse(data[1]);
                person.AddPerson(name, age);
            }

            Console.WriteLine(string.Join("\r\n", person.Print()));
        }
    }
}
