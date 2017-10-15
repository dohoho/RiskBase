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
    public partial class ucTab7 : UserControl
    {
        public ucTab7()
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
            String qs1 = "Is there a written procedure that defines the general training in site-wide " +
                            "safety procedures, work practices, etc., that a newly hired employee will " +
                            "receive ? ";
            addQS(1, qs1, true, "Score (Maximum 10)", dataGridView4);

            //qs2
            String qs2 = "Is there a written procedure that defines the amount and content of sitespecific training, in addition to the general training provided in Question 1, "+
                            "that an employee newly assigned to an operations position will receive "+
                            "prior to assuming his duties? ";
            addQS(2, qs2, true, "Score (Maximum 10)", dataGridView4);

            //qs3
            String qs3 = "Does the procedure described in Question 2 require that the training "+
                            "include the following ? ";
            addQS(3, qs3, false, "", dataGridView4);
            String qs3a = "a. An overview of the process and its specific safety and health hazards";
            addQS(3, qs3a, true, "Score (Maximum 3)", dataGridView4);
            String qs3b = "b. Training in all operating procedures";
            addQS(3, qs3b, true, "Score (Maximum 4)", dataGridView4);

            String qs3c = "c. Training on site-emergency procedures";
            addQS(3, qs3c, true, "Score (Maximum 3)", dataGridView4);

            String qs3d = "d. Emphasis on safety-related issues such as work permits, importance "+
                            "of interlocks and other safety systems, etc.";
            addQS(3, qs3d, true, "Score (Maximum 3)", dataGridView4);

            String qs3e = "e. Safe work practices";
            addQS(3, qs3e, true, "Score (Maximum 3)", dataGridView4);

            String qs3f = "f. Appropriate basic skills";
            addQS(3, qs3f, true, "Score (Maximum 3)", dataGridView4);

            //qs4
            String qs4 = "At the completion of formal training of operations personnel, what method "+
                            "is used to verify that the employee understands the information "+
                            "presented ? (Choose one)";
            addQS(4, qs4, false, "", dataGridView4);

            String qs4a = "Performance test followed by documented observation";
            addQS(4, qs4a, true, "Score (Maximum 10)", dataGridView4);

            String qs4b = "Performance test only ";
            addQS(4, qs4b, true, "Score (Maximum 7)", dataGridView4);

            String qs4c = "Opinion of instructor";
            addQS(4, qs4c, true, "Score (Maximum 3)", dataGridView4);

            String qs4d = "No verification";
            addQS(4, qs4d, true, "Score (Maximum 0)", dataGridView4);

            //qs5
            String qs5 = "How often are operations employees given formal refresher training? "+
                            "(Choose one)";
            addQS(5, qs5, false, "", dataGridView4);

            String qs5a = "At least once every three years";
            addQS(5, qs5a, true, "Score (Maximum 10)", dataGridView4);

            String qs5b = "Only when major process changes occur";
            addQS(5, qs5b, true, "Score (Maximum 5)", dataGridView4);

            String qs5c = "Never";
            addQS(5, qs5c, true, "Score (Maximum 0)", dataGridView4);

            // qs6
            String qs6 = "What is the average amount of training given to each operations employee "+
                            "per year, averaged over all grades ? (Choose one)";
            addQS(6, qs6, false, "", dataGridView4);

            String qs6a = "15 days/year or more";
            addQS(6, qs6a, true, "Score (Maximum 10)", dataGridView4);

            String qs6b = "11 to 14 days/year";
            addQS(6, qs6b, true, "Score (Maximum 7)", dataGridView4);

            String qs6c = "7 to 10 days/year";
            addQS(6, qs6c, true, "Score (Maximum 5)", dataGridView4);

            String qs6d = "3 to 6 days/year";
            addQS(6, qs6d, true, "Score (Maximum 3)", dataGridView4);

            String qs6e = "Less than 3 days/year";
            addQS(6, qs6e, true, "Score (Maximum 0)", dataGridView4);

            //qs7

            String qs7a = "Has a systematic approach (e.g., employee surveys, task analysis, etc.) "+
                            "been used to identify the training needs of all employees at the facility, "+
                            "including the training programs referred to in Questions 1 and 2 ? ";
            addQS(7, qs7a, true, "Score (Maximum 4)", dataGridView4);

            String qs7b = "a. Have training programs been established for the identified needs?";
            addQS(7, qs7b, true, "Score (Maximum 4)", dataGridView4);

            String qs7c = "b. Are training needs reviewed and updated periodically?";
            addQS(7, qs7c, true, "Score (Maximum 4)", dataGridView4);

            //qs8
            String qs8a = "Are the following features incorporated in the plant's formal training "+
                            "programs ? ";
            addQS(8, qs8a, false, "", dataGridView4);

            String qs8b = "a. Qualifications for trainers have been established and are documented "+
                            "for each trainer.";
            addQS(8, qs8b, true, "Score (Maximum 5)", dataGridView4);

            String qs8c = "b. Written lesson plans are used that have been reviewed and approved "+
                            "to ensure complete coverage of the topic.";
            addQS(8, qs8c, true, "Score (Maximum 5)", dataGridView4);

            String qs8d = "c. Training aids and simulators are used where appropriate to permit "+
                            "\"hands - on\" training.";
            addQS(8, qs8d, true, "Score (Maximum 5)", dataGridView4);

            String qs8e = "d. Records are maintained for each trainee showing the date of training "+
                            "and means used to verify that training was understood.";
            addQS(8, qs8e, true, "Score (Maximum 5)", dataGridView4);
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
