using System;
using System.Collections.Generic;
using System.Text;

namespace Containership
{
    public class Container
    {
        private static int lenght;
        private static int width;
        private static int height;
        private int z_coordinate;
        private int weight = 4;

        public ContainerType ContainerType
        {
            get;
            private set;
        }

        public int Lenght
        {
            get { return lenght; }
            private set { width = value; }
        }

        public int Width
        {
            get { return width; }
            private set { width = value; }
        }

        public int Height
        {
            get { return height; }
            private set { height = value; }
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
