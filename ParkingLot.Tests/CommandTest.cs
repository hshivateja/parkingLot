using System;
using ParkingLot;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ParkingLot.Tests
{
    [TestClass]
    public class CommandTest
    {
        MainProcessor command = new MainProcessor();
        [TestMethod]
        public void testCommandNegative()
        {
            string val = command.findcommand("create_parking_lot----null");
            Assert.IsTrue(val == null);
        }

        [TestMethod]
        public void testCommandPositive()
        {
            string val1 = command.findcommand("create_parking_lot");
            Assert.IsTrue(val1 != null);
        }
    }
}