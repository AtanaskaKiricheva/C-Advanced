using Exercise.Appenders.Contracts;
using Exercise.Loggers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise.Loggers
{
    public class LogFile : ILogFile
    {
        private int size;
        private readonly IAppender appender;

        public LogFile()
        {

        }
        public LogFile(IAppender appender)
        {
            this.appender = appender;
        }
        public void Write(string message)
        {
            this.Size += message.Where(char.IsLetter).Sum(x => x);
        }

        public int Size { get => size; private set => size = value; }
    }
}
