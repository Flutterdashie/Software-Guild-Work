using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor2.BLL
{
    public static class PrimeChecker
    {
        public static bool IsPrime(int target)
        {
            return !FactorFinder.HasFactors(target);
        }
        //this is here to offer a way that doesn't make the PrimeChecker class redundant.
        public static bool IsPrimeInefficient(int target)
        {
            List<int> factors = FactorFinder.FindFactorList(target);
            return factors.Sum() != 1;
        }
    }
}
