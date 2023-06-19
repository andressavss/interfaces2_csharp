using ExcInterface.Entities;
using System;

namespace ExcInterface.Services
{
    internal class ProcessContractService
    {
        private IOnlinePaymentService _onlinePaymentService;

        public ProcessContractService(IOnlinePaymentService onlinePaymentService)
        {
            _onlinePaymentService = onlinePaymentService;
        }

        public void ProcessContract(Contract contract, int months)
        {
            double basicQuota = contract.TotalValue / months;

            for (int i = 0; i < months; i++)
            {
                DateTime date = contract.Date.AddMonths(i);

                double updateQuota = basicQuota + _onlinePaymentService.Interest(basicQuota, i);
                double fullQuota = updateQuota + _onlinePaymentService.FeePayment(updateQuota);

                contract.AddInstallment(new Installment(date, fullQuota));
            }
        }
    }
}
