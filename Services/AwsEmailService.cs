using Digital_Services_BD.Models;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Digital_Services_BD.Services
{
    public class AwsEmailService : IEmailService
    {
        private readonly IOptions<AwsSesConfig> awsSesConfig;
        private readonly ILogger<AwsEmailService> logger;

        public AwsEmailService(IOptions<AwsSesConfig> awsSesConfig,
            ILogger<AwsEmailService> logger)
        {
            this.awsSesConfig = awsSesConfig;
            this.logger = logger;
        }
        public async Task<bool> SendEmailAsync(Email email)
        {
            if (email != null)
            {
                var mimeMessage = new MimeMessage();
                //Header part
                mimeMessage.From.Add(new MailboxAddress(email.FromName, awsSesConfig.Value.SenderAddress));
                foreach (var recipient in email.ToAddresses ?? new List<string> { })
                {
                    mimeMessage.To.Add(new MailboxAddress(string.Empty, recipient));
                }
                foreach (var cc in email.CcAddresses ?? new List<string> { })
                {
                    mimeMessage.Cc.Add(new MailboxAddress(string.Empty, cc));
                }
                foreach (var bcc in email.CcAddresses ?? new List<string> { })
                {
                    mimeMessage.Bcc.Add(new MailboxAddress(string.Empty, bcc));
                }
                mimeMessage.Subject = email.Subject;

                //Body part
                var bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = email.BodyHtmlPart;
                bodyBuilder.TextBody = email.BodyTextPart;
                if (email.Attachments != null)
                {
                    for (var i = 0; i < email.Attachments.Count; i++)
                    {
                        //If there is a filename in list with corresponding index
                        if (email.AttachmentNames.Count > i)
                        {
                            bodyBuilder.Attachments.Add(email.AttachmentNames[i], email.Attachments[i]);
                        }
                    }
                }
                mimeMessage.Body = bodyBuilder.ToMessageBody();
                try
                {
                    //Send email
                    using (var client = new SmtpClient())
                    {
                        await client.ConnectAsync(awsSesConfig.Value.SmtpHost, awsSesConfig.Value.SmtpPort, awsSesConfig.Value.EnableSsl);
                        await client.AuthenticateAsync(awsSesConfig.Value.SmtpUserName, awsSesConfig.Value.SmtpUserSecret);
                        await client.SendAsync(mimeMessage);
                        await client.DisconnectAsync(true);

                        logger.LogInformation($"An email is sent successfully to " +
                                $"{mimeMessage.To} on {DateTime.UtcNow:O}");
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    logger.LogError($"Failed to send an email to mimeMessage.To  " +
                           $"on {DateTime.UtcNow:O} due to error:" + ex.Message);
                    return false;
                }


            }
            logger.LogError($"Failed to send email from  " +
                           $"on {DateTime.UtcNow:O} due to null email object");
            return false;
        }
    }
}
