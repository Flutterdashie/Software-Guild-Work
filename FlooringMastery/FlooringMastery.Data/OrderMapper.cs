using FlooringMastery.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Data
{
    public static class OrderMapper
    {
        /// <summary>
        /// Attempts to read all orders for the file corresponding to the specified date
        /// </summary>
        /// <param name="date">Date to read from</param>
        /// <returns>Collection of orders from that date</returns>
        /// <exception cref="FileNotFoundException">Given date does not have an order file yet</exception>
        /// <exception cref="FormatException">One of the lines failed to pass through the parser. Invalid data source.</exception>
        public static IEnumerable<Order> ReadAllFromDate(DateTime date)
        {
            string[] lines  = File.ReadAllLines(GetPathByDate(date));
            List<Order> result = new List<Order>();
            foreach (string line in lines)
            {
                result.Add(FromLine(line,date));
            }
            return result;
        }
        
        public static void WriteAllToDate(DateTime date, IEnumerable<Order> orders)
        {
            List<string> lines = new List<string>();
            foreach (Order order in orders)
            {
                lines.Add(ToLine(order));
            }
            if(lines.Count == 0)
            {
                File.Delete(GetPathByDate(date));
            }
            else
            {
                File.WriteAllLines(GetPathByDate(date), lines);
            }
        }

        private static string GetPathByDate(DateTime date)
        {
            return @".\Orders_" + date.ToString("MMddyyyy") + ".txt";
        }

        /// <summary>
        /// Parses a line into an order object with provided date
        /// </summary>
        /// <param name="line">line to parse</param>
        /// <param name="date">date for order object</param>
        /// <returns>order object</returns>
        /// <exception cref="FormatException">This means that one of the parses failed. Data is corrupt. Thrown all the way up the stack, </exception>
        private static Order FromLine(string line, DateTime date)
        {
            string[] values = line.Split('?');
            int oNum = int.Parse(values[0]);
            string name = values[1];
            string sAbbr = values[2];
            decimal tax = decimal.Parse(values[3]);
            string pType = values[4];
            decimal area = decimal.Parse(values[5]);
            decimal cPSF = decimal.Parse(values[6]);
            decimal lcPSF = decimal.Parse(values[7]);
            decimal mCost =decimal.Parse(values[8]);
            decimal lCost = decimal.Parse(values[9]);
            decimal tTax = decimal.Parse(values[10]);
            decimal total = decimal.Parse(values[11]);
            return new Order(oNum, date, name, sAbbr, tax, pType, area, cPSF, lcPSF, mCost, lCost, tTax, total);
        }
        
        private static string ToLine(Order order)
        {
            string[] contents = new string[12];
            contents[0] = order.OrderNum.ToString();
            contents[1] = order.Name;
            contents[2] = order.StateAbbr;
            contents[3] = order.TaxRate.ToString();
            contents[4] = order.ProductType;
            contents[5] = order.Area.ToString();
            contents[6] = order.CostPSF.ToString();
            contents[7] = order.LaborCostPSF.ToString();
            contents[8] = order.MaterialCost.ToString();
            contents[9] = order.LaborCost.ToString();
            contents[10] = order.TaxTotal.ToString();
            contents[11] = order.Total.ToString();
            return string.Join("?", contents);
        }
    }
}
