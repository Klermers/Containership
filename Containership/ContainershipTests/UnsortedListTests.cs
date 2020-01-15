using Microsoft.VisualStudio.TestTools.UnitTesting;
using Containership;
using System;
using System.Collections.Generic;
using System.Text;

namespace Containership.Tests
{
    [TestClass()]
    public class UnsortedListTests
    {
        [TestMethod()]
        public void SortListContainersTest_SortNormal_ReturnEqual()
        {
            //Arrange
            UnsortedList unsortedlist = new UnsortedList();
            Container container10 = new Container(ContainerType.Normal, 10);
            Container container15 = new Container(ContainerType.Normal, 15);
            Container container20= new Container(ContainerType.Normal, 20);
            List<Container> expected = new List<Container>();
            expected.Add(container20);
            expected.Add(container15);
            expected.Add(container10);
            //Act
            unsortedlist.AddContainer(container15);
            unsortedlist.AddContainer(container10);
            unsortedlist.AddContainer(container20);
            unsortedlist.SortListContainers();
            //Assert
            CollectionAssert.AreEqual(expected, unsortedlist.SortedContainerList);
        }

        [TestMethod()]
        public void SortListContainersTest_SortValuable_ReturnEqual()
        {
            //Arrange
            UnsortedList unsortedlist = new UnsortedList();
            Container container10 = new Container(ContainerType.Valuable, 10);
            Container container15 = new Container(ContainerType.Valuable, 15);
            Container container20 = new Container(ContainerType.Valuable, 20);
            List<Container> expected = new List<Container>();
            expected.Add(container20);
            expected.Add(container15);
            expected.Add(container10);
            //Act
            unsortedlist.AddContainer(container15);
            unsortedlist.AddContainer(container10);
            unsortedlist.AddContainer(container20);
            unsortedlist.SortListContainers();
            //Assert
            CollectionAssert.AreEqual(expected, unsortedlist.SortedContainerList);
        }

        [TestMethod()]
        public void SortListContainersTest_Sortcold_ReturnEqual()
        {
            //Arrange
            UnsortedList unsortedlist = new UnsortedList();
            Container container10 = new Container(ContainerType.Coolable, 10);
            Container container15 = new Container(ContainerType.Coolable, 15);
            Container container20 = new Container(ContainerType.Coolable, 20);
            List<Container> expected = new List<Container>();
            expected.Add(container20);
            expected.Add(container15);
            expected.Add(container10);
            //Act
            unsortedlist.AddContainer(container15);
            unsortedlist.AddContainer(container10);
            unsortedlist.AddContainer(container20);
            unsortedlist.SortListContainers();
            //Assert
            CollectionAssert.AreEqual(expected, unsortedlist.SortedContainerList);
        }

        [TestMethod()]
        public void SortListContainersTest_SortAllContainers_ReturnEqual()
        {
            //Arrange
            UnsortedList unsortedlist = new UnsortedList();
            Container normal10 = new Container(ContainerType.Normal, 10);
            Container normal15 = new Container(ContainerType.Normal, 15);
            Container valuable15 = new Container(ContainerType.Valuable, 15);
            Container valuable25 = new Container(ContainerType.Valuable, 25);
            Container coolable20= new Container(ContainerType.Coolable, 20);
            Container coolable25 = new Container(ContainerType.Coolable, 25);
            List<Container> expected = new List<Container>();
            expected.Add(coolable25);
            expected.Add(coolable20);
            expected.Add(normal15);
            expected.Add(normal10);
            expected.Add(valuable25);
            expected.Add(valuable15);
            //Act
            unsortedlist.AddContainer(valuable25);
            unsortedlist.AddContainer(coolable20);
            unsortedlist.AddContainer(coolable25);
            unsortedlist.AddContainer(normal15);
            unsortedlist.AddContainer(valuable15);
            unsortedlist.AddContainer(normal10);
            unsortedlist.SortListContainers();
            //Assert
            CollectionAssert.AreEqual(expected, unsortedlist.SortedContainerList);
        }

    }
}