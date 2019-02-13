using FlooringMastery.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.BLL
{
    public static class OrderManagerFactory
    {
        public static OrderManager Create()
        {
            switch(ConfigurationManager.AppSettings["Mode"])
            {
                case "Test":
                    return new OrderManager(new TestOrderRepo());
                case "Prod":
                    return new OrderManager(new FileOrderRepo());
                default:
                    throw new Exception("Invalid config setting. Check your App.config.");
            }
        }
    }
}
