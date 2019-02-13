using FlooringMastery.Data;
using FlooringMastery.Models;
using FlooringMastery.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery
{
    class Program
    {
        static void Main(string[] args)
        {
            IUserIO userIO = new ConsoleIO();
            IProductGetter productGetter = new ProductGetter();
            Product product = userIO.PickProduct(productGetter.GetAllProducts());
            Console.WriteLine(product.ProductType);
            Console.ReadLine();
        }
    }
}
