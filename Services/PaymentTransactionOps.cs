using Digital_Services_BD.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Services
{
    public class PaymentTransactionOps : IPaymentTransactionOps
    {
        private readonly AppDbContext context;

        public PaymentTransactionOps(AppDbContext context)
        {
            this.context = context;
        }

        public PaymentTransaction AddPaymentTransaction(PaymentTransaction paymentTransaction)
        {
            paymentTransaction.CreatedOn = DateTime.UtcNow;
            paymentTransaction.LastModifiedOn = DateTime.UtcNow;
            context.PaymentTransactions.Add(paymentTransaction);
            try
            {
                context.SaveChanges();
                return paymentTransaction;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public PaymentTransaction DeletePaymentTransaction(int paymentTransactionId)
        {
            var paymentTransaction = context.PaymentTransactions.Find(paymentTransactionId);
            if (paymentTransaction != null)
            {
                context.PaymentTransactions.Remove(paymentTransaction);

                try
                {
                    context.SaveChanges();
                    return paymentTransaction;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
            return null;
        }

        public IEnumerable<PaymentTransaction> GetAllPaymentTransaction()
        {
            return context.PaymentTransactions.AsNoTracking().ToList();
        }

        public PaymentTransaction GetPaymentTransaction(int paymentTransactionId)
        {
            var paymentTransaction = context.PaymentTransactions.Find(paymentTransactionId);
            return paymentTransaction;
        }

        public PaymentTransaction UpdatePaymentTransaction(PaymentTransaction paymentTransaction)
        {
            paymentTransaction.LastModifiedOn = DateTime.UtcNow;
            context.PaymentTransactions.Update(paymentTransaction);
            try
            {
                context.SaveChanges();
                return paymentTransaction;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public PaymentTransaction UpdatePaymentTransaction(long trnxId, string status, string riskLevel, 
            string cardNo, string cardType, string currency, string bankTrnxId, string cardIssuer,
            string cardBrand, string cardIssuerCountry)
        {
            var transaction = context.PaymentTransactions.Find(trnxId);
            if(transaction != null)
            {
                transaction.Status = status;
                transaction.RiskLevel = riskLevel;
                transaction.CardNo = cardNo;
                transaction.CardType = cardType;
                transaction.GatewayCurrency = currency;
                transaction.BankTrnxId = bankTrnxId;
                transaction.CardIssuerBank = cardIssuer;
                transaction.CardBrand = cardBrand;
                transaction.CardIssuerCountry = cardIssuerCountry;
                try
                {
                    context.PaymentTransactions.Update(transaction);
                    context.SaveChanges();
                    return transaction;
                }
                catch(Exception e)
                {
                    return null;
                }
            }
            throw new NotImplementedException();
        }

        public bool UpdatePaymentTransactionStatus(long trnxId, string status)
        {
            var transaction = context.PaymentTransactions.Find(trnxId);
            if(transaction != null)
            {
                transaction.Status = status;
                context.PaymentTransactions.Update(transaction);
                try
                {
                    context.SaveChanges();
                    return true;
                }
                catch(Exception e)
                {
                    return false;
                }
            }
            return false;
        }
    }
}
