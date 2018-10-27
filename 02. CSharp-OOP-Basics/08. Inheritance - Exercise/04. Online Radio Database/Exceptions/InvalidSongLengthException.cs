using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Exceptions
{
    public class InvalidSongLengthException : InvalidSongException
    {
        private const string message = "Invalid song length.";

        public override string Message => message;
    }
}
