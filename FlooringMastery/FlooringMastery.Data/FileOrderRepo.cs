﻿using FlooringMastery.Models;
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
            return GetOrdersByDate(date).Max(o => o.OrderNum) + 1;
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
            } catch (FileNotFoundException e)
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

        public void SaveOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}