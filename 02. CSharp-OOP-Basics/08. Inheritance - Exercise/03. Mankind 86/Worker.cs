using System;

namespace Exercise
{
    public class Worker : Human
    {
        private decimal weekSalary;
        private decimal workHoursPerDay;

        public Worker(string firstName, string lastName, decimal weekSalary, decimal workHoursPerDay)
            : base(firstName, lastName)
        {
            WeekSalary = weekSalary;
            WorkHoursPerDay = workHoursPerDay;
        }

        public decimal SalaryPerHour()
        {
            return (weekSalary / 5) / workHoursPerDay;
        }

        public override string ToString()
        {
            return base.ToString() + $"Week Salary: {weekSalary:f2}\r\nHours per day: {workHoursPerDay:f2}\r\nSalary per hour: {SalaryPerHour():f2}";
        }
        public decimal WeekSalary
        {
            get => weekSalary;
            set
            {
                if (value < 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }
                weekSalary = value;
            }
        }
        public decimal WorkHoursPerDay
        {
            get => workHoursPerDay;
            set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }
                workHoursPerDay = value;
            }
        }
    }
}
