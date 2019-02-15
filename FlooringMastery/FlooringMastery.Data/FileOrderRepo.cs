using FlooringMastery.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Data
{
    public class FileOrderRepo : IOrderRepo
    {
        public int GetNextOrderNum(DateTime date)
        {
            try
            {
                return GetOrdersByDate(date).Max(o => o.OrderNum) + 1;
            }
            catch (InvalidOperationException e)
            {
                if (e.Message == "Sequence contains no elements")
                {
                    return 1;
                }
                else
                {
                    throw e;
                }
            }
        }
        /// <summary>
        /// Get all orders on specified date
        /// </summary>
        /// <param name="date">Date to look up</param>
        /// <returns>All orders on date</returns>
        public IEnumerable<Order> GetOrdersByDate(DateTime date)
        {
            IEnumerable<Order> result = new List<Order>();
            try
            {
                result = OrderMapper.ReadAllFromDate(date);
            } catch (FileNotFoundException)
            {
                //date doesn't exist yet, return empty list
            }
            return result;
        }

        /// <summary>
        /// Gets specific order on specific date
        /// </summary>
        /// <param name="orderNum">Order Number to look up</param>
        /// <param name="date">Date to look up</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">Throws if specified order does not exist</exception>
        public Order GetSpecificOrder(int orderNum, DateTime date)
        {
            return GetOrdersByDate(date).First(o => o.OrderNum == orderNum);
        }


        public void RemoveOrder(Order order)
        {
            List<Order> orders = GetOrdersByDate(order.Date).ToList();
            if(orders.RemoveAll(o => o.OrderNum == order.OrderNum) != 1) 
            {
                throw new InvalidOperationException();
            }
            OrderMapper.WriteAllToDate(order.Date, orders);
        }

        public void SaveOrder(Order order)
        {
            List<Order> orders = GetOrdersByDate(order.Date).ToList();
            if (orders.Count() == 0 || !orders.Exists(o => o.OrderNum == order.OrderNum))
            {
                orders.Add(order);
            }
            else
            {
                int index = orders.FindIndex(o => o.OrderNum == order.OrderNum);
                orders[index] = order;
            }
            OrderMapper.WriteAllToDate(order.Date, orders);
        }
    }
}
