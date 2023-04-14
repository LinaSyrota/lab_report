using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class Calculator
    {
        public Calculator(IStrategy s)
        {
            Strategy = s;
        }

        public IStrategy Strategy { private get; set; }
        
        public double calculate(int n, double[] arr)
        {
            return Strategy.calculate(n, arr);
        }
    }
}
