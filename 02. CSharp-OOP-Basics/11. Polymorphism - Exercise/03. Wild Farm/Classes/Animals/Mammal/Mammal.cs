using Polymorphism.Classes.Foods;

namespace Polymorphism.Classes.Animals.Mammal
{

    public abstract class Mammal: Animal
    {
        private string livingRegion;

        public Mammal(string name, double weight, int foodEaten, Food foodType, string livingRegion)
            : base(name, weight, foodEaten, foodType)
        {
            LivingRegion = livingRegion;
        }

        public override string ToString()
        {
            return $" [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }

        public string LivingRegion;
    }
}
