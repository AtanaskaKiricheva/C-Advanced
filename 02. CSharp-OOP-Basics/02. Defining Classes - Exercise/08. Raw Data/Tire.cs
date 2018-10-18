namespace DefiningClasses
{
    public class Tire
    {
        private double tire1;
        private double tire2;
        private double tire3;
        private double tire4;

        public Tire(double tire1, double tire2, double tire3, double tire4)
        {
            this.Tire1 = tire1;
            this.Tire2 = tire2;
            this.Tire3 = tire3;
            this.Tire4 = tire4;
        }
        public double TirePressure()
        {
            if (this.Tire1 < 1 || this.Tire2<1 || this.Tire3<1 || this.Tire4<1)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public double Tire1 { get; set; }
        public double Tire2 { get; set; }
        public double Tire3 { get; set; }
        public double Tire4 { get; set; }
    }
}