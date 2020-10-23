using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratory1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DGV.RowCount = 10;
            DGV.ColumnCount = 10;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn col in DGV.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
            DGV.Columns[0].HeaderText = "A";
        }

        private void AddColumn_Click(object sender, EventArgs e)
        {
            DGV.ColumnCount += 1;
            DGV.Columns[DGV.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

        }

        private void RemoveColumn_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGV.ColumnCount > 0)
                {
                    DGV.ColumnCount -= 1;
                }
                else
                {
                    throw new Exception("Немає стовпчиків для видалення.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddRow_Click(object sender, EventArgs e)
        {
            if(DGV.RowCount == 0)
            {
                DGV.RowCount += 1;
                DGV.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
            else
            {
                DGV.RowCount += 1;
            }
        }

        private void RemoveRow_Click(object sender, EventArgs e)
        {
            //DGV.Rows.RemoveAt(DGV.RowCount - 1);
            try
            {
                if (DGV.RowCount > 0)
                {
                    DGV.RowCount -= 1;
                    if(DGV.RowCount == 0)
                    {
                        DGV.ColumnCount = 0;
                    }
                }
                else
                {
                    throw new Exception("Немає рядків для видалення.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Apply_Click(object sender, EventArgs e)
        {

        }
    }
}
