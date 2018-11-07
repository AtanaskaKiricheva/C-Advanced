using Polymorphism.Classes.Animals.Bird;
using Polymorphism.Classes.Animals.Mammal;
using Polymorphism.Classes.Animals.Mammal.Feline;
using Polymorphism.Classes.Foods;
using System;

namespace Polymorphism.Classes.Animals
{
    public class AnimalFactory
    {
        private string type;
        private string name;
        private double weight;
        private int quantity;
        private Food foodType;
        private string[] animalInfo;

        public AnimalFactory(string type, string name, double weight,int quantity, Food foodType, string[] animalInfo)
        {
            this.type = type;
            this.name = name;
            this.weight = weight;
            this.quantity = quantity;
            this.foodType = foodType;
            this.animalInfo = animalInfo;
        }

        public Animal CheckAnimal ()
        {
            switch (type)
            {
                case "Owl": return new Owl(name, weight, quantity, foodType, double.Parse(animalInfo[3]));
                case "Hen": return new Hen(name, weight, quantity, foodType, double.Parse(animalInfo[3]));
                case "Dog":return new Dog(name, weight, quantity, foodType, animalInfo[3]);
                case "Tiger": return new Tiger(name, weight, quantity, foodType, animalInfo[3],animalInfo[4]);
                case "Mouse": return new Mouse(name, weight, quantity, foodType, animalInfo[3]);
                case "Cat": return new Cat(name, weight, quantity, foodType, animalInfo[3],animalInfo[4]);
                default: throw new ArgumentException("Invalid animal");
            }
        }
    }
}
