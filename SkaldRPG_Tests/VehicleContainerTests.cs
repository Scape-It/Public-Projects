using Microsoft.VisualStudio.TestTools.UnitTesting;
using SkaldRPG;
using static SkaldRPG.VehicleContainer;

namespace SkaldRPG_Test
{
    [TestClass]
    public class VehicleContainerTests
    {
        private VehicleContainer vehicleContainer;

        [TestInitialize]
        public void Initialize()
        {
            vehicleContainer = new VehicleContainer();
        }

        [TestMethod]
        public void MakeShip_Null_Test()
        {
            // Arrange and act
            vehicleContainer.MakeShip(null);
            Vehicle vehicle = vehicleContainer.GetVehicle();

            // Assert
            // We took the default switch\case condition, we should get a caravel not chartered.
            Assert.AreEqual("Models/Caravel", vehicle.ModelPath);
            Assert.IsTrue(vehicle.IsChartered == false);
            Assert.AreEqual("A ship lies at anchor.\n\nYou may charter this ship if you can afford it", vehicle.getDescription());
        }

        [TestMethod]
        public void MakeShip_Bogus_Non_Chartered_Test()
        {
            // Arrange and act
            vehicleContainer.MakeShip("Bogus");
            Vehicle vehicle = vehicleContainer.GetVehicle();

            // Assert
            Assert.IsTrue(vehicle.IsChartered == false);
            Assert.AreEqual("A ship lies at anchor.\n\nYou may charter this ship if you can afford it", vehicle.getDescription());
        }

        [TestMethod]
        public void MakeShip_Bogus_Chartered_Test()
        {
            // Arrange and act
            vehicleContainer.MakeShip("Bogus");
            Vehicle vehicle = vehicleContainer.GetVehicle();
            vehicle.CharterVehicle();

            // Assert
            Assert.IsTrue(vehicle.IsChartered == true);
            Assert.AreEqual("A ship lies at anchor.\n\nThis ship has been chartered and you may come onboard!", vehicle.getDescription());
        }

        [TestMethod]
        public void MakeShip_Kogge_LowerCase_Uppercase_Test()
        {
            // Arrange and act
            vehicleContainer.MakeShip("Kogge");
            Vehicle kogge_lowerCase = vehicleContainer.GetVehicle();

            vehicleContainer.MakeShip("KOGGE");
            Vehicle kogge_upperCase = vehicleContainer.GetVehicle();

            // Assert
            Assert.AreEqual("Models/Kogge", kogge_lowerCase.ModelPath);
            Assert.AreEqual(kogge_lowerCase.ModelPath, kogge_upperCase.ModelPath);
        }

        [TestMethod]
        public void SetVehicle_Null_Test()
        {
            // Arrange and act
            vehicleContainer.SetVehicle(null);

            // Assert
            Assert.IsNull(vehicleContainer.GetVehicle());
        }

        [TestMethod]
        public void SetVehicle_Test()
        {
            // Arrange and act
            vehicleContainer.MakeShip("Kogge");
            vehicleContainer.SetVehicle(vehicleContainer);

            // Assert
            Assert.IsNotNull(vehicleContainer.GetVehicle());
        }
    }
}
