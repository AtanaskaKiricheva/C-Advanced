using Exercise.Appenders.Contracts;
using Exercise.Appenders.Factory;
using Exercise.Core.Contracts;
using Exercise.Layouts;
using Exercise.Layouts.Factory;
using Exercise.Layouts.Factory.Contracts;
using Exercise.Loggers.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private ICollection<IAppender> appenders;
        private IAppenderFactory appenderFactory;
        private ILayoutFactory layoutFactory;

        public CommandInterpreter()
        {
            appenders = new List<IAppender>();
            appenderFactory = new AppenderFactory();
            layoutFactory = new LayoutFactory();
        }

        public void AddAppender(string[] args)
        {
            string appenderType = args[0];
            string layoutType = args[1];
            ReportLevel reportLevel = ReportLevel.INFO;

            if (args.Length == 3)
            {
                reportLevel = Enum.Parse<ReportLevel>(args[2]);
            }
            ILayout layout = layoutFactory.CreateLayout(layoutType);
            IAppender appender = appenderFactory.CreateAppender(appenderType, layout);
            appender.ReportLevel = reportLevel;
            this.appenders.Add(appender);
        }

        public void AddMessage(string[] args)
        {
            ReportLevel reportLevel = Enum.Parse<ReportLevel>(args[0]);
            string dateTime = args[1];
            string message = args[2];

            foreach (var appender in appenders)
            {
                appender.Append(dateTime, reportLevel, message);
            }
        }

        public void PrintInfo()
        {
            Console.WriteLine("Logger info");

            foreach (var appender in appenders)
            {
                Console.WriteLine(appender);
            }

        }
    }
}
