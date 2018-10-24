namespace Exercise
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public override string ToString()
        {

            return $"Surface Area - {2 * (this.length * this.width) + 2 * (this.length * this.height) + 2 * (this.width * this.height):f2}" +
                $"\r\nLateral Surface Area - {2 * (this.length * this.height) + 2 * (this.width * this.height):f2}" +
                $"\r\nVolume - {this.length * this.width * this.height:f2}";
        }

        internal void Validation(string type)
        {
            System.Console.WriteLine($"{type} cannot be zero or negative.");
            System.Environment.Exit(1);
        }

        public double Length
        {
            get
            {
                return length;
            }
            set
            {
                if (value > 0)
                    length = value;
                else
                    Validation("Length");
            }
        }
        public double Width
        {
            get
            {
                return width;
            }
            set
            {
                if (value > 0)
                    width = value;
                else
                    Validation("Width");
            }
        }
        public double Height
        {
            get
            {
                return height;
            }
            set
            {
                if (value > 0)
                    height = value;
                else
                    Validation("Height");
            }
        }
    }
}