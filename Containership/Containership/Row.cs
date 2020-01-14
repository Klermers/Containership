using System;
using System.Collections.Generic;
using System.Text;

namespace Containership
{
    public class Row
    {
        private static bool left = true;
        private List<Column> columns = new List<Column>();

        public List<Column> Columns
        { get { return columns; } }

        public Row(int shiplength)
        {
            for (int columnamount = 1; columnamount <= shiplength; columnamount++)
            {
                Column column = new Column(columnamount);
                columns.Add(column);
            }

        }

        public bool AddNormal(Container container)
        {
            for (int position = 0; position < columns.Count; position++)
            {
                if (columns[position].TotalWeight == LowestColumnWeight())
                {
                    return columns[position].IsContainerAdded(container);
                }
            }
            return false;
        }

        public bool AddValuable(Container container)
        {
            for (int position = 0; position < columns.Count; position++)
            {
                if (columns[position].IsThereARichContainer() == false)
                {
                    if (IsValuableAddible(position) == true)
                    {
                        return columns[position].IsContainerAdded(container);
                    }
                }
            }
            return false;
        }

        public bool AddCold(Container container)
        {
            return columns[0].IsContainerAdded(container);
        }

        private bool IsValuableAddible(int position)
        {
            if (position == 0 ||position == columns.Count -1||columns[position].Containers.Count >= columns[position - 1].Containers.Count
              || columns[position].Containers.Count >= columns[position + 1].Containers.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetWeight()
        {
            int weight = 0;
            foreach (var column in columns)
            {
                weight += column.TotalWeight;
            }

            return weight;
        }

        private int LowestColumnWeight()
        {
            int lowestweight = 200;
            foreach (var column in columns)
            {
                if (column.TotalWeight < lowestweight)
                {
                    lowestweight = column.TotalWeight;
                }
            }
            return lowestweight;
        }

    }
}
