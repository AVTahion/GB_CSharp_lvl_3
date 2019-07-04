namespace MailSender.lib.Data.BaseEntityes
{
    /// <summary>Персона</summary>
    public abstract class Human : NamedEntity
    {
        /// <summary>Адрес электронной почты</summary>
        public string Address { get; set; }

        /// <summary>Коментарий</summary>
        public string Description { get; set; }
    }
}
