using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio_199.Services
{
    interface IOnlinePaymentService {

        double PaymentFee(double amount);
        double Interest(double amount, int months);
    }
}
