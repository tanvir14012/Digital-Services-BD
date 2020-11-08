using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Models
{
    public class Email
    {
        public long Id { get; set; }
        public string FromAddress { get; set; }
        public string FromName { get; set; } = string.Empty;
        public List<string> ToAddresses { get; set; }
        public string Subject { get; set; }
        public string BodyHtmlPart { get; set; }
        public string BodyTextPart { get; set; }
        public List<Stream> Attachments { get; set; } = null;
        public List<string> AttachmentNames { get; set; } = null;
        public List<string> CcAddresses { get; set; } = null;
        public List<string> BccAddresses { get; set; } = null;
    }
}
