using Polymorphism.Classes.Foods;
using System;

namespace Polymorphism.Classes.Animals.Bird
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, int foodEaten, Food foodType, double wingSize)
            : base(name, weight, foodEaten, foodType, wingSize)
        {
        }

        public override Food FoodType { set => Weight += FoodEaten * 0.35; }

        public override string ToString()
        {
            return "Hen"+base.ToString();
        }

        public override void Sound()
        {
            Console.WriteLine("Cluck");
        }
    }
}
