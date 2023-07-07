using Microsoft.AspNetCore.Html;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net;
using System.Net.Mail;

namespace Alzheimer.Iservices
{
    public interface IMailService
    {
        Task SendEmailAsync(string toEmail, string subject, string content);

    }
    public class SendGridMailService : IMailService
    {
        private IConfiguration _configuration;

        public SendGridMailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string content)
        {
            //var apiKey = _configuration["SendGridAPIKey"];
            //var client = new SendGridClient(apiKey);
            //var from = new EmailAddress("mahmoudsafa349@gmail.com", "JWT Auth Demo");
            //var to = new EmailAddress(toEmail);
            //var msg = MailHelper.CreateSingleEmail(from, to, subject, content, content);
            //var response = await client.SendEmailAsync(msg);

            //var message = new MailMessage();
            //var smtp = new SmtpClient();
            //message.From = new MailAddress("maherkhalil1979@gmail.com");
            //message.To.Add(new MailAddress(toEmail));
            //message.Subject = "Test";
            //message.IsBodyHtml = true; //to make message body as html
            //message.Body = "welcome";
            //smtp.Port = 587;
            //smtp.Host = "smtp.gmail.com"; //for gmail host
            //smtp.EnableSsl = true;
            //smtp.UseDefaultCredentials = false;
            //smtp.Credentials = new NetworkCredential("maherkhalil1979@gmail.com", "rafrceqpzcawmblm");
            //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            //smtp.Send(message);


            var message = new MailMessage();
            var smtp = new SmtpClient();
            message.From = new MailAddress("maherkhalil1979@gmail.com");
            message.To.Add(new MailAddress(toEmail));
            message.Subject = "Test";
            message.IsBodyHtml = true; //to make message body as html
            message.Body = content;
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com"; //for gmail host
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("maherkhalil1979@gmail.com", "rafrceqpzcawmblm");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(message);

        }
    }
}
