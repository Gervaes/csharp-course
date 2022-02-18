using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course {
    internal class Product {
        public string Name { get; set; }
        public double Price { get; set; }
    }
}

/*
 int n = int.Parse(Console.ReadLine());

            Product[] vect = new Product[n];

            for (int i = 0; i < n; i++) {

                string name = Console.ReadLine();
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                vect[i] = new Product { Name = name, Price = price };
            }

            double sum = 0.0;

            for (int i = 0;i < vect.Length;i++) { 
                sum+=vect[i].Price;
            }

            double avg = sum/n;

            Console.WriteLine($"Average price: {avg.ToString("F2",CultureInfo.InvariantCulture)}");
 */