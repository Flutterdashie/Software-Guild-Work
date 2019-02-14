using FlooringMastery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Data
{
    public class StateGetter : IStateGetter
    {
        public IEnumerable<State> GetStates()
        {
            //Provides room for states to be invalidated due to stock issues or whatever else later.
            return StateMapper.GetStates();
        }
    }
}
