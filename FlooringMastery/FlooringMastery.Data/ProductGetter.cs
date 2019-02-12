using FlooringMastery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Data
{
    public class ProductGetter : IProductGetter
    {
        public IEnumerable<Product> GetAllProducts()
        {
            return ProductMapper.GetAllProducts();
        }

        public Product GetProductByName(string name)
        {
            var query = from p in ProductMapper.GetAllProducts()
                        where p.ProductType == name
                        select p;
            return query.FirstOrDefault();
        }
    }
}
