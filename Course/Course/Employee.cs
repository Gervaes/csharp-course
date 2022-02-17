using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Course {
    internal class Employee {

        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }

        public override string ToString() {
            return $"{Id}, {Name}, {Salary.ToString("F2", CultureInfo.InvariantCulture)}";
        }
        public void increaseSalary(double percentage) {
            Salary *= (1 + (percentage/100));
        }
    }
}

/*
            List<Employee> employees = new List<Employee>();

            Console.Write("How many employees will be registered? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++) {
                Console.WriteLine();
                Console.WriteLine($"Employee #{i+1}");
                Console.Write("Id: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Salary: ");
                double salary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                employees.Add(new Employee { Id = id, Name = name, Salary = salary });
            }

            Console.WriteLine();
            Console.Write("Enter the employee id that will have salary increase: ");
            int employeeId = int.Parse(Console.ReadLine());
            int index = employees.FindIndex(e => e.Id == employeeId);
            double percentage;

            if (index != -1) {
                Console.Write("Enter the percentage: ");
                percentage = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                employees[index].increaseSalary(percentage);
            } else {
                Console.WriteLine("This id does not exist!");
            }

            Console.WriteLine();
            Console.WriteLine("Updated list of employees:");
            foreach (Employee employee in employees) {
                Console.WriteLine(employee);
            }
 
 */