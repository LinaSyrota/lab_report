using System;
using System.Collections.Generic;
using System.Text;

namespace _2
{
    public abstract class AnimalFactory
    {
        public abstract Animal CreateAnimal(int x, int y, string name);
    }
}
