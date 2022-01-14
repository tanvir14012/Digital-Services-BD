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
            OrderItems = new HashSet<OrderItem>();
            OrderProductItemBundles = new HashSet<OrderProductItemBundle>();
        }
        public int Id { get; set; }
        public int CartId { get; set; }
        public string ConfirmEmail { get; set; }
        public string CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public int? BillingAddressId { get; set; }
        public virtual Address BillingAddress { get; set; }
        public decimal Subtotal { get; set; }
        public string PromoCode { get; set; }
        public decimal PromoCodeDiscount { get; set; }
        public decimal DiscountTotal { get; set; }
        public decimal TaxesAndFees { get; set; }
        public decimal GrandTotal { get; set; }
        public string PriceCurrency { get; set; }
        public bool SendOfferInMail { get; set; }

        public int? TransactionId { get; set; }
        public int? DeliverableId { get; set; }
        public bool IsAnonymousOrder { get; set; } = false;
        public OrderStatus Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public virtual PaymentTransaction Transaction { get; set; }
        public virtual Deliverable Deliverable { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<OrderProductItemBundle> OrderProductItemBundles { get; set; }
    }
}
