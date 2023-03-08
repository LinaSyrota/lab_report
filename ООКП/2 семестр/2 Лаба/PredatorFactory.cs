using System;
using System.Collections.Generic;
using System.Text;

namespace _2
{
    public class PredatorFactory : AnimalFactory
    {
        public override Animal CreateAnimal(int x, int y, string name)
        {
            return new Predator(x, y, name);
        }
    }
}
