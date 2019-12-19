using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Containership
{
    class UnsortedList
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
                if (GetContainerType(container) == ContainerType.Container)
                {
                    containers.Add(container);
                }
            }
            return containers;
        }

        private List<Container> GetListColdContainer()
        {
            List<Container> coldcontainer = new List<Container>();
            foreach (var container in unsortedcontainerslist)
            {
                if (GetContainerType(container) == ContainerType.ColdContainer)
                {
                    coldcontainer.Add(container);
                }
            }
            return coldcontainer;
        }

        private List<Container> GetListRichContainers()
        {
            List<Container> richcontainers = new List<Container>();
            foreach (var container in unsortedcontainerslist)
            {
                if (GetContainerType(container) == ContainerType.RichContainer)
                {
                    richcontainers.Add(container);
                }
            }
            return richcontainers;
        }

        private ContainerType GetContainerType(Container container)
        {
            if (container.ContainerType == ContainerType.Container)
            {
                return ContainerType.Container;
            }
            else if (container.ContainerType == ContainerType.ColdContainer)
            {
                return ContainerType.ColdContainer;
            }
            else
            {
                return ContainerType.RichContainer;
            }
        }

        public void SortListContainers()
        {
            foreach (var container in GetListColdContainer())
            {
                SortedContainerList.Add(container);
            }
            foreach (var coldcontainer in GetListContainer())
            {
                SortedContainerList.Add(coldcontainer);
            }
            foreach(var richcontainer in GetListRichContainers())
            {
                SortedContainerList.Add(richcontainer);
            }
            
        }
    }
}
