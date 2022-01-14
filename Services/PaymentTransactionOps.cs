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

        public async Task<PaymentTransaction> AddPaymentTransaction(PaymentTransaction paymentTransaction)
        {
            paymentTransaction.CreatedOn = DateTime.UtcNow;
            paymentTransaction.LastModifiedOn = DateTime.UtcNow;
            await context.PaymentTransactions.AddAsync(paymentTransaction);
            try
            {
                await context.SaveChangesAsync();
                return paymentTransaction;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<PaymentTransaction> DeletePaymentTransaction(int paymentTransactionId)
        {
            var paymentTransaction = await context.PaymentTransactions.FindAsync(paymentTransactionId);
            if (paymentTransaction != null)
            {
                context.PaymentTransactions.Remove(paymentTransaction);

                try
                {
                    await context.SaveChangesAsync();
                    return paymentTransaction;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
            return null;
        }

        public async Task<IEnumerable<PaymentTransaction>> GetAllPaymentTransaction()
        {
            return await context.PaymentTransactions.AsNoTracking().ToListAsync();
        }

        public async Task<PaymentTransaction> GetPaymentTransaction(int paymentTransactionId)
        {
            var paymentTransaction = await context.PaymentTransactions
                .AsNoTracking().FirstOrDefaultAsync(pt => pt.Id  == paymentTransactionId);
            return paymentTransaction;
        }

        public async Task<PaymentTransaction> UpdatePaymentTransaction(PaymentTransaction paymentTransaction)
        {
            paymentTransaction.LastModifiedOn = DateTime.UtcNow;
            context.PaymentTransactions.Update(paymentTransaction);
            try
            {
                await context.SaveChangesAsync();
                return paymentTransaction;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> UpdatePaymentTransactionStatus(int trnxId, string status)
        {
            var transaction = await context.PaymentTransactions.FindAsync(trnxId);
            if(transaction != null)
            {
                transaction.Status = status;
                try
                {
                    await context.SaveChangesAsync();
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
