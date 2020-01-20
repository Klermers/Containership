using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Containership
{
    public class Column
    {
        private List<Container> containers = new List<Container>();
        private int totalWeight = 0;

        public int Containercount
        {
            get { return containers.Count; }
        }
        public int TotalWeight
        {
            get { return totalWeight; }
        }

        public bool IsContainerAdded(Container container)
        {
            if (WeightOnContainer() + container.Weight <= 120)
            {
                containers.Add(container);
                totalWeight += container.Weight;
                return true;
            }
            return false;
        }

        private int WeightOnContainer()
        {
            int newtotalweight = 0;
            List<Container> newcontainerlist = new List<Container>();

            for (int position = 1; position <= containers.Count; position++)
            {
                newtotalweight += containers[position - 1].Weight;
            }
            return newtotalweight;
        }

        public bool IsThereARichContainer()
        {
            foreach(var container in containers)
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

            foreach (Container container in containers)
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

            foreach (Container container in containers)
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
