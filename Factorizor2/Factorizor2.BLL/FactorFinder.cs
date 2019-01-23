using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor2.BLL
{
    public class FactorFinder
    {

        public static List<int> FindFactorList(int target)
        {
            List<int> factors = new List<int>();
            for (int i = 1; i < (target / 2) + 1; i++)
            {
                if(target % i == 0)
                {
                    factors.Add(i);
                }
            }
            return factors;
        }

        public static bool HasFactors(int target)
        {
            for (int i = 2; i < (target / 2) + 1; i++)
            {
                if(target % i == 0)
                {
                    return true;
                }
            }
            return false;
        }


    }
}
