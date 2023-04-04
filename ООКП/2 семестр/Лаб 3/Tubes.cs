using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    // + довжини трубок і стрічок
    public class Tubes: Decorator
    {
        public Tubes(ICalculator item) : base(item) { }

        public override List<double> calculate()
        {
            List<double> result = new List<double>();
            List<double> n = base.calculate();

            double lt = n[0] * 0.1;
            result.Add(lt);

            return result;
        }

        public override string message(List<double> result) => $"\n\nДовжина трубок і стрічок: {result[0]} (м)";
    }
}
