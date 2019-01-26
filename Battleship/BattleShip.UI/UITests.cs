using BattleShip.BLL.Requests;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BattleShip.UI
{
    [TestFixture]
    public class UITests
    {
        [TestCase("a10", true, 10, 1)]
        [TestCase("basd", false, 0, 0)]
        [TestCase("", false, 0, 0)]
        [TestCase("K11", true, 11, 11)] //This passes because the parser is responsible only for conversion, not for range.
        [TestCase("C12", true, 12, 3)]
        [TestCase("J1", true, 1, 10)]
        [TestCase("ab1", false, 0, 0)]
        public void ParseCoordTest(string input, bool tryParseResult, int desiredX, int desiredY)
        {
            bool parseSuccess = UserIO.TryParseCoord(input, out Coordinate testCoord);
            Assert.AreEqual(parseSuccess, tryParseResult);
            Assert.AreEqual(desiredX, testCoord.XCoordinate);
            Assert.AreEqual(desiredY, testCoord.YCoordinate);
        }

        [TestCase('d', true, ShipDirection.Right)]
        [TestCase('D', true, ShipDirection.Right)]
        [TestCase('s', true, ShipDirection.Down)]
        [TestCase('S', true, ShipDirection.Down)]
        [TestCase('a', true, ShipDirection.Left)]
        [TestCase('A', true, ShipDirection.Left)]
        [TestCase('w', true, ShipDirection.Up)]
        [TestCase('W', true, ShipDirection.Up)]
        [TestCase('\u0000', false, ShipDirection.Down)] //This test represents the KeyChar value if ReadKey (which normally feeds into it) receives a special key!
        [TestCase('q', false, ShipDirection.Down)]
        [TestCase('1', false, ShipDirection.Down)]
        [TestCase('p', false, ShipDirection.Down)]
        public void ParseDirectionTest(char input, bool tryParseResult, ShipDirection desiredDirection)
        {
            bool parseSuccess = UserIO.TryParseDirection(input, out ShipDirection testDirection);
            Assert.AreEqual(parseSuccess, tryParseResult);
            Assert.AreEqual(testDirection, desiredDirection);
        }

    }
}
