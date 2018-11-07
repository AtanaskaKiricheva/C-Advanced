using Polymorphism.Classes.Foods;
using System;

namespace Polymorphism.Classes.Animals.Bird
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, int foodEaten, Food foodType, double wingSize)
            : base(name, weight, foodEaten, foodType, wingSize)
        {
        }

        public override string ToString()
        {
            return "Owl"+base.ToString();
        }

        public override Food FoodType
        {
            set
            {
                if (value is Meat)
                {
                    Weight += FoodEaten * 0.25;
                }
                else
                {
                    Console.WriteLine($"{this.GetType().Name} does not eat {value.GetType().Name}!");
                    FoodEaten = 0;
                }
            }
        }

        public override void Sound()
        {
            Console.WriteLine("Hoot Hoot");
        }
    }
}
