using FlooringMastery.BLL;
using FlooringMastery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI.Workflows
{
    public class ReadOrdersWorkflow : IWorkflow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();
            IUserIO io = new ConsoleIO(); //This can be replaced with a factory if we ever use multiple IO types

            io.Clear();
            io.WriteLine("Order Lookup By Date");
            io.WriteLine(new string('*', 27));
            DateTime target = io.GetDate("Please enter a date to look up.");
            io.WriteLine(manager.GetAllOrders(target));
            io.WaitForUser("Press any key to continue...");
        }


    }
}
