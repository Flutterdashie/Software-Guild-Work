using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models
{
    public struct Product
    {
        public readonly string ProductType;
        public readonly decimal CostPerSquareFoot;
        public readonly decimal LaborCostPerSquareFoot;
        public Product(string name, decimal costPSF, decimal laborCostPSF)
        {
            ProductType = name;
            CostPerSquareFoot = costPSF;
            LaborCostPerSquareFoot = laborCostPSF;
        }
    }
}
