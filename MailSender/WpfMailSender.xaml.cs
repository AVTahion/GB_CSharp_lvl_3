using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Net;
using System.Net.Mail;

namespace MailSender
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
            if (EmailSendServiceClass.SendMail(Data.recepientAddress, Data.senderAddress, Data.smtpServerAddress, Data.smtpPort, Data.enableSsl, passwordBox.Password, txtBoxSubject.Text, Data.emailBody, Data.isBodyHtml))
            {
                SendEndWindow sew = new SendEndWindow();
                sew.ShowDialog();
            }
            else
            {
                MessageBox.Show(Data.errorMessage);
            }
        }
    }
}
