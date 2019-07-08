using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MailSender.ConsoleTests
{
    class ThreadPoolTest
    {
        public static void Start()
        {
            //ThreadPool.SetMinThreads(2, 2);
            //ThreadPool.SetMaxThreads(5, 5);
            var cpu_count = Environment.ProcessorCount;
            ThreadPool.SetMaxThreads(cpu_count, cpu_count);
            for (int i = 0; i < 50; i++)
            {
                ThreadPool.QueueUserWorkItem(ThreadPoolMethod, "Bye Bye World!");
            }
        }

        private static void ThreadPoolMethod(object parameter)
        {
            Thread.Sleep(1000);
            Console.WriteLine($"Задание {parameter} в пуле потоков Thread id: {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
