using FlooringMastery.BLL;
using FlooringMastery.Data;
using FlooringMastery.Models;
using FlooringMastery.UI;
using FlooringMastery.UI.Workflows;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            IWorkflow workflow2 = new ReadOrdersWorkflow();
            workflow2.Execute();
            IWorkflow workflow = new CreateOrderWorkflow();
            workflow.Execute();
            
            workflow2.Execute();
        }
    }
}
