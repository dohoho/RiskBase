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
    public partial class ucTab9 : UserControl
    {
        public ucTab9()
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
            String qs1 = "Does company policy require a formal Process Hazard Analysis at the "+
                            "conception and/ or design stages of all new development, construction, and " +
                            "major modification projects?";
            addQS(1, qs1, true, "Score (Maximum 10)", dataGridView4);

            //qs2
            String qs2 = "Is there a written procedure requiring that all of the following items have "+
                            "been accomplished before the startup of new or significantly modified "+
                            "facilities ? ";
            addQS(2, qs2, true, "Score (Maximum 10)", dataGridView4);

            String qs2a = "a. Written operating procedures have been issued.";
            addQS(2, qs2a, false, "", dataGridView4);
            String qs2b = "b. Training has been completed for all personnel involved in the process.";
            addQS(2, qs2b, false, "", dataGridView4);
            String qs2c = "c. Adequate maintenance, inspection, safety and emergency procedures " +
                            "are in place.";
            addQS(2, qs2c, false, "", dataGridView4);
            String qs2d = "d. Any recommendations resulting from the formal PHA have been completed.";
            addQS(2, qs2d, false, "", dataGridView4);

            //qs3
            String qs3 = "Is there a written procedure requiring that all equipment be inspected prior "+
                            "to startup to confirm that it has been installed in accordance with the "+
                            "design specifications and manufacturer’s recommendations? ";
            addQS(3, qs3, true, "Score (Maximum 10)", dataGridView4);
            String qs3a = "a. Does the procedure require formal inspection reports at each "+
                            "appropriate stage of fabrication and construction?";
            addQS(3, qs3a, true, "Score (Maximum 5)", dataGridView4);
            String qs3b = "b. Does the procedure define the corrective action and follow-up needed "+
                            "when deficiencies are found? ";
            addQS(3, qs3b, true, "Score (Maximum 5)", dataGridView4);

            //qs4
            String qs4 = "In the pre-startup safety review, is it required that physical checks be "+
                            "made to confirm: ";
            addQS(4, qs4, false, "", dataGridView4);

            String qs4a = "a. Leak tightness of all mechanical equipment prior to the introduction of "+
                            "highly hazardous chemicals to the process?";
            addQS(4, qs4a, true, "Score (Maximum 5)", dataGridView4);

            String qs4b = "b. Proper operation of all control equipment prior to startup?";
            addQS(4, qs4b, true, "Score (Maximum 5)", dataGridView4);

            String qs4c = "c. Proper installation and operation of all safety equipment (relief valves, "+
                            "interlocks, leak detection equipment, etc.)?";
            addQS(4, qs4c, true, "Score (Maximum 5)", dataGridView4);

            //qs5
            String qs5 = "Is there a requirement to formally document the completion of the items in "+
                            "Questions 1, 2, 3, and 4 prior to startup, with a copy of the certification "+
                            "going to facility management?";
            addQS(5, qs5, true, "Score (Maximum 5)", dataGridView4);
           
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridView4.CurrentCell = dataGridView4[2, e.RowIndex];
                dataGridView4.BeginEdit(true);
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
    }
}
