using FlooringMastery.Data;
using FlooringMastery.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Tests
{
    [TestFixture]
    public class DataTests
    {

        [TestCase(3, 2013, 1, 1)]
        [TestCase(1, 2013, 1, 5)]
        public void TestThrowsMissingEntry(int orderNum, int year, int month, int day)
        {
            IOrderRepo orderRepo = new TestOrderRepo();
            Assert.Throws(typeof(InvalidOperationException), new TestDelegate(() => orderRepo.GetSpecificOrder(orderNum, new DateTime(year, month, day))));
        }

        [TestCase(3, 2013, 1, 1)]
        [TestCase(1, 2013, 1, 5)]
        public void FileThrowsMissingEntry(int orderNum, int year, int month, int day)
        {
            IOrderRepo orderRepo = new FileOrderRepo();
            Assert.Throws(typeof(InvalidOperationException), new TestDelegate(() => orderRepo.GetSpecificOrder(orderNum, new DateTime(year, month, day))));
        }

        [Test]
        public void FileCleanup()
        {
            string basePath = @"C:\Users\Jacob\Documents\bitbucket\jacob-harris-individual-work\FlooringMastery\FlooringMastery\bin\Debug";
            Product testProduct = new Product("whoa", 1.0m, 1.0m);
            State testState = new State("whoa", "wh", 1.0m);
            Order testOrder = new Order(new DateTime(3000, 3, 3), "whee", testState, testProduct, 100.0m);

            Assert.IsFalse(File.Exists(basePath + @"\Orders_03033000.txt"));

            IOrderRepo orderRepo = new FileOrderRepo();
            orderRepo.SaveOrder(testOrder);

            Assert.IsTrue(File.Exists(basePath + @"\Orders_03033000.txt"));

            orderRepo.RemoveOrder(testOrder);

            Assert.IsFalse(File.Exists(basePath + @"\Orders_03033000.txt"));
        }

        [TestCase(2,2013,1,1)]
        [TestCase(1,2013,1,1)]
        public void RemoveOrderTest(int orderNum, int year, int month, int day)
        {
            IOrderRepo orderRepo = new TestOrderRepo();

            Assert.DoesNotThrow(new TestDelegate(() => orderRepo.GetSpecificOrder(orderNum, new DateTime(year, month, day))));
            Order backup = orderRepo.GetSpecificOrder(orderNum, new DateTime(year, month, day));
            orderRepo.RemoveOrder(orderRepo.GetSpecificOrder(orderNum, new DateTime(year, month, day)));
            Assert.Throws(typeof(InvalidOperationException), new TestDelegate(() => orderRepo.GetSpecificOrder(orderNum, new DateTime(year, month, day))));

            //Clean up after itself:
            orderRepo.SaveOrder(backup);

        }


        [TestCase(3, 2013, 1, 1)]
        [TestCase(1, 2023, 1, 1)]
        public void SaveOrderTest(int orderNum, int year, int month, int day)
        {
            IOrderRepo orderRepo = new TestOrderRepo();
            Product testProduct = new Product("whoa", 1.0m, 1.0m);
            DateTime testDate = new DateTime(year, month, day);
            State testState = new State("whoa", "wh", 1.0m);

            Order testOrder = new Order(testDate, "testName", testState, testProduct, 100.0m);
            testOrder.UpdateNum(orderNum);
            
            Assert.Throws(typeof(InvalidOperationException), new TestDelegate(() => orderRepo.GetSpecificOrder(orderNum, testDate)));

            orderRepo.SaveOrder(testOrder);
            Assert.DoesNotThrow(new TestDelegate(() => orderRepo.GetSpecificOrder(orderNum, testDate)));

            //clean up after itself:
            orderRepo.RemoveOrder(testOrder);
        }

    }
}
