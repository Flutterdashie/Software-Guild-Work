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
        public State GetState(string id)
        {
            var query = from s in StateMapper.GetStates()
                        where s.StateAbbr == id || s.StateName == id
                        select s;
            return query.FirstOrDefault();
        }
    }
}
