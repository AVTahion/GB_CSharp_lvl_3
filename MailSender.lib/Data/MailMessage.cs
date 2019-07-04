using MailSender.lib.Data.BaseEntityes;

/// <summary>Сообщение электронной почты</summary>
namespace MailSender.lib.Data
{
    public class MailMessage : Entity
    {
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
