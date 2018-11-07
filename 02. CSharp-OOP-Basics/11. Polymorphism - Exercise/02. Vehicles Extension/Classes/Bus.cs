using System;

namespace Polymorphism.Classes
{
    public class Bus : Vehicle
    {


        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }

        public override void Drive(double distance)
        {
            double currentFuelConsumption = FuelConsumption;

            if (!IsVehicleEmpty)
            {
                currentFuelConsumption += 1.4;
            }
            double neededFuel = distance * currentFuelConsumption;

            if (FuelQuantity >= neededFuel)
            {
                FuelQuantity -= neededFuel;
                Console.WriteLine($"Bus travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"Bus needs refueling");
            }

        }
    }
}
