using System;
using System.Collections.Generic;
using System.Text;

namespace _2
{
    public class Prey : Animal
    {
        public override int X { get; set; }
        public override int Y { get; set; }
        public override string Name { get; set; }
        public Prey(int x, int y, string name)
        {
            X = x;
            Y = y;
            Name = name;
        }

        public void FindPrey(Animal prey, string[,] field, bool clear, string mes)
        {
            Field f = new Field(field);

            field[prey.Y, prey.X] = "@";

            Console.WriteLine(mes);
            f.OutputField(field);

            if (clear)
            {
                field[prey.Y, prey.X] = " ";
            }
        }

        public override void Move(Animal prey, (bool, Animal, string) isSensed, string[,] field)
        {
            int x0 = prey.X;
            int y0 = prey.Y;

            FindPrey(prey, field, true, isSensed.Item3);
            Console.WriteLine("press+");
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            int x = 0;
            int y = 0;

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    y = -1; break;
                case ConsoleKey.DownArrow:
                    y = 1; break;
                case ConsoleKey.LeftArrow:
                    x = -1; break;
                case ConsoleKey.RightArrow:
                    x = 1; break;
            }

            prey.X += x;
            prey.Y += y;

            if (prey.X > 10)
                prey.X = 10;
            else if (prey.X < 0)
                prey.X = 0;

            if (prey.Y > 10)
                prey.Y = 10;
            else if (prey.Y < 0)
                prey.Y = 0;

            Console.ReadKey();
            Console.Clear();
            Console.WriteLine($"{prey.Name} is moving from ({x0}, {y0}) to ({prey.X}, {prey.Y})");
            FindPrey(prey, field, false, isSensed.Item3);
            Console.ReadKey();
            Console.Clear();
        }
    }
}
