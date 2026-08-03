using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Models
{
    public class Address
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string CustomerId { get; set; }
        //True means home address
        public AddressType AddressType { get; set; }
        [Display(Name = "Address 1")]
        public string AddressLineOne { get; set; }
        [Display(Name = "Address 2")]
        public string AddressLineTwo { get; set; }
        [Display(Name = "Phone")]
        public string Mobile { get; set; }
        [Display(Name = "Other Phone")]

        public string AltMobile { get; set; }
        [Display(Name = "Post Code")]
        public string Zip { get; set; }
        [Display(Name = "Division")]
        public string State { get; set; }
        [Display(Name = "District")]
        public string City { get; set; }
        public string Country { get; set; }
        //Navigation property
        public virtual Customer Customer { get; set; }
    }
}
