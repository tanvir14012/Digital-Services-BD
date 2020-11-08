using Digital_Services_BD.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Digital_Services_BD.Models
{
    public class Order
    {
        public Order()
        {
            BillingAddress = new Address();
        }
        public int Id { get; set; }
        public int CartId { get; set; }
        public CartViewModel Cart { get; set; }
        public string ConfirmEmail { get; set; }
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int? BillingAddressId { get; set; }
        public Address BillingAddress { get; set; }

        public decimal TotalPrice { get; set; }
        public string PriceCurrency { get; set; }
        public bool SendOfferInMail { get; set; }

        public long? TransactionId { get; set; }
        public PaymentTransaction Transaction { get; set; }
        public bool IsAnonymousOrder { get; set; } = false;

        public DateTime CreatedOn { get; set; }
        public DateTime LastModifiedOn { get; set; }
    }
}
