using MailSender.lib.Data.BaseEntityes;

/// <summary>Получатель почты</summary>
namespace MailSender.lib.Data
{
    public class Recipient : Human
    {
        public override bool Equals(object obj)
        {
            Recipient recipient = obj as Recipient;
            if (recipient == null) return false;
            return
                Id == recipient.Id &&
                Name == recipient.Name &&
                Address == recipient.Address &&
                Description == recipient.Description;
        }
    }
}
