using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    // базовий декоратор
    public class Decorator: ICalculator
    {
        public ICalculator item;

        public Decorator(ICalculator _item)
        {
            item = _item;
        }

        public virtual List<double> calculate()
        {
            return item.calculate();
        }

        public virtual string message(List<double> result)
        {
            return item.message(result);
        }
    }
}
