using DTO.Configuration;
using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Data.Infrastructure.Email
{
    
    public class EmailSender : IEmailSender
    {
        public void SendEmail(EmailAccount emailAccount,
            string subject, string body,
            string fromAddress,
            string fromName,
            string toAddress,
            string toName,
            IList<string> bcc = null,
            IList<string> cc = null)
        {
            var message = new MailMessage
            {
                From = new MailAddress(fromAddress, fromName)
            };
            message.To.Add(new MailAddress(toAddress, toName));
            if (cc != null)
            {
                foreach (var address in cc)
                {
                    message.CC.Add(address.Trim());
                }
            }
            if (bcc != null)
            {
                foreach (var address in bcc)
                {
                    message.CC.Add(address.Trim());
                }
            }
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.UseDefaultCredentials = emailAccount.UseDefaultCredentials;
                smtpClient.Host = emailAccount.Host;
                smtpClient.Port = emailAccount.Port;
                smtpClient.EnableSsl = emailAccount.EnableSsl;
                smtpClient.Credentials = new NetworkCredential(emailAccount.Username, emailAccount.Password);
                smtpClient.Send(message);
            }
        }
    }
}
