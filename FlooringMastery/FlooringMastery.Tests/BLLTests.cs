using FlooringMastery.BLL;
using FlooringMastery.Data;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Tests
{
    [TestFixture]
    public class BLLTests
    {
        [TestCase(2020, 2, 2, 38)]
        [TestCase(2009, 2, 2, 38)]
        public void GetAllOrdersRepo(int year, int month, int day, int expectedLength)
        {
            OrderManager manager = new OrderManager(new TestOrderRepo());
            int responseLength = manager.GetAllOrders(new DateTime(year, month, day)).Length;
            Assert.AreEqual(expectedLength, responseLength);
        }
    }
}
