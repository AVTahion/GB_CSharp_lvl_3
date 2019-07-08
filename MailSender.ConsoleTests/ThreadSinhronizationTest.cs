using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MailSender.ConsoleTests
{
    class ThreadSinhronizationTest
    {
        public static void Start()
        {
            for (int i = 0; i < 5; i++)
            {
                new Thread(PrintNumbers).Start();
            }
        }

        private static object _SyncRoot = new object();
        private static void PrintNumbers()
        {
            lock (_SyncRoot)
            {
                Console.Write($"Thread id: {Thread.CurrentThread.ManagedThreadId} - ");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write($"{i}, ");
                    Thread.Sleep(10);
                }
                Console.WriteLine("10");
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private static void SequentalMethod()
        {
            //какой-то код
        }
    }

    [Synchronization]
    internal class FileLogger : ContextBoundObject
    {
        private readonly string _FileName;

        public FileLogger(string Filename) => _FileName = Filename;

        public void Log(string msg)
        {
            lock (this)
                System.IO.File.AppendAllText(_FileName, msg);
        }
    }
}
