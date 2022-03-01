using exercicio_199.Entities;
using System.Collections.Generic;

namespace exercicio_199.Services {
    internal class ContractService {
        private IOnlinePaymentService _paymentService { get; set; }
        
        public ContractService(IOnlinePaymentService paymentService) { 
            _paymentService = paymentService;
        }

        public void ProcessContract(Contract contract, int months) {

            List<Installment> installments = new List<Installment>();

            for (int i = 0; i < months; i++) {

                double amount = (contract.TotalValue / months);
                amount += _paymentService.Interest(amount, i + 1);
                amount += _paymentService.PaymentFee(amount);

                installments.Add(new Installment(contract.Date.AddMonths(1), amount));
            }

            contract.Installments = installments;
        }
    }
}
