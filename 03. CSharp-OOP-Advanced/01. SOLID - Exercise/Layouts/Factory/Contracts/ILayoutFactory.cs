using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Layouts.Factory.Contracts
{
    public interface ILayoutFactory
    {
        ILayout CreateLayout(string type);
    }
}
