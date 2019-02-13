using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models
{
    public class Order
    {
        public int OrderNum { get; private set; }
        public DateTime Date { get; private set; }
        public string Name { get; private set; }
        public string StateAbbr { get; private set; }
        public decimal TaxRate { get; private set; }
        public string ProductType { get; private set; }
        public decimal Area { get; private set; }
        public decimal CostPSF { get; private set; }
        public decimal LaborCostPSF { get; private set; }
        public decimal MaterialCost { get; private set; }
        public decimal LaborCost { get; private set; }
        public decimal TaxTotal { get; private set; }
        public decimal Total { get; private set; }

        public Order(int orderNum, DateTime date, string name, string stateAbbr, decimal taxRate, string productType, decimal area, decimal costPSF, decimal laborCostPSF, decimal materialCost, decimal laborCost, decimal taxTotal, decimal total)
        {
            this.OrderNum = orderNum;
            this.Date = date;
            this.Name = name;
            this.StateAbbr = stateAbbr;
            this.TaxRate = taxRate;
            this.ProductType = productType;
            this.Area = area;
            this.CostPSF = costPSF;
            this.LaborCostPSF = laborCostPSF;
            this.MaterialCost = materialCost;
            this.LaborCost = laborCost;
            this.TaxTotal = taxTotal;
            this.Total = total;
        }
        public Order(DateTime date, string name, State state, Product product, decimal area)
        {
            this.Date = date;
            this.Name = name;
            this.StateAbbr = state.StateAbbr;
            this.TaxRate = state.TaxRate;
            this.ProductType = product.ProductType;
            this.CostPSF = product.CostPerSquareFoot;
            this.LaborCostPSF = product.LaborCostPerSquareFoot;
            this.Area = area;
        }

        //TODO: Pick one of these to actually use
        public void Recalculate(string productType, decimal costPSF, decimal laborCostPSF, string stateAbbr, decimal taxRate, decimal area)
        {
            this.ProductType = productType;
            this.CostPSF = costPSF;
            this.LaborCostPSF = laborCostPSF;
            this.StateAbbr = stateAbbr;
            this.TaxRate = taxRate;
            this.Area = area;
            CalculateTotals();
        }

        public void Recalculate(Product product, State state, decimal area)
        {
            this.StateAbbr = state.StateAbbr;
            this.TaxRate = state.TaxRate;
            this.ProductType = product.ProductType;
            this.CostPSF = product.CostPerSquareFoot;
            this.LaborCostPSF = product.LaborCostPerSquareFoot;
            this.Area = area;
            CalculateTotals();
        }

        private void CalculateTotals()
        {
            MaterialCost = decimal.Round(Area * CostPSF,2);
            LaborCost = decimal.Round(Area * LaborCostPSF,2);
            TaxTotal = decimal.Round((MaterialCost + LaborCost) * TaxRate / 100.0M,2);
            Total = MaterialCost + LaborCost + TaxTotal;
        }

        public void UpdateName(string newName)
        {
            this.Name = newName;
        }

        public void UpdateNum(int newNum)
        {
            this.OrderNum = newNum;
        }

        public string GetFullOrderString()
        {
            string result = new string('*', 60);
            result += "\n" + OrderNum.ToString() + " | " + Date.ToShortDateString();
            result += "\n" + Name;
            result += "\n" + StateAbbr;
            result += "\n" + "Product: " + ProductType;
            result += "\n" + "Materials: " + string.Format("{0,10:c}", MaterialCost);
            result += "\n" + "Labor: " + string.Format("{0,10:c}", LaborCost);
            result += "\n" + "Tax: " + string.Format("{0,10:c}", TaxTotal);
            result += "\n" + "Total: " + string.Format("{0,10:c}", Total);
            result += "\n" + new string('*', 60);
            return result;

        }
    }
}
