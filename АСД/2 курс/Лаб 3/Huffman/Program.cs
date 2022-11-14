using System;
using System.Linq;
using System.Collections.Generic;

namespace Huffman
{
    class Program
    {
        public static Node node = new Node();
        static Dictionary<char, int> frequence(string s)
        {
            Dictionary<char, int> symbols = new Dictionary<char, int>();

            char[] temp = new char[1000];
            int t = 0; // лічильник на temp

            for (int i = 0; i < s.Length; i++)
            {
                bool flag = false; // визначити оцінку, як ту, яка ще не повторювалась
                int f = 0;
                

                for (int j = 0; j < temp.Length; j++)
                {
                    if (s[i] == temp[j])
                        flag = true;
                }

                if (flag == false)
                {
                    for (int j = 0; j < s.Length; j++)
                    {
                        if (s[i] == s[j])
                            f += 1;
                    }

                    temp[t] = s[i];
                    t++;

                    symbols.Add(s[i], f);
                }
            }

            return symbols;

        }

        static Node huffman(List<Node> TreeNodes)
        {
            while (TreeNodes.Count > 1)
            {
                TreeNodes = TreeNodes.OrderByDescending(node => node.Frequance).ToList<Node>();

                if (TreeNodes.Count >= 2)
                {
                    List<Node> FirstTwo = TreeNodes.GetRange(TreeNodes.Count - 2, 2);

                    Node parent = new Node() { Data = '\0', Frequance = FirstTwo[0].Frequance + FirstTwo[1].Frequance, Left = FirstTwo[0], Right = FirstTwo[1] };
                    TreeNodes.Remove(FirstTwo[0]);
                    TreeNodes.Remove(FirstTwo[1]);
                    TreeNodes.Add(parent); 
                }
                
            }

            return TreeNodes[0];
        }

        static Dictionary<char, string> stringCodes (Dictionary<char, int> symbols, Node tree)
        {
            Dictionary<char, string> strCodes = new Dictionary<char, string>();

            foreach (var symbol in symbols)
            {
                strCodes.Add(symbol.Key, tree.Code(symbol.Key, ""));
            }

            return strCodes;
        }

        static string StringEncode(string s, Dictionary<char, string> codes)
        {
            string encoded = null;
            for (int i = 0; i < s.Length; i++)
            {
                encoded += codes[s[i]];
            }

            return encoded;
        }

        static string huffmanDecode(string encoded, Node root)
        {
            string decoded = null;

            Node current = root;
            for (int i = 0; i < encoded.Length; i++)
            {
                if (encoded[i] == '0')
                    current = current.Left;
                else
                    current = current.Right;

                if (current.Data != '\0')
                {
                    decoded += current.Data;
                    current = root;
                }
            }

            return decoded;
        }

        static void Main(string[] args)
        {
            Console.Write("Введіть рядок: ");
            string s = Console.ReadLine();
            Console.WriteLine();

            // словник, що містить частоти
            Dictionary<char, int> symbols = frequence(s);

            // список вузлів
            List<Node> nodes = node.Nodes(symbols);

            // створення бінарного дерева зі списку вузлів
            Node tree = huffman(nodes);

            // словник, що містить двійкові коди
            Dictionary<char, string> codes = stringCodes(symbols, tree);
            Console.WriteLine("Таблиця Хаффмана");
            Console.WriteLine($"символ  | код");
            Console.WriteLine($"--------+----");
            foreach (var symbol in codes)
            {
                Console.WriteLine($"{symbol.Key}       |{symbol.Value}");
            }
            Console.WriteLine();

            // закодований рядок
            Console.WriteLine("----------------------------------------------------------------");
            Console.Write("Закодований рядок: ");
            string encoded = StringEncode(s, codes);
            Console.WriteLine(encoded);
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine();

            // розшифрований рядок
            Console.WriteLine("----------------------------------------------------------------");
            Console.Write("Розшифрований рядок: ");
            string decoded = huffmanDecode(encoded, tree);
            Console.WriteLine(decoded);
            Console.WriteLine("----------------------------------------------------------------");
        }
    }
}
