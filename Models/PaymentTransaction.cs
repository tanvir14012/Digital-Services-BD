using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using Digital_Services_BD.Utilities;

namespace Digital_Services_BD.Models
{
    public class PaymentTransaction
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public int OrderId { get; set; }

        [Encrypted]
        public string SurjoPayOrderId { get; set; }
        public int SurjoPayCode { get; set; }
        public string SurjoPayMsg { get; set; }
        public string TrnxMethod { get; set; }
        public string CardHolderName { get; set; }
        public string CardNo { get; set; }
        public string BankTrnxId { get; set; }
        public string CardIssuerBank { get; set; }
        public string CardIssuerCountry { get; set; }
        public string BankStatus { get; set; }
        public string InvoiceId { get; set; }
        public string Name { get; set; }

        [Encrypted]
        public string Email { get; set; }

        [Encrypted]
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
        public string RiskLevel { get; set; }
        public decimal AmountInUSD { get; set; }
        public decimal RateOfUSD { get; set; }

        [Encrypted]
        public string UserVerificationToken { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastModifiedOn { get; set; }

        public virtual Order Order { get; set; }
    }
}
