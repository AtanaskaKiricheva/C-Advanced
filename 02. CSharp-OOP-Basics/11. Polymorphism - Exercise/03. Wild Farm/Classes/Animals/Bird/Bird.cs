using Polymorphism.Classes.Foods;
using System;

namespace Polymorphism.Classes.Animals.Bird
{
    public abstract class Bird : Animal
    {
        private double wingSize;

        public Bird(string name, double weight, int foodEaten, Food foodType, double wingSize)
            : base(name, weight, foodEaten, foodType)
        {
            WingSize = wingSize;
        }

        public override string ToString()
        {
            return $" [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }

        public double WingSize { get; set; }
    }
}
