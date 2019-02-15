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
            List<string> lines =File.ReadAllLines(@".\taxes.txt").ToList();
            if (lines.First() == "StateAbbreviation,StateName,TaxRate")
            {
                lines.RemoveAt(0);
            }
            else
            {
                throw new FormatException("Header line of tax file is missing or invalid. Your file may have been compromised.");
            }
            foreach (string line in lines)
            {
                string[] values = line.Split(',');
                result.Add(new State(values[1], values[0], decimal.Parse(values[2])));
            }
            return result;
        }
    }
}
