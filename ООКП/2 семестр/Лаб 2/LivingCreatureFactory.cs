using System;
using System.Collections.Generic;
using System.Text;

namespace lab_2
{
    abstract class LivingCreatureFactory
    {
        public abstract Predator CreatePredator(int x, int y);
        public abstract Prey CreatePrey(int x, int y);
    }
}
