using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models
{
    public struct State
    {
        public readonly string StateName;
        public readonly string StateAbbr;
        public readonly decimal TaxRate;
        public State(string name, string abbr, decimal rate)
        {
            StateName = name;
            StateAbbr = abbr;
            TaxRate = rate;
        }
    }
}
