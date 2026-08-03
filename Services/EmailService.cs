using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Digital_Services_BD.Models;

using MailKit.Net.Smtp;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using MimeKit;

namespace Digital_Services_BD.Services
{
    public class EmailService : IEmailService
    {
        private readonly AppDbContext context;
        private readonly ILogger<EmailService> logger;


        public EmailService(AppDbContext context, ILogger<EmailService> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        public async Task<bool> SendEmailAsync(Email email)
        {
            var smtpCofig = await context.SmtpConfigs.AsNoTracking().FirstOrDefaultAsync();
            if (email != null && smtpCofig != null)
            {
                var mimeMessage = new MimeMessage();
                //Header part
                mimeMessage.From.Add(new MailboxAddress(email.FromName, email.FromAddress));
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

                if (email.EmailLinkedResources != null)
                {
                    foreach (var linkedRsrc in email.EmailLinkedResources)
                    {
                        var mimeEntity = bodyBuilder.LinkedResources.Add(linkedRsrc.ContentPath, linkedRsrc.ContentBytes,
                            ContentType.Parse(linkedRsrc.ContentType));
                        mimeEntity.ContentId = linkedRsrc.ContentId;
                    }
                }

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
                    using var client = new SmtpClient();
                    await client.ConnectAsync(smtpCofig.Server, smtpCofig.Port, smtpCofig.UseSecureConnection);
                    if (smtpCofig.UseAuthentication)
                    {
                        await client.AuthenticateAsync(smtpCofig.Username, smtpCofig.Password);
                    }
                    await client.SendAsync(mimeMessage);
                    await client.DisconnectAsync(true);

                    logger.LogInformation($"An email is sent successfully to " +
                            $"{mimeMessage.To} on {DateTime.UtcNow:O}");
                    return true;
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
