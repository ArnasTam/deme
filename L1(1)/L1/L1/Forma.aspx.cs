using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace L1
{
    public partial class Forma
    {
        public TaskUtils TaskUtils
        {
            get => default(TaskUtils);
            set
            {
            }
        }

        public Container Container
        {
            get => default(Container);
            set
            {
            }
        }

        public InOut InOut
        {
            get => default(InOut);
            set
            {
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Button3.Enabled = false;
            Button5.Enabled = false;
            Button4.Enabled = false;
            Label6.Visible = false;

            Table1.Visible = false;
            Table2.Visible = false;
        }

        // Button for generating an empty table
        protected void Button1_Click(object sender, EventArgs e)
        {
            // Takes the starting Info
            Container container = new Container(Convert.ToInt16(TextBox1.Text),
                Convert.ToInt16(TextBox2.Text));

            // Prints the starting "Empty" table to the Web
            TaskUtils obj = new TaskUtils();
            obj.ContainerToTable(container, Table1);

            Session["Container"] = container;
            Button3.Enabled = true;
            Button5.Enabled = false;
            Label6.Visible = false;

            Table1.Visible = true;
        }

        // Button for generating random points
        protected void Button3_Click(object sender, EventArgs e)
        {
            Table1.Rows.Clear();

            Container container = (Container)Session["Container"];

            TaskUtils obj = new TaskUtils();
            // Generates random painted points
            obj.GenerateRandomDots(container);
            // Prints the  table to the Web
            obj.ContainerToTable(container, Table1);

            Button3.Enabled = false;
            Button5.Enabled = true;
            Button4.Enabled = true;

            Table1.Visible = true;
        }

        // Button for calculating the number of spots and the biggest spot
        protected void Button4_Click(object sender, EventArgs e)
        {
            Container container = (Container)Session["Container"];
            TaskUtils obj = new TaskUtils();

            int spotCount = 0;
            int spotBiggest = 0;
            int spotRow = 0;
            int spotColumn = 0;

            // Calculates ant prints the results to the Web
            obj.CalculateResult(container, ref spotCount,
                ref spotBiggest, ref spotRow, ref spotColumn);
            obj.ResultTable(spotCount, spotBiggest, spotRow, spotColumn, Table2);
            obj.ContainerToTable(container, Table1);

            Label6.Visible = true;
            Table2.Visible = true;

            Table1.Visible = true;

            // Exports the information to the files
            InOut.ExportStartingData(container);
            InOut.ExportResult(spotCount, spotBiggest, spotRow, spotColumn);
        }

        // Button for erasing painted points
        protected void Button5_Click(object sender, EventArgs e)
        {
            Table1.Rows.Clear();

            Container container = (Container)Session["Container"];
            container.SetAllBlank();
            container.SetAllFalse();

            TaskUtils obj = new TaskUtils();
            obj.ContainerToTable(container, Table1);

            Button3.Enabled = true;
            Button5.Enabled = false;

            Table1.Visible = true;
        }
    }
}