using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Entities
{
    public class Engine
    {
        AnimalCentre animalCentre;
        public Engine()
        {
            animalCentre = new AnimalCentre();
        }
        public void Run()
        {
            string command = Console.ReadLine();

            while (command != "End")
            {
                try
                {
                    string[] args = command.Split();

                    switch (args[0])
                    {
                        case "RegisterAnimal":
                            Console.WriteLine(animalCentre.RegisterAnimal(args[1], args[2], int.Parse(args[3]), int.Parse(args[4]), int.Parse(args[5])));
                            break;
                        case "Chip":
                            Console.WriteLine(animalCentre.Chip(args[1], int.Parse(args[2])));
                            break;
                        case "Vaccinate":
                            Console.WriteLine(animalCentre.Vaccinate(args[1], int.Parse(args[2])));
                            break;
                        case "Fitness":
                            Console.WriteLine(animalCentre.Fitness(args[1], int.Parse(args[2])));
                            break;
                        case "Play":
                            Console.WriteLine(animalCentre.Play(args[1], int.Parse(args[2])));
                            break;
                        case "DentalCare":
                            Console.WriteLine(animalCentre.DentalCare(args[1], int.Parse(args[2])));
                            break;
                        case "NailTrim":
                            Console.WriteLine(animalCentre.NailTrim(args[1], int.Parse(args[2])));
                            break;
                        case "Adopt":
                            Console.WriteLine(animalCentre.Adopt(args[1], args[2]));
                            break;
                        case "History":
                            Console.WriteLine(animalCentre.History(args[1]));
                            break;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine("InvalidOperationException: " + ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("ArgumentException: " + ex.Message);
                }

                command = Console.ReadLine();
            }

            animalCentre.PrintAdopted();
        }
    }
}
