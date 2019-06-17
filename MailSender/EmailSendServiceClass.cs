using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;


namespace MailSender
{
    public class EmailSendServiceClass
    {
        static public bool SendMail(string recipient, string sender, string smtpServerAddress, int smtpPort, bool enableSsl, string password, string emailSubject, string emailBody, bool isBodyHtml)
        {
            using (MailMessage mm = new MailMessage(sender, recipient))
            {
                mm.Subject = emailSubject;
                mm.Body = emailBody;
                mm.IsBodyHtml = isBodyHtml;

                using (SmtpClient sc = new SmtpClient(smtpServerAddress, smtpPort))
                {
                    sc.EnableSsl = enableSsl;
                    sc.Credentials = new NetworkCredential(sender, password);
                    try
                    {
                        sc.Send(mm);
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
