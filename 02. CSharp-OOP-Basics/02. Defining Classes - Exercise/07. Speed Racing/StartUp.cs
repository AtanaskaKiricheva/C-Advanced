using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();
                string model = data[0];
                int fuelAmount = int.Parse(data[1]);
                double fuelConsumption = double.Parse(data[2]);
                int distance = 0;

                Car car = new Car(model, fuelAmount, fuelConsumption, distance);
                cars.Add(car);
            }

            string command = Console.ReadLine();

            while (command!="End")
            {
                string[] data = command.Split();
                string carModel = data[1];
                int amountOfKm = int.Parse(data[2]);

                cars.Where(car => car.Model == carModel).ToList().ForEach(car => car.isFuelEnough(amountOfKm));

                command = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.Distance}");
            }
        }
    }
}
