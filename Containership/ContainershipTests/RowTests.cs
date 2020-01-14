using Microsoft.VisualStudio.TestTools.UnitTesting;
using Containership;
using System;
using System.Collections.Generic;
using System.Text;

namespace Containership.Tests
{
    [TestClass()]
    public class RowTests
    {
        [TestMethod()]
        public void AddNormalTest_TotalWeight_ReturnTrue()
        {
            //Assert
            Row row = new Row(3);
            Container container = new Container(ContainerType.Normal,30);
            //Act
            bool result = row.AddNormal(container);
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void AddNormalTest_NextTotalWeight_ReturnTrue()
        {
            //Assert
            Row row = new Row(3);
            Container container = new Container(ContainerType.Normal, 20);
            Container container2 = new Container(ContainerType.Normal, 15);
            //Act
            row.AddNormal(container);
            row.AddNormal(container2);
            row.AddNormal(container);
            row.AddNormal(container2);
            bool result = row.AddNormal(container);
            //Assert
            Assert.IsTrue(result);
        }

        public void AddNormalTest_NextTotalWeight_ReturnFalse()
        {
            //Assert
            Row row = new Row(1);
            Container container = new Container(ContainerType.Normal, 100);
            //Act
            row.AddNormal(container);
            bool result = row.AddNormal(container);
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void AddValuableTest_PositionZero_ReturnTrue()
        {
            //Assert
            Row row = new Row(1);
            Container container = new Container(ContainerType.Valuable, 30);
            //Act
            bool result = row.AddValuable(container);
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void AddValuableTest_Position_ReturnTrue()
        {
            //Assert
            Row row = new Row(1);
            Container container = new Container(ContainerType.Valuable, 30);
            //Act
            bool result = row.AddValuable(container);
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void AddValuableTest_PositionMax_ReturnTrue()
        {
            //Assert
            Row row = new Row(3);
            Container container = new Container(ContainerType.Valuable, 30);
            //Act
            row.AddValuable(container);
            row.AddValuable(container);
            bool result = row.AddValuable(container);
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod()]
        public void AddValuableTest_IsThereARichContainer_ReturnFalse()
        {
            //Assert
            Row row = new Row(3);
            Container container = new Container(ContainerType.Valuable, 30);
            //Act
            row.AddValuable(container);
            row.AddValuable(container);
            row.AddValuable(container);
            bool result = row.AddValuable(container);
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void AddColdTest_ColumnWeight_Returntrue()
        {
            //Assert
            Row row = new Row(1);
            Container container = new Container(ContainerType.Coolable, 30);
            //Act
             bool result = row.AddCold(container);
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void AddColdTest_ColumnWeight_Returnfalse()
        {
            //Assert
            Row row = new Row(1);
            Container container = new Container(ContainerType.Coolable, 100);
            //Act
            row.AddCold(container);
            bool result = row.AddCold(container);
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void GetWeightTest()
        {
            //Assert
            Row row = new Row(0);
            //Act
            row.GetWeight();
            //Assert
        }
    }
}