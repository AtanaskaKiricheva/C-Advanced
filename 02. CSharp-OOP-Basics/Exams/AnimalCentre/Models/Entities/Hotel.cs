using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Entities.Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Models.Entities
{
    public class Hotel: IHotel
    {
        private const int capacity = 10;
        private Dictionary<string,Animal> animals;

        public Hotel()
        {
            animals = new Dictionary<string, Animal>();
        }

        public void Accommodate(IAnimal animal)
        {
            if (animals.Count >= capacity)
            {
                throw new InvalidOperationException("Not enough capacity");  
            }
            if (animals.ContainsKey(((Animal)animal).Name))
            {
                throw new ArgumentException($"Animal {((Animal)animal).Name} already exist");
            }
            animals.Add(((Animal)animal).Name, ((Animal)animal));
        }

        public void Adopt(string animalName, string owner)
        {
            if (!animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }
            Animal currentAnimal = animals.FirstOrDefault(x => x.Key == animalName).Value;
            currentAnimal.Owner = owner;
            currentAnimal.IsAdopt = true;

            animals.Remove(animalName);
        }

        public IReadOnlyDictionary<string, Animal> Animals { get => animals;}
    }
}
