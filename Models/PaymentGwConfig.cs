using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Models
{
    public partial class PaymentGwConfig
    {
        public short? Id { get; set; }

        [Required]
        [Display(Name = "Gateway Name")]
        [MaxLength(100)]
        public string GwName { get; set; }

        [Required]
        [Encrypted]
        [Display(Name = "Merchant Username")]
        public string Username { get; set; }

        [Required]
        [Encrypted]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Payment Redirect URL")]
        [MaxLength(150)]
        public string RedirectUrl { get; set; }

        [Required]
        [Display(Name = "Success return URL")]
        [MaxLength(150)]
        public string SuccessCallbackUrl { get; set; }

        [Required]
        [Display(Name = "Cancel return URL")]
        [MaxLength(150)]
        public string CancelCallbackUrl { get; set; }

        [Required]
        [Display(Name = "Fail return URL")]
        [MaxLength(150)]
        public string FailCallbackUrl { get; set; }

        [MaxLength(150)]
        public string ApiRoot { get; set; }
        public string Data_a { get; set; }
        public string Data_b { get; set; }
        public string Data_c { get; set; }
        public string Data_d { get; set; }
        public string Data_e { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
