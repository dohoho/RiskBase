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
    public partial class ucTab6 : UserControl
    {
        public ucTab6()
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
            String qs1 = "Have safe work practices been developed and implemented for employees "+
                            "and contractors to provide for the control of hazards during operation or "+
                            "maintenance, including:";
            addQS(1, qs1, false, "", dataGridView4);

            String qs1a = "a. Hot work";
            addQS(1, qs1a, true, "Score (Maximum 2)", dataGridView4);

            String qs1b = "b. Line breaking procedures";
            addQS(1, qs1b, true, "Score (Maximum 2)", dataGridView4);

            String qs1c = "c. Lockout/tagout";
            addQS(1, qs1c, true, "Score (Maximum 2)", dataGridView4);

            String qs1d = "d. Confined space entry";
            addQS(1, qs1d, true, "Score (Maximum 2)", dataGridView4);

            String qs1e = "e. Opening process equipment or piping";
            addQS(1, qs1e, true, "Score (Maximum 2)", dataGridView4);

            String qs1f = "f. Entrance into a facility by maintenance, contract, laboratory, or other support personnel";
            addQS(1, qs1f, true, "Score (Maximum 2)", dataGridView4);

            String qs1g = "g. Vehicle entry ";
            addQS(1, qs1g, true, "Score (Maximum 2)", dataGridView4);

            String qs1h = "h. Crane lifts ";
            addQS(1, qs1h, true, "Score (Maximum 2)", dataGridView4);

            String qs1i = "i. Handling of particularly hazardous materials (toxic, radioactive, etc.) ";
            addQS(1, qs1i, true, "Score (Maximum 2)", dataGridView4);

            String qs1j = "j. Inspection or maintenance of in-service equipment ";
            addQS(1, qs1j, true, "Score (Maximum 2)", dataGridView4);

            //qs2
            String qs2 = "Do all the safe work practices listed in Question 1 require a work "+
                            "authorization form or permit prior to initiating the activity ? ";
            addQS(2, qs2, true, "Score (Maximum 10)", dataGridView4);
            
            //qs3
            String qs3 = "If so, do the permit procedures include the following features?";
            addQS(3, qs3, false, "", dataGridView4);
            String qs3a = "a. Forms that adequately cover the subject area ";
            addQS(3, qs3a, true, "Score (Maximum 1)", dataGridView4);
            String qs3b = "b. Clear instructions denoting the number of copies issued and who "+
                            "receives each copy";
            addQS(3, qs3b, true, "Score (Maximum 1)", dataGridView4);
            String qs3c = "c. Authority required for issuance";
            addQS(3, qs3c, true, "Score (Maximum 1)", dataGridView4);
            String qs3d = "d. Sign-off procedure at completion of work ";
            addQS(3, qs3d, true, "Score (Maximum 1)", dataGridView4);
            String qs3e = "e. Procedure for extension or reissue after shift change ";
            addQS(3, qs3e, true, "Score (Maximum 1)", dataGridView4);

            //qs4
            String qs4 = "Is formal training provided to persons issuing each of the above permits?";
            addQS(4, qs4, true, "Score (Maximum 10)", dataGridView4);

            //qs5
            String qs5 = "Are the affected employees trained in the above permit and procedure "+
                            "requirements ? ";
            addQS(5, qs5, true, "Score (Maximum 10)", dataGridView4);

            // qs6
            String qs6 = "How often is an independent evaluation made (e.g., by Safety Department "+
                            "or similar group), with results communicated to appropriate management, "+
                            "to determine the extent of compliance with requirements for work permits "+
                            "and specialized procedures for major units within the organization ? "+
                            "(Choose one) ";
            addQS(6, qs6, false, "", dataGridView4);

            String qs6a = "Every 3 months ";
            addQS(6, qs6a, true, "Score (Maximum 7)", dataGridView4);

            String qs6b = "Every 6 months";
            addQS(6, qs6b, true, "Score (Maximum 4)", dataGridView4);

            String qs6c = "Yearly";
            addQS(6, qs6c, true, "Score (Maximum 2)", dataGridView4);

            String qs6d = "Not done";
            addQS(6, qs6d, true, "Score (Maximum 0)", dataGridView4);

            //qs7
            String qs7 = "Is a procedure in place that requires that all work permit procedures and "+
                            "work rules be formally reviewed at least every three years and updated as "+
                            "required ? ";
            addQS(7, qs7, true, "Score (Maximum 10)", dataGridView4);

            String qs7a = "Do records indicate that these reviews are being conducted on a timely basis ? ";
            addQS(7, qs7a, true, "Score (Maximum 5)", dataGridView4);

            //qs8
            String qs8 = "Have surveys been conducted to determine whether working "+
                            "environments are consistent with ergonomic standards?";
            addQS(8, qs8, true, "Score (Maximum 4)", dataGridView4);

            String qs8a = "Either no deficiencies were found in the above survey, or if they were, are "+
                            "they being corrected ? ";
            addQS(8, qs8a, true, "Score (Maximum 4)", dataGridView4);

        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                dataGridView4.CurrentCell = dataGridView4[2, e.RowIndex];
                dataGridView4.BeginEdit(true);
            }
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
