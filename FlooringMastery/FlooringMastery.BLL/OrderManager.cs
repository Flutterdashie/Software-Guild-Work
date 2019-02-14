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
        private LogisticsManager _manager;
        public OrderManager(IOrderRepo repo)
        {
            _manager = LogisticsManagerFactory.Create();
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

        public bool TryGetOrder(int orderNum, DateTime orderDate, out Order order)
        {
            bool result = false;
            try
            {
                order = _repo.GetSpecificOrder(orderNum, orderDate);
                result = true;
            }
            catch (InvalidOperationException)
            {
                result = false;
                order = null;
            }
            return result;
        }

        public string DeleteOrder(Order order)
        {
            try
            {
                _repo.RemoveOrder(order);
                return "Order deleted successfully.";
            }
            catch (InvalidOperationException)
            {
                return "Order was not found. Please contact IT.";
            }
        }
        public IEnumerable<Product> GetProducts()
        {
            return _manager.GetProducts();
        }
        
        public IEnumerable<State> GetStates()
        {
            return _manager.GetStates();
        }
    }
}
