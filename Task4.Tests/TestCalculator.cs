using System;
using System.Collections.Generic;
using NUnit.Framework;
using Task4;
using Task4.Solution.Version_1;
using Task4.Solution.Version_2;
using System.Linq;

namespace Task4.Tests
{
    [TestFixture]
    public class TestCalculator
    {
        private readonly List<double> values = new List<double> { 10, 5, 7, 15, 13, 12, 8, 7, 4, 2, 9 };
        ICalculator calculator;

        [Test]
        public void Test_AverageByMean()
        {
            calculator = new MeanCalculator();

            double expected = 8.3636363;

            double actual = calculator.CalculateAverage(values);

            Assert.AreEqual(expected, actual, 0.000001);

            Assert.AreEqual(expected, AverageCalculator.CalculateAverage(values, vls => vls.Sum() / vls.Count()), 0.000001);

            Assert.AreEqual(expected, AverageCalculator.CalculateAverage(values, calculator), 0.000001);
        }

        [Test]
        public void Test_AverageByMedian()
        {
            calculator = new MedianCalculator();

            double expected = 8.0;

            double actual = calculator.CalculateAverage(values);

            Assert.AreEqual(expected, actual, 0.000001);

            Func<IEnumerable<double>, double> method = delegate
            {
                var sortedValues = values.OrderBy(x => x).ToList();

                int n = sortedValues.Count;

                if (n % 2 == 1)
                {
                    return sortedValues[(n - 1) / 2];
                }

                return (sortedValues[sortedValues.Count / 2 - 1] + sortedValues[n / 2]) / 2;
            };

            Assert.AreEqual(expected, AverageCalculator.CalculateAverage(values, method), 0.000001);

            Assert.AreEqual(expected, AverageCalculator.CalculateAverage(values, calculator), 0.000001);
        }
    }
}