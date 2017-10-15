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
    public partial class ucTab8 : UserControl
    {
        public ucTab8()
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
            String qs1 = "Has a written inspection plan for the process unit been developed that "+
                            "includes the following elements:";
            addQS(1, qs1, false, "", dataGridView4);

            String qs1a = "a. All equipment needing inspection has been identified? ";
            addQS(1, qs1a, true, "Score (Maximum 2)", dataGridView4);

            String qs1b = "b. The responsibilities to conduct the inspections have been assigned?";
            addQS(1, qs1b, true, "Score (Maximum 2)", dataGridView4);

            String qs1c = "c. Inspection frequencies have been established?";
            addQS(1, qs1c, true, "Score (Maximum 2)", dataGridView4);

            String qs1d = "d. The inspection methods and locations have been specified?";
            addQS(1, qs1d, true, "Score (Maximum 2)", dataGridView4);

            String qs1e = "e. Inspection reporting requirements have been defined?";
            addQS(1, qs1e, true, "Score (Maximum 2)", dataGridView4);
           
            //qs2
            String qs2 = "Does the inspection plan referred to in Question 1 include a formal, "+
                            "external visual inspection program for all process units ? ";
            addQS(2, qs2, true, "Score (Maximum 2)", dataGridView4);

            String qs2a = "a. Are all the following factors considered in the visual inspection "+
                            "program: the condition of the outside of equipment, insulation, "+
                            "painting / coatings, supports and attachments, and identifying "+
                            "mechanical damage, corrosion, vibration, leakage or improper "+
                            "components or repairs ? ";
            addQS(2, qs2a, true, "Score (Maximum 1)", dataGridView4);

            String qs2b = "b. Based on the inspection plan referred to in Question 1, do all pressure "+
                            "vessels in the unit receive such a visual external inspection at least "+
                            "every 5 years ? ";
            addQS(2, qs2b, true, "Score (Maximum 2)", dataGridView4);

            String qs2c = "c. Based on this inspection plan, do all on-site piping systems that "+
                            "handle volatile, flammable products, toxins, acids and caustics, and "+
                            "other similar materials receive a visual external inspection at least "+
                            "every 5 years ? ";
            addQS(2, qs2c, true, "Score (Maximum 2)", dataGridView4);

            //qs3
            String qs3a = "Based on the inspection plan, do all pressure vessels in the unit receive an "+
                            "internal or detailed inspection using appropriate nondestructive "+
                            "examination procedures at least every 10 years?";
            addQS(3, qs3a, true, "Score (Maximum 5)", dataGridView4);

            //qs4
            String qs4 = "Has each item of process equipment been reviewed by appropriate "+
                            "personnel to identify the probable causes of deterioration or failure?";
            addQS(4, qs4, true, "Score (Maximum 5)", dataGridView4);

            String qs4a = "a. Has this information been used to establish the inspection methods, "+
                            "locations, and frequencies and the preventive maintenance programs ? ";
            addQS(4, qs4a, true, "Score (Maximum 1)", dataGridView4);

            String qs4b = "b. Have defect limits been established, based on fitness for service "+
                            "considerations ? ";
            addQS(4, qs4b, true, "Score (Maximum 1)", dataGridView4);

            //qs5
            String qs5 = "Is a formal program for thickness measurements of piping as well as "+
                            "vessels being used ? ";
            addQS(5, qs5, true, "Score (Maximum 3)", dataGridView4);

            String qs5a = "a. When the locations for thickness measurements are chosen,";
            addQS(5, qs5a, false, "", dataGridView4);

            String qs5a1 = "1. Is the likelihood and consequence of failure a major factor?";
            addQS(5, qs5a1, true, "Score (Maximum 1)", dataGridView4);

            String qs5a2 = "2. Is localized corrosion and erosion a consideration?";
            addQS(5, qs5a2, true, "Score (Maximum 1)", dataGridView4);

            String qs5b = "b. Are thickness measurement locations clearly marked on inspection "+
                            "drawings and on the vessel or piping system to allow repetitive "+
                            "measurements at precisely the same locations ? ";
            addQS(5, qs5b, true, "Score (Maximum 2)", dataGridView4);

            String qs5c = "c. Are thickness surveys up to date?";
            addQS(5, qs5c, true, "Score (Maximum 2)", dataGridView4);

            String qs5d = "d. Are the results used to predict remaining life and adjust future "+
                            "inspection frequency?";
            addQS(5, qs5d, true, "Score (Maximum 2)", dataGridView4);

            // qs6
            String qs6 = "Has the maximum allowable working pressure (MAWP) been established "+
                            "for all piping systems, using applicable codes and current operating "+
                            "conditions?";
            addQS(6, qs6, true, "Score (Maximum 3)", dataGridView4);

            String qs6a = "Are the MAWP calculations updated after each thickness measurement, "+
                            "using the latest wall thickness and corrosion rate ? ";
            addQS(6, qs6a, true, "Score (Maximum 2)", dataGridView4);

            //qs7

            String qs7a = "Is there a written procedure that requires an appropriate level of review "+
                            "and authorization prior to any changes in inspection frequencies or "+
                            "methods and testing procedures ? ";
            addQS(7, qs7a, true, "Score (Maximum 5)", dataGridView4);

            //qs8
            String qs8a = "Have adequate inspection checklists been developed and are they being used ? ";
            addQS(8, qs8a, true, "Score (Maximum 3)", dataGridView4);

            String qs8b = "Are they periodically reviewed and updated as equipment or processes change ? ";
            addQS(8, qs8b, true, "Score (Maximum 2)", dataGridView4);

            //qs9
            String qs9 = "Are all inspections, tests and repairs performed on the process equipment " +
                            "being promptly documented ? ";
            addQS(9, qs9, true, "Score (Maximum 3)", dataGridView4);

            String qs9a = "Does the documentation include all of the following information?:";
            addQS(9, qs9a, true, "Score (Maximum 3)", dataGridView4);

            String qs9a1 = "a. The date of the inspection";
            addQS(9, qs9a1, false, "", dataGridView4);
            String qs9a2 = "b. The name of the person who performed the inspection";
            addQS(9, qs9a2, false, "", dataGridView4);
            String qs9a3 = "c. Identification of the equipment inspected";
            addQS(9, qs9a3, false, "", dataGridView4);
            String qs9a4 = "d. A description of the inspection or testing";
            addQS(9, qs9a4, false, "", dataGridView4);
            String qs9a5 = "e. The results of the inspection";
            addQS(9, qs9a5, false, "", dataGridView4);
            String qs9a6 = "f. All recommendations resulting from the inspection";
            addQS(9, qs9a6, false, "", dataGridView4);
            String qs9a7 = "g. A date and description of all maintenance performed";
            addQS(9, qs9a7, false, "", dataGridView4);

            //qs10
            String qs10 = "Is there a written procedure requiring that all process equipment "+
                            "deficiencies identified during an inspection be corrected in a safe and "+
                            "timely manner and are they tracked and followed up to assure completion ? ";
            addQS(10, qs10, true, "Score (Maximum 5)", dataGridView4);

            String qs10a = "a. Is a system used to help determine priorities for action? ";
            addQS(10, qs10a, true, "Score (Maximum 1)", dataGridView4);

            String qs10b = "b. If defects are noted, are decisions to continue to operate the "+
                            "equipment based on sound engineering assessments of fitness for "+
                            "service ? ";
            addQS(10, qs10b, true, "Score (Maximum 2)", dataGridView4);

            //qs11
            String qs11 = "Is there a complete, up-to-date, central file for all inspection program "+
                            "information and reports ? ";
            addQS(11, qs11, true, "Score (Maximum 3)", dataGridView4);

            String qs11a = "Is this file information available to everyone who works with the process?";
            addQS(11, qs11a, true, "Score (Maximum 2)", dataGridView4);

            //qs12
            String qs12 = "Have all employees involved in maintaining and inspecting the process " +
                            "equipment been trained in an overview of the process and its hazards?";
            addQS(12, qs12, true, "Score (Maximum 5)", dataGridView4);

            //qs13
            String qs13 = "Have all employees involved in maintaining and inspecting the process " +
                            "equipment been trained in all procedures applicable to their job tasks to " +
                            "ensure that they can perform the job tasks in a safe and effective manner ? ";
            addQS(13, qs13, true, "Score (Maximum 3)", dataGridView4);
            String qs13a = "At completion of the training described above, are formal methods used to " +
                            "verify that the employee understands what he was trained on?";
            addQS(13, qs13a, true, "Score (Maximum 2)", dataGridView4);

            //qs14
            String qs14 = "Are inspectors certified for performance in accordance with applicable " +
                            "industry codes and standards (e.g., API 510, 570 and 653)?";
            addQS(14, qs14, true, "Score (Maximum 5)", dataGridView4);

            //qs15
            String qs15 = "Are training programs conducted for contractors’ employees where special "+
                            "skills or techniques unique to the unit or plant are required for these "+
                            "employees to perform the job safely ? ";
            addQS(15, qs15, true, "Score (Maximum 5)", dataGridView4);

            //qs16
            String qs16 = "Has a schedule been established for the inspection or testing of all " +
                            "pressure relief valves in the unit?";
            addQS(16, qs16, true, "Score (Maximum 3)", dataGridView4);

            String qs16a = "a. Is the schedule being met?";
            addQS(16, qs16a, true, "Score (Maximum 1)", dataGridView4);

            String qs16b = "b. Are all inspections and repairs fully documented?";
            addQS(16, qs16b, true, "Score (Maximum 1)", dataGridView4);

            String qs16c = "c. Are all repairs made by personnel fully trained and experienced in "+
                            "relief valve maintenance ? ";
            addQS(16, qs16c, true, "Score (Maximum 1)", dataGridView4);

            //qs17
            String qs17 = "Does the preventive maintenance program used at the facility meet the "+
                            "following criteria?";
            addQS(17, qs17, false, "", dataGridView4);

            String qs17a = "a. All safety-critical items and other key equipment, such as electrical "+
                            "switchgear and rotating equipment, are specifically addressed.";
            addQS(17, qs17a, true, "Score (Maximum 1)", dataGridView4);

            String qs17b = "b. Check lists and inspection sheets are being used.";
            addQS(17, qs17b, true, "Score (Maximum 1)", dataGridView4);

            String qs17c = "c. Work is being completed on time.";
            addQS(17, qs17c, true, "Score (Maximum 1)", dataGridView4);

            String qs17d = "d. The program is continuously modified based on inspection feedback.";
            addQS(17, qs17d, true, "Score (Maximum 1)", dataGridView4);

            String qs17e = "e. Repairs are identified, tracked and completed as a result of the PM program";
            addQS(17, qs17e, true, "Score (Maximum 1)", dataGridView4);

            //qs18
            String qs18 = "Does the facility have a quality assurance program for construction and " +
                            "maintenance to ensure that:";
            addQS(18, qs18, false, "", dataGridView4);

            String qs18a = "Does the facility have a quality assurance program for construction and " +
                            "maintenance to ensure that:";
            addQS(18, qs18a, true, "Score (Maximum 1)", dataGridView4);

            String qs18b = "Does the facility have a quality assurance program for construction and " +
                            "maintenance to ensure that:";
            addQS(18, qs18b, true, "Score (Maximum 1)", dataGridView4);

            String qs18c = "Does the facility have a quality assurance program for construction and " +
                            "maintenance to ensure that:";
            addQS(18, qs18c, true, "Score (Maximum 1)", dataGridView4);

            String qs18d = "Does the facility have a quality assurance program for construction and " +
                            "maintenance to ensure that:";
            addQS(18, qs18d, true, "Score (Maximum 1)", dataGridView4);

            String qs18e = "Does the facility have a quality assurance program for construction and " +
                            "maintenance to ensure that:";
            addQS(18, qs18e, true, "Score (Maximum 1)", dataGridView4);

            //qs19
            String qs19 = "Is there a permanent and progressive record for all pressure vessels that "+
                           "includes all of the following ? ";
            addQS(19, qs19, true, "Score (Maximum 5)", dataGridView4);

            String qs19a = "a. Manufacturers’ data reports and other pertinent data records";
            addQS(19, qs19a, false, "", dataGridView4);

            String qs19b = "b. Vessel identification numbers";
            addQS(19, qs19b, false, "", dataGridView4);

            String qs19c = "c. Relief valve information";
            addQS(19, qs19c, false, "", dataGridView4);

            String qs19d = "d. Results of all inspections, repairs, alterations, or re-ratings that have "+
                            "occurred to date ";
            addQS(19, qs19d, false, "", dataGridView4);

            //qs20
            String qs20 = "Are systems in place, such as written requirements, with supervisor sign " +
                            "off, sufficient to ensure that all design repair and alteration done on any " +
                            "pressure vessel or piping system be done in accordance with the code to " +
                            "which the item was built, or in-service repair and inspection code?";
            addQS(20, qs20, true, "Score (Maximum 5)", dataGridView4);
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
