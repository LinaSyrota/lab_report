using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class RegularStrategy: IStrategy
    {
        public double calculate(int n, double[] arr)
        {
            return arr[0] * n;
        }
    }
}
