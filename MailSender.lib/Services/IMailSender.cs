using MailSender.lib.Data;
using System.Collections.Generic;

namespace MailSender.lib.Services
{
    public interface IMailSender
    {
        void Send(Data.MailMessage Message, Sender From, Recipient To);

        void Send(Data.MailMessage Message, Sender From, IEnumerable<Recipient> To);

        void SendParallel(Data.MailMessage Message, Sender From, IEnumerable<Recipient> To);
    }
}
