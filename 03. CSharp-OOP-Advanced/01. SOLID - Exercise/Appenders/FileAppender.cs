namespace Exercise.Appenders
{
    using Exercise.Appenders.Contracts;
    using Exercise.Layouts;
    using Exercise.Loggers.Contracts;
    using Exercise.Loggers.Enums;
    using System.IO;

    public class FileAppender : Appender
    {
        private const string path = "log.txt";
        private readonly ILogFile logFile;

        public FileAppender(ILayout layout, ILogFile logFile)
            :base(layout)
        {
            this.logFile = logFile;
        }

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (reportLevel >= this.ReportLevel)
            {
                MessagesCount++;
                string content = string.Format(this.Layout.Format, dateTime, reportLevel, message) + "\r\n";
                File.AppendAllText(path, content);
                logFile.Write(content);
            }
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {Layout.GetType().Name}, Report level: {ReportLevel.ToString().ToUpper()}, Messages appended: {MessagesCount}, File size: {logFile.Size}";
        }
    }
}
