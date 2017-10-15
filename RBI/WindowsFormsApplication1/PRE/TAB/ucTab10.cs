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
    public partial class ucTab10 : UserControl
    {
        public ucTab10()
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
            String qs1 = "Does the facility have an emergency plan in writing to address all probable "+
                            "emergencies ? ";
            addQS(1, qs1, true, "Score (Maximum 10)", dataGridView4);

            //qs2
            String qs2 = "Is there a requirement to formally review and update the emergency plan "+
                            "on a specified schedule?";
            addQS(2, qs2, true, "Score (Maximum 5)", dataGridView4);
            String qs2a = "a. Does the facility's Management of Change procedure include a " +
                            "requirement to consider possible impact on the facility emergency " +
                            "plan?";
            addQS(2, qs2a, true, "Score (Maximum 2)", dataGridView4);
            String qs2b = "b. Are the results of all new or updated PHA’s reviewed to determine " +
                            "whether any newly identified hazards will necessitate a change in the " +
                            "facility emergency plan?";
            addQS(2, qs2b, true, "Score (Maximum 2)", dataGridView4);

            //qs3
            String qs3 = "Does the emergency plan include at least the following?";
            addQS(3, qs3, false, "", dataGridView4);
            String qs3a = "a. Procedures to designate one individual as Coordinator in an "+
                            "emergency situation, with a clear statement of his or her "+
                            "responsibilities.";
            addQS(3, qs3a, true, "Score (Maximum 2)", dataGridView4);
            String qs3b = "b. Emergency escape procedures and emergency escape route assignments.";
            addQS(3, qs3b, true, "Score (Maximum 2)", dataGridView4);

            String qs3c = "c. Procedures to be followed by employees who remain to perform "+
                            "critical plant operations before they evacuate. ";
            addQS(3, qs3c, true, "Score (Maximum 2)", dataGridView4);

            String qs3d = "d. Procedures to account for all employees after emergency evacuation "+
                            "has been completed.";
            addQS(3, qs3d, true, "Score (Maximum 2)", dataGridView4);

            String qs3e = "e. Rescue and medical duties for those employees who are to perform them.";
            addQS(3, qs3e, true, "Score (Maximum 2)", dataGridView4);

            String qs3f = "f. Preferred means of reporting fires and other emergencies. ";
            addQS(3, qs3f, true, "Score (Maximum 2)", dataGridView4);

            String qs3g = "g. Procedures for control of hazardous materials.";
            addQS(3, qs3g, true, "Score (Maximum 2)", dataGridView4);

            String qs3h = "h. A search and rescue plan.  ";
            addQS(3, qs3h, true, "Score (Maximum 2)", dataGridView4);

            String qs3i = "i. An all-clear and re-entry procedure.";
            addQS(3, qs3i, true, "Score (Maximum 2)", dataGridView4);

            //qs4
            String qs4 = "Has an emergency control center been designated for the facility? ";
            addQS(4, qs4, true, "Score (Maximum 5)", dataGridView4);

            String qs4a = "Does it have the following minimum resources?";
            addQS(4, qs4a, false, "", dataGridView4);

            String qs4b = "a. Emergency power source ";
            addQS(4, qs4b, true, "Score (Maximum 2)", dataGridView4);

            String qs4c = "b. Adequate communication facilities";
            addQS(4, qs4c, true, "Score (Maximum 2)", dataGridView4);

            String qs4d = "c. Copies of P&IDs, SOPs, MSDS, Plot Plans, and other critical safety "+
                            "information for all process units at the facility";
            addQS(4, qs4d, true, "Score (Maximum 2)", dataGridView4);

            //qs5
            String qs5 = "Have persons been designated who can be contacted for further "+
                            "information or explanation of duties under the emergency plan ? ";
            addQS(5, qs5, true, "Score (Maximum 5)", dataGridView4);

            String qs5a = "Is this list of names posted in all appropriate locations (control rooms, "+
                            "security office, emergency control center, etc.)? ";
            addQS(5, qs5a, true, "Score (Maximum 2)", dataGridView4);


            // qs6

            String qs6a = "Are regular drills conducted to evaluate and reinforce the emergency plan?";
            addQS(6, qs6a, true, "Score (Maximum 10)", dataGridView4);

            
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
