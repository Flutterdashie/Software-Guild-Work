using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models
{
    public interface IProductGetter
    {
        Product GetProductByName(string name);
        IEnumerable<Product> GetAllProducts();
    }
}
