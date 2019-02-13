using FlooringMastery.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Data
{
    public class FileOrderRepo : IOrderRepo
    {
        public int GetNextOrderNum(DateTime date)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetOrdersByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Order GetSpecificOrder(int orderNum, DateTime date)
        {
            throw new NotImplementedException();
        }

        public void SaveOrder(Order order)
        {
            throw new NotImplementedException();
        }

        private static string GetPathByDate(DateTime date)
        {
            return @".\Orders_" + date.ToString("MMddyyyy") + ".txt";
        }
    }
}
