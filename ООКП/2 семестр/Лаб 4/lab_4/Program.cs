using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace TCP_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();

            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;

            // Встановлюємо для сокету локальну кінцеву точку
            IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 11000);

            // Створюємо сокет Tcp/Ip
            Socket sListener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            // Призначаємо сокет локальної кінцевої точки та слухаємо вхідні сокети
            try
            {
                sListener.Bind(ipEndPoint);
                sListener.Listen(10);
                bool continueWork = true;
                // Починаємо слухати з’єднання
                while (continueWork)
                {
                    Console.WriteLine("Очікуємо з’єднання через порт {0}", ipEndPoint);

                    // Програма припиняється, очікуючи на вхідне з’єднання
                    Socket handler = sListener.Accept();
                    string data = null;
                    string reply = null;

                    // Ми дочекалися клієнта, який намагається з нами з’єднатися
                    byte[] bytes = new byte[1024];
                    int bytesRec = handler.Receive(bytes);
                    data += Encoding.UTF8.GetString(bytes, 0, bytesRec);

                    // розбиваємо отриманий меседж на команду і масив
                    string[] part = data.Split(' ');

                    // розбиваємо другу частину на числа і записуємо їх у масив
                    if (part[0] == "array")
                    {
                        string[] nums = part[1].Split(',');

                        // перевірка числа на коректність
                        foreach (string n in nums)
                        {
                            int number;
                            bool isNumber = int.TryParse(n, out number);
                            if (isNumber)
                            {
                                numbers.Add(number);
                                reply = "Успішно збережено";
                            }
                            else
                            {
                                reply = $"Помилка введення {n}\n";
                                numbers.Clear();
                                break;
                            }
                        }
                        Console.WriteLine(reply + "\n\n");
                    }
                    else
                    {
                        List<int> resultNumbers = new List<int>(numbers);
                        switch (part[1])
                        {
                            case "sortup":
                                //resultNumbers = numbers;
                                resultNumbers.Sort();
                                reply = "Відсортований за зростанням набір чисел: " + string.Join(", ", resultNumbers.ToArray());
                                Console.WriteLine("Отримано набір чисел: " + string.Join(", ", numbers.ToArray()));
                                Console.WriteLine("Відсортований за зростанням набір чисел: " + string.Join(", ", resultNumbers.ToArray()) + "\n\n");
                                break;
                            case "sortdown":
                                resultNumbers.Sort();
                                resultNumbers.Reverse();
                                reply = "Відсортований за спаданням набір чисел: " + string.Join(", ", resultNumbers.ToArray());
                                Console.WriteLine("Отримано набір чисел: " + string.Join(", ", numbers.ToArray()));
                                Console.WriteLine("Відсортований за спаданням набір чисел: " + string.Join(", ", resultNumbers.ToArray()) + "\n\n");
                                break;
                            case "sum":
                                int sum = numbers.Sum();
                                reply = "Сума введених цілих чисел: " + sum.ToString();
                                Console.WriteLine("Отримано набір чисел: " + string.Join(", ", numbers.ToArray()));
                                Console.WriteLine("Сума: " + sum.ToString() + "\n\n");
                                break;
                            case "mean":
                                double mean = numbers.Average();
                                reply = "Середнє арифметичне введених цілих чисел: " + Math.Round(mean, 2).ToString();
                                Console.WriteLine("Отримано набір чисел: " + string.Join(", ", numbers.ToArray()));
                                Console.WriteLine("Середнє арифметичне: " + Math.Round(mean, 2).ToString() + "\n\n");
                                break;
                            case "reset":
                                numbers.Clear();
                                reply = "Всі числа на сервері видалено";
                                Console.WriteLine("Всі числа на сервері видалено\n\n");
                                break;
                            case "delete":
                                int elem;
                                Console.WriteLine("Отримано набір чисел: " + string.Join(", ", numbers.ToArray()));
                                if (int.TryParse(part[0], out elem))
                                {
                                    int k = numbers.RemoveAll(el => el == int.Parse(part[0]));
                                    if (k > 0)
                                    {
                                        reply = $"Видалено {part[0]}";
                                        Console.WriteLine($"Видалено {part[0]}");
                                        Console.WriteLine("Новий набір чисел: " + string.Join(", ", numbers.ToArray()) + "\n\n");
                                    }
                                    else
                                    {
                                        reply = "Не знайдено елемент, який потрібно видалити";
                                        Console.WriteLine($"Не знайдено елемент, який потрібно видалити: {part[0]}\n\n");
                                    }
                                }
                                else
                                {
                                    reply = "Помилка введення шуканого елемента";
                                    Console.WriteLine("Помилка введення шуканого елемента\n\n");
                                }
                                break;
                            case "end":
                                reply = "Сервер завершив з’єднання з клієнтом.";
                                Console.WriteLine("Сервер завершив з’єднання з клієнтом.");
                                continueWork = false;
                                break;
                        }

                        // Показуємо дані на консолі
                        reply = "Поточний набір чисел: " + string.Join(", ", numbers.ToArray()) + "\n" + reply;
                    }

                    byte[] msg = Encoding.UTF8.GetBytes(reply);
                    handler.Send(msg);
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
