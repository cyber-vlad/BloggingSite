using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Forums.Helpers
{
    public class EmailService
    {
        public static async Task<bool> SendEmailToUserAsync(string email, string name, string subject, string body)
        {
            try
            {
                using (var client = new SmtpClient())
                {
                    client.Host = "smtp.mail.ru";
                    client.Port = 587;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential("bloghubforums@mail.ru", "YdcmYGctervYacDjtLfC");

                    using (var message = new MailMessage(
                        from: new MailAddress("bloghubforums@mail.ru", "BlogHub Forums"),
                        to: new MailAddress(email, name)
                        ))
                    {
                        message.Subject = subject;
                        message.Body = body;

                        await client.SendMailAsync(message);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false; // Or do something else to indicate failure
            }
        }
    }
}
