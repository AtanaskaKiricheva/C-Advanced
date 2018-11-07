using System;
using System.Collections.Generic;
using System.Text;

namespace Polymorphism.Contracts
{
    public interface IVehicle
    {
        double FuelQuantity { get; }
        double FuelConsumption { get; }

        void Drive(double distance);

        void Refuel(double fuel);
    }
}
