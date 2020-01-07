using System;
using System.Collections.Generic;
using System.Text;

namespace Containership
{
    public class Grid
    {

        private Column[] grid;

        public int X_coordinate
        {
            get;
            private set;
        }

        public Grid(int shiplength)
        {
            grid = new Column[shiplength];
            for (int i = 1; i <= shiplength; i++ )
            {
                Column column = new Column(i);
                grid[i - 1] = column;
            }
        }

        public bool IsContainerAddedToColumnOfGrid()
        {
            return true;
        }

        public Column TheLightestColumnInGrid()
        {
            Column lowestweightcolumn = grid[0];
            foreach(var column in grid)
            {
                if(column.TotalWeight < lowestweightcolumn.TotalWeight)
                {
                    lowestweightcolumn = column;
                }
            }
            return lowestweightcolumn;
        }

        public decimal CalculateLeftWeight()
        {
            decimal leftweight = 0m;
            if (grid.Length % 2 != 0)
            {
                int lefthalf = (grid.Length-1) /2;
                for(int i = 0; i <= lefthalf; i++)
                {
                    leftweight += grid[i].TotalWeight;
                }
                return leftweight;
            }
            else
            {
                int lefthalf = (grid.Length) / 2;
                for (int i = 0; i <= lefthalf; i++)
                {
                    leftweight += grid[i].TotalWeight;
                }
                return leftweight;
            }
        }
    }
}
