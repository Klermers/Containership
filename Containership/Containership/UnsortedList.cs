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

        public void AddContainer(Container container)
        {
            unsortedcontainerslist.Add(container);
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
            foreach (var coldcontainer in GetListContainer())
            {
                SortedContainerList.Add(coldcontainer);
            }
            foreach (var container in GetListColdContainer())
            {
                SortedContainerList.Add(container);
            }
            foreach(var richcontainer in GetListRichContainers())
            {
                SortedContainerList.Add(richcontainer);
            }
            
        }
    }
}
