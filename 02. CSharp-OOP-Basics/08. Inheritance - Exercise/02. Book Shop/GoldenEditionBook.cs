using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise
{
    public class GoldenEditionBook : Book
    {

        public GoldenEditionBook(string title, string author, decimal price)
            : base(title, author, price)
        {
            base.Price += price * 0.3m;
        }

    }
}
