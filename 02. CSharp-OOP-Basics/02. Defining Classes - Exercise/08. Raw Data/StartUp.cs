using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            List<string> fragiles = new List<string>();
            List<string> flamables = new List<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();
                string model = data[0];
                int engineSpeed = int.Parse(data[1]);
                int enginePower = int.Parse(data[2]);
                int cargoWeight = int.Parse(data[3]);
                string cargoType = data[4];
                double tire1Pressure = double.Parse(data[5]);
                int tire1Age = int.Parse(data[6]);
                double tire2Pressure = double.Parse(data[7]);
                int tire2Age = int.Parse(data[8]);
                double tire3Pressure = double.Parse(data[9]);
                int tire3Age = int.Parse(data[10]);
                double tire4Pressure = double.Parse(data[11]);
                int tire4Age = int.Parse(data[12]);

                var tire = new Tire(tire1Pressure, tire2Pressure, tire3Pressure, tire4Pressure);
                var pressure = tire.TirePressure();

                if (cargoType == "fragile" && pressure < 1)
                {
                    fragiles.Add(model);
                }
                else if (cargoType == "flamable" && enginePower > 250)
                {
                    flamables.Add(model);
                }

            }
            string command = Console.ReadLine();
            if (command == "flamable")
            {
                Console.WriteLine(string.Join("\r\n", flamables));
            }
            else
            {
                Console.WriteLine(string.Join("\r\n", fragiles));
            }
        }
    }
}
