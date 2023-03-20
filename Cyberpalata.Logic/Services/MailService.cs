using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Configuration;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.DataProvider.Interfaces;

namespace Cyberpalata.Logic.Services
{
    internal class MailService : IMailService
    {
        private readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        private void SendMail(string emailTo, string subject, string body)
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
        public async Task SendPasswordResetEmail(string emailTo)
        {
            string bodyHtml = @$"<html>
                                    <div>
                                        <a href='{_configuration["PasswordResetPageUrl"]}' class='btn btn-outline-dark btn-sm text-white w-50 m-1'>Reset password</a>
                                    </div>
                                </html>";
            SendMail(emailTo, "Password reset", bodyHtml);
        }

        public async Task SendVerificationCodeToMail(string emailTo,int code)
        {
            string bodyHtml = @$"<html>
                                <div>
                                    <h1>Your verification code:</h1>
                                    <div><b>{code}</b></div>
                                </div>
                            </html>";
            SendMail(emailTo,"Verification code", bodyHtml);
        }
    }
}
