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

            double carFuelQuantity = double.Parse(carInfo[1]);
            double carFuelConsumption = double.Parse(carInfo[2]);

            double truckFuelQuantity = double.Parse(truckInfo[1]);
            double truckFuelConsumption = double.Parse(truckInfo[2]);

            IVehicle car = new Car(carFuelQuantity, carFuelConsumption);
            IVehicle truck = new Truck(truckFuelQuantity, truckFuelConsumption);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] args = Console.ReadLine().Split();

                string action = args[0];
                string type = args[1];
                double value = double.Parse(args[2]);

                if (action =="Refuel")
                {
                    if (type == "Car")
                    {
                        car.Refuel(value);
                    }
                    else
                    {
                        truck.Refuel(value);
                    }

                }
                else
                {
                    if (type =="Car")
                    {
                        car.Drive(value);
                    }
                    else
                    {
                        truck.Drive(value);
                    }
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
    }
}
