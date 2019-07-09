using MailSender.lib.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Services.InMemory
{
    public class SendersDataInMemory : DataInMemory<Sender>, ISenderDataService
    {
        public SendersDataInMemory()
        {
            for (int i = 1; i < 10; i++)
            {
                _Items.Add(new Sender { Id = i, Name = $"Отправитель_{i}", Address = $"Sender_{i}@server.com" });
            }
        }
        public override void Update(Sender item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            var db_item = GetById(item.Id);
            if (db_item is null) return;

            db_item.Name = item.Name;
            db_item.Address = item.Address;
        }
    }
}
