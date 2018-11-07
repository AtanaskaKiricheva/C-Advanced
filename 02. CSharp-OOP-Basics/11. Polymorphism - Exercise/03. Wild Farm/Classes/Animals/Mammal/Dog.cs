using Polymorphism.Classes.Foods;
using System;

namespace Polymorphism.Classes.Animals.Mammal
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, int foodEaten, Food foodType, string livingRegion)
            : base(name, weight, foodEaten, foodType, livingRegion)
        {
        }

        public override string ToString()
        {
            return "Dog" + base.ToString();
        }

        public override Food FoodType
        {
            set
            {
                if (value is Meat)
                {
                    Weight += FoodEaten * 0.40;
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
            Console.WriteLine("Woof!");
        }
    }
}
