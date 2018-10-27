using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Exceptions
{
    public class InvalidSongMinutesException : InvalidSongLengthException
    {
        private const string message = "Song minutes should be between 0 and 14.";

        public override string Message => message;
    }
}
