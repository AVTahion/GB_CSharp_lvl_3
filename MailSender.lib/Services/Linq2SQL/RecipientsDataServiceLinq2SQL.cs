using MailSender.lib.Data.Linq2SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Services.Linq2SQL
{
    public class RecipientsDataServiceLinq2SQL : IRecipientsDataService
    {
        private readonly MailSenderDBContext _db;

        public RecipientsDataServiceLinq2SQL(MailSenderDBContext db)
        {
            _db = db;
        }

        public IEnumerable<Recipient> GetAll()
        {
            return _db.Recipient.ToArray();
        }
    }
}
