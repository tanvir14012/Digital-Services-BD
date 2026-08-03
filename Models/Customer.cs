using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Digital_Services_BD.Models
{
    public class Customer : IdentityUser
    {
        public Customer()
        {
            Addresses = new HashSet<Address>();
            AddressIds = new List<int>();
            Orders = new HashSet<Order>();
        }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public string? ProfilePicLink { get; set; }
        public DateTime BirthDate { get; set; }
        public string? IdCardNo { get; set; }
        public IdCardType IdCardType { get; set; }
        public string? IdCardVerifyPic { get; set; }
        public bool IsVerified { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        //Navigation property
        public virtual ICollection<Address> Addresses { get; set; }
        [BindProperty]
        public virtual ICollection<int> AddressIds { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
