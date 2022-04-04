using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace ASD_lab1
{
    class Search
    {
        public void LinSearchArray(int[] arr, int n)
        {
            Console.WriteLine("---------- Пошук для масиву ----------");
            Console.WriteLine("Введіть шуканий елемент:");
            int x = int.Parse(Console.ReadLine());

            int i = 0;
            bool Found = false;

            Stopwatch duration = new Stopwatch();
            duration.Start();
            while (i < n && Found == false)
            {
                if (arr[i] == x)
                    Found = true;
                i++;
            }
            duration.Stop();

            if (Found == true)
                Console.WriteLine("Індекс шуканого елемента: " + (i - 1));
            else if (i == n)
                Console.WriteLine("Не знайдено такий елемент");

            Console.WriteLine("Час роботи алгоритму (ns): " + duration.ElapsedTicks + "00");
        }

        public void BarSearchArray(int[] arr, int n)
        {
            Console.WriteLine("---------- Пошук для масиву ----------");
            Console.WriteLine("Введіть шуканий елемент:");
            int x = int.Parse(Console.ReadLine());

            Stopwatch duration = new Stopwatch();
            duration.Start();
            int m = n + 1;
            int[] arr1 = new int[m];
            for (int j = 0; j < n; j++)
                arr1[j] = arr[j];
            
            arr1[n] = x;
            int i = 0;
            while (arr1[i] != x)
                i++;
            duration.Stop();

            if (i == n)
                Console.WriteLine("Не знайдено такий елемент");
            else
                Console.WriteLine("Індекс шуканого елемента: " + i);


            Console.WriteLine("Час роботи алгоритму (ns): " + duration.ElapsedTicks + "00");
        }

        public void BinarySearchArray(double m, int n)
        {
            Console.WriteLine("---------- Пошук для масиву ----------");
            int c = 0;
            bool flag = false;
            int[] arr = new int[n]; //визначення масиву

            Console.WriteLine("Масив:");
            for (int i = 0; i < n; i++)
            {
                arr[i] = i + 1;
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine(" ");

            Console.WriteLine("Введіть шуканий елемент:");
            int x = int.Parse(Console.ReadLine());

            Stopwatch duration = new Stopwatch();

            double c1;
            int l = 0;
            int r = n - 1;
            duration.Start();
            while (l <= r)
            {
                c1 = l + (r - l) / m;
                c = (int)c1;
                if (x < arr[c])
                    r = c - 1;
                else if (x > arr[c])
                    l = c + 1;
                else
                {
                    flag = true; break;
                }
            }
            duration.Stop();

            if (flag == true)
                Console.WriteLine("Елемент знайдено, його індекс: " + c);
            else
                Console.WriteLine("Елемент не знайдено");
            Console.WriteLine("Час роботи алгоритму (ns): " + duration.ElapsedTicks + "00");
        }
    }
}
