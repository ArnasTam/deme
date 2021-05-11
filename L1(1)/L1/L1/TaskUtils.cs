using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;

namespace L1
{
    public class TaskUtils
    {
        public Container Container
        {
            get => default(Container);
            set
            {
            }
        }

        /// <summary>
        /// Transfers the data from container into a table in Web
        /// </summary>
        /// <param name="container"> A container object </param>
        /// <param name="table"> A table object in the web </param>
        public void ContainerToTable(Container container, Table table)
        {
            for (int i = 0; i <= container.GetRowCount(); i++)
            {
                AddRow(container, i, table);
            }
        }

        // Adds a row
        private void AddRow(Container container, int rowCount, Table table)
        {
            TableRow row = new TableRow();

            for (int i = 0; i <= container.GetColumnCount(); i++)
            {
                row.Cells.Add(AddCell(container, rowCount, i));
            }

            table.Rows.Add(row);
        }

        /// <summary>
        /// Adds a cell
        /// </summary>
        /// <param name="container"> Container object</param>
        /// <param name="rowIndex"> the number of current row </param>
        /// <param name="columnIndex"> the number of current column </param>
        /// <returns></returns>
        private TableCell AddCell(Container container, int rowIndex, int columnIndex)
        {
            TableCell cell = new TableCell();

            cell.Text = Convert.ToString(container.Get_Point(rowIndex, columnIndex));

            // Paints all painted table cells Black
            if(cell.Text == "*")
            {
                cell.BackColor = Color.Black;
            }

            return cell;
        }

        /// <summary>
        /// Paints random points until a third of a table is painted
        /// </summary>
        /// <param name="container"></param>
        public void GenerateRandomDots(Container container)
        {
            Random rnd = new Random();
            int paintedCount = 0;
            
            while(paintedCount < ((container.GetColumnCount()) * 
                (container.GetRowCount()))/3)
            {
                int row = rnd.Next(1, container.GetRowCount() + 1);
                int column = rnd.Next(1, container.GetColumnCount() + 1);

                if (!container.Get_Point(row, column).Equals("*"))
                {
                    container.Set_String(row, column, "*");
                    container.Set_Bool(row, column, true);
                    paintedCount++;
                }
            }
        }

        /// <summary>
        /// Prints out the results to a table in Web
        /// </summary>
        /// <param name="spotCount"> the amount of spots </param>
        /// <param name="spotBiggest"> the size of the biggest spot </param>
        /// <param name="spotRow"> row number of any point of biggest spot </param>
        /// <param name="spotColumn"> column number of any point of biggest spot</param>
        /// <param name="table"> The table object in Web </param>
        public void ResultTable(int spotCount, int spotBiggest, 
            int spotRow, int spotColumn, Table table)
        {
            // Adding the amount of spots
            TableCell count = new TableCell();
            count.Text = Convert.ToString(spotCount);
            TableCell count1 = new TableCell();
            count1.Text = "Dėmių skaičius";
            TableRow tableRow1 = new TableRow();
            tableRow1.Cells.Add(count1);
            tableRow1.Cells.Add(count);
            table.Rows.Add(tableRow1);

            // Adding the number of biggest spot
            TableCell biggest = new TableCell();
            biggest.Text = Convert.ToString(spotBiggest);
            TableCell biggest1 = new TableCell();
            biggest1.Text = "Didžiausia dėmė";
            TableRow tableRow2 = new TableRow();
            tableRow2.Cells.Add(biggest1);
            tableRow2.Cells.Add(biggest);
            table.Rows.Add(tableRow2);

            // Adding the row number of  biggest spot
            TableCell row = new TableCell();
            row.Text = Convert.ToString(spotRow);
            TableCell row1 = new TableCell();
            row1.Text = "Eilutė";
            TableRow tableRow3 = new TableRow();
            tableRow3.Cells.Add(row1);
            tableRow3.Cells.Add(row);
            table.Rows.Add(tableRow3);

            // Adding the column number of  biggest spot
            TableCell column = new TableCell();
            column.Text = Convert.ToString(spotColumn);
            TableCell column1 = new TableCell();
            column1.Text = "Stulpelis";
            TableRow tableRow4 = new TableRow();
            tableRow4.Cells.Add(column1);
            tableRow4.Cells.Add(column);
            table.Rows.Add(tableRow4);
        }

        /// <summary>
        /// Calculates the amount of spots, biggest spot 
        /// number of points, spot row and column number
        /// </summary>
        /// <param name="container"> A container object </param>
        /// <param name="spotCount"> the amount of spots </param>
        /// <param name="spotBiggest"> the size of the biggest spot </param>
        /// <param name="spotRow"> row number of any point of biggest spot </param>
        /// <param name="spotColumn"> column number of any point of biggest spot</param>
        public void CalculateResult(Container container, ref int spotCount, 
            ref int spotBiggest, ref int spotRow, ref int spotColumn)
        {
            int spotSize;
            spotBiggest = 0;

            // Goes through every point
            for (int i = 1; i <= container.GetRowCount(); i++)
            {
                for (int j = 1; j <= container.GetColumnCount(); j++)
                {
                    // If point is painted
                    if(container.Get_Bool(i, j) == true)
                    {
                        spotCount++;
                        spotSize = 1;

                        // Means we already used
                        container.Set_Bool(i, j, false);
                        // Checks if spot connects to another near spot
                        CheckNearPoints(container, ref spotSize, i, j);

                        // Checks whether the currect spots is the biggest yet
                        if(spotSize > spotBiggest)
                        {
                            spotRow = i;
                            spotColumn = j;
                            spotBiggest = spotSize;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Checks all 9 near coordinates of a point
        /// </summary>
        /// <param name="container"></param>
        /// <param name="spotSize"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void CheckNearPoints(Container container, ref int spotSize, int x, int y)
        {
            // Goes through (x-1)(x)(x+1) coordinates
            for(int i = - 1; i <= 1; i++)
            {
                // Goes through (y-1)(y)(y+1) coordinates
                for (int j = -1; j <= 1; j++)
                {
                    // Checks wheteher the point is painted or not
                    if (container.Get_Bool(x + i, y + j) == true)
                    {
                        spotSize++;
                        container.Set_Bool(x + i, y + j, false);
                        // Checks other near points
                        CheckNearPoints(container, ref spotSize, x + i, y + j);
                    }
                }
            }
        }
    }
}