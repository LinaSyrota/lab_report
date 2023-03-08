using System;
using System.Collections.Generic;
using System.Text;

namespace _2
{
    public class PreyFactory : AnimalFactory
    {
        public override Animal CreateAnimal(int x, int y, string name)
        {
            return new Prey(x, y, name);
        }
    }
}
