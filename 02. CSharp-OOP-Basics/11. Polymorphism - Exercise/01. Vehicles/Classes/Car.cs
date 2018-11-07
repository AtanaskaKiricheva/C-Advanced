using Polymorphism.Contracts;
using System;

namespace Polymorphism.Classes
{
    public class Car : Vehicle
    {
        private const double airConditionConsumption = 0.9;
        public Car(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity,fuelConsumption)
        {
            FuelConsumption += airConditionConsumption;
        }

    }
}
