using Microsoft.VisualStudio.TestTools.UnitTesting;
using Containership;
using System;
using System.Collections.Generic;
using System.Text;

namespace Containership.Tests
{
    [TestClass()]
    public class BoatTests
    {
        [TestMethod()]
        public void AddContainersTest_AddNormalContainer_ReturnEqual()
        {
            //Arrange 
            Boat boat = new Boat(2, 2);
            List<Container> containers = new List<Container>();
            Container container = new Container(ContainerType.Normal, 100);
            containers.Add(container);
            containers.Add(container);
            containers.Add(container);
            containers.Add(container);
            string expected = $"https://i872272core.venus.fhict.nl/ContainerVisualizer/index.html?length=2&width=2&stacks=1,1/1,1&weights=100,100/100,100";
            //Act 
            boat.AddContainersToUnsorted(containers);
            boat.AddContainers();
            string result = boat.GetURL();
            //Assrt
            Assert.AreEqual(expected, result);
        }
        [TestMethod()]
        public void AddContainersTest_AddNormalContainerColumn_ReturnEqual()
        {
            //Arrange 
            Boat boat = new Boat(2, 2);
            List<Container> containers = new List<Container>();
            Container container = new Container(ContainerType.Normal, 30);
            containers.Add(container);
            containers.Add(container);
            containers.Add(container);
            containers.Add(container);
            containers.Add(container);
            containers.Add(container);
            containers.Add(container);
            containers.Add(container);
            string expected = $"https://i872272core.venus.fhict.nl/ContainerVisualizer/index.html?length=2&width=2&stacks=1-1,1-1/1-1,1-1&weights=30-30,30-30/30-30,30-30";
            //Act 
            boat.AddContainersToUnsorted(containers);
            boat.AddContainers();
            string result = boat.GetURL();
            //Assrt
            Assert.AreEqual(expected, result);
        }
        [TestMethod()]
        public void AddContainersTest_AddColdContainer_ReturnEqual()
        {
            //Arrange 
            Boat boat = new Boat(2, 2);
            List<Container> containers = new List<Container>();
            Container container = new Container(ContainerType.Coolable, 30);
            containers.Add(container);
            containers.Add(container);
            containers.Add(container);
            containers.Add(container);
            containers.Add(container);
            containers.Add(container);
            containers.Add(container);
            containers.Add(container);
            string expected = $"https://i872272core.venus.fhict.nl/ContainerVisualizer/index.html?length=2&width=2&stacks=3-3-3-3,/3-3-3-3,&weights=30-30-30-30,/30-30-30-30,";
            //Act 
            boat.AddContainersToUnsorted(containers);
            boat.AddContainers();
            string result = boat.GetURL();
            //Assrt
            Assert.AreEqual(expected, result);
        }
        [TestMethod()]
        public void AddContainersTest_AddValuableContainer_ReturnEqual()
        {
            //Arrange 
            Boat boat = new Boat(2, 2);
            List<Container> containers = new List<Container>();
            Container container = new Container(ContainerType.Valuable, 30);
            containers.Add(container);
            containers.Add(container);
            containers.Add(container);
            string expected = $"https://i872272core.venus.fhict.nl/ContainerVisualizer/index.html?length=2&width=2&stacks=2,2/2,2&weights=30,30/30,30";
            //Act 
            boat.AddContainersToUnsorted(containers);
            boat.AddContainers();
            string result = boat.GetURL();
            //Assrt
            Assert.AreEqual(expected, result);
        }
        [TestMethod()]
        public void AddContainersTest_AddContainers_ReturnEqual()
        {
            //Arrange 
            Boat boat = new Boat(2, 2);
            List<Container> containers = new List<Container>();
            Container container = new Container(ContainerType.Normal, 30);
            Container coolable = new Container(ContainerType.Coolable, 30);
            Container valuable = new Container(ContainerType.Valuable, 30);
            containers.Add(container);
            containers.Add(container);
            containers.Add(container);
            containers.Add(container);
            containers.Add(container);
            containers.Add(coolable);
            containers.Add(coolable);
            containers.Add(valuable);
            containers.Add(valuable);
            containers.Add(valuable);
            string expected = $"https://i872272core.venus.fhict.nl/ContainerVisualizer/index.html?length=2&width=2&stacks=3,2/2,2&weights=30,30/30,30";
            //Act 
            boat.AddContainersToUnsorted(containers);
            boat.AddContainers();
            string result = boat.GetURL();
            //Assrt
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void CheckWeightTest_MinimumWeight_ReturnString()
        {
            //Arrange
            Boat boat = new Boat(3, 3);
            string expected = "There isnt enough weight for the boat";
            //Act
            string result = boat.CheckWeight();
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void CheckWeightTest_MaximumWeight_ReturnString()
        {
            //Arrange
            Boat boat = new Boat(1, 1);
            List<Container> containers = new List<Container>();
            Container container = new Container(ContainerType.Normal, 170);
            string expected = "There is too much weight for the boat";
            //Act
            containers.Add(container);
            boat.AddContainersToUnsorted(containers);
            string result = boat.CheckWeight();
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void BoatBalanceTest_BoatBalanceOff_Returnstring()
        {
            //Arrange
            Boat boat = new Boat(2, 2);
            List<Container> containers = new List<Container>();
            Container container = new Container(ContainerType.Normal, 39);
            Container container2 = new Container(ContainerType.Normal, 61);
            string expected = "The Balance of The ship is off.";
            //Act
            containers.Add(container);
            containers.Add(container2);
            boat.AddContainersToUnsorted(containers);
            boat.AddContainers();
            string result = boat.BoatBalance();
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void BoatBalanceTest_BoatBalance_Returnstring()
        {
            //Arrange
            Boat boat = new Boat(1, 1);
            List<Container> containers = new List<Container>();
            Container container = new Container(ContainerType.Normal, 50);
            Container container2 = new Container(ContainerType.Normal, 50);
            string expected = null;
            //Act
            containers.Add(container);
            boat.AddContainersToUnsorted(containers);
            boat.AddContainers();
            string result = boat.BoatBalance();
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void CheckRemainingContainersTest_MorethanZero_AreEqual()
        {
            //Arrange
            Boat boat = new Boat(1, 1);
            List<Container> containers = new List<Container>();
            Container container = new Container(ContainerType.Normal, 100);
            string expected = $"{3} aren't placed into the boat.";
            //Act
            containers.Add(container);
            containers.Add(container);
            containers.Add(container);
            containers.Add(container);
            boat.AddContainersToUnsorted(containers);
            boat.AddContainers();
            string result = boat.CheckRemainingContainers();
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void CheckRemainingContainersTest_Zero_AreEqual()
        {
            //Arrange
            Boat boat = new Boat(1, 1);
            List<Container> containers = new List<Container>();
            string expected = null;
            //Act
            boat.AddContainersToUnsorted(containers);
            boat.AddContainers();
            string result = boat.CheckRemainingContainers();
            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}