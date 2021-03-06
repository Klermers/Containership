﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            bool result = row.IsNormalAdded(container);
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
            row.IsNormalAdded(container);
            row.IsNormalAdded(container2);
            row.IsNormalAdded(container);
            row.IsNormalAdded(container2);
            bool result = row.IsNormalAdded(container);
            //Assert
            Assert.IsTrue(result);
        }

        public void AddNormalTest_NextTotalWeight_ReturnFalse()
        {
            //Assert
            Row row = new Row(1);
            Container container = new Container(ContainerType.Normal, 100);
            //Act
            row.IsNormalAdded(container);
            bool result = row.IsNormalAdded(container);
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
            bool result = row.IsValuableAdded(container);
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
            bool result = row.IsValuableAdded(container);
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
            row.IsValuableAdded(container);
            row.IsValuableAdded(container);
            bool result = row.IsValuableAdded(container);
            //Assert
            Assert.IsFalse(result);
        }
        [TestMethod()]
        public void AddValuableTest_IsThereARichContainer_ReturnFalse()
        {
            //Assert
            Row row = new Row(3);
            Container container = new Container(ContainerType.Valuable, 30);
            //Act
            row.IsValuableAdded(container);
            row.IsValuableAdded(container);
            row.IsValuableAdded(container);
            bool result = row.IsValuableAdded(container);
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
             bool result = row.IsColdAdded(container);
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
            row.IsColdAdded(container);
            bool result = row.IsColdAdded(container);
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void GetWeightTest()
        {
            //Assert
            Row row = new Row(3);
            Container container = new Container(ContainerType.Normal, 30);
            int expected = 120;
            //Act
            row.IsNormalAdded(container);
            row.IsNormalAdded(container);
            row.IsNormalAdded(container);
            row.IsNormalAdded(container);
            int result = row.GetWeight();
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void GetColdColumnWeight()
        {
            //Assert
            Row row = new Row(2);
            Container container = new Container(ContainerType.Normal,30);
            Container coolable = new Container(ContainerType.Coolable, 30);
            int expected = 60;
            //Act
            row.IsColdAdded(coolable);
            row.IsColdAdded(coolable);
            row.IsNormalAdded(container);
            int result = row.GetColdColumnWeight();
            //Arrange
            Assert.AreEqual(expected, result);
        }
    }
}