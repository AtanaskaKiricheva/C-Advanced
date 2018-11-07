using Polymorphism.Classes.Foods;
using System;

namespace Polymorphism.Classes.Animals
{
    public abstract class Animal
    {
        private string name;
        private double weight;
        private int foodEaten;
        private Food foodType;

        public Animal(string name, double weight, int foodEaten, Food foodType)
        {
            Sound();
            Name = name;
            Weight = weight;
            FoodEaten = foodEaten;
            FoodType = foodType;
        }

        public abstract void Sound();

        public string Name;
        public double Weight;
        public int FoodEaten;
        public abstract Food FoodType { set; }
    }
}
