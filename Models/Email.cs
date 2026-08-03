using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Digital_Services_BD.Models
{
    public class Email
    {
        public int Id { get; set; }
        public string FromAddress { get; set; }
        public string FromName { get; set; } = string.Empty;
        public IList<string> ToAddresses { get; set; }
        public string Subject { get; set; }
        public string BodyHtmlPart { get; set; }
        public string BodyTextPart { get; set; }
        public IList<Stream> Attachments { get; set; } = null;
        public IList<string> AttachmentNames { get; set; } = null;
        public IList<string> CcAddresses { get; set; } = null;
        public IList<string> BccAddresses { get; set; } = null;
        public IList<EmailLinkedResource> EmailLinkedResources { get; set; } = null;
    }

    public class EmailLinkedResource
    {
        public string ContentId { get; set; }
        public string ContentPath { get; set; }
        public string ContentType { get; set; }
        public byte[] ContentBytes { get; set; }
    }
}
