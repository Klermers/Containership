using Microsoft.VisualStudio.TestTools.UnitTesting;
using Containership;
using System;
using System.Collections.Generic;
using System.Text;

namespace Containership.Tests
{
    [TestClass()]
    public class ColumnTests
    {
        [TestMethod()]
        public void IsTheContainerAddedTest_Weight_Returntrue()
        {
            //Arrange
            Column column = new Column(1);
            Container container = new Container(ContainerType.Normal, 30);
            //Act
            bool result = column.IsContainerAdded(container);
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void IsTheContainerAddedTest_Weight_Returnfalse()
        {
            //Arrange
            Column column = new Column(1);
            Container container = new Container(ContainerType.Normal, 30);
            //Act
            column.IsContainerAdded(container);
            column.IsContainerAdded(container);
            column.IsContainerAdded(container);
            column.IsContainerAdded(container);
            column.IsContainerAdded(container);
            bool result = column.IsContainerAdded(container);
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void IsThereARichContainerTest_containerType_ReturnsTrue()
        {
            //Arrange
            Column column = new Column(1);
            Container container = new Container(ContainerType.Valuable, 30);
            //Act
            column.IsContainerAdded(container);
            bool result = column.IsThereARichContainer();
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void IsThereARichContainerTest_containerType_ReturnsFalse()
        {
            //Arrange
            Column column = new Column(1);
            Container container = new Container(ContainerType.Valuable, 30);
            //Act
            bool result = column.IsThereARichContainer();
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void BuildStacksURLTest_Substring_ReturnSubstring()
        {
            //Arrange
            Column column = new Column(0);
            Container container = new Container(ContainerType.Normal, 30);
            string urlExpected = "1-1-1";

            //Act

            column.IsContainerAdded(container);
            column.IsContainerAdded(container);
            column.IsContainerAdded(container);

            string urlReturn = column.BuildStacksURL();

            //Assert
            Assert.AreEqual(urlExpected, urlReturn);
        }

        [TestMethod()]
        public void BuildWeigthsURLTest_Substring_ReturnSubstring()
        {
            //Arrange
            Column column = new Column(1);
            Container container = new Container(ContainerType.Normal, 20);
            string urlExpected = "20-20-20";

            //Act
            for (int i = 0; i < 3; i++)
            {
                column.IsContainerAdded(container);
            }

            string urlReturn = column.BuildWeigthsURL();

            //Assert
            Assert.AreEqual(urlExpected, urlReturn);
        }
    }
}