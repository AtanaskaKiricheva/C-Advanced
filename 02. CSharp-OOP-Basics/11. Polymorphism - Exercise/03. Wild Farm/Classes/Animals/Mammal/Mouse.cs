using Polymorphism.Classes.Foods;
using System;

namespace Polymorphism.Classes.Animals.Mammal
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, int foodEaten, Food foodType, string livingRegion)
            : base(name, weight, foodEaten, foodType, livingRegion)
        {
        }

        public override string ToString()
        {
            return "Mouse"+base.ToString();
        }

        public override Food FoodType
        {
            set
            {
                if (value is Vegetable || value is Fruit)
                {
                    Weight += FoodEaten * 0.10;
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
            Console.WriteLine("Squeak");
        }
    }
}
