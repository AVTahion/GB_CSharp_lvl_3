using MailSender.lib.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Services
{
    public interface IMailMessagesDataService : IDataService<MailMessage> { }
}
