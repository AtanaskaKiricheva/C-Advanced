namespace DefiningClasses
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumption;
        private int distance;

        public Car(string model, int fuelAmount, double fuelConsumption, int distance)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumption = fuelConsumption;
            this.Distance = distance;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumption { get; set; }
        public int Distance { get; set; }

        public void isFuelEnough (int amountOfKm)
        {
            var wasted = amountOfKm * this.FuelConsumption;

            if (wasted <= this.FuelAmount)
            {
                this.FuelAmount -= wasted;
                this.Distance += amountOfKm;
            }
            else
            {
                System.Console.WriteLine("Insufficient fuel for the drive");
            }
        }

    }
}