using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    // + параметри магістрального трубопроводу
    public class Main_Pipeline: Decorator
    {
        double lengthS { get; }
        public Main_Pipeline(ICalculator item, double _lengthS) : base(item) 
        {
            lengthS = _lengthS;
        }

        public override List<double> calculate()
        {
            List<double> result = new List<double>();
            List<double> sq = base.calculate();

            double length = lengthS + 2 * 2; // довжина магістрального трубопроводу
            result.Add(length);

            double diameter = Math.Sqrt((4 * sq[1]) / (Math.PI * 1.2)); // діаметр магістрального трубопроводу
            result.Add(Math.Round(diameter, 2));

            return result;
        }

        public override string message(List<double> result) => $"\n\nМагістральна труба: \nДовжина: {result[0]} (м)\nДіаметр: {result[1]} (м)";

    }
}
