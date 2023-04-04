using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    // + робочий тиск
    // + продуктивність насосу
    public class Pump: Decorator
    {
        public Pump(ICalculator item) : base(item) { }

        public override List<double> calculate()
        {
            List<double> result = new List<double>();
            List<double> sq = base.calculate();

            double pressure = (9 * (sq[1] / 3600) * 1.2) / (60 * (sq[0] / 10000)); // робочий тиск
            result.Add(pressure);

            double productivity = (2.5 * sq[0] * 0.85 * 1.2) / 2; // продуктивність насосу
            result.Add(productivity);

            return result;
        }

        public override string message(List<double> result) => $"\n\nНасос: \nРобочий тиск: {result[0]} (бар)\nПродуктивність насосу: {result[1]} (л/год)";
    }
}
