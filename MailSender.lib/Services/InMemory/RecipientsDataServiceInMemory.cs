using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.Data.Linq2SQL;

namespace MailSender.lib.Services.InMemory
{
    public class RecipientsDataServiceInMemory : IRecipientsDataService
    {
        private readonly List<Recipient> _Recipients = new List<Recipient>
        {
            new Recipient {Id = 1, Name = "Ivanov", Address = "ivanov@server.net", Description = ""},
            new Recipient {Id = 2, Name = "Petrov", Address = "petrov@server.net", Description = ""},
            new Recipient {Id = 3, Name = "Sidorov", Address = "sidorov@server.net", Description = ""},
        };

        public void Create(Recipient item)
        {
            if (_Recipients.Contains(item)) return;
            item.Id = _Recipients.Count == 0 ? 1 : _Recipients.Max(r => r.Id) + 1;
            _Recipients.Add(item);
        }

        public void Delete(Recipient item)
        {
            if (_Recipients.Contains(item)) return;
            var db_item = GetById(item.Id);
            if (db_item is null) return;

            _Recipients.Remove(db_item);
        }

        public IEnumerable<Recipient> GetAll() => _Recipients;

        public Recipient GetById(int id) => _Recipients.FirstOrDefault(r => r.Id == id);

        public void Update(Recipient item)
        {
            if(_Recipients.Contains(item)) return;
            var db_item = GetById(item.Id);
            if (db_item is null) return;

            db_item.Name = item.Name;
            db_item.Address = item.Address;
            db_item.Description = item.Description;
        }
    }
}
