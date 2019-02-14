using FlooringMastery.BLL;
using FlooringMastery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI.Workflows
{
    public class RemoveOrderWorkflow : IWorkflow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();
            IUserIO io = new ConsoleIO(); //This can be replaced with a factory if we ever use multiple IO types

            io.Clear();
            io.WriteLine("Order Removal");
            io.WriteLine(new string('*', 27));
            int targetNum = io.GetInt("Enter the order number to remove: ");
            DateTime targetDate = io.GetDate("Enter the date of the order to remove: ").Date;
            string result = "";
            if (manager.TryGetOrder(targetNum,targetDate, out Order target))
            {
                io.Clear();
                io.WriteLine("Search result:");
                io.WriteLine(target.GetFullOrderString());
                bool confirm = io.GetBool("Are you sure you would like to delete this order?");

                if(confirm)
                {
                    result = manager.DeleteOrder(target);
                }
                else
                {
                    result = "Removal cancelled.";
                }
            }
            else
            {
                result = "No order found with given parameters. Returning to menu.";
            }
            io.WriteLine(result);
            io.WaitForUser("Press any key to continue...");
        }
    }
}
