using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.ViewModels
{
    public class ResetPassword
    {
        public string Id { get; set; }
        public string Token { get; set; }
        [Required]
        [MaxLength(128, ErrorMessage = "Password can not contain more than 128 characters")]
        [MinLength(8, ErrorMessage = "Password must contain at least 8 characters")]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{8,128}$", ErrorMessage = "The given password is not valid. Password must be minimum 8 characters long and must have 1  uppercase letter, 1 lowercase letter, 1 digit and 1 special character(e.g. !#)")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and confirm password do not match. They should be same")]
        public string ConfirmPassword { get; set; }
    }
}
