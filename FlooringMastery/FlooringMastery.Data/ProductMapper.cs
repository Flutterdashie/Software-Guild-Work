using FlooringMastery.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Data
{
    public static class ProductMapper
    {
        public static List<Product> GetAllProducts()
        {
            List<Product> result = new List<Product>();
            string[] lines = File.ReadAllLines(@".\Products.txt");
            foreach (string line in lines)
            {
                string[] values = line.Split(',');
                result.Add(new Product(values[0], decimal.Parse(values[1]), decimal.Parse(values[2])));
            }
            return result;
        }
    }

}
