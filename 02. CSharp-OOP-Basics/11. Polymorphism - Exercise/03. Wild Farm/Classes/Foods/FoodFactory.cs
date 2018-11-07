using System;

namespace Polymorphism.Classes.Foods
{
    public class FoodFactory
    {
        private string foodType;
        private int quantity;
        public FoodFactory(int quantity, string foodType)
        {
            this.foodType = foodType;
            this.quantity = quantity;
        }

        public Food CheckFood()
        {
            switch (foodType)
            {
                case "Vegetable": return new Vegetable(quantity);
                case "Fruit": return new Fruit(quantity);
                case "Meat": return new Meat(quantity);
                case "Seeds": return new Seeds(quantity);
                default: throw new ArgumentException("Invalid food");
            }
        }
    }
}
