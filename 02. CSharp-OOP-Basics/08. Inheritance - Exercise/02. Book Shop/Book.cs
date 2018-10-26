using System;
using System.Text;

namespace Exercise
{
    public class Book
    {
        private string title;
        private string author;
        private decimal price;

        public Book(string author, string title, decimal price)
        {
            this.Title = title;
            this.Author = author;
            this.Price = price;
        }

        public override string ToString()
        {
            return $"Type: {this.GetType().Name}\r\nTitle: {title}\r\nAuthor: {author}\r\nPrice: {price:f2}";
        }

        public string Title
        {
            get => title;
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Title not valid!");
                }
                title = value;
            }
        }
        public string Author
        {
            get => author;
            set
            {
                if ((value.Split()[1][0] >= '0' && value.Split()[1][0] <= '9') && value.Split().Length > 1)
                {
                    throw new ArgumentException("Author not valid!");
                }
                author = value;
            }
        }
        public virtual decimal Price
        {
            get => price;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price not valid!");
                }
                price = value;
            }
        }
    }
}
