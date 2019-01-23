using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Factorizor2.BLL;

namespace Factorizor2.Tests
{
    [TestFixture]
    public class FactorizorTests
    {
        [TestCase(-1,false)]
        [TestCase(6, true)]
        [TestCase(7,false)]
        [TestCase(28,true)]
        [TestCase(29,false)]
        [TestCase(496,true)]
        [TestCase(497,false)]
        public void PerfectTest(int target, bool perfectResult)
        {
            bool isPerfect = PerfectChecker.IsPerfect(target);
            bool testResult = (isPerfect == perfectResult);
            Assert.IsTrue(testResult);
        }
        
        [TestCase(2,true)]
        [TestCase(3,true)]
        [TestCase(5,true)]
        [TestCase(6,false)]
        [TestCase(7,true)]
        [TestCase(31,true)]
        [TestCase(34,false)]
        [TestCase(997,true)]
        [TestCase(4967297, true)]
        [TestCase(4967299, false)]
        public void PrimeTest(int target, bool primeResult)
        {
            bool isPrime = PrimeChecker.IsPrime(target);
            bool testResult = (isPrime == primeResult);
            Assert.IsTrue(testResult);
        }

        [TestCase(1)] //The factor list does not include the target number itself for calculation purposes
        [TestCase(-1)]
        [TestCase(-27)] //Factor list being empty for negative numbers is intended.
        [TestCase(2,1)]
        [TestCase(6,1,2,3)]
        [TestCase(7,1)]
        [TestCase(8,1,2,4)]
        [TestCase(9,1,3)]
        [TestCase(34,1,2,17)]
        public void FactorListTest(int target, params int[] resultList)
        {
            List<int> factors = FactorFinder.FindFactorList(target);
            int[] targetArray = factors.ToArray();
            Assert.AreEqual(targetArray.Length, resultList.Length);
            if (targetArray.Length == resultList.Length)
            {
                for(int i = 0; i < targetArray.Length; i++)
                {
                    Assert.AreEqual(targetArray[i], resultList[i]);
                }
            }
            
        }

    }
}
