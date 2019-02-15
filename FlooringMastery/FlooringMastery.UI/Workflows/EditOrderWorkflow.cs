using FlooringMastery.BLL;
using FlooringMastery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI.Workflows
{
    public class EditOrderWorkflow : IWorkflow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();
            IUserIO io = new ConsoleIO(); //This can be replaced with a factory if we ever use multiple IO types

            io.Clear();
            io.WriteLine("Order Editing");
            io.WriteLine(new string('*', 27));
            int targetNum = io.GetInt("Enter the order number to edit: ");
            DateTime targetDate = io.GetDate("Enter the date of the order to edit: ").Date;
            string result = "";
            if (manager.TryGetOrder(targetNum, targetDate, out Order target))
            {
                Order pendingChanges = target;
                io.Clear();
                io.WriteLine("Search result:");
                io.WriteLine(target.GetFullOrderString());
                //TODO: Clean this WAYYYYYYYY up.
                pendingChanges = MakeEdits(io, target,manager);

                io.WriteLine(pendingChanges.GetFullOrderString());

                bool confirm = io.GetBool("Are you sure you would like to make these changes?");

                if (confirm)
                {
                    manager.SaveValidOrder(pendingChanges);
                    result = "Edits saved.";
                }
                else
                {
                    result = "Edits cancelled.";
                }
            }
            else
            {
                result = "No order found with given parameters. Returning to menu.";
            }
            io.WriteLine(result);
            io.WaitForUser("Press any key to continue...");
        }

        private Order MakeEdits(IUserIO io, Order target, OrderManager manager)
        {
            string newName = io.PromptReplaceName("Enter customer name",target.Name);
            bool nameChanged = !target.Name.Equals(newName);
            bool orderChanged = false;
            State oldState = new State("unknown", target.StateAbbr, target.TaxRate);
            State newState = io.PromptReplaceState("Enter order state", oldState, manager.GetStates());
            orderChanged |= oldState.StateAbbr != newState.StateAbbr;
            Product oldProduct = new Product(target.ProductType, target.CostPSF, target.LaborCostPSF);
            Product newProduct = io.PromptReplaceProduct("Enter product", oldProduct, manager.GetProducts());
            orderChanged |= !oldProduct.ProductType.Equals(newProduct.ProductType, StringComparison.CurrentCultureIgnoreCase);
            decimal newArea = io.PromptReplaceArea("Enter area", target.Area);
            orderChanged |= target.Area != newArea;
            if(orderChanged)
            {
                Order newOrder =  new Order(target.Date, newName, newState, newProduct, newArea);
                newOrder.UpdateNum(target.OrderNum);
                return newOrder;
            } else if(nameChanged)
            {
                Order newOrder =new Order(target.Date, newName, oldState, oldProduct, target.Area);
                newOrder.UpdateNum(target.OrderNum);
                return newOrder;
            }
            return target;
        }
    }
}
