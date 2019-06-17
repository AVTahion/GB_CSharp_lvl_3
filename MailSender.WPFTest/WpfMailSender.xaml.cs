using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Net;
using System.Net.Mail;

namespace MailSender.WPFTest
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class WpfMailSender : Window
    {
        public WpfMailSender()
        {
            InitializeComponent();
        }

        private void btnSendMail_Click(object sender, RoutedEventArgs e)
        {
            //string strPassword = passwordBox.Password;  // для WinForms - string strPassword = passwordBox.Text;
            //// Используем using, чтобы гарантированно удалить объект MailMessage после использования
            //using (MailMessage mm = new MailMessage("mfortests@yandex.ru", "spbcon75@mail.ru"))
            //{
            //    // Формируем письмо
            //    mm.Subject = "Тест"; // Заголовок письма
            //    mm.Body = "Hello, world!";       // Тело письма
            //    mm.IsBodyHtml = false;           // Не используем html в теле письма
            //                                     // Авторизуемся на smtp-сервере и отправляем письмо
            //                                     // Оператор using гарантирует вызов метода Dispose, даже если при вызове 
            //                                     // методов в объекте происходит исключение.
            //    using (SmtpClient sc = new SmtpClient("smtp.yandex.ru", 25))
            //    {
            //        sc.EnableSsl = true;
            //        sc.Credentials = new NetworkCredential("mfortests@yandex.ru", strPassword);
            //        try
            //        {
            //            sc.Send(mm);
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show("Невозможно отправить письмо " + ex.ToString());
            //        }
            //    }
            //}
            SendEndWindow sew = new SendEndWindow();
            sew.ShowDialog();
        }
    }
}
