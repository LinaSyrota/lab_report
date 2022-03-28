using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace ASD_lab1
{
    class List
    {
        public Item head;
        public Item addItem(int data)
        {
            if (head == null)
                head = new Item(data, null);
            else
            {
                Item p = head;
                while (p.Next != null)
                {
                    p = p.Next;
                }
                p.Next = new Item(data, null);
            }
            return head;
        }

        public void loop()
        {
            Item p = head;
            while (p != null)
            {
                Console.Write(p.Data + " ");
                p = p.Next;
            }
            Console.WriteLine(" ");
        }

        public void LinSearchList()
        {
            Console.WriteLine("===== Пошук для списку =====");
            Console.WriteLine("Введіть шуканий елемент:");
            int x = int.Parse(Console.ReadLine());

            
            bool Found = false;
            Item p = head;
            int i = 0;

            Stopwatch duration = new Stopwatch();
            duration.Start();
            while (p != null && Found == false)
            {
                if (p.Data == x)
                    Found = true;
                p = p.Next;
                i++;
            }
            duration.Stop();

            if (Found == true)
                Console.WriteLine("Індекс шуканого елемента: " + (i - 1));
            else
                Console.WriteLine("Не знайдено такий елемент");

            Console.WriteLine("Час роботи коду (ns): " + duration.ElapsedTicks + "00");

            Console.ReadKey();
        }

        public void BarSearchList(int n)
        {
            Console.WriteLine("===== Пошук для списку =====");
            Console.WriteLine("Введіть шуканий елемент:");
            int x = int.Parse(Console.ReadLine());

            bool Found = false;
            int i = 0;
            Item p = head;
            while (p.Next != null)
                p = p.Next;
            p.Next = new Item(x, null);

            p = head;
            Stopwatch duration = new Stopwatch();
            duration.Start();
            while (p.Data != x)
            { 
                i++;
                p = p.Next;
            }
            
            duration.Stop();

            if (i == n)
                Console.WriteLine("Не знайдено такий елемент");
            else
                Console.WriteLine("Індекс шуканого елемента: " + i);


            Console.WriteLine("Час роботи коду (ns): " + duration.ElapsedTicks + "00");

            Console.ReadKey();
        }

        public void BinarySearchList(double m, int n)
        {
            int k = 0, i = 0, l = 0, c = 0;
            double c1;
            int r = n - 1, j;
            bool flag = false;
            Item p = head;
            int[] arr = new int[n]; //визначення масиву

            Console.WriteLine("Список:");

            while (i < n && p != null)
            {
                p.Data = i + 1;
                Console.Write(p.Data + " ");
                p = p.Next;
                i++;
            }
            Console.WriteLine(" ");

            Console.WriteLine("Введіть шуканий елемент:");
            int x = int.Parse(Console.ReadLine());

            Stopwatch duration = new Stopwatch();
            duration.Start();

            while (l <= r)
            {
                c1 = l + (r - l) / m;
                c = (int)c1;
                Item p1 = head;
                j = 0;
                while (j < n && p1 != null)
                {
                    if (j == c)
                    {
                        k = p1.Data; break;
                    }
                    p1 = p1.Next;
                    j++;
                }
                
                if (x < k)
                    r = c;
                else if (x > k)
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
            Console.WriteLine("Час роботи коду (ns): " + duration.ElapsedTicks + "00");

            Console.ReadKey();
        }
    }
}
