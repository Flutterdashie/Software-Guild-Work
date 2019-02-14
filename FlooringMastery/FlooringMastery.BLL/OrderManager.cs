using FlooringMastery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.BLL
{
    public class OrderManager
    {
        private IOrderRepo _repo;
        public OrderManager(IOrderRepo repo)
        {
            _repo = repo;
        }

        public string GetAllOrders(DateTime date)
        {
            List<Order> orders = _repo.GetOrdersByDate(date).ToList();
            if (orders.Count() == 0)
            {
                return "There are no orders on the given date.";
            }
            string result = orders[0].GetFullOrderString();
            for(int i = 1; i < orders.Count; i++)
            {
                result = result.TrimEnd('*');
                result += orders[i].GetFullOrderString();
            }
            return result;
        }

    }
}
