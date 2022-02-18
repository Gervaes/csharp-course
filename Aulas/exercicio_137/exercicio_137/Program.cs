using exercicio_137.Entities;
using System.Globalization;

List<TaxPayer> taxPayers = new List<TaxPayer>();

Console.Write("Enter the number of tax payers: ");
int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++) {
    Console.WriteLine($"Tax payer #{i+1} data:");
    Console.Write("Individual or company (i/c): ");
    char type = char.Parse(Console.ReadLine());
    Console.Write("Name: ");
    string name = Console.ReadLine();
    Console.Write("Anual income: ");
    double yearlyIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

    if(type == 'i') {
        Console.Write("Health Expenditures: ");
        double healthcareSpendings = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        taxPayers.Add(new Individual(name, yearlyIncome, healthcareSpendings));
    } else if(type == 'c') {
        Console.Write("Number of employees: ");
        int numberOfEmployees = int.Parse(Console.ReadLine());

        taxPayers.Add(new Company(name, yearlyIncome, numberOfEmployees));
    }
}

double sum = 0;

Console.WriteLine();
Console.WriteLine("TAXES PAID:");
foreach (TaxPayer taxPayer in taxPayers) {
    double taxes = taxPayer.Taxes();
    sum += taxes;
    Console.WriteLine($"{taxPayer.Name}: ${taxes.ToString("F2", CultureInfo.InvariantCulture)}");
}

Console.WriteLine();
Console.WriteLine($"TOTAL TAXES: ${sum.ToString("F2", CultureInfo.InvariantCulture)}");

