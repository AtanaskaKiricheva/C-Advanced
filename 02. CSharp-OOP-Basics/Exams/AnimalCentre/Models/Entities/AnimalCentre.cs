using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Entities.Animals;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AnimalCentre.Models.Entities.Procedures;

namespace AnimalCentre.Models.Entities
{
    public class AnimalCentre
    {
        Hotel hotel;
        private Dictionary<string, List<Animal>> history;
        private SortedDictionary<string, List<string>> adopted;

        public AnimalCentre()
        {
            hotel = new Hotel();
            history = new Dictionary<string, List<Animal>>();
            adopted = new SortedDictionary<string, List<string>>();
        }

        private void CheckForAnimal(string animalName)
        {
            if (!hotel.Animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }
        }

        internal void PrintAdopted()
        {
            foreach (var owner in adopted)
            {
                Console.WriteLine($"--Owner: {owner.Key}");
                Console.WriteLine($"    - Adopted animals: {string.Join(" ",owner.Value)}");
            }
        }

        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            switch (type)
            {
                case "Cat":
                    hotel.Accommodate(new Cat(name, energy, happiness, procedureTime));
                    break;
                case "Dog":
                    hotel.Accommodate(new Dog(name, energy, happiness, procedureTime));
                    break;
                case "Lion":
                    hotel.Accommodate(new Lion(name, energy, happiness, procedureTime));
                    break;
                case "Pig":
                    hotel.Accommodate(new Pig(name, energy, happiness, procedureTime));
                    break;
            }

            return $"Animal {name} registered successfully";
        }

        public string Chip(string name, int procedureTime)
        {
            CheckForAnimal(name);
            Chip chip = new Chip();
            Animal animal = hotel.Animals.Values.FirstOrDefault(x => x.Name == name);
            chip.DoService(animal, procedureTime);
            if (!history.ContainsKey("Chip"))
            {
                history.Add("Chip", new List<Animal>());
            }
            history["Chip"].Add(animal);
            return $"{name} had chip procedure";
        }

        public string Vaccinate(string name, int procedureTime)
        {
            CheckForAnimal(name);
            Vaccinate vaccinate = new Vaccinate();
            Animal animal = hotel.Animals.Values.FirstOrDefault(x => x.Name == name);
            vaccinate.DoService(animal, procedureTime);
            if (!history.ContainsKey("Vaccinate"))
            {
                history.Add("Vaccinate", new List<Animal>());
            }
            history["Vaccinate"].Add(animal);
            return $"{name} had vaccination procedure";
        }

        public string Fitness(string name, int procedureTime)
        {
            CheckForAnimal(name);
            Fitness fitness = new Fitness();
            Animal animal = hotel.Animals.Values.FirstOrDefault(x => x.Name == name);
            fitness.DoService(animal, procedureTime);
            if (!history.ContainsKey("Fitness"))
            {
                history.Add("Fitness", new List<Animal>());
            }
            history["Fitness"].Add(animal);
            return $"{name} had fitness procedure";
        }

        public string Play(string name, int procedureTime)
        {
            CheckForAnimal(name);
            Play play = new Play();
            Animal animal = hotel.Animals.Values.FirstOrDefault(x => x.Name == name);
            play.DoService(animal, procedureTime);
            if (!history.ContainsKey("Play"))
            {
                history.Add("Play", new List<Animal>());
            }
            history["Play"].Add(animal);
            return $"{name} was playing for {procedureTime} hours";
        }

        public string DentalCare(string name, int procedureTime)
        {
            CheckForAnimal(name);
            DentalCare dentalCare = new DentalCare();
            Animal animal = hotel.Animals.Values.FirstOrDefault(x => x.Name == name);
            dentalCare.DoService(animal, procedureTime);
            if (!history.ContainsKey("DentalCare"))
            {
                history.Add("DentalCare", new List<Animal>());
            }
            history["DentalCare"].Add(animal);
            return $"{name} had dental care procedure";
        }

        public string NailTrim(string name, int procedureTime)
        {
            CheckForAnimal(name);
            NailTrim nailTrim = new NailTrim();
            Animal animal = hotel.Animals.Values.FirstOrDefault(x => x.Name == name);
            nailTrim.DoService(animal, procedureTime);
            if (!history.ContainsKey("NailTrim"))
            {
                history.Add("NailTrim", new List<Animal>());
            }
            history["NailTrim"].Add(animal);
            return $"{name} had nail trim procedure";
        }

        public string Adopt(string animalName, string owner)
        {
            CheckForAnimal(animalName);
            Animal animal = hotel.Animals.Values.FirstOrDefault(x => x.Name == animalName);
            hotel.Adopt(animalName, owner);

            if (!adopted.ContainsKey(owner))
            {
                adopted.Add(owner, new List<string>());
            }
            adopted[owner].Add(animalName);
            if (animal.IsChipped)
            {
                return $"{animal.Owner} adopted animal with chip";
            }
            else
            {
                return $"{animal.Owner} adopted animal without chip";
            }

        }

        public string History(string type)
        {
            List<string> output = new List<string>();

            output.Add(type);
            foreach (var animal in history[type])
            {
                output.Add($"    Animal type: {animal.GetType().Name} - {animal.Name} - Happiness: {animal.Happiness} - Energy: {animal.Energy}");
            }

            return string.Join("\r\n",output);
        }

    }
}
