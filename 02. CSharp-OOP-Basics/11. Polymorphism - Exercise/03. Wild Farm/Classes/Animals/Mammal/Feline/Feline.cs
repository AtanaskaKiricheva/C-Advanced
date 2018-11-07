using Polymorphism.Classes.Foods;

namespace Polymorphism.Classes.Animals.Mammal.Feline
{
    public abstract class Feline : Mammal
    {
        private string breed;
        public Feline(string name, double weight, int foodEaten, Food foodType, string livingRegion, string breed)
            : base(name, weight, foodEaten, foodType, livingRegion)
        {
            Breed = breed;
        }

        public string Breed;

        public override string ToString()
        {
            return $" [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
