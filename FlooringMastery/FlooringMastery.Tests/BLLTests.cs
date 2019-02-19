using FlooringMastery.BLL;
using FlooringMastery.Data;
using FlooringMastery.Models;
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
        [TestCase(2013, 1, 1, 318)]
        public void GetAllOrdersRepo(int year, int month, int day, int expectedLength)
        {
            OrderManager manager = new OrderManager(new TestOrderRepo());
            int responseLength = manager.GetAllOrders(new DateTime(year, month, day)).Length;
            Assert.AreEqual(expectedLength, responseLength);
        }

        [TestCase(1,2013,1,1,true)]
        [TestCase(2,2013,1,1,true)]
        [TestCase(3,2013,1,1,false)]
        [TestCase(1,2020,1,1,false)]
        public void GetSpecificOrderTest(int orderNum,int year, int month, int day, bool expectedExists)
        {
            OrderManager manager = new OrderManager(new TestOrderRepo());
            bool result = manager.TryGetOrder(orderNum, new DateTime(year, month, day), out Order order);
            Assert.AreEqual(expectedExists, result);
            Assert.AreEqual(expectedExists, order != null);

        }

        [TestCase(2013,1,1,3)]
        [TestCase(2000,1,1,1)]
        public void OrderNumUpdates(int year, int month, int day, int expectedNum)
        {
            Product testProd = new Product("whee",1.0m,1.0m);
            State testState = new State("Rawr","XD",5.00m);
            DateTime testDate = new DateTime(year, month, day);
            Order order = new Order(testDate,"TestGuy",testState,testProd,100.0m);
            OrderManager manager = new OrderManager(new TestOrderRepo());
            int resultNum = manager.ValidateNewOrder(order).OrderNum;
            Assert.AreEqual(expectedNum, resultNum);
        }

        [TestCase(2000,1,1)]
        [TestCase(1000,1,1)]
        public void OrderSaveDeleteTest(int year, int month, int day)
        {
            //Currently, these two tests are run together to ensure that the test environment remains clean.
            Product testProd = new Product("whee", 1.0m, 1.0m);
            State testState = new State("Rawr", "XD", 5.00m);
            DateTime testDate = new DateTime(year, month, day);
            OrderManager manager = new OrderManager(new TestOrderRepo());

            Order order = manager.ValidateNewOrder(new Order(testDate, "TestGuy", testState, testProd, 100.0m));
            if(manager.TryGetOrder(order.OrderNum,testDate,out Order junk))
            {
                Assert.Fail("Order number already exists. ValidateNewOrder may be broken.");
            }

            manager.SaveValidOrder(order);
            Assert.IsTrue(manager.TryGetOrder(order.OrderNum, testDate, out Order resultOrder));
            Assert.AreEqual(order.GetFullOrderString(), resultOrder.GetFullOrderString());

            //Successful delete
            Assert.AreEqual("Order deleted successfully.", manager.DeleteOrder(order));
            if (manager.TryGetOrder(order.OrderNum, testDate, out Order junk2))
            {
                Assert.Fail("Order number still exists after deletion.");

            }

            //Can't delete something that was just deleted already
            Assert.AreEqual("Order was not found. Please contact IT.", manager.DeleteOrder(order));



        }



    }
}
