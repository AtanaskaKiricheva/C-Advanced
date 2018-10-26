using System;

namespace Exercise
{
    public abstract class Human
    {
        private string firstName;
        private string lastName;

        public Human(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString()
        {
            return $"First Name: {firstName}\r\nLast Name: {lastName}\r\n";
        }

        private string Uppercase(string arg)
        {
            return $"Expected upper case letter! Argument: {arg}";
        }
        private string Length(string arg, int symbols)
        {
            return $"Expected length at least {symbols} symbols! Argument: {arg}";
        }

        public string FirstName
        {
            get => firstName;
            set
            {
                if (value[0].ToString() != value[0].ToString().ToUpper())
                {
                    throw new ArgumentException(Uppercase("firstName"));
                }
                else if (value.Length < 4)
                {
                    throw new ArgumentException(Length("firstName",4));
                }
                firstName = value;
            }
        }
        public string LastName
        {
            get => lastName;
            set
            {
                if (value[0].ToString() != value[0].ToString().ToUpper())
                {
                    throw new ArgumentException(Uppercase("lastName"));
                }
                else if (value.Length < 3)
                {
                    throw new ArgumentException(Length("lastName",3));
                }
                lastName = value;
            }
        }
    }
}
