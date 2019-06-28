using MailSender.lib.Data.Linq2SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Services
{
    public interface IRecipientsDataService
    {
        IEnumerable<Recipient> GetAll();

        void Update(Recipient item);

        void Create(Recipient item);

        void Delete(Recipient item);

    }
}
