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
            Boat boat = new Boat("boat", 2, 2, 150);
            List<Container> containers = new List<Container>();
            Container container = new Container(ContainerType.Normal, 100);
            containers.Add(container);
            containers.Add(container);
            containers.Add(container);
            containers.Add(container);
            string expected = $"https://i872272core.venus.fhict.nl/ContainerVisualizer/index.html?length=2&width=2&stacks=1,1/1,1&weights=100,100/100,100";
            //Act 
            boat.AddContainersToUnsorted(containers);
            boat.AddFilteredContainers();
            boat.AddContainers();
            string result = boat.GetURL();
            //Assrt
            Assert.AreEqual(expected, result);
        }
        [TestMethod()]
        public void AddContainersTest_AddNormalContainerColumn_ReturnEqual()
        {
            //Arrange 
            Boat boat = new Boat("boat", 2, 2, 150);
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
            boat.AddFilteredContainers();
            boat.AddContainers();
            string result = boat.GetURL();
            //Assrt
            Assert.AreEqual(expected, result);
        }
        [TestMethod()]
        public void AddContainersTest_AddColdContainer_ReturnEqual()
        {
            //Arrange 
            Boat boat = new Boat("boat", 2, 2, 150);
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
            boat.AddFilteredContainers();
            boat.AddContainers();
            string result = boat.GetURL();
            //Assrt
            Assert.AreEqual(expected, result);
        }
        [TestMethod()]
        public void AddContainersTest_AddValuableContainer_ReturnEqual()
        {
            //Arrange 
            Boat boat = new Boat("boat", 2, 2, 150);
            List<Container> containers = new List<Container>();
            Container container = new Container(ContainerType.Valuable, 30);
            containers.Add(container);
            containers.Add(container);
            containers.Add(container);
            string expected = $"https://i872272core.venus.fhict.nl/ContainerVisualizer/index.html?length=2&width=2&stacks=2,2/2,2&weights=30,30/30,30";
            //Act 
            boat.AddContainersToUnsorted(containers);
            boat.AddFilteredContainers();
            boat.AddContainers();
            string result = boat.GetURL();
            //Assrt
            Assert.AreEqual(expected, result);
        }
        [TestMethod()]
        public void AddContainersTest_AddContainers_ReturnEqual()
        {
            //Arrange 
            Boat boat = new Boat("boat", 2, 2, 150);
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
            boat.AddFilteredContainers();
            boat.AddContainers();
            string result = boat.GetURL();
            //Assrt
            Assert.AreEqual(expected, result);
        }
    }
}