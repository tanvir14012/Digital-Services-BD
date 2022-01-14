using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.ViewModels
{
    public class UpdateEncryptionKey
    {
        [Required]
        public string OldKey { get; set; }

        [Required]
        public string NewKey { get; set; }

        [Required]
        [Compare("NewKey")]
        public string ConfirmNewKey { get; set; }
    }
}
