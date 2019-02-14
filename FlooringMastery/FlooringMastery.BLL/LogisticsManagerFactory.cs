using FlooringMastery.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.BLL
{
    internal static class LogisticsManagerFactory
    {
        internal static LogisticsManager Create()
        {
            return new LogisticsManager(new StateGetter(), new ProductGetter());
        }
    }
}
