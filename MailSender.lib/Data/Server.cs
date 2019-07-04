using MailSender.lib.Data.BaseEntityes;

namespace MailSender.lib.Data
{
    /// <summary>Почтовый сервер</summary>
    public class Server : NamedEntity
    {
        public string Address { get; set; }
        public int Port { get; set; } = 25;
        public bool SSL { get; set; } = true;
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
