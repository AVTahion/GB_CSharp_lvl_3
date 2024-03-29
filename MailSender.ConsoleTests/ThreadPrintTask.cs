﻿using System;
using System.Threading;

namespace MailSender.ConsoleTests
{
    internal class ThreadPrintTask
    {
        public string Message { get; set; }
        public int Count { get; set; }
        public int Timeout { get; set; }

        public void PrintMethod()
        {
            var msg = Message;
            var count = Count;
            var timeout = Timeout;
            for (var i = 0; i < count; i++)
            {
                Console.WriteLine($"Сообщение из потока id: {Thread.CurrentThread.ManagedThreadId} - {msg} - {i}");
                Thread.Sleep(timeout);
            }
        }


    }
}
