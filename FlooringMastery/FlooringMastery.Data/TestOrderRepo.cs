using FlooringMastery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Data
{
    public class TestOrderRepo : IOrderRepo
    {
        private static Dictionary<DateTime, List<Order>> AllOrders = new Dictionary<DateTime, List<Order>>();
        private static readonly DateTime Jan012013 = new DateTime(2013, 1, 1);
        private static List<Order> _OrdersJan12013 = new List<Order>
        {
            new Order(1,Jan012013,"Greg","OH",6.25M,"Tile",100.0M,3.50M,4.15M,350.0M,415.0M,47.81M,812.81M),
            new Order(2,Jan012013,"Bob","PA",6.75M,"Laminate",200.0M,1.75M,2.10M,350M,420M,51.98M,821.98M)
        };
        static TestOrderRepo()
        {
            AllOrders.Add(Jan012013, _OrdersJan12013);
        }
        public int GetNextOrderNum(DateTime date)
        {
            return GetOrdersByDate(date).Max(o => o.OrderNum) + 1;
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
    }
}
