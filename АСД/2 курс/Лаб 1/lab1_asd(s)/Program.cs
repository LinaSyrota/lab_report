using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_asd_s_
{
    class Program
    {
        public static string str;
        public static string operation = null; // арифметична дія
        public static int indexOp = 0; //індекс арифметичної дії
        public static double res = 0;
        public static int p = 0;
        public static double max = 0;
        public static string maxstr = null;
        public static bool firstRes = true; // перевірити, чи є дане обчислення першим

        public static bool IsCorrect(string s)
        {
            bool correct = true;
            bool IsNum = false;
            //bool IsOp = false;
            
            string symbol;
            string[] numbers = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string[] oper = { "+", "-", "*", "/" };

            for (int i = 0; i < s.Length; i++)
            {
                // якщо перший символ - арифметична операція
                symbol = s.Substring(i, 1);
                if (i == 0 && (symbol == "+" || symbol == "*" || symbol == "/"))
                    correct = false;

                // якщо крім цифр і знаків є інші символи
                for (int j = 0; j < oper.Length; j++) // перебирати всі арифметичні дії
                {
                    for (int k = 0; k < numbers.Length; k++) // перебирати всі цифри
                    {
                        if (symbol == numbers[k] || symbol == oper[j] || symbol == ",")
                        {
                            IsNum = true; break;
                        }
                    }

                    // якщо "," у неправильному місці
                    if (symbol == ",")
                    {
                        if (i != 0 && i != (s.Length - 1))
                        {
                            if (s.Substring(i - 1, 1) == oper[j] || s.Substring(i + 1, 1) == oper[j])
                                correct = false;
                        }
                        else
                            correct = false;
                    }

                    // неможлива комбінаця арифметичних дій
                    if (i != (s.Length - 1))
                        if (symbol == oper[j] && s.Substring(i + 1, 1) == oper[j])
                        {
                            if (symbol == "*" && s.Substring(i + 1, 1) == "-")
                            { }
                            else
                                correct = false;
                        }
                }

                if (IsNum == false) // якщо символ не є числом, комою і арифметичною дією
                    correct = false;
                else
                    IsNum = false;
            }

            return correct;
        }

        static void brackets(string s)
        {
            string s1, s2 = null;
            string a = null, b = null;
            bool IsOperation = false;

            int k = count(s);

            if (k != 1)
            {
                for (int i = 0; i <= s.Length - 1; i++) //поставити "("
                {
                    if (i != 0)
                        a = s.Substring(i - 1, 1); // а - шукана арифметина дія

                    if (a == "+" || a == "-" || a == "*" || a == "/" || i == 0)
                    {
                        s1 = s.Insert(i, "("); // поставити відкриту дужку після арифметичної дії
                        IsOperation = false;

                        for (int j = i + 2; j <= s1.Length; j++) // поставити ")"
                        {
                            if (j < s1.Length)
                                a = s1.Substring(j, 1);

                            if (a == "+" || a == "-" || a == "*" || a == "/" || j == s1.Length)
                            {
                                if (IsOperation && b != "+" && b != "-" && b != "*" && b != "/") // якщо перед шуканою ар дією не стоїть ще одна ар дії
                                {
                                    s2 = s1;

                                    s2 = s2.Insert(j, ")"); // закрити дужку після арифметичної дії
                                    j++;

                                    res = calculate(s2);
                                    if (firstRes) // якщо результат обчислюється вперше, присвоїти йому максимальне значення (на випадок від'ємного максимуму)
                                    {
                                        firstRes = false;
                                        max = res;
                                        maxstr = s2;
                                    }
                                    if (res > max)
                                    {
                                        max = res;
                                        maxstr = s2;
                                    }
                                }
                                else
                                    IsOperation = true; // зафіксувати, що а було арифм дією
                            }
                            b = a;
                        }
                    }
                }
                p++; 
                while (p < k) // ставити пари дужок, допоки їхня кількість менша, ніж кількість арифм дій
                    brackets(s2);
            }
            else
            {
                max = calculate(s); // яккщо лише одна арифм дія не ставити дужки
                maxstr = s;
            }    
        }

        static int count(string s)
        {
            int k = 0;
            string a, b; // ар дія і ар дія

            for (int j = 0; j < s.Length; j++)
            {
                a = s.Substring(j, 1);
                b = "";
                if (j > 0)
                    b = s.Substring(j - 1, 1);
                if ((a == "+" || a == "-" || a == "*" || a == "/") && j != 0 && b != "+" && b != "-" && b != "*" && b != "/") // рахувати як одну дію, якщо їх підряд дві
                {
                    k++;
                    operation = a;
                    indexOp = j;
                }
            }

            return k;
        }

        static double calculate(string s)
        {
            int k; // кількість арифметичниї дій
            string s1, s2, sq;
            string c1 = null, c2 = null; // ліва і права частини
            int h, hm, hd; // індекс арифметичної дії
            int indexqo = 0, indexqc = 0; // індекс дужки
            int l1 = 0, r1 = 0; // індекс знака лівої частини і правої

            for (int j = indexqo + 1; j < s.Length; j++) // пошук дужок у рядку
            {
                if (s.Substring(j, 1) == "(")
                    indexqo = j;
                if (s.Substring(j, 1) == ")")
                {
                    indexqc = j; break;
                }
            }

            if (indexqo != -1) // вирізати рядок, що міститься між дужками
            {
                sq = s.Substring(indexqo + 1, indexqc - indexqo - 1);
                res = calculate(sq);
                s1 = s.Substring(0, indexqo) + res.ToString() + s.Substring(indexqc + 1);
                res = calculate(s1);
                return res;
            }

            // визначити кількість знаків
            k = count(s);

            // якщо не має знаків - повернути число
            if (k == 0)
                return double.Parse(s);

            if (k == 1)
            {
                h = indexOp; // індекс останнього знака
                c1 = s.Substring(0, h); // зліва від знака
                c2 = s.Substring(h + 1, s.Length - h - 1); // справа від знака

                // якщо під час обрахунків виникло --число
                if (c1.Length > 2 && c1.Substring(0, 2) == "--")
                    c1 = c1.Substring(2);
                else if (c2.Length > 2 && c2.Substring(0, 2) == "--")
                    c2 = c2.Substring(2);

                if (operation == "+")
                    res = double.Parse(c1) + double.Parse(c2);
                if (operation == "-")
                    res = double.Parse(c1) - double.Parse(c2);
                if (operation == "*")
                    res = double.Parse(c1) * double.Parse(c2);
                if (operation == "/")
                    res = double.Parse(c1) / double.Parse(c2);
            }

            else
            {
                hm = s.IndexOf("*");
                hd = s.IndexOf("/");
                h = hm;

                // пріоритетність * і /
                if (hm != -1 || hd != -1)
                {
                    if ((hd < hm || hm == -1) && hd != -1) // виконувати /, якщо немає *, або якщо / розташоване ближче до початку рядку
                        h = hd;
                    else if ((hd > hm || hd == -1) && hm != -1)
                        h = hm;
                }

                // визначити + або -
                if (h == -1)
                {
                    for (int j = 0; j < s.Length; j++)
                    {
                        if (s.Substring(j, 1) == "+" || s.Substring(j, 1) == "-")
                        {
                            h = j; break;
                        }
                    }
                }

                // знайти частину рядка, що розташована зліва від знайденого знака і обмежується попереднім знаком
                for (int l = h - 1; l >= 0; l--)
                {
                    if (l == 0) // якщо це перший знак
                    {
                        c1 = s.Substring(l, h - l);
                        l1 = l; break;
                    }

                    // обмежується попереднім знаком
                    else if (s.Substring(l, 1) == "+" || s.Substring(l, 1) == "-" || s.Substring(l, 1) == "*" || s.Substring(l, 1) == "/")
                    {
                        c1 = s.Substring(l + 1, h - 1 - l);
                        l1 = l; break;
                    }
                }

                // знайти праву частину
                for (int r = h + 1; r <= s.Length; r++)
                {
                    if (r == s.Length) // якщо це останній знак
                    {
                        c2 = s.Substring(h + 1, r - 1 - h);
                        r1 = r; break;
                    }

                    // обмежується наступною арифметичною дією
                    else if (s.Substring(r, 1) == "+" || s.Substring(r, 1) == "-" || s.Substring(r, 1) == "*" || s.Substring(r, 1) == "/")
                    {
                        // якщо дійшли до наступної арифм дії і символ після неї не арифм дія
                        if (r != h + 1)
                        {
                            c2 = s.Substring(h + 1, r - 1 - h);
                            r1 = r; break;
                        }

                    }
                }

                // порахувати вирізану частину
                res = calculate(c1 + s.Substring(h, 1) + c2);

                // склеїти назад у рядок
                if (l1 == 0)
                    s2 = res.ToString() + s.Substring(r1, s.Length - r1);
                else
                    s2 = s.Substring(0, l1 + 1) + res.ToString() + s.Substring(r1, s.Length - r1);

                // порахувати цей рядок
                res = calculate(s2);
            }
            return res;
        }

        static void Main(string[] args)
        {
            bool isCorrect;

            Console.WriteLine("Введіть вираз без дужок:");
            str = Console.ReadLine();

            // виконувати, якщо рядок введено коректно
            isCorrect = IsCorrect(str);
            if (isCorrect)
            {
                brackets(str);
                Console.WriteLine();
                Console.WriteLine("Максимальне значення");
                Console.WriteLine(maxstr + " = " + max);
            }
            else
                Console.WriteLine("Дані введено не коректно");
            Console.ReadKey();
        }
    }
}
