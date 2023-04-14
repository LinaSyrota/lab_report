using System;
using System.Collections.Generic;
using System.Text;

namespace lab_2
{
    class Prey : LivingCreature
    {
        public Prey(int x, int y, int maxSpeed): base(x, y, maxSpeed)
        {
        }

        public override void Move()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            int dx = 0;
            int dy = 0;
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    dy = -1;
                    break;
                case ConsoleKey.DownArrow:
                    dy = 1;
                    break;
                case ConsoleKey.LeftArrow:
                    dx = -1;
                    break;
                case ConsoleKey.RightArrow:
                    dx = 1;
                    break;
            }
            int newX = X + dx;
            int newY = Y + dy;
            if (newX >= 0 && newX <= Console.WindowWidth - 1 && newY >= 0 && newY <= Console.WindowHeight - 1)
            {
                X = newX;
                Y = newY;
            }
        }
    }
}
