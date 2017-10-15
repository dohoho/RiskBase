using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RBI.PRE.TabPlant
{
    public partial class ucTab12 : UserControl
    {
        public ucTab12()
        {
            InitializeComponent();
            loadTab4();
        }
        private void addQS(int num, String qs, bool enableEdit, String numScore, DataGridView grid)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(grid);
            row.Cells[0].Value = num;
            row.Cells[0].ReadOnly = true;
            row.Cells[1].Value = qs;
            row.Cells[1].ReadOnly = true;
            if (enableEdit)
            {
                row.Cells[2].Value = numScore;
                row.Cells[2].Style.ForeColor = Color.Black;//Color.Gainsboro;
                row.Cells[2].ReadOnly = false;
            }
            else
            {
                row.Cells[2].ReadOnly = true;
            }
            grid.Rows.Add(row);
        }
        bool IsTheSameCellValue(int column, int row, DataGridView dtg)
        {
            DataGridViewCell cell1 = dtg[column, row];
            DataGridViewCell cell2 = dtg[column, row - 1];
            if (cell1.Value == null || cell2.Value == null)
            {
                return false;
            }
            else
            {
                int a, b;
                bool c = int.TryParse(cell1.Value.ToString(), out a);
                bool d = int.TryParse(cell2.Value.ToString(), out b);
                if (c && d)
                {
                    return cell1.Value.ToString() == cell2.Value.ToString();
                }
                else
                    return false;
            }

        }
        private void loadTab4()
        {
            dataGridView4.AutoGenerateColumns = false;
            dataGridView4.Columns[0].ReadOnly = true;
            dataGridView4.Columns[1].ReadOnly = true;
            //qs1
            String qs1 = "Do contractor selection procedures include the following prior to awarding the contract?";
            addQS(1, qs1, false, "", dataGridView4);

            String qs1a = "a. A review of the contractor’s existing safety and health programs";
            addQS(1, qs1a, true, "Score (Maximum 3)", dataGridView4);

            String qs1b = "b. A review of the contractor’s previous loss experience data";
            addQS(1, qs1b, true, "Score (Maximum 3)", dataGridView4);

            String qs1c = "c. A review of the documentation of the experience and skills necessary "+
                            "to reasonably expect the contractor to perform the work safely and "+
                            "efficiently";
            addQS(1, qs1c, true, "Score (Maximum 3)", dataGridView4);

            //qs2
            String qs2 = "Before the start of work, is the contract employer advised in writing of: ";
            addQS(2, qs2, false, "", dataGridView4);

            String qs2a = "a. All known potential hazards of the process and of the contractor's work ? ";
            addQS(2, qs2a, true, "Score (Maximum 2)", dataGridView4);

            String qs2b = "b. Plant safe-work practices?";
            addQS(2, qs2b, true, "Score (Maximum 2)", dataGridView4);

            String qs2c = "c. Entry/access controls? ";
            addQS(2, qs2c, true, "Score (Maximum 2)", dataGridView4);

            String qs2d = "d. All applicable provisions of the emergency response plan?";
            addQS(2, qs2d, true, "Score (Maximum 2)", dataGridView4);

            //qs3
            String qs3 = "Are pre-job meetings held with contractors to review the scope of contract "+
                            "work activity plus the company's requirements for safety, quality "+
                            "assurance, and performance?";
            addQS(3, qs3, true, "Score (Maximum 9)", dataGridView4);
            

            //qs4
            String qs4 = "Are periodic assessments performed to ensure that the contract employer "+
                            "is providing to his or her employees the training, instruction, monitoring, "+
                            "etc., required to ensure the contract employees abide by all facility safework practices?";
            addQS(4, qs4, true, "Score (Maximum 9)", dataGridView4);


            //qs5

            String qs5a = "Are all contractors who perform maintenance or repair, turnaround, major "+
                            "renovation or specialty work covered by all the procedures addressed in "+
                            "this section ? ";
            addQS(5, qs5a, true, "Score (Maximum 10)", dataGridView4);

        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridView4.CurrentCell = dataGridView4[2, e.RowIndex];
                dataGridView4.BeginEdit(true);
            }
        }

        private void dataGridView4_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            if (e.RowIndex == 0)
            {
                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.Single;
            }
            if (e.RowIndex < 1 || e.ColumnIndex < 0)
                return;
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex, dataGridView4))
            {
                if (e.ColumnIndex == 0)
                {
                    e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
                }
                else
                {
                    e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.Single;
                }

            }
            else
            {
                e.AdvancedBorderStyle.Top = dataGridView4.AdvancedCellBorderStyle.Top;
            }
            if (e.RowIndex == dataGridView4.RowCount - 1)
            {
                e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Single;
            }
        }

        private void dataGridView4_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == 0)
                return;
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex, dataGridView4))
            {
                if (e.ColumnIndex == 0)
                {
                    e.Value = "";
                    e.FormattingApplied = true;
                }
            }
        }
    }
}
