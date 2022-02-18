using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio_137.Entities
{
    internal class Individual : TaxPayer {
        public double HealthcareSpendings { get; set; }

        public Individual() { }
        public Individual(string name, double yearlyIncome, double healthcareSpendings) : base(name, yearlyIncome) { 
            HealthcareSpendings = healthcareSpendings;
        }

        public override double Taxes() {
            if(YearlyIncome < 20000.00) {
                return YearlyIncome * 0.15;
            }

            return YearlyIncome * 0.25 - HealthcareSpendings * 0.5;
        }
    }
}
