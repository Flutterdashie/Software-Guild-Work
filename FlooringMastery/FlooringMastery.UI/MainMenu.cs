using FlooringMastery.Models;
using FlooringMastery.UI.Workflows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI
{
    public static class MainMenu
    {
        public static void Run()
        {
            IUserIO io = new ConsoleIO();
            MenuChoice choice;
            do
            {
                io.Clear();
                choice = io.GetMenuChoice();
                IWorkflow workflow = null;
                switch (choice)
                {
                    case MenuChoice.DisplayOrders:
                        workflow = new ReadOrdersWorkflow();
                        break;
                    case MenuChoice.AddOrder:
                        workflow = new CreateOrderWorkflow();
                        break;
                    case MenuChoice.EditOrder:
                        workflow = new EditOrderWorkflow();
                        break;
                    case MenuChoice.RemoveOrder:
                        workflow = new RemoveOrderWorkflow();
                        break;
                    case MenuChoice.Quit:
                        workflow = null;
                        break;
                }
                workflow?.Execute();
            } while (choice != MenuChoice.Quit);
            io.WriteLine("Exiting...");
        }
    }
}
