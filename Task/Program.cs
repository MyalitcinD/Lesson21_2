using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task
{
    class Program
    {
        static int n = 8;
        static char[,] garden = new char[8, 8]{
                { 'O','W','O','W','O','W','O','W'},
                { 'O','W','O','O','W','O','O','W'},
                { 'W','W','O','O','W','W','W','W'},
                { 'O','W','O','O','W','O','W','O'},
                { 'W','O','W','O','W','O','O','W'},
                { 'O','O','O','W','O','O','W','W'},
                { 'W','O','O','W','W','O','O','O'},
                { 'W','O','W','O','W','O','W','O'},
            };
        //static int tm1 = 35;
        //static int tm2 = 15;

        static void Main(string[] args)
        {
            for(int i = 0; i < n; i++) {
                for(int j = 0; j < n; j++) {
                    Console.Write(garden[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.Write("Введите скорость работы первного('X') садовника (int):");
            int tm1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите скорость работы второго('Y') садовника (int):");
            int tm2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            ParameterizedThreadStart threadStart = new ParameterizedThreadStart(Gardener2);
            Thread thread = new Thread(threadStart);
            thread.Start(tm2);
            Gardener1(tm1);

            for(int i = 0; i < n; i++) {
                for(int j = 0; j < n; j++) {
                    Console.Write(garden[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        static void Gardener1(object tm1)
        {
            for(int i = 0; i < n; i++) {
                for(int j = 0; j < n; j++) {
                    if(garden[i, j] == 'W') {
                        garden[i, j] = 'X';
                        Thread.Sleep((int)tm1);
                    }

                }
            }

        }
        static void Gardener2(object tm2)
        {
            for(int i = n - 1; i >= 0; i--) {
                for(int j = n - 1; j >= 0; j--) {
                    if(garden[j, i] == 'W') {
                        garden[j, i] = 'Y';
                        Thread.Sleep((int)tm2);
                    }

                }
            }

        }
    }
}
