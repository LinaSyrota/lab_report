using System;
using System.Collections.Generic;
using System.Text;

namespace lab_2
{
    class Predator : LivingCreature
    {
        public int SearchRadius { get; set; }
        public int SwallowRadius { get; set; }

        public Predator(int x, int y, int maxSpeed, int searchRadius, int swallowRadius)
            : base(x, y, maxSpeed)
        {
            SearchRadius = searchRadius;
            SwallowRadius = swallowRadius;
        }

        public override void Move()
        {
            // move randomly within search radius
            Random random = new Random();
            int dx = random.Next(-MaxSpeed, MaxSpeed + 1);
            int dy = random.Next(-MaxSpeed, MaxSpeed + 1);
            int distance = (int)Math.Sqrt(dx * dx + dy * dy);
            if (distance <= MaxSpeed)
            {
                X += dx;
                Y += dy;
            }
        }

        public bool CanSwallowPrey(Prey prey)
        {
            int distance = (int)Math.Sqrt((X - prey.X) * (X - prey.X) + (Y - prey.Y) * (Y - prey.Y));
            return distance <= SwallowRadius;
        }
    }
}
