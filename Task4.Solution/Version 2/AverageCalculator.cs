using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4.Solution.Version_1;

namespace Task4.Solution.Version_2
{
    public static class AverageCalculator
    {
        public static double CalculateAverage(IEnumerable<double> values, Func<IEnumerable<double>, double> averagingMethod)
        {
            return averagingMethod.Invoke(values);
        }

        public static double CalculateAverage(IEnumerable<double> values, ICalculator calculator)
        {
            return calculator.CalculateAverage(values);
        }
    }
}
