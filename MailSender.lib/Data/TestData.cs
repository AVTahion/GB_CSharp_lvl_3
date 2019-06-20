using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Data
{
    public static class TestData
    {
        public static Server[] Servers { get; } = Enumerable.Range(1, 10)
            .Select(i => new Server
            {
                Name = $"Server {i}",
                Address = $"smtp.server{i}.ru",
                UserName = $"Server {i} username",
                Password = $"Password{i}"
            })
            .ToArray();

        public static Sender[] Sender { get; } = Enumerable.Range(1, 10)
            .Select(i => new Sender
            {
                Name = $"Sender {i}",
                Address = $"adress@server{i}.ru",
            })
            .ToArray();

        public static MailMessage[] MailMessages { get; } = Enumerable.Range(1, 10)
            .Select(i => new MailMessage
            {
                Subject = $"Subject_{i}",
                Body = $"body{i}",
            })
            .ToArray();

    }
}
