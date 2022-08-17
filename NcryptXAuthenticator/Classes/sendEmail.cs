using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace NcryptXAuthenticator.Classes
{
    public class sendEmail
    {

        public static Tuple<bool, string> SendEMail(mailModel mailArgs, bool isSsl)
        {
            try
            {
                var networkCredential = new NetworkCredential
                {
                    Password = mailArgs.Password,
                    UserName = mailArgs.MailFrom
                };

                var mailMsg = new MailMessage
                {
                    Body = mailArgs.Message,
                    Subject = mailArgs.Subject,
                    IsBodyHtml = true // This indicates that message body contains the HTML part as well.
                };
                mailMsg.To.Add(mailArgs.MailTo);

                mailMsg.From = new MailAddress(mailArgs.MailFrom, mailArgs.Name);

                var smtpClient = new SmtpClient(mailArgs.SmtpHost)
                {
                    Port = Convert.ToInt32(mailArgs.Port),
                    EnableSsl = isSsl,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = networkCredential
                };
                smtpClient.Send(mailMsg);
                return Tuple.Create(true, "Email Sent Successfully.");


            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return Tuple.Create(false, msg);
            }
        }

        


    }
}
