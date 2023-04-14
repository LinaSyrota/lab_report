using System;
using System.Collections.Generic;
using System.Text;

namespace _2
{
    public class Predator : Animal
    {
        public override int X { get; set; }
        public override int Y { get; set; }
        public override string Name { get; set; }
        public Predator(int x, int y, string name)
        {
            X = x;
            Y = y;
            Name = name;
        }

        public void FindPredator(Animal predator, string[,] field, bool clear, string mes)
        {
            Field f = new Field(field);

            field[predator.Y, predator.X] = "#";
            Console.WriteLine(mes);
            f.OutputField(field);

            if (clear)
            {
                field[predator.Y, predator.X] = " ";
            }

            Console.ReadKey();
            Console.Clear();
        }

        public override void Move(Animal predator, (bool, Animal, string) isSensed, string[,] field)
        {
            int x0 = predator.X;
            int y0 = predator.Y;
            int x = 0;
            int y = 0;

            FindPredator(predator, field, true, isSensed.Item3);
            
            if (isSensed.Item1)
            {
                if (x0 - isSensed.Item2.X < 0)
                    predator.X += 1;
                else if(x0 - isSensed.Item2.X > 0)
                    predator.X -= 1;

                if (y0 - isSensed.Item2.Y < 0)
                    predator.Y += 1;
                else if (y0 - isSensed.Item2.Y > 0)
                    predator.Y -= 1;
            }
            else
            {
                Random rnd = new Random();
                x = rnd.Next(-1, 2);
                y = rnd.Next(-1, 2);
            }

            predator.X += x;
            predator.Y += y;

            if (predator.X > 10)
                predator.X = 10;
            else if (predator.X < 0)
                predator.X = 0;

            if (predator.Y > 10)
                predator.Y = 10;
            else if (predator.Y < 0)
                predator.Y = 0;

            Console.WriteLine($"{predator.Name} is moving from ({x0}, {y0}) to ({predator.X}, {predator.Y})");
            FindPredator(predator, field, false, isSensed.Item3);
        }

        public (bool, string) SensePrey(Animal prey, Animal predator, int R, int r)
        {
            int distance = CalculateDistance(this, prey);
            string message = null;

            if (distance <= R)
            {
                message = $"{predator.Name} has detected prey within range!";

                if (distance <= r)
                {
                    Console.WriteLine($"{predator.Name} has swallowed prey!");
                    Console.WriteLine(".");
                    Console.WriteLine(".");
                    Console.WriteLine(".");
                    Console.WriteLine();
                    Console.WriteLine("GAME OVER");

                    Console.ReadKey();

                    Environment.Exit(0);
                }
                return (true, message);
            }
            return (false, message);
        }

        private int CalculateDistance(Animal a, Animal b)
        {
            return (int)Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
        }
    }
}
