using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            List<Employee> employees = new List<Employee>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();

                string name = data[0];
                decimal salary = decimal.Parse(data[1]);
                string position = data[2];
                string department = data[3];
                string email = "n/a";
                int age = -1;

                if (data.Length > 4)
                {
                    if (int.TryParse(data[4], out int result))
                    {
                        age = result;
                    }
                    else
                    {
                        email = data[4];
                    }
                    if (data.Length > 5)
                    {
                        age = int.Parse(data[5]);
                    }
                }

                Employee employee = new Employee(name, salary, position, department, email, age);
                employees.Add(employee);
            }

            var topDepartment = employees.GroupBy(x => x.Department).OrderByDescending(x => x.Average(s => s.Salary)).FirstOrDefault();

            Console.WriteLine($"Highest Average Salary: {topDepartment.Key}");

            foreach (var item in topDepartment.OrderByDescending(x=>x.Salary))
            {
                Console.WriteLine($"{item.Name} {item.Salary:f2} {item.Email} {item.Age}");
            }
        }
    }
}
