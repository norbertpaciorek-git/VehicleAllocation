using VehicleAllocation.SQL.Models;

namespace VehicleAllocation.Tests
{
    [TestClass]
    public sealed class VahicleAllocationModelTests
    {
        [TestMethod]
        public void CalulateCharegBasedOnTime_SmallType()
        {
            DateTime timeIn = DateTime.Now.AddMinutes(-7);

            VehicleAllocationDbModel model = new VehicleAllocationDbModel { SpaceNumber = 10, VehicleReg = "V1", TimeIn = timeIn, VehicleType = "small" };
            model.CalculateCost();

            //Should be 1.7 as 7 min * 0.1 + 1 for each 5 minutes 

            Assert.AreEqual(Math.Round(model.VehicleCharge, 1, MidpointRounding.AwayFromZero), 1.7);

        }

        [TestMethod]
        public void CalulateCharegBasedOnTime_MeduimType()
        {
            DateTime timeIn = DateTime.Now.AddMinutes(-7);

            VehicleAllocationDbModel model = new VehicleAllocationDbModel { SpaceNumber = 10, VehicleReg = "V1", TimeIn = timeIn, VehicleType = "medium" };
            model.CalculateCost();

            //Should be 2.7 as 7 min * 0.2 + 1 for each 5 minutes 

            Assert.AreEqual(Math.Round(model.VehicleCharge, 1, MidpointRounding.AwayFromZero), 2.4);

        }

        [TestMethod]
        public void CalulateCharegBasedOnTime_LargeType()
        {
            DateTime timeIn = DateTime.Now.AddMinutes(-7);

            VehicleAllocationDbModel model = new VehicleAllocationDbModel { SpaceNumber = 10, VehicleReg = "V1", TimeIn = timeIn, VehicleType = "large" };
            model.CalculateCost();

            //Should be 3.8 as 7 min * 0.4 + 1 for each 5 minutes 

            Assert.AreEqual(Math.Round(model.VehicleCharge, 1, MidpointRounding.AwayFromZero), 3.8);

        }

        [TestMethod]
        public void CalulateCharegBasedOnTime_SmallType_ForOneHour()
        {
            DateTime timeIn = DateTime.Now.AddHours(-1);

            VehicleAllocationDbModel model = new VehicleAllocationDbModel { SpaceNumber = 10, VehicleReg = "V1", TimeIn = timeIn, VehicleType = "small" };
            model.CalculateCost();

            //Should be 60 min * 0.1 = 6
            // extra 1 for every 5 = 12
            //total 12 + 6 = 18

            Assert.AreEqual(Math.Round(model.VehicleCharge, 1, MidpointRounding.AwayFromZero), 18);

        }
    }
}
