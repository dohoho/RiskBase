using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RBI.PRE.TabPlant
{
    public partial class RBIQuestion : Form
    {
        public RBIQuestion()
        {
            InitializeComponent();
            loadTab1();
            loadTab2();
            loadTab3();
            loadTab4();
            loadOther();
        }
        /// <summary>
        /// setup tab1;
        /// </summary>
        public void loadTab1()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            //question 1
            String question1 = "Does the organization at the corporate or local level have a general policy" +
                                   " statement reflecting management’s commitment to Process Safety" +
                                    " Management, and emphasizing safety and loss control issues?";
            addQS(1, question1, true, "Score (Maximum 10)",dataGridView1);

            // quesion 2
            String title = "Is the general policy statement:";
            addQS(2, title, false, "",dataGridView1);
            String suba = "a. Contained in manuals?";
            addQS(2, suba, true, "Score (Maximum 2)",dataGridView1);            
            String subb = "b. Posted in various locations?";
            addQS(2, subb, true, "Score (Maximum 2)",dataGridView1);          
            String subc = "c. Included as a part of all rule booklets?";
            addQS(2, subc, true, "Score (Maximum 2)",dataGridView1);
            String subd = "d. Referred to in all major training programs?";
            addQS(2, subd, true, "Score (Maximum 2)",dataGridView1);
            String sube = "e. Used in other ways? (Describe)";
            addQS(2, sube, true, "Score (Maximum 2)",dataGridView1);

            // question 3
            String question2 = "Are responsibilities for process safety and health issues clearly defined in"
                                + " every manager’s job description ?";
            addQS(3, question2, true, "Score (Maximum 10)",dataGridView1);

            //question 4
            String qs4 = "Are annual objectives in the area of process safety and health issues " +
                        "established for all management personnel, and are they then included as " +
                        "an important consideration in their regular annual appraisals ? ";
            addQS(4, qs4, true, "Score (Maximum 15)",dataGridView1);

            // question 5
            String qs5 = "What percentage of the total management team has participated in a " +
                        "formal training course or outside conference or seminar on Process " +
                        "Safety Management over the last three years ? ";
            addQS(5, qs5, true, "Percent (%)",dataGridView1);

            //question 6
            String qs6 = "Is there a site Safety Committee, or equivalent? ";
            addQS(6, qs6, true, "Score (Maximum 5)",dataGridView1);
            String qs6a = "a. Does the committee make-up represent a diagonal slice of the organization ? ";
            addQS(6, qs6a, true, "Score (Maximum 5)",dataGridView1);
            String qs6b = "b. Does the committee meet regularly and document that appropriate recommendations are implemented ? ";
            addQS(6, qs6b, true, "Score (Maximum 5)",dataGridView1);
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

        //bool IsTheSameCellValue(int column, int row)

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        { 
          /* try
            {
                String data = dataGridView1[2, e.RowIndex].Value.ToString();
                double f;
                bool check = double.TryParse(data, out f);
                if (!check)
                {
                    dataGridView1[2, e.RowIndex].Value = "";
                    dataGridView1[2, e.RowIndex].Style.ForeColor = Color.Black;
                }
            }
            catch(Exception ex)
            {

            }  */
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridView1.CurrentCell = dataGridView1[2, e.RowIndex];
                dataGridView1.BeginEdit(true);
            }
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
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            if(e.RowIndex == 0)
            {
                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.Single;
            }
            if (e.RowIndex < 1 || e.ColumnIndex < 0)
                return;
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex, dataGridView1))
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
                e.AdvancedBorderStyle.Top = dataGridView1.AdvancedCellBorderStyle.Top;
            }
            if(e.RowIndex == dataGridView1.RowCount -1)
            {
                e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Single;
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == 0)
                return;
            // if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            if(IsTheSameCellValue(e.ColumnIndex, e.RowIndex, dataGridView1))
            {
                if (e.ColumnIndex == 0)
                {
                    e.Value = "";
                    e.FormattingApplied = true;
                }
            }
            
        }

        ///<summary>
        ///setup tab2
        ///</summary>
        private void loadTab2()
        {
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.Columns[0].ReadOnly = true;
            dataGridView2.Columns[1].ReadOnly = true;
            // addQS(6, qs6b, true, "Score (Maximum 5)",dataGridView1);
            //question 1
            String qs1 = "Are Material Safety Data Sheets (MSDS) available for all chemical substances used or handled in each unit?";
            addQS(1, qs1, true, "Score (Maximum 5)", dataGridView2);
            String qs1a = "a. Is the maximum on-site inventory of each of these chemicals listed?";
            addQS(1, qs1a, true, "Score (Maximum 2)", dataGridView2);
            String qs1b = "b. Is this information available to operations and maintenance personnel and any appropriate contract personnel in the unit?";
            addQS(1, qs1b, true, "Score (Maximun 2)", dataGridView2);
            String qs1c = "c. Are the hazardous effects, if any, of inadvertent mixing of the various " +
                            "materials on site clearly stated in the Standard Operating Procedures " +
                            "and emphasized in operator training programs?";
            addQS(1, qs1c, true, "Score (Maximum 2)", dataGridView2);

            //question 2
            String qs2 = "Are quality control procedures in place and practiced to ensure that all " +
                           "identified materials meet specifications when received and used?";
            addQS(2, qs2, true, "Score (Maximum 10)", dataGridView2);

            //question 3
            String qs3 = "Is up-to-date written information readily available in the unit that:";
            addQS(3, qs3, false, "", dataGridView2);
            String qs3a = "a. Summarizes the process chemistry?";
            addQS(3, qs3a, true, "Score (Maximum 3)", dataGridView2);
            String qs3b = "b. Lists the safe upper and lower limits for such items as temperatures, " +
                            "pressures, flows and compositions ? ";
            addQS(3, qs3b, true, "Score (Maximum 3)", dataGridView2);
            String qs3c = "c. States the safety-related consequences of deviations from these " +
                            "limits ? ";
            addQS(3, qs3c, true, "Score (Maximum 3)", dataGridView2);

            //question 4
            String qs4 = "Is a block flow diagram or simplified process flow diagram available to aid " +
                           "in the operator’s understanding of the process ? ";
            addQS(4, qs4, true, "Score (Maximum 5)", dataGridView2);

            //question 5
            String qs5 = "Are P&IDs available for all units at the site?";
            addQS(5, qs5, true, "Score (Maximum 10)", dataGridView2);

            //question 6
            String qs6 = "Does documentation show all equipment in the unit is designed and " +
                         "constructed in compliance with all applicable codes, standards, and " +
                         "generally accepted good engineering practices?";
            addQS(6, qs6, true, "Score (Maximum 8)", dataGridView2);

            //question 7
            String qs7 = "Has all existing equipment been identified that was designed and " +
                            "constructed in accordance with codes, standards, or practices that are no " +
                            "longer in general use?";
            addQS(7, qs7, true, "Score (Maximum 4)", dataGridView2);
            String qs7a = "Has it been documented that the design, maintenance, inspection and " +
                            "testing of such equipment will allow it to be operated in a safe manner ? ";
            addQS(7, qs7a, true, "Score (Maximum 4)", dataGridView2);

            //question 8
            String qs8 = "Have written records been compiled for each piece of equipment in the " +
                            "process, and do they include all of the following ? ";
            addQS(8, qs8, false, "", dataGridView2);
            String qs8a = "a. Materials of construction ";
            addQS(8, qs8a, true, "Score (Maximum 1)", dataGridView2);
            String qs8b = "b. Design codes and standards employed ";
            addQS(8, qs8b, true, "Score (Maximum 1)", dataGridView2);
            String qs8c = "c. Electrical classification";
            addQS(8, qs8c, true, "Score (Maximum 1)", dataGridView2);
            String qs8d = "d. Relief system design and design basis";
            addQS(8, qs8d, true, "Score (Maximum 1)", dataGridView2);
            String qs8e = "e. Ventilation system design";
            addQS(8, qs8e, true, "Score (Maximum 1)", dataGridView2);
            String qs8f = "f. Safety systems, including interlocks, detection and suppression systems";
            addQS(8, qs8f, true, "Score (Maximum 1)", dataGridView2);

            //question 9
            String qs9 = "Are procedures in place to ensure that each individual with responsibility " +
                            "for managing the process has a working knowledge of the process safety " +
                            "information appropriate to his or her responsibilities ? ";
            addQS(9, qs9, true, "Score (Maximum 5)", dataGridView2);

            //question 10
            String qs10 = "Is a documented compilation of all the above Process Safety Information " +
                            "maintained at the facility as a reference? The individual elements of the " +
                            "Information may exist in various forms and locations, but the compilation " +
                            "should confirm the existence and location of each element.";
            addQS(10, qs10, true, "Score (Maximum 8)", dataGridView2);
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                dataGridView2.CurrentCell = dataGridView2[2, e.RowIndex];
                dataGridView2.BeginEdit(true);
            }
   
        }

        private void dataGridView2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            if (e.RowIndex == 0)
            {
                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.Single;
            }
            if (e.RowIndex < 1 || e.ColumnIndex < 0)
                return;
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex, dataGridView2))
            {
                if(e.ColumnIndex == 0)
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
                e.AdvancedBorderStyle.Top = dataGridView2.AdvancedCellBorderStyle.Top;
            }
            if (e.RowIndex == dataGridView2.RowCount - 1)
            {
                e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Single;
            }
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == 0)
                return;
            // if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex, dataGridView2))
            {
                if(e.ColumnIndex == 0)
                {
                    e.Value = "";
                    e.FormattingApplied = true;
                }    
            }
        }

        ///<summary>
        /// setup tab3
        ///</summary>
        private void loadTab3()
        {
            dataGridView3.AutoGenerateColumns = false;
            dataGridView3.Columns[0].ReadOnly = true;
            dataGridView3.Columns[1].ReadOnly = true;
            // addQS(6, qs6b, true, "Score (Maximum 5)",dataGridView1);
            //qs1
            String qs1 = "What percentage of all process units that handle hazardous chemicals at " +
                            "the facility have had a formal Process Hazard Analysis(PHA) within the " +
                            "last five years ? ";
            addQS(1, qs1, true, "Percent (%)", dataGridView3);
            
            //qs2
            String qs2 = "Has a priority order been established for conducting future PHAs? ";
            addQS(2, qs2, true, "Score (Maximum 5)", dataGridView3);
            String qs2a = "Does the basis for the prioritization address the following factors?:";
            addQS(2, qs2a, false, "", dataGridView3);
            String qs2b = "a. The quantity of toxic, flammable, or explosive material at the site";
            addQS(2, qs2b, true, "Score (Maximum 1)", dataGridView3);
            String qs2c = "b. The level of toxicity or reactivity of the materials ";
            addQS(2, qs2c, true, "Score (Maximum 1)", dataGridView3);
            String qs2d = "c. The number of people in the immediate proximity of the facility, " +
                            "including both onsite and offsite locations";
            addQS(2, qs2d, true, "Score (Maximum 1)", dataGridView3);
            String qs2e = "d. Process complexity ";
            addQS(2, qs2e, true, "Score (Maximum 1)", dataGridView3);
            String qs2f = "e. Severe operating conditions or conditions that can cause corrosion or erosion";
            addQS(2, qs2f, true, "Score (Maximum 1)", dataGridView3);

            //qs3
            String qs3 = "Do the PHAs conducted to date address:";
            addQS(3, qs3, false, "", dataGridView3);
            String qs3a = "a. The hazards of the process?";
            addQS(3, qs3a, true, "Score (Maximum 2)", dataGridView3);
            String qs3b = "b. A review of previous incident/accident reports from the unit being " +
                            "analyzed to identify any previous incidents that had a potential for " +
                            "catastrophic consequences?";
            addQS(3, qs3b, true, "Score (Maximum 2)", dataGridView3);
            String qs3c = "c. Engineering and administrative controls applicable to the hazards and " +
                            "their interrelationships?";
            addQS(3, qs3c, true, "Score (Maximum 2)", dataGridView3);
            String qs3d = "d. Consequences of failure of engineering and administrative controls?";
            addQS(3, qs3d, true, "Score (Maximum 2)", dataGridView3);
            String qs3e = "e. Facilities siting? ";
            addQS(3, qs3e, true, "Score (Maximum 2)", dataGridView3);
            String qs3f = "f. Human factors? ";
            addQS(3, qs3f, true, "Score (Maximum 2)", dataGridView3);
            String qs3g = "g. A qualitative evaluation of the possible safety and health effects of failure";
            addQS(3, qs3g, true, "Score (Maximum 2)", dataGridView3);

            //qs4
            String qs4 = "Based on the most recent PHA conducted:";
            addQS(4, qs4, false, "", dataGridView3);
            String qs4a = "a. Was the team leader experienced in the technique being employed?";
            addQS(4, qs4a, true, "Score (Maximum 3)", dataGridView3);
            String qs4b = "b. Had the team leader received formal training in the method being " +
                            "employed ? ";
            addQS(4, qs4b, true, "Score (Maximum 3)", dataGridView3);
            String qs4c = "c. Was at least one member of the team an expert on the process being analyzed ? ";
            addQS(4, qs4c, true, "Score (Maximum 3)", dataGridView3);
            String qs4d = "d. Were all appropriate disciplines represented on the team or brought in " +
                            "as required during the analysis ? ";
            addQS(4, qs4d, true, "Score (Maximum 3)", dataGridView3);
            String qs4e = "e. Was at least one member of the team a person who did not participate " +
                            "in the original design of the facility?";
            addQS(4, qs4e, true, "Score (Maximum 3)", dataGridView3);

            //qs5
            String qs5 = "Is a formal system in place to promptly address the findings and " +
                            "recommendations of a Process Hazard Analysis to ensure that the " +
                            "recommendations are resolved in a timely manner and that the resolution " +
                            "is documented ? ";
            addQS(5, qs5, true, "Score (Maximum 8)", dataGridView3);
            String qs5a = "a. If so, are timetables established for implementation?";
            addQS(5, qs5a, true, "Score (Maximum 3)", dataGridView3);
            String qs5b = "b. Does the system require that decisions concerning recommendations " +
                            "in PHAs and the status of implementation be communicated to all " +
                            "operations, maintenance and other personnel who may be affected?";
            addQS(5, qs5b, true, "Score (Maximum 3)", dataGridView3);

            // qs6
            String qs6 = "Is the methodology used in past PHAs and/or planned future PHAs " +
                            "appropriate for the complexity of the process ? ";
            addQS(6, qs6, true, "Score (Maximum 10)", dataGridView3);

            //qs7
            String qs7 = "Are the PHAs being led by an individual who has been trained in the " +
                            "methods being used ? ";
            addQS(7, qs7, true, "Score (Maximum 12)", dataGridView3);

            //qs8
            String qs8 = "Based on the most recent PHAs conducted, are the average rates of " +
                            "analysis appropriate for the complexity of the systems being analyzed ? " +
                            "(Typically, 2–4 P & IDs of average complexity will be analyzed per day.) ";
            addQS(8, qs8, true, "Score (Maximum 10)", dataGridView3);

            // qs9
            String qs9 = "After the process hazards have been identified, are the likelihood and " +
                            "consequences of the failure scenarios assessed using either qualitative or " +
                            "quantitative techniques ? ";
            addQS(9, qs9, true, "Score (Maximum 5)", dataGridView3);
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridView3.CurrentCell = dataGridView3[2, e.RowIndex];
                dataGridView3.BeginEdit(true);
            }
        }

        private void dataGridView3_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            if (e.RowIndex == 0)
            {
                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.Single;
            }
            if (e.RowIndex < 1 || e.ColumnIndex < 0)
                return;
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex, dataGridView3))
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
                e.AdvancedBorderStyle.Top = dataGridView3.AdvancedCellBorderStyle.Top;
            }
            if (e.RowIndex == dataGridView3.RowCount - 1)
            {
                e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Single;
            }
        }

        private void dataGridView3_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == 0)
                return;
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex, dataGridView3))
            {
                if (e.ColumnIndex == 0)
                {
                    e.Value = "";
                    e.FormattingApplied = true;
                }
            }
        }

        ///<summary>
        /// setuptab4
        ///</summary>
        private void loadTab4()
        {
            dataGridView4.AutoGenerateColumns = false;
            dataGridView4.Columns[0].ReadOnly = true;
            dataGridView4.Columns[1].ReadOnly = true;
            // addQS(6, qs6b, true, "Score (Maximum 5)",dataGridView1);
            //qs1
            String qs1 = "Does the facility have a written Management of Change procedure that " +
                            "must be followed whenever new facilities are added or changes are made " +
                            "to a process ? ";
            addQS(1, qs1, true, "Score (Maximum 9)", dataGridView4);
            String qs1a = "Are authorization procedures clearly stated and at an appropriate level?";
            addQS(1, qs1a, true, "Score (Maximum 5)", dataGridView4);

            //qs2
            String qs2 = "Do the following types of “changes” invoke the Management of Change procedure ? ";
            addQS(2, qs2, false, "", dataGridView4);
            String qs2a = "a. Physical changes to the facility, other than replacement in kind "+
                            "(expansions, equipment modifications, instrument or alarm system "+
                            "revisions, etc.).";
            addQS(2, qs2a, true, "Score (Maximum 4)", dataGridView4);
            String qs2b = "b. Changes in process chemicals (feedstocks, catalysts, solvents, etc.).";
            addQS(2, qs2b, true, "Score (Maximum 4)", dataGridView4);
            String qs2c = "c. Changes in process conditions (operating temperatures, pressures, production rates, etc.).";
            addQS(2, qs2c, true, "Score (Maximum 4)", dataGridView4);
            String qs2d = "d. Significant changes in operating procedures (startup or shutdown sequences, unit staffing level or assignments, etc.).";
            addQS(2, qs2d, true, "Score (Maximum 4)", dataGridView4);
            

            //qs3
            String qs3 = "Is there a clear understanding at the facility of what constitutes a \"temporary change?\"";
            addQS(3, qs3, true, "Score (Maximum 5)", dataGridView4);
            String qs3a = "a. Does Management of Change handle temporary changes as well as permanent changes?";
            addQS(3, qs3a, true, "Score (Maximum 4)", dataGridView4);
            String qs3b = "b. Are items that are installed as “temporary” tracked to ensure that they " +
                            "are either removed after a reasonable period of time or reclassified as " +
                            "permanent ? ";
            addQS(3, qs3b, true, "Score (Maximum 5)", dataGridView4);
            

            //qs4
            String qs4 = "Do the Management of Change procedures specifically require the following actions whenever a change is made to a process ? ";
            addQS(4, qs4, false, "", dataGridView4);
            String qs4a = "a. Require an appropriate Process Hazard Analysis for the unit. ";
            addQS(4, qs4a, true, "Score (Maximum 3)", dataGridView4);
            String qs4b = "b. Update all affected operating procedures.";
            addQS(4, qs4b, true, "Score (Maximum 3)", dataGridView4);
            String qs4c = "c. Update all affected maintenance programs and inspection schedules.";
            addQS(4, qs4c, true, "Score (Maximum 3)", dataGridView4);
            String qs4d = "d. Modify P&IDs, statement of operating limits, Material Safety Data "+
                            "Sheets, and any other process safety information affected. ";
            addQS(4, qs4d, true, "Score (Maximum 3)", dataGridView4);
            String qs4e = "e. Notify all process and maintenance employees who work in the area " +
                            "of the change, and provide training as required.";
            addQS(4, qs4e, true, "Score (Maximum 3)", dataGridView4);
            String qs4f = "f. Notify all contractors affected by the change. ";
            addQS(4, qs4f, true, "Score (Maximum 3)", dataGridView4);
            String qs4g = "g. Review the effect of the proposed change on all separate but " +
                            "interrelated upstream and downstream facilities.";
            addQS(4, qs4g, true, "Score (Maximum 3)", dataGridView4);

            //qs5
            String qs5 = "When changes are made in the process or operating procedures, are "+
                            "there written procedures requiring that the impact of these changes on the "+
                            "equipment and materials of construction be reviewed to determine whether "+
                            "they will cause any increased rate of deterioration or failure, or will result in "+
                            "different failure mechanisms in the process equipment ? ";
            addQS(5, qs5, true, "Score (Maximum 10)", dataGridView4);
   
            // qs6
            String qs6 = "When the equipment or materials of construction are changed through "+
                            "replacement or maintenance items, is there a system in place to formally "+
                            "review any metallurgical change to ensure that the new material is suitable "+
                            "for the process?";
            addQS(6, qs6, true, "Score (Maximum 5)", dataGridView4);
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
        /// <summary>
        /// load other
        /// </summary>
        private void loadOther()
        {
            ucTab5 uctab5 = new ucTab5();
            ucTab6 uctab6 = new ucTab6();
            ucTab7 uctab7 = new ucTab7();
            ucTab8 uctab8 = new ucTab8();
            ucTab9 uctab9 = new ucTab9();
            ucTab10 uctab10 = new ucTab10();
            ucTab11 uctab11 = new ucTab11();
            ucTab12 uctab12 = new ucTab12();
            ucTab13 uctab13 = new ucTab13();

            uctab5.Dock = DockStyle.Fill;
            tabPage5.Controls.Add(uctab5);

            uctab6.Dock = DockStyle.Fill;
            tabPage6.Controls.Add(uctab6);

            uctab7.Dock = DockStyle.Fill;
            tabPage7.Controls.Add(uctab7);

            uctab8.Dock = DockStyle.Fill;
            tabPage8.Controls.Add(uctab8);

            uctab9.Dock = DockStyle.Fill;
            tabPage9.Controls.Add(uctab9);

            uctab10.Dock = DockStyle.Fill;
            tabPage10.Controls.Add(uctab10);

            uctab11.Dock = DockStyle.Fill;
            tabPage11.Controls.Add(uctab11);

            uctab12.Dock = DockStyle.Fill;
            tabPage12.Controls.Add(uctab12);

            uctab13.Dock = DockStyle.Fill;
            tabPage13.Controls.Add(uctab13);
        }
    }
}
