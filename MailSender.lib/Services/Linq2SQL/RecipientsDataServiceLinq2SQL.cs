using MailSender.lib.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Services.Linq2SQL
{
    public class RecipientsDataServiceLinq2SQL : IRecipientsDataService
    {
        private readonly MailSender.lib.Data.Linq2SQL.MailSenderDBContext _db;

        public RecipientsDataServiceLinq2SQL(MailSender.lib.Data.Linq2SQL.MailSenderDBContext db)
        {
            _db = db;
        }

        public IEnumerable<Recipient> GetAll()
        {
            return _db.Recipient
                .Select(r => new Recipient
                {
                    Id = r.Id,
                    Name = r.Name,
                    Address = r.Address,
                    Description = r.Description
                })
                .ToArray();
        }

        public Recipient GetById(int id) => _db.Recipient
                .Select(r => new Recipient
                {
                    Id = r.Id,
                    Name = r.Name,
                    Address = r.Address,
                    Description = r.Description
                })
            .FirstOrDefault(r => r.Id == id);

        public void Create(Recipient item)
        {
            if (item.Id != 0) return;
            _db.Recipient.InsertOnSubmit(new Data.Linq2SQL.Recipient
            {
                Name = item.Name,
                Address = item.Address,
                Description = item.Description
            });
            _db.SubmitChanges();
        }

        public void Update(Recipient item) => _db.SubmitChanges();

        public void Delete(Recipient item)
        {
            var db_item = _db.Recipient.FirstOrDefault(r => r.Id == item.Id);
            if (db_item is null) return;
            _db.Recipient.DeleteOnSubmit(db_item);
            _db.SubmitChanges();
        }

    }
}
