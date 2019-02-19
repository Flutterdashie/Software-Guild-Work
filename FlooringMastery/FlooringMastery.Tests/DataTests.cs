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


        //[Test]
        //public void SafelyThrowsForMissingEntry()
        //{
        //    IOrderRepo orderRepo = new TestOrderRepo();
        //    Assert.Throws(typeof(InvalidOperationException),new TestDelegate(() =>orderRepo.GetSpecificOrder(3, new DateTime(2013, 1, 1))));
        //}

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

        //TODO: Test Remove order

        //TODO: Test Save order


    }
}
