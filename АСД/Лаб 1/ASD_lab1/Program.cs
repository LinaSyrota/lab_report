using System;

namespace ASD_lab1
{
    class Program
    {
        public static int n;
        public static double f = (1 + Math.Sqrt(5)) / 2;
        public static int[] arr = new int[n];
        public static List list = new List();
        public static Search search = new Search();

        public static void GenArr()
        {
            arr = new int[n]; // визначення масиву
            Random aRand = new Random();
            Console.WriteLine("Згенерований масив:");
            for (int i = 0; i < n; i++)
            {
                arr[i] = aRand.Next(-100, 100); // генерація масиву
                Console.Write(arr[i] + " "); // вивід на консоль
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

        public static void OutList()
        {
            Console.WriteLine("Згенеровано список:");
            GetList();
            list.loop();
        }

        static void LinSearch()
        {
            GetList();
            search.LinSearchArray(arr, n);
            list.LinSearchList();
        }

        static void BarSearch()
        {
            GetList();
            search.BarSearchArray(arr, n);
            list.BarSearchList(n);
        }

        static void BinSearch(double r)
        {
            search.BinarySearchArray(r, n);
            list.BinarySearchList(r, n);
        }

        static void Menu()
        {
            int command;

            Console.WriteLine(" ");
            Console.WriteLine("======== Меню ========");
            Console.WriteLine("1. Лінійний пошук");
            Console.WriteLine("2. Пошук з бар'єром. Масив");
            Console.WriteLine("3. Бінарний пошук. Масив");
            Console.WriteLine("4. Бінарний пошук, золотий переріз. Масив");
            do
            {
                Console.WriteLine(" ");
                Console.WriteLine("Оберіть пункт меню:");
                command = int.Parse(Console.ReadLine());
                switch (command)
                {
                    case 1: LinSearch(); break;
                    case 2: BarSearch(); break;
                    case 3: BinSearch(2); break;
                    case 4: BinSearch(f); break;
                    case 0: Environment.Exit(0); break;
                    default: Console.WriteLine("0. Вийти з програми"); break;
                }
            }
            while (command != 0);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Ведіть кількість елементів: ");
            n = int.Parse(Console.ReadLine());
            GenArr();
            Console.WriteLine("=====================================================");
            OutList();

            Menu();

            Console.ReadKey();
        }
    }
}
