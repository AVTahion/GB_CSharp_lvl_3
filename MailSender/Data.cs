using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender
{
    public static class Data
    {
        public static string senderAddress = "mfortests@yandex.ru";

        public static string recepientAddress = "spbcon75@mail.ru";

        public static string smtpServerAddress = "smtp.yandex.ru";
        public static int smtpPort = 25;
        public static bool enableSsl = true;

        public static string emailSubject = "Тест";
        public static string emailBody = "Hello, world!";
        public static bool isBodyHtml = false;

        public static string errorMessage = "Невозможно отправить письмо ";

    }
}
