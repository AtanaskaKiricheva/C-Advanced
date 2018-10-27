using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Exceptions
{
    public class InvalidSongSecondsException : InvalidSongLengthException
    {
        private const string message = "Song seconds should be between 0 and 59.";

        public override string Message => message;
    }
}
