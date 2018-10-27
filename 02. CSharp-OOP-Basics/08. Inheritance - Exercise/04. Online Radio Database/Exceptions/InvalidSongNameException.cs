using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Exceptions
{
    public class InvalidSongNameException : InvalidSongException
    {
        private const string message = "Song name should be between 3 and 30 symbols.";

        public override string Message => message;
    }
}
