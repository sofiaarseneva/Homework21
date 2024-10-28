using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task1
{
    internal class Program
    {
        const int n = 10;
        const int m = 20;
        const int delay = 1;
        static int[,] garden = new int[n, m];
        static void Main(string[] args)
        {
            Console.WriteLine("Моделируем садовников!\n\n");
            Console.WriteLine("План сада:\n");
            try
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        garden[i, j] = 0;
                        Console.Write($"{garden[i, j]} ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                ThreadStart threadStart = new ThreadStart(Garden1);
                Thread thread = new Thread(threadStart);
                thread.Start();
                Garden2();
                Console.WriteLine("Результат:\n");
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        Console.Write($"{garden[i, j]} ");
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка!" + ex.Message);
            }
            Console.ReadKey();
        }
        static void Garden1()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (garden[i, j] == 0)
                    {
                        garden[i, j] = 1;
                        Thread.Sleep(delay);
                    }
                }
            }
        }
        static void Garden2()
        {
            for (int i = m - 1; i >= 0; i--)
            {
                for (int j = n - 1; j >= 0; j--)
                {
                    if (garden[j, i] == 0)
                    {
                        garden[j, i] = 2;
                        Thread.Sleep(delay);
                    }
                }
            }
        }
    }
}
