using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ExcInterface.Services
{
    internal class PaypalService : IOnlinePaymentService
    {
        private const double InterestPerMonth = 0.01;
        private const double Fee = 0.02;

        public double Interest(double amount, int months)
        {
            return amount * InterestPerMonth * months;
        }

        public double FeePayment(double amount)
        {
            return amount * Fee;
        }
    }
}
