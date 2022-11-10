using System;

namespace asd_2
{
    class Program
    {
        static int max(int i, int j)
        {
            if (i >= j)
                return i;
            else
                return j;
        }

        static int calculate(int W, int n, int[] w, int[] v)
        {
            int[] mv = new int[W + 1];

            for (int i = 0; i <= W; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (w[j] <= i)
                    {
                        mv[i] = max(mv[i], v[j] + mv[i - w[j]]);
                        Console.WriteLine("----- Цінність рюкзака: " + mv[i] + "        предмет: вага = " + w[j] + "     цінність = " + v[j]);
                    }
                }

            }

            return mv[W];
        }

        static void Main(string[] args)
        {
            Console.Write("Введіть значення місткості рюкзака: ");
            int W = int.Parse(Console.ReadLine());
            
            Console.Write("Введіть кількість видів товару: ");
            int n = int.Parse(Console.ReadLine());

            int[] weight = new int[n];
            int[] value = new int[n];

            // заповнення масивів 
            for (int i = 0; i < n; i++)
            {
                Console.Write("Вага предмета: ");
                weight[i] = int.Parse(Console.ReadLine());
                Console.Write("Цінність предмета: ");
                value[i] = int.Parse(Console.ReadLine());
            }

            int result = calculate(W, n, weight, value);
            Console.WriteLine();
            Console.WriteLine("Максимальна цінність рюкзака: " + result);
        }
    }
}
