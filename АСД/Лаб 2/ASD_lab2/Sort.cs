using System;
using System.Collections.Generic;
using System.Text;

namespace ASD_lab2
{
    class Sort
    {
        public void MergeSort(int[] mas)
        {
            if (mas.Length <= 1)
            {
                return;
            }

            int LeftLength = mas.Length / 2;
            int RightLength = mas.Length - LeftLength;
            int[] LeftArr = new int[LeftLength];
            int[] RightArr = new int[RightLength];
            int j = LeftLength;

            for (int i = 0; i < LeftLength; i++)
            {
                LeftArr[i] = mas[i];
            }

            for (int i = 0; i < RightLength; i++)
            {
                RightArr[i] = mas[j];
                j++;
            }

            MergeSort(LeftArr);
            MergeSort(RightArr);

            Merge(mas, LeftArr, RightArr);
        }

        public void Merge(int[] mas, int[] left, int[] right)
        {
            int LIndex = 0;
            int RIndex = 0;
            int Index = 0;
            
            while (Index < mas.Length)
            {
                if (LIndex >= left.Length)
                {
                    mas[Index] = right[RIndex];
                    RIndex++;
                }

                else if (RIndex >= right.Length)
                {
                    mas[Index] = left[LIndex];
                    LIndex++;
                }

                else if (left[LIndex] < right[RIndex])
                {
                    mas[Index] = left[LIndex];
                    LIndex++;
                }

                else
                {
                    mas[Index] = right[RIndex];
                    RIndex++;
                }

                Index++;
            }
        }
    }
}
