using System;

namespace ExcInterface.Services
{
    internal interface IOnlinePaymentService 
    { 
        public double Interest(double amount, int months);
        public double FeePayment(double amount);
    }
}
