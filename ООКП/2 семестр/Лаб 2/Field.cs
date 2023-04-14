using System;
using System.Collections.Generic;
using System.Text;

namespace _2
{
    class Field
    {
        public string[,] field { get; set; }

        public Field(string[,] _field)
        {
            field = _field;
        }

        public string[,] CreateField(string[,] field)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    field[i, j] = " ";
                }
            }

            return field;
        }

        public void OutputField(string[,] field)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(field[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
