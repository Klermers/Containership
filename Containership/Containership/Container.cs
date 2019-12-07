using System;
using System.Collections.Generic;
using System.Text;

namespace Containership
{
    class Container
    {
        private static int lenght;
        private static int width;
        private static int height;
        private int z_coordinate;
        private decimal weight;
        private int currentcapacity;
        private int maxcapacity;

        public int Lenght
        {
            get { return lenght; }
        }

        public int Width
        {
            get { return width; }
        }

        public int Height
        {
            get { return height; }
        }

        public decimal Weight
        {
            get { return weight; }
        }

        public int Y_coordinate
        {
            get { return z_coordinate; }
        }

        public Container(int z_position)
        {
            this.z_coordinate = z_position;
        }

    }
}
