using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] engineInfo = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string engineModel = engineInfo[0];
                int enginePower = int.Parse(engineInfo[1]);
                string engineDisplacement = "n/a";
                string engineEfficiency = "n/a";

                Engine currentEngine = new Engine(engineModel, enginePower, engineDisplacement, engineEfficiency);

                if (engineInfo.Length == 4)
                {
                    engineDisplacement = engineInfo[2];
                    currentEngine.Displacement = engineDisplacement;
                    engineEfficiency = engineInfo[3];
                    currentEngine.Efficiency = engineEfficiency;
                }
                else if(engineInfo.Length == 3)
                {
                    int result;
                    if (int.TryParse(engineInfo[2], out result))
                    {
                        engineDisplacement = engineInfo[2];
                        currentEngine.Displacement = engineDisplacement;
                    }
                    else
                    {
                        engineEfficiency = engineInfo[2];
                        currentEngine.Efficiency = engineEfficiency;
                    }
                }
                engines.Add(currentEngine);

            }
            int m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                string[] carInfo = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string carModel = carInfo[0];
                string carEngine = carInfo[1];
                string carWeigth = "n/a";
                string carColor = "n/a";

                Car currentCar = new Car(carModel, engines.Where(e => e.Model == carEngine).FirstOrDefault(),carWeigth, carColor);

                if (carInfo.Length == 4)
                {
                    carWeigth = carInfo[2];
                    currentCar.Weight = carWeigth;
                    carColor = carInfo[3];
                    currentCar.Color = carColor;
                }
                else if(carInfo.Length == 3)
                {
                    int result;
                    if (int.TryParse(carInfo[2], out result))
                    {
                        carWeigth = carInfo[2];
                        currentCar.Weight = carWeigth;
                    }
                    else
                    {
                        carColor = carInfo[2];
                        currentCar.Color = carColor;
                    }
                }
                cars.Add(currentCar);
            }
            foreach (var car in cars)
            {
                Console.WriteLine(car.Model+":");
                Console.WriteLine($"    {car.Engine.Model}:");
                Console.WriteLine($"        Power: {car.Engine.Power}");
                Console.WriteLine($"        Displacement: {car.Engine.Displacement}");
                Console.WriteLine($"        Efficiency: {car.Engine.Efficiency}");
                Console.WriteLine($"    Weight: {car.Weight}");
                Console.WriteLine($"    Color: {car.Color}");
            }
        }
    }
}
