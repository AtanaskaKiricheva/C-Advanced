namespace P07_FamilyTree
{
    internal class Box
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
            return $"Surface Area - {2*(this.length*this.width)+2*(this.length*this.height)+2*(this.width*this.height):f2}" +
                $"\r\nLateral Surface Area - {2*(this.length*this.height)+2*(this.width*this.height):f2}" +
                $"\r\nVolume - {this.length*this.width*this.height:f2}";
        }

        public double Length { get => length; set => length = value; }
        public double Width { get => width; set => width = value; }
        public double Height { get => height; set => height = value; }
    }
}