using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models
{
    public interface IOrderRepo
    {
        IEnumerable<Order> GetOrdersByDate(DateTime date);
        Order GetSpecificOrder(int orderNum, DateTime date);
        int GetNextOrderNum(DateTime date);
        void SaveOrder(Order order);

    }
}
