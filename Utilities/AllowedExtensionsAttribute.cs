using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

namespace Digital_Services_BD.Utilities
{
    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] extensions;

        public AllowedExtensionsAttribute(string[] extensions)
        {
            this.extensions = extensions;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            var extension = "";
            if (file != null)
            {
                extension = Path.GetExtension(file.FileName).Replace(".", "");
            }
            if (file != null && !this.extensions.Contains(extension.ToLower()))
            {
                return new ValidationResult($"Image file must end with one of the following extensions [{string.Join(", ", this.extensions)}]");
            }
            return ValidationResult.Success;
        }
    }
}
