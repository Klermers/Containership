using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Containership
{
    public class StringBuild
    {
        public string BuildURL(List<Row> rows, int width, int length)
        {
            string url = $"https://i872272core.venus.fhict.nl/ContainerVisualizer/index.html?length={length}&width={width}";
            string urlStacks = "";
            string urlWeights = "";

            for (int x = 0; x < width; x++)
            {
                string stackUrlStacks = "";
                string stackUrlWeights = "";

                for (int y = 0; y < length; y++)
                {
                    stackUrlStacks += CheckURL($",{rows[x].Columns[y].BuildStacksURL()}", ",");
                    stackUrlWeights += CheckURL($",{rows[x].Columns[y].BuildWeigthsURL()}", ",");
                }

                urlStacks += CheckURL($"/{stackUrlStacks.Substring(1)}", "/");
                urlWeights += CheckURL($"/{stackUrlWeights.Substring(1)}", "/");
            }

            return $"{url}&stacks={urlStacks.Substring(1)}&weights={urlWeights.Substring(1)}";
        }

        private string CheckURL(string url, string seperator)
        {
            if (url.Equals(""))
            {
                return $"{seperator}{seperator}";
            }
            else
            {
                return url;
            }
        }
    }
}
