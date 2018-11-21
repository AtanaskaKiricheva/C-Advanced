namespace Exercise.Loggers
{
    using Exercise.Appenders.Contracts;
    using Exercise.Loggers.Contracts;
    using Exercise.Loggers.Enums;

    public class Logger : ILogger
    {
        private readonly IAppender consoleAppender;
        private readonly IAppender fileAppender;

        public Logger(IAppender consoleAppender)
        {
            this.consoleAppender = consoleAppender;
        }
        public Logger(IAppender consoleAppender, IAppender fileAppender)
            : this(consoleAppender)
        {
            this.fileAppender = fileAppender;
        }

        public void Critical(string dateTime, string errorMessage)
        {
            AppendMessage(dateTime, ReportLevel.CRITICAL, errorMessage);
        }

        public void Error(string dateTime, string errorMessage)
        {
            AppendMessage(dateTime, ReportLevel.ERROR, errorMessage);
        }

        public void Fatal(string dateTime, string errorMessage)
        {
            AppendMessage(dateTime, ReportLevel.FATAL, errorMessage);
        }

        public void Info(string dateTime, string errorMessage)
        {
            AppendMessage(dateTime, ReportLevel.INFO, errorMessage);
        }

        public void Warning(string dateTime, string errorMessage)
        {
            AppendMessage(dateTime, ReportLevel.WARNING, errorMessage);
        }
        private void AppendMessage(string dateTime, ReportLevel reportLevel, string errorMessage)
        {
            this.fileAppender?.Append(dateTime, reportLevel, errorMessage);
            this.consoleAppender?.Append(dateTime, reportLevel, errorMessage);
        }
    }
}
