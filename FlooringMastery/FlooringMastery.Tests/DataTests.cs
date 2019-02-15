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

    }
}
