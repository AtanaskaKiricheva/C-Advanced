using System;

namespace Polymorphism.Classes.Foods
{
    public abstract class Food
    {
        private int quantity;

        public Food(int quantity)
        {
            Quantity = quantity;
        }

        public override string ToString()
        {
            //TODO
            return base.ToString();
        }

        public int Quantity { get; set; }

    }
}
