using System;
using System.Net;
using System.Net.Mail;
using UserManagement.Business.Extensions;

namespace UserManagement.Business.Helpers
{
    public static class Mailer
    {
        public static void Send(string toAddress, string securityCode)
        {
            const string fromAddress = "dpchowdaryd@gmail.com";

            var basicCredential = new NetworkCredential(fromAddress, "Prasanna1405");
            var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = "UserManagement Code",
                Body = securityCode
            };

            var client = new SmtpClient("smtp.gmail.com")
            {
                UseDefaultCredentials = true,
                Credentials = basicCredential,
                EnableSsl = true,
                Port = 587
            };

            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                throw new UserManagementException($"Unable to send an email :(", ex);
            }
        }
    }
}
