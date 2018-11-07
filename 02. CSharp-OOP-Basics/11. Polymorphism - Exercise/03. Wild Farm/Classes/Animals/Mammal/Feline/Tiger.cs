using Polymorphism.Classes.Foods;
using System;

namespace Polymorphism.Classes.Animals.Mammal.Feline
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, int foodEaten, Food foodType, string livingRegion, string breed)
            : base(name, weight, foodEaten, foodType, livingRegion,breed)
        {
        }

        public override string ToString()
        {
            return "Tiger" + base.ToString();
        }

        public override Food FoodType
        {
            set
            {
                if (value is Meat)
                {
                    Weight += FoodEaten * 1.00;
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
            Console.WriteLine("ROAR!!!");
        }
    }
}
