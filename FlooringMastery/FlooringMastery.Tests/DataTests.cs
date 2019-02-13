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
        [Test]
        public void SafelyThrowsForMissingEntry()
        {
            IOrderRepo orderRepo = new TestOrderRepo();
            Assert.Throws(typeof(InvalidOperationException),new TestDelegate(() =>orderRepo.GetSpecificOrder(3, new DateTime(2013, 1, 1))));
        }
    }
}
