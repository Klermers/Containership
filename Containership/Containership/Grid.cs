using System;
using System.Collections.Generic;
using System.Text;

namespace Containership
{
    class Grid
    {
        private Column[] grid;

        public Grid(int shiplength)
        {
            grid = new Column[shiplength];
        }

        public bool IsContainerAddedToColumnOfGrid()
        {
            //One side is heavier than the other
            //Het gewicht van de column is te groot maar dat check je in column
            foreach (var column in grid)
            {

            }
            return false;
        }

        public Column TheLightestColumnInGrid()
        {
            decimal lowestweight;

            foreach(var column in grid)
            {
                if(lowestweight > column.TotalWeight)
                {

                }
            }
            return;
        }

        public decimal CalculateLeftWeight()
        {
            return
        }

        public decimal CalculateRightWeight()
        {
            return
        }
    }
}
