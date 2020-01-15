using Microsoft.VisualStudio.TestTools.UnitTesting;
using Containership;
using System;
using System.Collections.Generic;
using System.Text;

namespace Containership.Tests
{
    [TestClass()]
    public class StringBuildTests
    {
        [TestMethod()]
        public void BuildURLTest()
        {
          //Arrange
            StringBuild stringBuilder = new StringBuild();
            List<Row> rows = new List<Row>();
            Container container1 = new Container(ContainerType.Normal, 4);
            Container container2 = new Container(ContainerType.Coolable, 10);
            Container container3 = new Container(ContainerType.Valuable, 16);
            Container container4 = new Container(ContainerType.Normal, 22);

            int length = 2;
            int width = 2;
            string urlExpected = $"https://i872272core.venus.fhict.nl/ContainerVisualizer/index.html?length={length}&width={width}&stacks=3-1,1/2,&weights=10-4,22/16,";

            //Act
            rows.Add(new Row(2));
            rows.Add(new Row(2));

            rows[0].Columns[0].IsContainerAdded(container2);
            rows[0].Columns[0].IsContainerAdded(container1);
            rows[1].Columns[0].IsContainerAdded(container3);
            rows[0].Columns[1].IsContainerAdded(container4);

            string urlReturn = stringBuilder.BuildURL(rows, width, length);

            //Assert
            Assert.AreEqual(urlExpected, urlReturn);
        }
    }
}