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
        private List<Row> Rows;
        private List<Container> InsertContainers = new List<Container>();
        private List<Container> RemainingContainers = new List<Container>();
        UnsortedList unsortedlist = new UnsortedList();
        private bool leftplacement = true;

        public StringBuild StringBuilder
        {
            get;
            private set;
        }

        public Boat(string name, int length, int width, int weight )
        {
            this.name = name;
            this.length = length;
            this.width = width;
            this.weight = weight;
            StringBuilder = new StringBuild();
            for (int i = 0; i < width; i++)
            {
                Rows.Add(new Row(length));
            }
        }

        public string GetURL()
        {
            return StringBuilder.BuildURL(Rows, width, length);
        }

        public void AddContainers()
        {
            foreach(var container in InsertContainers)
            {
                for(int position = 0; position < length; position++)
                {
                    if(Rows[position].GetWeight() == LowestRowWeight())
                    {
                        if (container.ContainerType == ContainerType.Normal)
                        {
                            Rows[position].AddNormal(container);
                            break;
                        }
                        else if (container.ContainerType == ContainerType.Valuable)
                        {
                            Rows[position].AddValuable(container);
                            break;
                        }
                    }
                    if (container.ContainerType == ContainerType.Valuable)
                    {
                        Rows[position].AddCold(container);
                        break;
                    }
                }
            }
        }

        public void AddFilteredContainers()
        {
            unsortedlist.SortListContainers();
            InsertContainers = unsortedlist.SortedContainerList;
        }

        public void AddContainerToUnsorted(string typestring,int weight)
        {
            ContainerType type = (ContainerType)Enum.Parse(typeof(ContainerType), typestring);
            Container container = new Container(type, weight);
            unsortedlist.AddContainer(container);
        }

        public string CheckRemainingContainers()
        {
            if(RemainingContainers.Count > 0)
            {
                return $"{RemainingContainers.Count} arent placed into the boat.";
            }
            return null;
        }

        public string BoatBalance()
        {
            int leftWeight = 0;
            int rightWeight = 0;

            for (int i = 0; i < (width / 2); i++)
            {
                leftWeight += Rows[i].GetWeight();
            }

            for (int i = width - 1; i > Math.Ceiling((decimal)width / 2) - 1; i--)
            {
                rightWeight += Rows[i].GetWeight();
            }

            if (leftWeight > rightWeight * 1.2 || rightWeight > leftWeight * 1.2)
            {
                return "The Balance of The ship is off.";
            }

            return null;
        }

        public string CheckWeight()
        {
            int weight = 0;
            foreach(var container in InsertContainers)
            {
                weight += container.Weight;
            }

            if(weight < this.weight/2)
            {
                return $"There isnt enough weight on the boat";
            }
            else if(weight > this.weight)
            {
                return $"There is too much weight on the boat";
            }
            return null;
        }

        private int LowestRowWeight()
        {
            int lowestweight = 100000;
            foreach (var row in Rows)
            {
                if (row.GetWeight() < lowestweight)
                {
                    lowestweight = row.GetWeight();
                }
            }
            return lowestweight;
        }
    }
}
