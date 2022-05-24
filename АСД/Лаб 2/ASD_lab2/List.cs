using System;
using System.Collections.Generic;
using System.Text;

namespace ASD_lab2
{
    class List
    {
        public Item head;
        public void addItem(int data)
        {
            if (head == null)
                head = new Item(data, null);
            else
            {
                Item p = head;
                while (p.Next != null)
                {
                    p = p.Next;
                }
                p.Next = new Item(data, null);
            }
            
            
        }

        public void newList(int[] arr, int n)
        {
            Console.WriteLine("Згенеровано список:");
            int i = 0;
            Item p = head;
            while (i < n && p != null)
            {
                p.Data = arr[i];
                Console.Write(p.Data + " ");
                p = p.Next;
                i++;
            }
            Console.WriteLine(" ");
        }

        public Item Merge(Item Left, Item Right)
        {
            Item result = null;

            if (Left == null)
                return Right;
            if (Right == null)
                return Left;

            if (Left.Data <= Right.Data)
            {
                result = Left;
                result.Next = Merge(Left.Next, Right);
            }
            else
            {
                result = Right;
                result.Next = Merge(Left, Right.Next);
            }
            return result;
        }

        public Item MergeSort(Item head)
        {
            if (head == null || head.Next == null)
            {
                return head;
            }

            Item middle = getMiddle(head);
            Item Nextmiddle = middle.Next;

            middle.Next = null;

            Item left = MergeSort(head);

            Item right = MergeSort(Nextmiddle);

            Item ResultList = Merge(left, right);
            return ResultList;
        }
     
        Item getMiddle(Item head)
        {
            Item current = head;

            int k = 0, k1 = 0;

            while (current != null)
            {
                k++;
                current = current.Next;
            }

            current = head;
            while (k1 * 2 + 1 < k - 1)
            {
                k1++;
                current = current.Next;
            }
            return current;
        }
    }
}
