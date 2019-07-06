using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MailSender.ConsoleTests
{
    internal static class ThreadTest
    {
        public static void Start()
        {
            Thread.CurrentThread.Name = "Main Thread";

            //var thread1 = new Thread(new ThreadStart(FirstThreadMethod));
            var thread1 = new Thread(FirstThreadMethod);

            //var thread2 = new Thread(new ParameterizedThreadStart(PaarametricFirstThreadMethod));
            var thread2 = new Thread(ParametricFirstThreadMethod);

            thread1.Start();
            thread2.Start("Hello World!");

            var clockThread = new Thread(UpdateClockMethod);
            clockThread.Priority = ThreadPriority.Lowest;
            clockThread.IsBackground = true;

            clockThread.Start();

            string msg = "Bye Bye Bad Guy!";
            int count = 100;
            int timeout = 100;
            var print_thread = new Thread(() => printMethod(msg, count, timeout));
            //print_thread.Start();

            var printTask = new ThreadPrintTask
            {
                Message = "asd",
                Count = 100,
                Timeout = 10
            };

            var print_thread2 = new Thread(printTask.PrintMethod);
            print_thread2.Start();

            Console.WriteLine($"Главный поток программы id: {Thread.CurrentThread.ManagedThreadId}");
            Console.ReadLine();

            Console.WriteLine("остановка потока часов");
            _IsClockUpdating = false;

            if (!clockThread.Join(1))
            {
                //clockThread.Interrupt();
                clockThread.Abort();
            }
        }

        private static void FirstThreadMethod()
        {
            Console.WriteLine($"Выполнение в потоке id: {Thread.CurrentThread.ManagedThreadId}");
        }
        private static void ParametricFirstThreadMethod(object parameter)
        {
            Console.WriteLine($"Выполнение в потоке id: {Thread.CurrentThread.ManagedThreadId} с параметром {parameter}");
        }

        private static bool _IsClockUpdating = true;
        private static void UpdateClockMethod()
        {
            try
            {
                while (_IsClockUpdating)
                {
                    Thread.Sleep(100);
                    Console.Title = DateTime.Now.ToString("hh:mm:ss:ff");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("Часы завершили свою работу");
        }

        private static void printMethod(string Message, int Count, int Timeout)
        {
            for (var i = 0; i < Count; i++)
            {
                Console.WriteLine($"Сообщение из потока id: {Thread.CurrentThread.ManagedThreadId} - {Message} - {i}");
                Thread.Sleep(Timeout);
            }
        }

    }
}

