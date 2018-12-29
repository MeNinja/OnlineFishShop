﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace OnlineFishShop.Web.Infrastructure.WebServices
{
    public class CustomEmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
//            var client = new SmtpClient("yoursmtpserver")
//            {
//                UseDefaultCredentials = false,
//                Credentials = new NetworkCredential("yourusername", "yourpassword")
//            };
//
//            var mailMessage = new MailMessage
//            {
//                From = new MailAddress("account-security-noreply@yourdomain.com")
//            };
//
//            mailMessage.To.Add(email);
//            mailMessage.Subject = subject;
//            mailMessage.Body = htmlMessage;
//            return client.SendMailAsync(mailMessage);

            return Task.CompletedTask;
        }
    }
}
