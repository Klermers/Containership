using System;
using System.Collections.Generic;
using System.Text;

namespace Containership
{
    class Grid
    {
        private Column[] grid;
        private decimal

        public Grid(int shiplength)
        {
            grid = new Column[shiplength];
        }

        public bool IsContainerAddedToColumnOfGrid()
        {
            //One side is heavier than the other
            //Het gewicht van de column is te groot maar dat check je in column
            foreach
            return false;
        }
    }
}
