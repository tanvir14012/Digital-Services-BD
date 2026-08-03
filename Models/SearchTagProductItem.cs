using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Models
{
    public class SearchTagProductItem
    {
        public SearchTagProductItem()
        {
            ProductItemJoinSearchTagProductItem = new HashSet<ProductItemJoinSearchTagProductItem>();
        }
        public int Id { get; set; }
        public string TagName { get; set; }
        //Ef core navigation properties
        public virtual ICollection<ProductItemJoinSearchTagProductItem> ProductItemJoinSearchTagProductItem { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastModifiedOn { get; set; }
    }
}
