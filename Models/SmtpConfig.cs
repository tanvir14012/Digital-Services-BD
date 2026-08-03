using System;
using System.ComponentModel.DataAnnotations;

using Digital_Services_BD.Utilities;

namespace Digital_Services_BD.Models
{
    public partial class SmtpConfig
    {
        public short? Id { get; set; }
        public string Server { get; set; }

        [Encrypted]
        public string Username { get; set; }

        [Encrypted]
        public string Password { get; set; }
        public string FromName { get; set; }
        public string FromAddress { get; set; }
        public short Port { get; set; }
        public bool UseAuthentication { get; set; }
        public bool UseSecureConnection { get; set; }
        public string? CreatedUserId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string? UpdatedUserId { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
    }
}
