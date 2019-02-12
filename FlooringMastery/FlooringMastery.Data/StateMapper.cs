using FlooringMastery.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Data
{
    public static class StateMapper
    {
        public static List<State> GetStates()
        {
            List<State> result = new List<State>();
            string[] lines =File.ReadAllLines(@".\taxes.txt");
            foreach(string line in lines)
            {
                string[] values = line.Split(',');
                result.Add(new State(values[1], values[0], decimal.Parse(values[2])));
            }
            return result;
        }
    }
}
