using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Containership
{
    public class Column
    {
        private static int y_as = 0;
        private readonly int y_position;
        private decimal totalWeight = 0;
        private List<Container> ColumnContainers = new List<Container>();

        public int X_position
        {
            get { return y_position; }
        }

        public int Y_position
        {
            get { return y_position; }
        }

        public decimal TotalWeight
        {
            get { return totalWeight; }
        }

        public Column(int yposition)
        {
            y_position = yposition;
        }

        private void CalculateTheTotalWeight()
        {
            totalWeight = 0;

            foreach(var container in ColumnContainers)
            {
                totalWeight += container.Weight;
            }
        }

        private decimal WeightOnContainer()
        {
            decimal newtotalweight = 0;

            var newcontainerlist = from container in ColumnContainers
                                   where container.Z_coordinate > 1
                                   select container;

            foreach(var container in newcontainerlist)
            {
                newtotalweight += container.Weight;
            }

            return newtotalweight;
        }

        public bool IsTheContainerAdded(Container container)
        {
            int z_position = ColumnContainers.Count() + 1;
            container = new Container(z_position);
            var newtotalweight = WeightOnContainer() + container.Weight;

            if (newtotalweight < 116)
            {
                ColumnContainers.Add(container);
                CalculateTheTotalWeight();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
