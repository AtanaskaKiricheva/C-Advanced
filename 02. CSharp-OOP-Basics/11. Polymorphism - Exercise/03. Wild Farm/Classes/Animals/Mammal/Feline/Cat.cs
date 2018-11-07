using Polymorphism.Classes.Foods;
using System;

namespace Polymorphism.Classes.Animals.Mammal.Feline
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, int foodEaten, Food foodType, string livingRegion, string breed)
            : base(name, weight, foodEaten, foodType, livingRegion,breed)
        {
        }

        public override string ToString()
        {
            return "Cat"+base.ToString();
        }

        public override Food FoodType
        {
            set
            {
                if (value is Vegetable || value is Meat)
                {
                    Weight += FoodEaten * 0.30;
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
            Console.WriteLine("Meow");
        }
    }
}
