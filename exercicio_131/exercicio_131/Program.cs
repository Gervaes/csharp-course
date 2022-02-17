using System;
using System.Globalization;
using exercicio_131.Entities;

Console.Write("Enter the number of employees: ");
int n = int.Parse(Console.ReadLine());

List<Employee> employees = new List<Employee>();

for (int i = 0; i < n; i++) {
    Console.WriteLine($"Employee #{i+1} data:");
    Console.Write("Outsourced (y/n)? ");
    char outsourced = char.Parse(Console.ReadLine());
    Console.Write("Name: ");
    string name = Console.ReadLine();
    Console.Write("Hours: ");
    int hours = int.Parse(Console.ReadLine());
    Console.Write("Value per hour: ");
    double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

    Employee emp;

    if(outsourced == 'y') {
        Console.Write("Additional Charge: ");
        double addCharge = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        emp = new OutsourcedEmployee(name, hours, valuePerHour, addCharge);
    } else
    {
        emp = new Employee(name, hours, valuePerHour);//
    }

    employees.Add(emp);
}

Console.WriteLine();
Console.WriteLine("PAYMENTS");

foreach (Employee employee in employees) {
    Console.WriteLine($"{employee.Name} - ${employee.Payment().ToString("F2", CultureInfo.InvariantCulture)}");
}