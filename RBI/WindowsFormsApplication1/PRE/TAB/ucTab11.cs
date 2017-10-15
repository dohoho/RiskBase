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
    public partial class ucTab11 : UserControl
    {
        public ucTab11()
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
            String qs1 = "Is there a written incident/accident investigation procedure that includes both accidents and near misses ? ";
            addQS(1, qs1, true, "Score (Maximum 10)", dataGridView4);

            String qs1a = "Does the procedure require that findings and recommendations of investigations be addressed and resolved promptly?";
            addQS(1, qs1a, true, "Score (Maximum 5)", dataGridView4);
            
            //qs2
            String qs2 = "Does the procedure require that the investigation team include:";
            addQS(2, qs2, false, "", dataGridView4);

            String qs2a = "a. A member trained in accident investigation techniques?";
            addQS(2, qs2a, true, "Score (Maximum 3)", dataGridView4);

            String qs2b = "b. The line supervisor or someone equally familiar with the process?";
            addQS(2, qs2b, true, "Score (Maximum 3)", dataGridView4);

            //qs3
            String qs3 = "Indicate whether the investigation procedure requires an investigation of "+
                            "the following items by the immediate supervisor with the results recorded " +
                            "on a standard form: ";
            addQS(3, qs3, false, "", dataGridView4);
            String qs3a = "a. Fire and explosions";
            addQS(3, qs3a, true, "Score (Maximum 2)", dataGridView4);
            String qs3b = "b. Property losses at or above an established cost base";
            addQS(3, qs3b, true, "Score (Maximum 2)", dataGridView4);

            String qs3c = "c. All non-disabling injuries and occupational illnesses";
            addQS(3, qs3c, true, "Score (Maximum 2)", dataGridView4);

            String qs3d = "d. Hazardous substance discharge ";
            addQS(3, qs3d, true, "Score (Maximum 2)", dataGridView4);

            String qs3e = "e. Other accidents/incidents (near-misses)";
            addQS(3, qs3e, true, "Score (Maximum 2)", dataGridView4);


            //qs4
            String qs4 = "Is there a standard form for accident/incident investigation that includes "+
                            "the following information ? ";
            addQS(4, qs4, false, "", dataGridView4);

            String qs4a = "a. Date of incident";
            addQS(4, qs4a, true, "Score (Maximum 2)", dataGridView4);

            String qs4b = "b. Date investigation began";
            addQS(4, qs4b, true, "Score (Maximum 2)", dataGridView4);

            String qs4c = "c. Description of the incident";
            addQS(4, qs4c, true, "Score (Maximum 2)", dataGridView4);

            String qs4d = "d. Underlying causes of the incident";
            addQS(4, qs4d, true, "Score (Maximum 2)", dataGridView4);

            String qs4e = "e. Evaluation of the potential severity and probable frequency of recurrence";
            addQS(4, qs4e, true, "Score (Maximum 2)", dataGridView4);

            String qs4f = "f. Recommendations to prevent recurrence";
            addQS(4, qs4f, true, "Score (Maximum 2)", dataGridView4);

            //qs5

            String qs5a = "Based on a review of plant records, to what degree does it appear that the "+
                            "established incident investigation procedures are being followed ? ";
            addQS(5, qs5a, true, "Score (Maximum 5)", dataGridView4);


            // qs6
            String qs6 = "If the incident/accident involved a failure of a component or piece of " +
                            "equipment, are appropriate inspection or engineering people required to "+
                            "be involved in a failure analysis to identify the conditions or practices that "+
                            "caused the failure ? ";
            addQS(6, qs6, true, "Score (Maximum 10)", dataGridView4);

            //qs7

            String qs7a = "Are incident investigation reports reviewed with all affected personnel "+
                            "whose job tasks are relevant to the incident findings, including contract "+
                            "employees, where applicable?";
            addQS(7, qs7a, true, "Score (Maximum 5)", dataGridView4);

            //qs8
            String qs8 = "During the last 12-month period, have any incident or accident reports or "+
                            "report conclusions been transmitted to other sites that operate similar "+
                            "facilities within the company?";
            addQS(8, qs8, true, "Score (Maximum 6)", dataGridView4);

      
            //qs9
            String qs9 = "Do the procedures for incident reporting and/or process hazard analysis "+
                            "require that the findings from all applicable incident reports be reviewed "+
                            "and incorporated into future PHAs?";
            addQS(9, qs9, true, "Score (Maximum 6)", dataGridView4);
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
