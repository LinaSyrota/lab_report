using System;
using System.Diagnostics;

namespace ASD_lab2
{
    class Program
    {
        public static List list = new List();
        public static Sort sort = new Sort();
        public static int n;
        public static int[] arr = new int[n];

        public static void GenArrList()
        {
            arr = new int[n];
            Random aRand = new Random();
            for (int i = 0; i < n; i++)
                arr[i] = aRand.Next(-100, 100);

            GetList();
        }

        public static void OutputArr()
        {
            for (int i = 0; i < n; i++)
                Console.Write(arr[i] + " "); // вивід на консоль

            Console.WriteLine(" ");
        }

        public static void OutputList()
        {
            Console.WriteLine("Відсортований список:");
            Item p = list.head;
            while (p != null)
            {
                Console.Write(p.Data + " ");
                p = p.Next;
            }
            Console.WriteLine(" ");
        }

        public static void GetList()
        {
            int i = 0;
            while (i < n)
            {
                list.addItem(arr[i]);
                i++;
            }
        }

        public static void Data()
        {
            Console.WriteLine("Введіть кількість елементів:");
            n = int.Parse(Console.ReadLine());

            GenArrList();
            Console.WriteLine("Згенеровано масив:");
            OutputArr();
            list.newList(arr, n);
        }

        static void Main(string[] args)
        {
            Data();
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine(" ");

            Stopwatch durationList = new Stopwatch();
            durationList.Start();
            list.head = list.MergeSort(list.head);
            durationList.Stop();

            OutputList();

            Stopwatch durationArray = new Stopwatch();
            durationArray.Start();
            sort.MergeSort(arr);
            durationArray.Stop();

            Console.WriteLine("Відсортований масив:");
            OutputArr();

            Console.WriteLine(" ");
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("Час роботи алгоритму сортування на масиві (ns): " + durationArray.ElapsedTicks + "00");
            Console.WriteLine("Час роботи алгоритму сортування на списку (ns): " + durationList.ElapsedTicks + "00");
            Console.WriteLine("---------------------------------------------------------------");

            Console.ReadKey();
        }
    }
}
