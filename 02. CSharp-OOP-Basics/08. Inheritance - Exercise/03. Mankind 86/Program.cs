using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise
{
    class Program
    {
        static void Main()
        {
            string[] studentInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] workerInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string studentFirstName = studentInfo[0];
            string studentLastName = studentInfo[1];
            string facultyNumber = studentInfo[2];

            string workerFirstName = workerInfo[0];
            string workerLastName = workerInfo[1];
            decimal salary = decimal.Parse(workerInfo[2]);
            decimal workingHours = decimal.Parse(workerInfo[3]);

            try
            {
                Student student = new Student(studentFirstName, studentLastName, facultyNumber);
                Worker worker = new Worker(workerFirstName, workerLastName, salary, workingHours);

                Console.WriteLine(student);
                Console.WriteLine(worker);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}