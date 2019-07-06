using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.ConsoleTests
{
    class Program
    {
        private static void Main(string[] args)
        {
            ThreadTest.Start();

            Console.ReadLine();
        }
    }
}
