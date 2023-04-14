using System;
using System.Collections.Generic;
using System.Text;

namespace lab_2
{
    abstract class LivingCreature
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int MaxSpeed { get; set; }

        public LivingCreature(int x, int y, int maxSpeed)
        {
            X = x;
            Y = y;
            MaxSpeed = maxSpeed;
        }

        public abstract void Move();
    }
}
