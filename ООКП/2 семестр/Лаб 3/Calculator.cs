using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public interface ICalculator
    {
        List<double> calculate();
        string message(List<double> result);
    }
}
