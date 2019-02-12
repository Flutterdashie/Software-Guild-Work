using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models
{
    public class Order
    {
        private int orderNum;
        private DateTime date;
        private string name;
        private string stateAbbr;
        private decimal taxRate;
        private string productType;
        private decimal area;
        private decimal costPSF;
        private decimal laborCostPSF;
        private decimal materialCost;
        private decimal laborCost;
        private decimal taxTotal;
        private decimal total;

        public Order(int orderNum, DateTime date, string name, string stateAbbr, decimal taxRate, string productType, decimal area, decimal costPSF, decimal laborCostPSF, decimal materialCost, decimal laborCost, decimal taxTotal, decimal total)
        {
            this.orderNum = orderNum;
            this.date = date;
            this.name = name;
            this.stateAbbr = stateAbbr;
            this.taxRate = taxRate;
            this.productType = productType;
            this.area = area;
            this.costPSF = costPSF;
            this.laborCostPSF = laborCostPSF;
            this.materialCost = materialCost;
            this.laborCost = laborCost;
            this.taxTotal = taxTotal;
            this.total = total;
        }
        public Order(DateTime date, string name, State state, Product product, decimal area)
        {
            this.date = date;
            this.name = name;
            this.stateAbbr = state.StateAbbr;
            this.taxRate = state.TaxRate;
            this.productType = product.ProductType;
            this.costPSF = product.CostPerSquareFoot;
            this.laborCostPSF = product.LaborCostPerSquareFoot;
            this.area = area;
        }

        //TODO: Pick one of these to actually use
        public void Recalculate(string productType, decimal costPSF, decimal laborCostPSF, string stateAbbr, decimal taxRate, decimal area)
        {
            this.productType = productType;
            this.costPSF = costPSF;
            this.laborCostPSF = laborCostPSF;
            this.stateAbbr = stateAbbr;
            this.taxRate = taxRate;
            this.area = area;
            CalculateTotals();
        }

        private void CalculateTotals()
        {
            materialCost = area * costPSF;
            laborCost = area * laborCostPSF;
            taxTotal = (materialCost + laborCost) * taxRate / 100.0M;
            total = materialCost + laborCost + taxTotal;
        }

        public void UpdateName(string newName)
        {
            this.name = newName;
        }

        public string GetFullOrderString()
        {
            string result = new string('*', 60);
            result += "\n" + orderNum.ToString() + " | " + date.ToShortDateString();
            result += "\n" + name;
            result += "\n" + stateAbbr;
            result += "\n" + "Product: " + productType;
            result += "\n" + "Materials: " + string.Format("{0,10:c}", materialCost);
            result += "\n" + "Labor: " + string.Format("{0,10:c}", laborCost);
            result += "\n" + "Tax: " + string.Format("{0,10:c}", taxTotal);
            result += "\n" + "Total: " + string.Format("{0,10:c}", total);
            result += "\n" + new string('*', 60);
            return result;

        }
    }
}
