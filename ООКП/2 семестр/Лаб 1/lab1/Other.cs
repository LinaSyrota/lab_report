using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class Other: IStrategy
    {
        public double calculate(int n, double[] arr)
        {
            double p = 0;

            for (int i = 0; i < n; i++)
                p += arr[i];

            return p;
        }
    }
}
