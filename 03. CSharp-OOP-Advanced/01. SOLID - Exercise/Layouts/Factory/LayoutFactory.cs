using Exercise.Layouts.Factory.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Layouts.Factory
{
    public class LayoutFactory : ILayoutFactory
    {
        public ILayout CreateLayout(string type)
        {
            type = type.ToLower();

            switch (type)
            {
                case "simplelayout":
                    return new SimpleLayout();
                case "xmllayout":
                    return new XmlLayout();
                default: throw new ArgumentException("Invalid layout type");
            }
        }
    }
}
