using System;
using System.Globalization;

double preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

double desconto;

desconto = (preco < 20) ? preco*0.1 : preco*0.05;

Console.WriteLine($"Desconto: ${desconto.ToString("F2",CultureInfo.InvariantCulture)}");