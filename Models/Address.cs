using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Models
{
    public class Address
    {
        public int Id { get; set; }
        //Navigation property
        public Customer HomeCustomer { get; set; }
        //Navigation property
        public Customer BillingCustomer { get; set; }
        public string AddressLineOne { get; set; }
        public string AddressLineTwo { get; set; }
        public string Mobile { get; set; }
        public string AltMobile { get; set; }
        public string Zip { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
