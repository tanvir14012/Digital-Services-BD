using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Models
{
    public class AwsSesConfig
    {
        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        public bool EnableSsl { get; set; }
        public string SenderAddress { get; set; }
        public string SmtpUserName { get; set; }
        public string SmtpUserSecret { get; set; }
    }
}
