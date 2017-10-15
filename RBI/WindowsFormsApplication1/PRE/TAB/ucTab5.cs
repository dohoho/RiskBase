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
    public partial class ucTab5 : UserControl
    {
        public ucTab5()
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
            // addQS(6, qs6b, true, "Score (Maximum 5)",dataGridView1);
            //qs1
            String qs1 = "Are written operating procedures available to operations and maintenance "+
                            "personnel in all units?";
            addQS(1, qs1, true, "Score (Maximum 10)", dataGridView4);
            String qs1a = "Do the operating procedures clearly define the position of the person or "+
                           "persons responsible for operation of each applicable area ? ";
            addQS(1, qs1a, true, "Score (Maximum 5)", dataGridView4);

            //qs2
            String qs2 = "Are the following operating considerations covered in all Standard "+
                            "Operating Procedures (SOPs) ? ";
            addQS(2, qs2, false, "", dataGridView4);
            String qs2a = "a. Initial startup";
            addQS(2, qs2a, true, "Score (Maximum 2)", dataGridView4);
            String qs2b = "b. Normal (as well as emergency) operation";
            addQS(2, qs2b, true, "Score (Maximum 2)", dataGridView4);
            String qs2c = "c. Normal shutdown";
            addQS(2, qs2c, true, "Score (Maximum 2)", dataGridView4);
            String qs2d = "d. Emergency shutdown";
            addQS(2, qs2d, true, "Score (Maximum 2)", dataGridView4);
            String qs2e = "e. Is the position of the person or persons who may initiate these procedures defined?";
            addQS(2, qs2e, true, "Score (Maximum 2)", dataGridView4);
            String qs2f = "f. Steps required to correct or avoid deviation from operating limits and "+
                           "consequences of the deviation";
            addQS(2, qs2f, true, "Score (Maximum 2)", dataGridView4);

            String qs2g = "g. Startup following a turnaround";
            addQS(2, qs2g, true, "Score (Maximum 2)", dataGridView4);

            String qs2h = "h. Safety systems and their functions";
            addQS(2, qs2h, true, "Score (Maximum 2)", dataGridView4);

            //qs3
            String qs3 = "Are the following safety and health considerations covered in all SOPs for "+
                            "the chemicals used in the process?";
            addQS(3, qs3, false, "", dataGridView4);
            String qs3a = "a. Properties of, and hazards presented by, the chemicals";
            addQS(3, qs3a, true, "Score (Maximum 3)", dataGridView4);
            String qs3b = "b. Precautions necessary to prevent exposure, including controls and "+
                            "personal protective equipment";
            addQS(3, qs3b, true, "Score (Maximum 4)", dataGridView4);

            String qs3c = "c. Control measures to be taken if physical contact occurs";
            addQS(3, qs3c, true, "Score (Maximum 3)", dataGridView4);

            //qs4
            String qs4 = "Are the SOPs in the facility written in a clear and concise style to ensure " +
                            "effective comprehension and promote compliance of the users?";
            addQS(4, qs4, true, "Score (Maximum 10)", dataGridView4);

            //qs5
            String qs5 = "Are there adequate procedures for handover/transfer of information " +
                            "between shifts? ";
            addQS(5, qs5, true, "Score (Maximum 10)", dataGridView4);

            // qs6
            String qs6 = "How frequently are operating procedures formally reviewed to ensure they " +
                            "reflect current operating practices and updated as required ? (Choose one)";
            addQS(6, qs6, false, "", dataGridView4);

            String qs6a = "At least annually, or as changes occur";
            addQS(6, qs6a, true, "Score (Maximum 11)", dataGridView4);

            String qs6b = "Each two years";
            addQS(6, qs6b, true, "Score (Maximum 6)", dataGridView4);

            String qs6c = "Only when major process changes occur";
            addQS(6, qs6c, true, "Score (Maximum 3)", dataGridView4);

            String qs6d = "No schedule has been established";
            addQS(6, qs6d, true, "Score (Maximum 0)", dataGridView4);

            //qs7
            String qs7 = "How often is an unbiased evaluation made of the level of compliance with "+
                            "written operating procedures ? (Choose one)";
            addQS(7, qs7, false, "", dataGridView4);

            String qs7a = "Every 6 months ";
            addQS(7, qs7a, true, "Score (Maximum 8)", dataGridView4);

            String qs7b = "Yearly";
            addQS(7, qs7b, true, "Score (Maximum 4)", dataGridView4);

            String qs7c = "Each 3 years";
            addQS(7, qs7c, true, "Score (Maximum 2)", dataGridView4);

            String qs7d = "Not Done";
            addQS(7, qs7d, true, "Score (Maximum 0)", dataGridView4);
        }

        private void dataGridView4_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridView4.CurrentCell = dataGridView4[2, e.RowIndex];
                dataGridView4.BeginEdit(true);
            }
        }

        private void dataGridView4_CellPainting_1(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void dataGridView4_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
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
