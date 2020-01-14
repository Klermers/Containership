using System;
using System.Collections.Generic;
using System.Text;

namespace Containership
{
    public class Row
    {

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
            if(RowBalance() == 1)
            {
                for (int position = 0; position < (columns.Count / 2); position++)
                {
                    if (columns[position].TotalWeight == LowestColumnWeight())
                    {
                        return columns[position].isContainerAdded(container);
                    }
                }
            }
            else
            {
                for (int position = columns.Count - 1; position > Math.Ceiling((decimal)columns.Count / 2) - 1; position--)
                {
                    if (columns[position].TotalWeight == LowestColumnWeight())
                    {
                        return columns[position].isContainerAdded(container);
                    }
                }
            }
            return false;
        }

        public bool AddValuable(Container container)
        {
            if (RowBalance() == 1)
            {
                for (int position = 0; position < (columns.Count / 2); position++)
                {
                    if(columns[position].IsThereARichContainer() == false)
                    {
                        if (IsValuableAddible(position) == true)
                        {

                        }
                    }
                }
            }
            else
            {
                for (int position = columns.Count - 1; position > Math.Ceiling((decimal)columns.Count / 2) - 1; position--)
                {
                    if(columns[position].IsThereARichContainer() == false)
                    {
                        if (IsValuableAddible(position) == true)
                        {

                        }
                    }
                }
            }
            return false;
        }

        public bool AddCold(Container container)
        {
            return columns[0].isContainerAdded(container); ;
        }

        private bool IsValuableAddible(int position)
        {
            if (columns[position].Containers.Count >= columns[position - 1].Containers.Count
              || columns[position].Containers.Count >= columns[position + 1].Containers.Count || position == 0 || position == columns.Count - 1)
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


        private int RowBalance()
        {
            int leftWeight = 0;
            int rightWeight = 0;

            for (int i = 0; i < (columns.Count / 2); i++)
            {
                leftWeight += columns[i].TotalWeight;
            }

            for (int i = columns.Count - 1; i > Math.Ceiling((decimal)columns.Count / 2) - 1; i--)
            {
                rightWeight += columns[i].TotalWeight;
            }

            if (leftWeight > rightWeight * 1.2)
            {
                return  1;
            }
            else if(rightWeight > leftWeight * 1.2)
            {
                return 2;
            }
            return 1;
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
