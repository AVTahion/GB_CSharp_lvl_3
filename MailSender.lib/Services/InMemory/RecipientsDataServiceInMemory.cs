using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.Data;

namespace MailSender.lib.Services.InMemory
{
    public class RecipientsDataServiceInMemory : DataInMemory<Recipient>, IRecipientsDataService
    {
        public RecipientsDataServiceInMemory()
        {
            var test_data = new List<Recipient>
            {
                new Recipient {Id = 1, Name = "Ivanov", Address = "ivanov@server.net", Description = ""},
                new Recipient {Id = 2, Name = "Petrov", Address = "petrov@server.net", Description = ""},
                new Recipient {Id = 3, Name = "Sidorov", Address = "sidorov@server.net", Description = ""},
            };
            _Items.AddRange(test_data);
        }

        public override void Update(Recipient item)
        {
            if(item is null) throw new ArgumentNullException(nameof(item));

            var db_item = GetById(item.Id);
            if (db_item is null) return;

            db_item.Name = item.Name;
            db_item.Address = item.Address;
            db_item.Description = item.Description;
        }
    }
}
