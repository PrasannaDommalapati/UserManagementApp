using System;
using System.Net.Mail;

namespace UserManagement.Business.Helpers
{
    public static class Mailer
    {
        public static void Send()
        {
            string to = "dommalapati.chowdary@gmail.com";
            string from = "dpchowdaryd@gmail.com";
            MailMessage message = new MailMessage(from, to)
            {
                Subject = "Using the new SMTP client.",
                Body = "Using this new feature, you can send an email message from an application very easily."
            };
            SmtpClient client = new SmtpClient("smtp.gmail.com")
            {
                // Credentials are necessary if the server requires the client
                // to authenticate before it will send email on the client's behalf.
                UseDefaultCredentials = true,
                Port = 587
            };

            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateTestMessage2(): {0}",
                    ex.ToString());
            }
        }
    }
}
