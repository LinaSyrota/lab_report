using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    // + кількість сполучної та запірної фурнітури
    public class Furniture: Decorator
    {
        public Furniture(ICalculator item) : base(item) { }

        public override List<double> calculate()
        {
            List<double> result = new List<double>();
            List<double> tubesL = base.calculate();

            double Ns = (10 * tubesL[0]) / 0.5; //сполучна
            result.Add((int)Ns);

            double Nz = (10 * tubesL[0]) / 0.1; // запірна
            result.Add((int)Nz);

            return result;
        }

        public override string message(List<double> result) => $"\n\nКількість сполучної фурнітури: {result[0]}\nКількість запірної фурнітури: {result[1]}";
    }
}
