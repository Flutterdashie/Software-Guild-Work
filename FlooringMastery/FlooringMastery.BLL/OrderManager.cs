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
            try
            {
                List<Order> orders = _repo.GetOrdersByDate(date).ToList();
                if (orders.Count() == 0)
                {
                    return "There are no orders on the given date.";
                }
                string result = orders[0].GetFullOrderString();
                for (int i = 1; i < orders.Count; i++)
                {
                    result = result.TrimEnd('*');
                    result += orders[i].GetFullOrderString();
                }
                return result;
            } catch (Exception)
            {
                return "The order file for the given date is corrupt or cannot be read. Please contact IT if this issue persists.";
            }
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

        public void SaveValidOrder(Order order)
        {
            //This should handle updating as well as adding new orders.
            _repo.SaveOrder(order);
        }

        public Order ValidateNewOrder(Order order)
        {
            //This is used to ensure that a new order to be placed will have a valid order number before being displayed or used.
            order.UpdateNum(_repo.GetNextOrderNum(order.Date));
            return order;
        }
    }
}
