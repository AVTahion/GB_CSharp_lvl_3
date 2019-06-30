using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Data.Linq2SQL
{
    public partial class Recipient : IDataErrorInfo
    {

        string IDataErrorInfo.Error => "";

        string IDataErrorInfo.this[string propertyName]
        {
            get
            {
                switch (propertyName)
                {
                    default: return "";
                    case nameof(Name):
                        if (!char.IsUpper(Name[0])) return "Имя должно начинаться с заглавной буквы";
                        break;
                }
                return "";
            }
        }

        partial void OnNameChanging(string value)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value), "Передана пустая ссылка на строку имени");
            }

            if (value.Length < 2)
            {
                throw new InvalidOperationException("Строка имени должна быть не менее 2 символов");
            }
        }
    }
}
