using Polymorphism.Classes;
using Polymorphism.Contracts;
using System;

namespace Polymorphism.Core
{
    public class Engine
    {
        public void Run()
        {
            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();
            string[] busInfo = Console.ReadLine().Split();

            double carFuelQuantity = double.Parse(carInfo[1]);
            double carFuelConsumption = double.Parse(carInfo[2]);
            double carTankCapacity = double.Parse(carInfo[3]);

            double truckFuelQuantity = double.Parse(truckInfo[1]);
            double truckFuelConsumption = double.Parse(truckInfo[2]);
            double truckTankCapacity = double.Parse(truckInfo[3]);

            double busFuelQuantity = double.Parse(busInfo[1]);
            double busFuelConsumption = double.Parse(busInfo[2]);
            double busTankCapacity = double.Parse(busInfo[3]);

            IVehicle car = new Car(carFuelQuantity, carFuelConsumption, carTankCapacity);
            IVehicle truck = new Truck(truckFuelQuantity, truckFuelConsumption, truckTankCapacity);
            IVehicle bus = new Bus(busFuelQuantity, busFuelConsumption, busTankCapacity);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] args = Console.ReadLine().Split();

                string action = args[0];
                string type = args[1];
                double value = double.Parse(args[2]);

                if (action == "Refuel")
                {
                    if (type == "Car")
                    {
                        car.Refuel(value);
                    }
                    else if (type == "Truck")
                    {
                        truck.Refuel(value);
                    }
                    else
                    {
                        bus.Refuel(value);
                    }

                }
                else if (action == "DriveEmpty")
                {
                    bus.IsVehicleEmpty = true;
                    bus.Drive(value);
                }
                else if (action == "Drive")
                {
                    if (type == "Car")
                    {
                        car.Drive(value);
                    }
                    else if (type == "Truck")
                    {
                        truck.Drive(value);
                    }
                    else
                    {
                        bus.IsVehicleEmpty = false;
                        bus.Drive(value);
                    }
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}
