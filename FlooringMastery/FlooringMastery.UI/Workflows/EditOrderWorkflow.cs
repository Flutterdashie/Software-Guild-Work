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
                io.Clear();
                io.WriteLine("Search result:");
                io.WriteLine(target.GetFullOrderString());
                //TODO: Actually allow editing.
                target = MakeEdits(io, target);

                io.WriteLine(target.GetFullOrderString());

                bool confirm = io.GetBool("Are you sure you would like to make these changes?");

                if (confirm)
                {
                    manager.SaveValidOrder(target);
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

        private Order MakeEdits(IUserIO io, Order target)
        {
            io.WriteLine("Haha, joke's on you! No editing allowed!");
            return target;
        }
    }
}
