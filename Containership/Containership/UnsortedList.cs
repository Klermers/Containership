using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Containership
{
    public class UnsortedList
    {
        private List<Container> unsortedcontainerslist = new List<Container>();

        public List<Container> SortedContainerList
        {
            get;
            private set;
        }

        public void AddContainers(List<Container> containers)
        {
            foreach(var container in containers)
            {
                unsortedcontainerslist.Add(container);
            }
        }

        private List<Container> SortContainersWeight(List<Container> containers)
        {
            return containers.OrderByDescending(container => container.Weight).ToList();
        }

        private List<Container> GetListContainer()
        {
            List<Container> containers = new List<Container>();
            foreach(var container in unsortedcontainerslist)
            {
                if (GetContainerType(container) == ContainerType.Normal)
                {
                    containers.Add(container);
                }
            }
            return SortContainersWeight(containers);
        }

        private List<Container> GetListColdContainer()
        {
            List<Container> coldcontainers = new List<Container>();
            foreach (var container in unsortedcontainerslist)
            {
                if (GetContainerType(container) == ContainerType.Coolable)
                {
                    coldcontainers.Add(container);
                }
            }
            return SortContainersWeight(coldcontainers);
        }

        private List<Container> GetListRichContainers()
        {
            List<Container> richcontainers = new List<Container>();
            foreach (var container in unsortedcontainerslist)
            {
                if (GetContainerType(container) == ContainerType.Valuable)
                {
                    richcontainers.Add(container);
                }
            }
            return SortContainersWeight(richcontainers);
        }

        private ContainerType GetContainerType(Container container)
        {
            if (container.ContainerType == ContainerType.Normal)
            {
                return ContainerType.Coolable;
            }
            else if (container.ContainerType == ContainerType.Coolable)
            {
                return ContainerType.Coolable;
            }
            else
            {
                return ContainerType.Valuable;
            }
        }

        public void SortListContainers()
        {
            List<Container> containers = new List<Container>();

            foreach (var coldcontainer in GetListContainer())
            {
                containers.Add(coldcontainer);
            }
            foreach (var container in GetListColdContainer())
            {
                containers.Add(container);
            }
            foreach(var richcontainer in GetListRichContainers())
            {
                containers.Add(richcontainer);
            }
            SortedContainerList = containers;           
        }

        public int GetWeight()
        {
            int tobeaddedweight = 0;
            foreach(var contianer in unsortedcontainerslist)
            {
                tobeaddedweight += contianer.Weight;
            }
            return tobeaddedweight;
        }
    }
}
