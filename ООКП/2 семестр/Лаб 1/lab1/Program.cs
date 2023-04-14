using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Program
    {
        public static bool isReg = true;

        static double[] CreateArr(int n)
        {
            Console.WriteLine("Введіть довжини сторін багатокутника: ");
            double[] arr = new double[n];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = double.Parse(Console.ReadLine());

                if (i > 0)
                    if (arr[i - 1] != arr[i])
                        isReg = false;

            }

            return arr;
        }

        static void Main(string[] args)
        {
            double p;

            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;

            Console.Write("Введіть кількість сторін багатокутника: ");
            int n = int.Parse(Console.ReadLine());

            if (n > 2)
            {
                double[] arr = new double[n];
                arr = CreateArr(n);

                Calculator calculator = new Calculator(new Other());

                if (isReg)
                    calculator.Strategy = new RegularStrategy();   

                p = calculator.calculate(n, arr);
                Console.WriteLine("Периметр багатокутника: " + p);
            }
            else 
                Console.WriteLine("Неправильно задано кількість сторін багатокутника. n >= 3");

            Console.ReadKey();  
        }
    }
}
