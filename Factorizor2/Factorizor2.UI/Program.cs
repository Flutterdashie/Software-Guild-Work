using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factorizor2.BLL;

namespace Factorizor2.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            FactorHandler calc = new FactorHandler();
            calc.Run();
        }
    }
}
