using System;
using System.Collections.Generic;
using System.Text;

namespace Containership
{
    class Boat
    {
        private string name;
        private int length;
        private int width;
        private int weight;
        private int seperatorlenght = 1;
        private int seperatorwidth = 3;
        private Boat[, ,] boatcapacity;
        private Container addcontainer;

        public Boat(string name, int length, int width, int weight )
        {
            addcontainer = new Container();
            this.name = name;
            this.length = length;
            this.width = width;
            this.weight = weight;
        }

        private void BoatCapicityCalculator()
        {
            int totalcontainerlenght = addcontainer.Lenght + seperatorlenght; ;
            int totalcontainerwidth = addcontainer.Width + seperatorwidth; ;

            int amountcontainerslenght = this.length / totalcontainerlenght;
            int amountcontainerswidth = this.width / totalcontainerwidth;

            boatcapacity = new Boat[totalcontainerwidth,totalcontainerlenght,38];
        }

    }
}
