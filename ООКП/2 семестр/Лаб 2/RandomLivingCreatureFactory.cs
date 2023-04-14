using System;
using System.Collections.Generic;
using System.Text;

namespace lab_2
{
    class RandomLivingCreatureFactory : LivingCreatureFactory
    {
        public override Predator CreatePredator(int x, int y)
        {
            return new Predator(x, y, 5, 50, 20);
        }

        public override Prey CreatePrey(int x, int y)
        {
            return new Prey(x, y, 3);
        }
    }
}
