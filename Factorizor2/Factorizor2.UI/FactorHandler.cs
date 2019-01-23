using Factorizor2.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor2.UI
{
    public class FactorHandler
    {
        private int _target;
        private List<int> _factors;
        private bool _isPrime;
        private bool _isPerfect;

        public FactorHandler()
        {
            _target = 0;
            _factors = new List<int>();
        }
        private void Calculate()
        {
            _factors = FactorFinder.FindFactorList(_target);
            _factors.Add(_target);
            _isPrime = PrimeChecker.IsPrime(_target);
            _isPerfect = PerfectChecker.IsPerfect(_target);
        }

        public void PrintResults()
        {
            Calculate();
            string prompt = $"The factors of {_target} are: ";
            UserIO.PrintIntList(prompt, _factors);
            string firstHalf = $"{_target} is ";
            string primeStatement = UserIO.BoolInserter(firstHalf, _isPrime, "a prime number");
            UserIO.DisplayString(primeStatement);
            string perfectStatement = UserIO.BoolInserter(firstHalf, _isPerfect, "a perfect number");
            UserIO.DisplayString(perfectStatement);
        }

        public void Run()
        {
            _target = UserIO.GetIntFromUser("Enter a positive, non-zero integer to factorize: ", 1);
            PrintResults();
        }

    }
}
