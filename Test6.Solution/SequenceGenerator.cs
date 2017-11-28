using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test6.Solution
{
    public static class SequenceGenerator<T>
    {
        public static IEnumerable<T> Generate(T x1, T x2, uint length, Func<T,T,T> formula)
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
