using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MailSender.ConsoleTests
{
    class Program
    {
        private static void Main(string[] args)
        {
            //ThreadTest.Start();
            //ThreadSinhronizationTest.Start();
            //ThreadPoolTest.Start();

            //var threads = new Thread[10];
            //for (int i = 0; i < threads.Length; i++)
            //{
            //    //threads[i] = new Thread(() => Console.WriteLine($"Сообщение №{i}"));

            //    var j = i;
            //    threads[i] = new Thread(() => Console.WriteLine($"Сообщение №{j}"));
            //}
            //for (int i = 0; i < threads.Length; i++)
            //{
            //    threads[i].Start();
            //}

            Task.Start();
            Console.ReadLine();
        }
    }
}
