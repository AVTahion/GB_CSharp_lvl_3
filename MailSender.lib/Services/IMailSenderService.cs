﻿using MailSender.lib.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Services
{
    public interface IMailSenderService
    {
        IMailSender CreateSender(Server Server);
    }

    public interface IMailSender
    {
        void Send(Data.MailMessage Message, Sender From, Recipient To);

        void Send(Data.MailMessage Message, Sender From, IEnumerable<Recipient> To);
    }

    public class SmtpMailSenderService : IMailSenderService
    {
        public IMailSender CreateSender(Server Server) => 
            new SmtpMailSender(Server.Address, Server.Port, Server.SSL, Server.UserName, Server.Password);
    }

    public class SmtpMailSender : IMailSender
    {
        private readonly string _Host;
        private readonly int _Port;
        private readonly bool _UseSSL;
        private readonly string _Login;
        private readonly string _Password;

        public SmtpMailSender(string Host, int Port, bool UseSSL, string Login, string Password)
        {
            _Host = Host;
            _Port = Port;
            _UseSSL = UseSSL;
            _Login = Login;
            _Password = Password;
        }

        public void Send(Data.MailMessage Message, Sender From, Recipient To)
        {
            using (var server = new SmtpClient(_Host, _Port) { EnableSsl = _UseSSL} )
            {
                server.Credentials = new NetworkCredential(_Login, _Password);

                using(var msg = new System.Net.Mail.MailMessage())
                {
                    msg.From = new MailAddress(From.Address, From.Name);
                    msg.To.Add(new MailAddress(To.Address, To.Name));

                    server.Send(msg);
                }
            }
        }

        public void Send(Data.MailMessage Message, Sender From, IEnumerable<Recipient> To)
        {
            foreach (var recipient in To)
            {
                Send(Message, From, recipient);
            }
        }
    }
}