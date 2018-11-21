namespace Exercise.Appenders
{
    using Exercise.Appenders.Contracts;
    using Exercise.Layouts;
    using Exercise.Loggers.Enums;
    using System;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            :base(layout)
        {
        }

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (reportLevel >= this.ReportLevel)
            {
                MessagesCount++;
                Console.WriteLine(string.Format(this.Layout.Format, dateTime, reportLevel, message));
            }
        }


        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {Layout.GetType().Name}, Report level: {ReportLevel.ToString().ToUpper()}, Messages appended: {MessagesCount}";
        }
    }
}
