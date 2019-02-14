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

        [TestCase(3,2013,1,1)]
        public void SafelyThrowsForMissingEntry(int orderNum, int year, int month, int day)
        {
            IOrderRepo orderRepo = new TestOrderRepo();
            Assert.Throws(typeof(InvalidOperationException), new TestDelegate(() => orderRepo.GetSpecificOrder(orderNum, new DateTime(year, month, day))));
        }
    }
}
