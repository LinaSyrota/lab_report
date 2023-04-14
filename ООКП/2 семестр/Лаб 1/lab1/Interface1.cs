using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public interface IStrategy
    {
        double calculate(int n, double[] arr);
    }
}
