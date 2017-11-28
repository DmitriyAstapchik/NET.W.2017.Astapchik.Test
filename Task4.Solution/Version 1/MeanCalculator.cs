using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.Solution.Version_1
{
    public class MeanCalculator : ICalculator
    {
        public double CalculateAverage(IEnumerable<double> values)
        {
            return values.Sum() / values.Count();
        }
    }
}
