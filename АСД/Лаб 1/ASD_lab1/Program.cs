using System;

namespace ASD_lab1
{
    class Program
    {
        public static List list = new List();
        public static Search search = new Search();
        public static int n;
        public static double f = (1 + Math.Sqrt(5)) / 2;
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
            Console.WriteLine("Згенеровано масив:");
            for (int i = 0; i < n; i++)
                Console.Write(arr[i] + " "); // вивід на консоль

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

        static void LinSearch()
        {
            Console.WriteLine("=============== Лінійний пошук ==============");
            Console.WriteLine(" ");
            OutputArr();
            Console.WriteLine("=============================================");
            list.newList(arr, n);
            Console.WriteLine(" ");
            search.LinSearchArray(arr, n);
            Console.WriteLine(" ");
            list.LinSearchList();
        }

        static void BarSearch()
        {
            Console.WriteLine("============== Пошук з бар'єром =============");
            Console.WriteLine(" ");
            OutputArr();
            Console.WriteLine("=============================================");
            list.newList(arr, n);
            Console.WriteLine(" ");
            search.BarSearchArray(arr, n);
            Console.WriteLine(" ");
            list.BarSearchList(n);
        }

        static void BinSearch(double r)
        {
            Console.WriteLine("============== Бінарний пошук ===============");
            Console.WriteLine(" ");
            search.BinarySearchArray(r, n);
            Console.WriteLine(" ");
            list.BinarySearchList(r, n);
        }

        static void Menu()
        {
            int command;

            Console.WriteLine(" ");
            Console.WriteLine("======== Меню ========");
            Console.WriteLine("1. Лінійний пошук");
            Console.WriteLine("2. Пошук з бар'єром");
            Console.WriteLine("3. Бінарний пошук");
            Console.WriteLine("4. Бінарний пошук (золотий переріз)");
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
            GenArrList();

            Menu();

            Console.ReadKey();
        }
    }
}
