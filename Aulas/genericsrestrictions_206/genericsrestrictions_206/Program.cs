using genericsrestrictions_206;
using genericsrestrictions_206.Entities;
using System.Globalization;

List<Product> list = new List<Product>();

Console.Write("Enter N: ");
int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++) {
    string[] productArgs = Console.ReadLine().Split(",");
    list.Add(new Product(productArgs[0], double.Parse(productArgs[1], CultureInfo.InvariantCulture)));
}

CalculationService calculationService = new CalculationService();
Product max = calculationService.Max(list);

Console.WriteLine($"Max: {max}");