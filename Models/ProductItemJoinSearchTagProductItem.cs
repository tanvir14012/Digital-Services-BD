using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Models
{
    /// <summary>
    /// Join table that joins tables productItem, searchTagProductItem
    /// </summary>
    public class ProductItemJoinSearchTagProductItem
    {
        //Foreign keys
        public int ProductItemId { get; set; }
        public int SearchTagProductItemId { get; set; }
        //Navigation properties
        public virtual ProductItem ProductItem { get; set; }
        public virtual SearchTagProductItem SearchTagProductItem { get; set; }
    }
}
