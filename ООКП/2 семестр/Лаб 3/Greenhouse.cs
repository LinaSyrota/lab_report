using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public class Greenhouse: ICalculator
    {
        double length { get; }
        double width { get; }

        public Greenhouse(double _length, double _widht)
        {
            length = _length;
            width = _widht;
        }

        public List<double> calculate()
        {
            List<double> result = new List<double>();

            double S = length * width; // площа 
            result.Add(S);

            double Q = S * 0.75 * 2; // кількість води в годину
            result.Add(Q);

            return result;
        }

        public string message(List<double> r) => $"Параметри теплиці: \nДовжина: {length} (м)\nШирина: {width} (м)";
    }
}
