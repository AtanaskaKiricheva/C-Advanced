using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Rectangle
    {
        private string id;
        private int width;
        private int height;
        private int x;
        private int y;

        public Rectangle(string id, int width, int height, int x, int y)
        {
            this.Id = id;
            this.Width = width;
            this.Height = height;
            this.X = x;
            this.Y = y;
        }

        public string Id { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
