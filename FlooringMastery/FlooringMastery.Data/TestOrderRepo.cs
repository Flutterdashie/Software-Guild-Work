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
        private static Dictionary<DateTime, IEnumerable<Order>> AllOrders = new Dictionary<DateTime, IEnumerable<Order>>();
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
            try
            {
                return GetOrdersByDate(date).Max(o => o.OrderNum) + 1;
            } catch (InvalidOperationException)
            {
                return 1;
            }
            
        }

        public IEnumerable<Order> GetOrdersByDate(DateTime date)
        {
            if (AllOrders.ContainsKey(date))
            {
                return AllOrders[date];
            } else
            {
                return new List<Order>();
            }
        }

        //Can throw InvalidOperationException
        public Order GetSpecificOrder(int orderNum, DateTime date)
        {
            return GetOrdersByDate(date).First(o => o.OrderNum == orderNum);
        }

        public void SaveOrder(Order order)
        {
            List<Order> orders = GetOrdersByDate(order.Date).ToList();
            if(orders.Count() == 0 || !orders.Contains(order))
            {
                orders.Add(order);
            }
            else
            {
                int index = orders.IndexOf(order);
                orders[index] = order;
            }
            WriteAllToDate(order.Date,orders);
        }

        private void WriteAllToDate(DateTime date, IEnumerable<Order> orders)
        {
            if(AllOrders.ContainsKey(date))
            {
                AllOrders[date] = orders;
            }
            else
            {
                AllOrders.Add(date, orders);
            }
        }

        public void RemoveOrder(Order order)
        {
            List<Order> daysOrders = AllOrders[order.Date].ToList();
            if (!daysOrders.Remove(order))
            {
                throw new InvalidOperationException();
            }
            AllOrders[order.Date] = daysOrders;
        }
    }
}
