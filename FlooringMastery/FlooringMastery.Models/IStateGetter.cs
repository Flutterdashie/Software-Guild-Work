using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models
{
    public interface IStateGetter
    {
        State GetState(string id); // can use either name or abbrevation
    }
}
