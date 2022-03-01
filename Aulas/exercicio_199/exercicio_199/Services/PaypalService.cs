using exercicio_199.Entities;
using exercicio_199.Services;

namespace exercicio_199.Services
{
    class PaypalService : IOnlinePaymentService {
    
        public double PaymentFee(double amount) {
            return amount * 0.02;
        }

        public double Interest(double amount, int months) {
            return amount * 0.01 * months;
        }
    }
}
