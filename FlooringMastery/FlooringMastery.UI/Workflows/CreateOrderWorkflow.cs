using FlooringMastery.BLL;
using FlooringMastery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI.Workflows
{
    public class CreateOrderWorkflow : IWorkflow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();
            IUserIO io = new ConsoleIO();

            io.Clear();
            io.WriteLine("Order Creation Form");
            io.WriteLine(new string('*', 27));
            DateTime date = GetFutureDate(io);
            string name = GetCustomerName(io);
            State state = io.GetState("Enter the desired state:", manager.GetStates());
            Product product = io.PickProduct(manager.GetProducts());
            decimal area = io.GetArea("Enter the area for the order");
            Order newOrder = manager.ValidateNewOrder(new Order(date, name, state, product, area));
            io.WriteLine(newOrder.GetFullOrderString());
            bool confirm = io.GetBool("Are you sure you would like to place this order?");
            if(confirm)
            {
                manager.SaveValidOrder(newOrder);
                io.WriteLine("Order placed!");
            } else
            {
                io.WriteLine("Order cancelled.");
            }
            io.WaitForUser("Press any key to continue...");

        }

        private DateTime GetFutureDate(IUserIO io)
        {
            DateTime target;
            bool firstTry = true;
            do
            {
                if (!firstTry)
                {
                    io.WriteLine("Order date must be in the future.");
                }
                target = io.GetDate("Please enter a date for the order:");
                firstTry = false;
            } while (target < DateTime.Now);
            return target;
        }

        private string GetCustomerName(IUserIO io)
        {
            throw new NotImplementedException();
        }
    }
}
