using System;
using Exercise.Animals;

namespace Exercise.Core
{
    public class Engine
    {
        public void Run()
        {
            string command = Console.ReadLine();

            while (command != "Beast!")
            {
                string[] data = Console.ReadLine().Split();
                if (data.Length < 2 || data.Length > 3)
                {
                    Console.WriteLine("Invalid input!");
                    command = Console.ReadLine();
                    continue;
                }
                string name = data[0];
                int age = int.Parse(data[1]);
                string gender = "default";

                if (data.Length == 3)
                {
                    gender = data[2];
                }


                try
                {
                    switch (command)
                    {
                        case "Dog":
                            Dog dog = new Dog(name, age, gender);
                            Console.WriteLine(dog);
                            break;
                        case "Cat":
                            Cat cat = new Cat(name, age, gender);
                            Console.WriteLine(cat);
                            break;
                        case "Frog":
                            Frog frog = new Frog(name, age, gender);
                            Console.WriteLine(frog);
                            break;
                        case "Tomcat":
                            Tomcat tom = new Tomcat(name, age, gender);
                            Console.WriteLine(tom);
                            break;
                        case "Kitten":
                            Kitten kitten = new Kitten(name, age, gender);
                            Console.WriteLine(kitten);
                            break;
                        default:
                            Console.WriteLine("Invalid input!");
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                command = Console.ReadLine();
            }
        }
    }
}
