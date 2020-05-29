using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Models
{
    public class Customer: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int HomeAddrId { get; set; }
        public Address HomeAddress { get; set; }
        public int BillingAddrId { get; set; }
        public Address BillingAddress { get; set; }
        public string ProfilePicLink { get; set; }
        public DateTime BirthDate { get; set; }
        public string IdCardNo { get; set; }
        public string IdCardType { get; set; }
        public string IdCardVerifyPic { get; set; }
        public bool IsVerified { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
