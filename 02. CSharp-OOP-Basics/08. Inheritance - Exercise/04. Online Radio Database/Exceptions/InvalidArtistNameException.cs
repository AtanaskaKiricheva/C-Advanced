using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Exceptions
{
    public class InvalidArtistNameException : InvalidSongException
    {
        private const string message = "Artist name should be between 3 and 20 symbols.";
        public override string Message => message;
    }
}
