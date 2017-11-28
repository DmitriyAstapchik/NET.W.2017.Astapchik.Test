using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test6.Solution
{
    public static class SequenceGenerator
    {
        public static IEnumerable<T> GenerateSequence<T>(T x1, T x2, int length, Func<T, T, T> formula)
        {
            if (x1 == null || x2 == null || formula == null)
            {
                throw new ArgumentNullException();
            }

            if (length < 2)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }

            return Generate(x1, x2, length, formula);
        }

        private static IEnumerable<T> Generate<T>(T x1, T x2, int length, Func<T, T, T> formula)
        {
            yield return x1;
            yield return x2;

            for (uint i = 2; i < length; i++)
            {
                yield return x2 = formula(x1, x1 = x2);
            }
        }
    }
}
