using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Cyberpalata.Logic.Interfaces.Services;

namespace Cyberpalata.Logic.Services
{
    internal class MailService : IMailService
    {
        private readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendMail(string emailTo, string subject, string body)
        {
            var message = new MailMessage();
            message.From = new MailAddress(_configuration["EmailSettings:EmailAddress"]);
            message.To.Add(new MailAddress(emailTo));

            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;
            using (SmtpClient client = new SmtpClient())
            {
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(_configuration["EmailSettings:EmailAddress"], _configuration["EmailSettings:Password"]);
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(message);
            }
        }
    }
}
