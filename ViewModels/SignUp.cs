using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using Digital_Services_BD.Models;

using Microsoft.AspNetCore.Http;

namespace Digital_Services_BD.ViewModels
{
    public class SignUp
    {
        [Required]
        [Display(Name = "First Name")]
        [MaxLength(35, ErrorMessage = "First Name should not contain more than 35 characters")]
        [RegularExpression("^[A-Z][a-zA-Z\\s]{1,34}$", ErrorMessage = "First Name should begin with an Uppercase letter and should contain at least 3 letters. No digit or special character is allowed")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        [MaxLength(35, ErrorMessage = "Last Name should not contain more than 35 characters")]
        [RegularExpression("^[A-Z][a-zA-Z\\s]{1,34}$", ErrorMessage = "Last Name should begin with an Uppercase letter and should contain at least 3 letters. No digit or special character is allowed")]
        public string LastName { get; set; }
        [Required]
        [MaxLength(254, ErrorMessage = "Email should not contain more than 254 characters")]
        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$", ErrorMessage = "The given email address is not valid")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [MaxLength(128, ErrorMessage = "Password can not contain more than 128 characters")]
        [MinLength(8, ErrorMessage = "Password must contain at least 8 characters")]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{8,128}$", ErrorMessage = "The given password is not valid")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and confirm password do not match. They should be same")]
        public string ConfirmPassword { get; set; }
    }
}
