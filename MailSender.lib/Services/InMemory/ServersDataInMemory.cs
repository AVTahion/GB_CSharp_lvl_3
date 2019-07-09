using MailSender.lib.Data;
using System;

namespace MailSender.lib.Services.InMemory
{
    public class ServersDataInMemory : DataInMemory<Server>, IServersDataService
    {
        public ServersDataInMemory()
        {
            for (int i = 1; i < 10; i++)
            {
                _Items.Add(new Server { Id = i,Name = $"Сервер_{1}", Address = $"smtp.Server{i}.com"});
            }
        }
        public override void Update(Server item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            var db_item = GetById(item.Id);
            if (db_item is null) return;

            db_item.Name = item.Name;
            db_item.Address = item.Address;
            db_item.Port = item.Port;
            db_item.SSL = item.SSL;
            db_item.UserName = item.UserName;
            db_item.Password = item.Password;
        }
    }

}
