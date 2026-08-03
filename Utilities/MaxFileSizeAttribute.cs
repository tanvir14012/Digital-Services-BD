using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

namespace Digital_Services_BD.Utilities
{
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int maxSize;

        public MaxFileSizeAttribute(int maxSize)
        {
            this.maxSize = maxSize * 1024 * 1024; //Convert MB to byte
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null && file.Length > this.maxSize)
            {
                return new ValidationResult($"Image file size can not be greater than {this.maxSize / (1024.00 * 1024)} MB");
            }
            return ValidationResult.Success;
        }
    }
}
