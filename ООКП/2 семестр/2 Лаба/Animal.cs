using System;
using System.Collections.Generic;
using System.Text;

namespace _2
{
    public abstract class Animal
    {
        public abstract int X { get; set; }
        public abstract int Y { get; set; }
        public abstract string Name { get; set; }
        public abstract void Move(Animal predator, (bool, Animal, string) isSensed, string[,] field);
    }
}
