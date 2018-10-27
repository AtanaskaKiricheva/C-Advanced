using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Exceptions
{
    public class InvalidSongException : Exception
    {
        private const string message = "Invalid song.";

        public override string Message => message;

    }
}
