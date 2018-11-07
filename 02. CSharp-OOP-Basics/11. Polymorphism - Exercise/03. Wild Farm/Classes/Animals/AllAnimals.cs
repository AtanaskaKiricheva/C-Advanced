using System;
using System.Collections.Generic;
using System.Text;

namespace Polymorphism.Classes.Animals
{
    public class AllAnimals
    {
        private List<Animal> animals;

        public AllAnimals()
        {
            animals = new List<Animal>();
        }

        public void Add(Animal animal)
        {
            animals.Add(animal);
        }

        public void Print()
        {
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
