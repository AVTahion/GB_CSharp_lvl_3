using MailSender.lib.Data;
using System;

namespace MailSender.lib.Services.InMemory
{
    public class MailMessagesDataInMemory : DataInMemory<MailMessage>, IMailMessagesDataService
    {
        public MailMessagesDataInMemory()
        {
            for (int i = 1; i <= 10; i++)
            {
                _Items.Add(new MailMessage { Id = i, Subject = $"Письмо {i}", Body = $"Текст письма {i}" });
            }
        }
        public override void Update(MailMessage item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            var db_item = GetById(item.Id);
            if (db_item is null) return;

            db_item.Subject = item.Subject;
            db_item.Body = item.Body;
        }
    }

}
