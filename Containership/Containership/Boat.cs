﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Containership
{
    public class Boat
    {
        private int length;
        private int width;
        private List<Row> Rows = new List<Row>();
        private List<Container> RemainingContainers = new List<Container>();
        private UnsortedList unsortedlist = new UnsortedList();
        public int Surface { get { return width * length; } }

        public StringBuild StringBuilder
        {
            get;
            private set;
        }

        public Boat(int length, int width)
        {
            this.length = length;
            this.width = width;
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
            foreach(var container in unsortedlist.SortedContainerList)
            {
                if(container.ContainerType== ContainerType.Coolable)
                {
                    if (IsColdAdded(container) == false)
                    {
                        RemainingContainers.Add(container);
                    }
                }
                else if(container.ContainerType == ContainerType.Normal)
                {
                    if (IsNormalContainerAdded(container) == false)
                    {
                        RemainingContainers.Add(container);
                    }
                }
                else if(container.ContainerType == ContainerType.Valuable)
                {
                    if (IsValuableAdded(container) == false)
                    {
                        RemainingContainers.Add(container);
                    }
                }
            }
        }

        private bool IsNormalContainerAdded(Container container)
        {
            for(int position = 0; position <= length; position++)
            {
                if (Rows[position].GetWeight() == LowestRowWeight())
                {
                    if (Rows[position].IsNormalAdded(container) == true)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool IsValuableAdded(Container container)
        {
            foreach(var row in Rows)
            {
                if (row.IsValuableAdded(container) == true)
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsColdAdded(Container container)
        {
            for (int position = 0; position <= length; position++)
            {
                if (Rows[position].GetColdColumnWeight() == LowestColdColumn())
                {
                    if (Rows[position].IsColdAdded(container) == true)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void AddContainersToUnsorted(List<Container> containers)
        {
            unsortedlist.AddContainers(containers);
            unsortedlist.SortListContainers();
        }

        public string CheckRemainingContainers()
        {
            if(RemainingContainers.Count > 0)
            {
                return $"{RemainingContainers.Count} aren't placed into the boat.";
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
            int minWeight = Surface * 75;
            int maxWeight = Surface * 150;

            if (unsortedlist.GetWeight() < minWeight)
            {
                return $"There isnt enough weight for the boat";
            }
            else if(unsortedlist.GetWeight() > maxWeight)
            {
                return $"There is too much weight for the boat";
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

        private int LowestColdColumn()
        {
            int lowestweight = 200;
            foreach(var row in Rows)
            {
                lowestweight = row.GetColdColumnWeight();
            }
            return lowestweight;
        }
    }
}
