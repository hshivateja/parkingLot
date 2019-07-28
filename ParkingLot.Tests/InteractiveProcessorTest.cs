using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ParkingLot.Tests
{
    [TestClass]
    public class InteractiveProcessorTest
    {
        static MainProcessor mp = new MainProcessor();
        [TestInitialize]
        [TestMethod]
        public static void setUp()
        {
            mp.validateandprocess("create_parking_lot 6");
        }

        [TestMethod]
        public void testCreateProcess()
        {
            try
            {
                mp.validateandprocess("create_parking_lot 6");
            }
            catch (Exception e)
            {
                Assert.Fail("Creation of parking slot failed");
            }
        }

        [TestMethod]
        public void testPark()
        {
            try
            {
                mp.validateandprocess("park Mh14-111 White");
            }
            catch (Exception e)
            {
                Assert.Fail("Creation of parking slot failed");
            }
        }

        [TestMethod]
        public void testGetStatus()
        {
            try
            {
                mp.validateandprocess("status");
            }
            catch (Exception e)
            {
                Assert.Fail("Fetching status functioanlity failed");
            }
        }

        [TestMethod]
        public void testGetSlotsByColor()
        {
            try
            {
                mp.validateandprocess("slot_numbers_for_cars_with_colour White");
            }
            catch (Exception e)
            {
                Assert.Fail("slot_numbers_for_cars_with_colour functionality failed");
            }
        }

        [TestMethod]
        public void testGetRegNoByColor()
        {
            try
            {
                mp.validateandprocess("registration_numbers_for_cars_with_colour White");
            }
            catch (Exception e)
            {
                Assert.Fail("registration_numbers_for_cars_with_colour functionality failed");
            }
        }

        [TestMethod]
        public void testSlotByRegNo()
        {
            try
            {
                mp.validateandprocess("registration_numbers_for_cars_with_colour 1234");
            }
            catch (Exception e)
            {
                Assert.Fail("registration_numbers_for_cars_with_colour functionality failed");
            }
        }
    }
}