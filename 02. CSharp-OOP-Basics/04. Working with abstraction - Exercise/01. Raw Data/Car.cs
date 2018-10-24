using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_RawData
{
    public class Car
    {
        private string model;
        private int engineSpeed;
        private int enginePower;
        private int cargoWeight;
        private string cargoType;
        private KeyValuePair<double, int>[] tires;


        public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType, double tire1Pressure, int tire1Age, double tire2Pressure, int tire2Age, double tire3Pressure, int tire3age, double tire4Pressure, int tire4age)
        {
            this.Model = model;
            this.EngineSpeed = engineSpeed;
            this.EnginePower = enginePower;
            this.CargoWeight = cargoWeight;
            this.CargoType = cargoType;
            this.Tires = new KeyValuePair<double, int>[] { KeyValuePair.Create(tire1Pressure, tire1Age), KeyValuePair.Create(tire2Pressure, tire2Age), KeyValuePair.Create(tire3Pressure, tire3age), KeyValuePair.Create(tire4Pressure, tire4age) };
        }

        public string Model { get => model; set => model = value; }
        public int EngineSpeed { get => engineSpeed; set => engineSpeed = value; }
        public int EnginePower { get => enginePower; set => enginePower = value; }
        public int CargoWeight { get => cargoWeight; set => cargoWeight = value; }
        public string CargoType { get => cargoType; set => cargoType = value; }
        public KeyValuePair<double, int>[] Tires { get => tires; set => tires = value; }
    }
}