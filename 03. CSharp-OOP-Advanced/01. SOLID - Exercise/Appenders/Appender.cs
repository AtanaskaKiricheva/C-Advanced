using Exercise.Appenders.Contracts;
using Exercise.Layouts;
using Exercise.Loggers.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Appenders
{
    public abstract class Appender : IAppender
    {
        private readonly ILayout layout;

        protected Appender(ILayout layout)
        {
            this.layout = layout;
        }

        protected ILayout Layout => this.layout;
        public ReportLevel ReportLevel { get; set; }

        public int MessagesCount { get; protected set; }

        public abstract void Append(string dateTime, ReportLevel reportLevel, string message);

    }
}
