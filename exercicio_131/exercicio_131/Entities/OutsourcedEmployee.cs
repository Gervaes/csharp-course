using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio_131.Entities
{
    internal class OutsourcedEmployee : Employee {
        public double AdditionalCharge { get; set; }

        public OutsourcedEmployee() : base() { }

        public OutsourcedEmployee(string name, int hours, double valuePerHour, double additionalCharge) : base(name, hours, valuePerHour) {
            AdditionalCharge = additionalCharge;
        }

        public override double Payment() {
            double total = base.Payment();
            return total += 1.1*AdditionalCharge;
        }
    }
}
