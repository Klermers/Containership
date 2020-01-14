using System;
using System.Collections.Generic;
using System.Text;

namespace Containership
{
    public class Container
    {
        private int z_coordinate;
        private int weight = 4;

        public ContainerType ContainerType
        {
            get;
            private set;
        }

        public int Weight
        {
            get { return weight; }
            private set { weight = value; }
        }

        public int Z_coordinate
        {
            get { return z_coordinate; }
            private set { z_coordinate = value; }
        }

        public Container(ContainerType containertype, int weight)
        {
            ContainerType = containertype;
            Weight = weight;
        }

        public Container()
        {
        }

    }
}
