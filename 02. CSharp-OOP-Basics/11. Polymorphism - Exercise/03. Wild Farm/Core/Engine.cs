using Polymorphism.Classes.Animals;
using Polymorphism.Classes.Foods;
using System;

namespace Polymorphism.Core
{
    public class Engine
    {
        public void Run()
        {
            string command = Console.ReadLine();
            AllAnimals animals = new AllAnimals();

            while (command != "End")
            {
                string[] animalInfo = command.Split();
                string[] foodInfo = Console.ReadLine().Split();

                string animalType = animalInfo[0];
                string name = animalInfo[1];
                double weight = double.Parse(animalInfo[2]);

                string foodType = foodInfo[0];
                int quantity = int.Parse(foodInfo[1]);

                FoodFactory foodFactory = new FoodFactory(quantity, foodType);
                Food food = foodFactory.CheckFood();
                AnimalFactory animalFactory = new AnimalFactory(animalType, name, weight, quantity, food, animalInfo);
                Animal animal = animalFactory.CheckAnimal();

                animals.Add(animal);

                command = Console.ReadLine();
            }
            animals.Print();
        }
    }
}
