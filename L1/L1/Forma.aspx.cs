using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace L1
{
    public partial class Forma : System.Web.UI.Page
    {
        Container container;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            container = new Container(Convert.ToInt32(TextBox1.Text),
                Convert.ToInt32(TextBox2.Text));

            ContainerToTable(container);
        }

        private void ContainerToTable(Container container)
        {
            Table1.Rows.Clear();

            TableCell cell = new TableCell();
            TableRow row = new TableRow();
            for(int i = -1; i < container.ColumnCount(); i++)
            {
                row.Cells.Clear();

                for (int j = -1; j < container.RowCount(); j++)
                {
                    if(i == -1 && j == -1)
                    {
                        cell.Text = "";
                        row.Cells.Add(cell);
                    }

                    if (i == -1 && j != -1)
                    {
                        cell.Text = Convert.ToString(j + 1);
                        row.Cells.Add(cell);
                    }

                    if(i != -1 && j == -1)
                    {
                        cell.Text = Convert.ToString(i + 1);
                        row.Cells.Add(cell);
                    }

                    if(i != -1 && j != -1)
                    {
                        cell.Text = Convert.ToString(container.Get_Point(i,j));
                        row.Cells.Add(cell);
                    }
                }

                Table1.Rows.Add(row);
            }
        }
    }
}