using Polymorphism.Contracts;
using System;

namespace Polymorphism.Classes
{
    public class Truck : Vehicle
    {
        private const double airConditionConsumption = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
        {
            FuelConsumption += airConditionConsumption;
        }

    }
}
