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

        public void OrderNumUpdates(int year, int month, int day, int expectedNum)
        {
            Product testProd = new Product("whee",1.0m,1.0m);
            State testState = new State("Rawr","XD",5.00m);
            DateTime testDate = new DateTime(year, month, day);
            Order order = new Order(testDate,"TestGuy",testState,testProd,100.0m);
            //TODO: Finish order num test
        }

        //TODO: Test order saving

        //TODO: Test order deletion

    }
}
