using System;
using System.Collections.Generic;
using System.Text;

namespace Huffman
{
    class Node
    {
        public char Data { get; set; }
        public int Frequance { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public List<Node> Nodes(Dictionary<char, int> symbols)
        {
            List<Node> Nodes = new List<Node>();

            foreach (var symbol in symbols)
            {
                Nodes.Add(new Node() { Data = symbol.Key, Frequance = symbol.Value});
            }

            return Nodes;
        }

        public string Code(Char symbol, string bincode)
        {
            if (Data == symbol)
            {
                return bincode;
            }
            else 
            {
                if (Left != null)
                {
                    string path = Left.Code(symbol, bincode + "0");
                    if (path != null)
                    {
                        return path;
                    }
                }
                if (Right != null)
                {
                    string path = Right.Code(symbol, bincode + "1");
                    if (path != null)
                    {
                        return path;
                    }
                }
            }
            return null;
        }

    }
}
