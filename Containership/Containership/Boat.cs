using System;
using System.Collections.Generic;
using System.Text;

namespace Containership
{
    public class Boat
    {
        private string name;
        private int length;
        private int width;
        private int weight;
        private int seperatorlenght = 1;
        private int seperatorwidth = 3;
        private Grid[] CapacityGrid;
        private List<Container> InsertContainers = new List<Container>();

        public Boat(string name, int length, int width, int weight )
        {
            this.name = name;
            this.length = length;
            this.width = width;
            this.weight = weight;
        }

        private void BoatCapicityCalculator()
        {
            CapacityGrid = new Grid[width];
            for(int i = 1; i <= width;i++)
            {
                Grid grid = new Grid(length);
                CapacityGrid[i-1] = grid;
            }

        }

        public void ContainerOntoShip()
        {

        }

    }
}
