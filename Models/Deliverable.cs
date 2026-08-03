using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Models
{
    public class Deliverable
    {
        public Deliverable()
        {
            DeliverableItems = new HashSet<DeliverableItem>();
            DeliverableBundles = new HashSet<DeliverableBundle>();
        }
        public int Id { get; set; }
        public int OrderId { get; set; }

        public bool Completed { get; set; }
        public virtual Order Order { get; set; }
        public virtual ICollection<DeliverableItem> DeliverableItems { get; set; }
        public virtual ICollection<DeliverableBundle> DeliverableBundles { get; set; }
    }

    public class DeliverableItem
    {
        public int Id { get; set; }
        public int DeliverableId { get; set; }
        public int? OrderItemId { get; set; }
        public int? ProductStockId { get; set; }

        public virtual Deliverable Deliverable { get; set; }
        public virtual OrderItem OrderItem { get; set; }
        public virtual ProductStock ProductStock { get; set; }
    }

    public class DeliverableBundle
    {
        public DeliverableBundle()
        {
            DeliverableBundleItems = new HashSet<DeliverableBundleItem>();
        }
        public int Id { get; set; }
        public int DeliverableId { get; set; }
        public int ProductItemBundleId { get; set; }
        public virtual ICollection<DeliverableBundleItem> DeliverableBundleItems { get; set; }
        public virtual Deliverable Deliverable { get; set; }
        public virtual ProductItemBundle ProductItemBundle { get; set; }
    }

    public class DeliverableBundleItem
    {
        public int Id { get; set; }
        public int DeliverableBundleId { get; set; }
        public int? ProductStockId { get; set; }
        public virtual DeliverableBundle DeliverableBundle { get; set; }
        public virtual ProductStock ProductStock { get; set; }
    }
}
