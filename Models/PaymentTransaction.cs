using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Models
{
    public class PaymentTransaction
    {
        public long Id { get; set; }
        public string Status { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public string TrnxType { get; set; }
        public string CardType { get; set; }
        public string CardNo { get; set; }
        public string BankTrnxId { get; set; }
        public string CardIssuerBank { get; set; }
        public string CardIssuerCountry { get; set; }
        public string CardBrand { get; set; }
        public string IPAddr { get; set; }
        public string StatementShow { get; set; }
        public string GatewayCurrency { get; set; }
        public decimal Amount { get; set; }
        public string RiskLevel { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastModifiedOn { get; set; }
    }
}
