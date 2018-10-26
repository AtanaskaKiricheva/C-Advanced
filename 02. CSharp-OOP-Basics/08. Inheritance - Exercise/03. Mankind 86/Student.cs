using System;
using System.Linq;

namespace Exercise
{
    public class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber)
            : base(firstName, lastName)
        {
            FacultyNumber = facultyNumber;
        }

        public override string ToString()
        {
            return base.ToString() + $"Faculty number: {facultyNumber}\n";
        }

        public string FacultyNumber
        {
            get => facultyNumber;
            set
            {
                if (value.Length < 5 || value.Length > 10 || !value.All(char.IsLetterOrDigit))
                {
                    throw new ArgumentException("Invalid faculty number!");
                }
                facultyNumber = value;
            }
        }
    }
}
