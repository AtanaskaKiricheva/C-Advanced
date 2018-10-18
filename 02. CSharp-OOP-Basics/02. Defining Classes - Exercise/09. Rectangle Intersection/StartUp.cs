using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            List<Rectangle> rectangles = new List<Rectangle>();

            string[] data = Console.ReadLine().Split();
            int n = int.Parse(data[0]);
            int m = int.Parse(data[1]);

            for (int i = 0; i < n; i++)
            {
                string[] data1 = Console.ReadLine().Split();
                string id = data1[0];
                int width = int.Parse(data1[1]);
                int heigth = int.Parse(data1[2]);
                int x = int.Parse(data1[3]);
                int y = int.Parse(data1[4]);

                rectangles.Add(new Rectangle(id, width, heigth, x, y));
            }

            for (int i = 0; i < m; i++)
            {
                string[] ids = Console.ReadLine().Split();
                string id1 = ids[0];
                string id2 = ids[1];

                var rect1 = rectangles.Where(x => x.Id == id1).FirstOrDefault();
                var rect2 = rectangles.Where(x => x.Id == id2).FirstOrDefault();

                if (rect1.X + rect1.Width < rect2.X 
                    || rect2.X + rect2.Width < rect1.X
                    || rect1.Y + rect1.Height < rect2.Y
                    || rect2.Y + rect2.Height < rect1.Y)
                {
                    Console.WriteLine("false");
                }
                else
                {
                    Console.WriteLine("true");
                }
               
            }

        }
    }
}
