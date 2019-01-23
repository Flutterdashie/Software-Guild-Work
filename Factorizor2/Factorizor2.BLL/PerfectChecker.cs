using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor2.BLL
{
    public static class PerfectChecker
    {
        private static int SumFactors(List<int> factors)
        {
            int sum = 0;
            foreach(int factor in factors)
            {
                sum += factor;
            }
            //I could also just do factors.Sum() but I want to treat this as though I'm using a list instead of an array
            return sum;
        }
        public static bool IsPerfect(int target)
        {
            List<int> factors = FactorFinder.FindFactorList(target);
            int sum = SumFactors(factors);
            return sum == target;
        }
    }
}
