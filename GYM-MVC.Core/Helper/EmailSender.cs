using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net.Mail;

namespace GYM_MVC.Core.Helper {

    public class EmailSender : IEmailSender {

        public Task SendEmailAsync(string receiverEmail, string subject, string htmlMessage) {
            var stmpClient = new SmtpClient("stmp.gmail.com") {
                Port = 587,
                Credentials = new System.Net.NetworkCredential("Email", "password"),
                EnableSsl = true
            };
            var mailMesseage = new MailMessage("Email", receiverEmail) {
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true
            };
            return stmpClient.SendMailAsync(mailMesseage);
        }
    }
}