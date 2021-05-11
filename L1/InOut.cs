using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace L1
{
    public class InOut
    {
        // Prints the painted table, number of rows and columns to a text file
        public static void ExportStartingData(Container container)
        {
            List<string> lines = new List<string>();

            lines.Add("N(Eilučių skaičius) : " + container.GetRowCount());
            lines.Add("M(Stuleplių skaičius) : " + container.GetColumnCount());
            lines.Add("");
            lines.Add("Sugeneruota lentelė:");

            for (int i = 0; i <= container.GetRowCount(); i++)
            {
                lines.Add(new string('-', container.GetColumnCount() * 5 + 6));

                string line = "|";

                for (int j = 0; j <= container.GetColumnCount(); j++)
                {
                    line += " ";
                    line += string.Format("{0,2}", container.Get_Point(i, j));
                    line += " |";
                }

                lines.Add(line);
            }

            lines.Add(new string('-', container.GetColumnCount() * 5 + 6));

            File.WriteAllLines(@"StartingData.txt", lines);

        }

        // Exports the results to a txt file
        public static void ExportResult(int spotCount, int spotBiggest, int row, int column)
        {
            List<string> lines = new List<string>();

            lines.Add("Dėmių skaičius: " + spotCount);
            lines.Add("Didžiausia dėmė: " + spotBiggest);
            lines.Add("Eilutė: " + row);
            lines.Add("Stulpelis: " + column);

            File.WriteAllLines(@"Result.txt", lines);
        }

    }
}