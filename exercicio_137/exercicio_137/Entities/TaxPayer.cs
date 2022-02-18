using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio_137.Entities
{
    abstract class TaxPayer {
        public string Name { get; set; }
        public double YearlyIncome { get; set; }

        public TaxPayer() { }

        public TaxPayer(string name, double yearlyIncome) { 
            Name = name;
            YearlyIncome = yearlyIncome;
        }

        public abstract double Taxes();
    }
}
