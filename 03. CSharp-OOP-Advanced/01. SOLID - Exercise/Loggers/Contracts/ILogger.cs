namespace Exercise.Loggers.Contracts
{
  
    public interface ILogger
    {
        void Error(string dateTime, string errorMessage);
        void Info(string dateTime, string errorMessage);
        void Warning(string dateTime, string errorMessage);
        void Critical(string dateTime, string errorMessage);
        void Fatal(string dateTime, string errorMessage);
    }
}
