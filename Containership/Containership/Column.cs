using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Containership
{
    public class Column
    {
        private readonly int y_position;
        private int totalWeight = 0;
        private List<Container> columnContainers = new List<Container>();

        public int Y_position
        {
            get { return y_position; }
        }

        public int TotalWeight
        {
            get { return totalWeight; }
        }

        public List<Container> Containers
        {
            get { return columnContainers; }
        }

        public Column(int yposition)
        {
            y_position = yposition;
        }


        public bool isContainerAdded(Container container)
        {
            int z_position = columnContainers.Count() + 1;
            if (WeightOnContainer() + container.Weight < 116)
            {
                columnContainers.Add(container);
                return false;
            }
            else
            {
                columnContainers.Add(container);
                return true;
            }
        }

        private int WeightOnContainer()
        {
            int newtotalweight = 0;

            var newcontainerlist = from container in columnContainers
                                   where container.Z_coordinate > 1
                                   select container;

            foreach(var container in newcontainerlist)
            {
                newtotalweight += container.Weight;
            }

            return newtotalweight;
        }

        public bool IsThereARichContainer()
        {
            foreach(var container in columnContainers)
            {
                if(container.ContainerType == ContainerType.Valuable)
                {
                    return true;
                }
            }
            return false;
        }

        public string BuildStacksURL()
        {
            string urlStacks = "";

            foreach (Container container in columnContainers)
            {
                urlStacks += $"-{(int)container.ContainerType}";
            }

            if (urlStacks.Equals(""))
            {
                return urlStacks;
            }
            else
            {
                return urlStacks.Substring(1);
            }
        }

        public string BuildWeigthsURL()
        {
            string urlWeights = "";

            foreach (Container container in columnContainers)
            {
                urlWeights += $"-{container.Weight}";
            }

            if (urlWeights.Equals(""))
            {
                return urlWeights;
            }
            else
            {
                return urlWeights.Substring(1);
            }
        }
    }
}
