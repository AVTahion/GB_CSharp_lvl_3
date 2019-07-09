using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace MailSender.ConsoleTests
{
    class Task
    {
        public static void Start()
        {
            uint x = InputData("для вычисления факториала");
            var thread_1 = new Thread(() => Factorial(x));
            thread_1.Start();

            x = InputData("для вычмсления суммы целых чисел");
            var thread_2 = new Thread(() => SumN(x));
            thread_2.Start();
        }

        private static uint InputData(string msg)
        {
            string b;
            uint result;
            do
            {
                Console.WriteLine("Введите натуральное число " + msg);
                b = Console.ReadLine();
            }
            while (!UInt32.TryParse(b, out result));
            return result;
        }

        public static void Factorial(uint a)
        {
            {
                int result = 1;
                for (int i = 1; i <= a; i++)
                {
                    result *= i;
                }
                Thread.Sleep(5000);
                Console.WriteLine($"Факториал числа {a} равен {result}");
            }
        }

        public static void SumN(uint a)
        {
            {
                int result = 0;
                for (int i = 1; i <= a; i++)
                {
                    result += i;
                }

                Console.WriteLine($"Сумма целых чисел до {a} равна {result}");
            }
        }
    }
}
