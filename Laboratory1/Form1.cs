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
        private Calculator calculator;
        public Form1()
        {
            InitializeComponent();
            /*
            DGV.RowCount = 10;
            DGV.ColumnCount = 10;
            */

            DataGridViewColumn colToInsert;
            int columnCount = 10;
            calculator = new Calculator(DGV);
            for (int i = 0; i < columnCount; i++)
            {
                colToInsert = new DataGridViewColumn(new ExpressionCell());
                DGV.Columns.Insert(0, colToInsert);
            }

            DGV.RowCount = 10;
            foreach (DataGridViewColumn col in DGV.Columns)
            {
                col.HeaderText = NameGenerator.ConvertToBase26(col.Index);
                //col.CellTemplate = new ExpressionCell();
            }
            foreach (DataGridViewRow row in DGV.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn col in DGV.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
        }

        private void AddColumn_Click(object sender, EventArgs e)
        {
            DataGridViewColumn column =  new DataGridViewColumn(new ExpressionCell());
            DGV.Columns.Insert(DGV.ColumnCount, column);
            DGV.Columns[DGV.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            DGV.Columns[DGV.ColumnCount - 1].HeaderText = NameGenerator.ConvertToBase26(DGV.Columns[DGV.ColumnCount - 1].Index);
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
            DGV.RowCount += 1;
            if (DGV.RowCount == 1)
            {
                DGV.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
            DGV.Rows[DGV.RowCount - 1].HeaderCell.Value = (DGV.Rows[DGV.RowCount - 1].Index + 1).ToString();
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
            foreach (ExpressionCell cell in DGV.SelectedCells)
            {
                cell.Expression = ExpressionTextBox.Text;
                cell.CleanEdges();
            }
            foreach (ExpressionCell cell in DGV.SelectedCells)
            {
                calculator.NameCurentCell = cell;
                cell.Value = calculator.Evaluate(cell.Expression);
            }

        }

        private void GetExpressionFromCell(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DGV.SelectedCells.Count > 1)
                {
                    throw new Exception("Виділено більше ніж 1 клітину");
                }
                ExpressionTextBox.Text = ((ExpressionCell)DGV.Rows[e.RowIndex].Cells[e.ColumnIndex]).Expression;
             }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            GetExpressionFromCell(sender, e);
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GetExpressionFromCell(sender, e);
        }
    }
}
