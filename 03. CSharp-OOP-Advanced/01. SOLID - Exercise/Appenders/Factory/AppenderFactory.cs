using Exercise.Appenders.Contracts;
using Exercise.Layouts;
using Exercise.Loggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Appenders.Factory
{
    public class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(string type, ILayout layout)
        {
            string typeToLower = type.ToLower();

            switch (typeToLower)
            {
                case "consoleappender":
                    return new ConsoleAppender(layout);
                case "fileappender":
                    return new FileAppender(layout, new LogFile());
                default: throw new ArgumentException("Invalid appender type");
            }
        }
    }
}
