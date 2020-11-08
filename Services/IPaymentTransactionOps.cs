using Digital_Services_BD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Services
{
    public interface IPaymentTransactionOps
    {
        PaymentTransaction AddPaymentTransaction(PaymentTransaction paymentTransaction);
        IEnumerable<PaymentTransaction> GetAllPaymentTransaction();
        PaymentTransaction GetPaymentTransaction(int paymentTransactionId);
        PaymentTransaction UpdatePaymentTransaction(PaymentTransaction paymentTransaction);
        PaymentTransaction UpdatePaymentTransaction(long trnxId, string status, string riskLevel,
            string cardNo, string cardType, string currency, string bankTrnxId, string cardIssuer, string cardBrand, string cardIssuerCountry);
        PaymentTransaction DeletePaymentTransaction(int paymentTransactionId);
        public bool UpdatePaymentTransactionStatus(long trnxId, string status);
    }
}
