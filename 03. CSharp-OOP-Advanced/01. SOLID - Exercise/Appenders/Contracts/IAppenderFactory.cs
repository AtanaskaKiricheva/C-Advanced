using Exercise.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Appenders.Contracts
{
    public interface IAppenderFactory
    {
        IAppender CreateAppender(string type, ILayout layout);
    }
}
