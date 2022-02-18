using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio_137.Entities
{
    internal class Company : TaxPayer {
        public int NumberOfEmployees { get; set; }

        public Company() { }
        public Company(string name, double yearlyIncome, int numberOfEmployees) : base(name, yearlyIncome) {
            NumberOfEmployees = numberOfEmployees;
        }

        public override double Taxes() {
            if (NumberOfEmployees > 10) {
                return YearlyIncome * 0.14;
            }

            return YearlyIncome * 0.16;
        }
    }
}
