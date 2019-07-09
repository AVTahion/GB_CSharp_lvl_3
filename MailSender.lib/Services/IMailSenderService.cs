using MailSender.lib.Data;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Services
{
    public interface IMailSenderService
    {
        IMailSender CreateSender(Server Server);
    }

    public class SmtpMailSenderService : IMailSenderService
    {
        public IMailSender CreateSender(Server Server) => 
            new SmtpMailSender(Server.Address, Server.Port, Server.SSL, Server.UserName, Server.Password);
    }
}
