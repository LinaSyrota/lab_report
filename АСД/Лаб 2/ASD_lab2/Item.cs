using System;
using System.Collections.Generic;
using System.Text;

namespace ASD_lab2
{
    public class Item
    {
        public Item(int data, Item next)
        {
            Data = data;
            Next = next;
        }

        public int Data;
        public Item Next;
    }
}
