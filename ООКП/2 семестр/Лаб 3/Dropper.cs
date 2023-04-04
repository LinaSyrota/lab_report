using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    // + кількість крапельниць
    public class Dropper: Decorator
    {
        public double length { get; }
        public double width { get; }

        public Dropper(ICalculator item, double _length, double _width) : base(item) 
        {
            length = _length;
            width = _width;
        }

        public override List<double> calculate()
        {
            List<double> result = new List<double>();
            List<double> sq = base.calculate();

            double n = (sq[1] * length) / (width * 0.5);
            result.Add(Math.Round(n));

            return result;
        }

        public override string message(List<double> result) => $"\n\nКількість крапельниць: {result[0]}";
    }
}
