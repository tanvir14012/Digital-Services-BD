using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Digital_Services_BD.Models;

namespace Digital_Services_BD.Services
{
    public interface IPaymentTransactionOps
    {
        Task<PaymentTransaction> AddPaymentTransaction(PaymentTransaction paymentTransaction);
        Task<IEnumerable<PaymentTransaction>> GetAllPaymentTransaction();
        Task<PaymentTransaction> GetPaymentTransaction(int paymentTransactionId);
        Task<PaymentTransaction> UpdatePaymentTransaction(PaymentTransaction paymentTransaction);
        Task<PaymentTransaction> DeletePaymentTransaction(int paymentTransactionId);
        Task<bool> UpdatePaymentTransactionStatus(int trnxId, string status);
    }
}
