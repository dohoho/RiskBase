using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RBI.Object;
using RBI.BUS;
using Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;

namespace RBI.PRE.subForm
{
    public partial class UCrisk : UserControl
    {
        public UCrisk()
        {
            InitializeComponent();
            load();
        }

        private void load()
        {
            BusEquipments buseq = new BusEquipments();
            BusRiskSummary bus = new BusRiskSummary();
            List<RiskSummary> list = bus.loads();
            DataGridViewRow row;
            for (int i = 0;i <list.Count; i++)
            {
                row = new DataGridViewRow();
                row.CreateCells(dataGridView1);
                row.Cells[0].Value = list[i].ItemNo;
                row.Cells[1].Value = buseq.getdes(list[i].ItemNo);
                row.Cells[2].Value = buseq.gettype(list[i].ItemNo);
                row.Cells[3].Value = list[i].ComName;
                row.Cells[4].Value = list[i].RepresentFluid;
                row.Cells[5].Value = list[i].FluidPhase;
                row.Cells[6].Value = list[i].CotcatFlammable;
                row.Cells[7].Value = list[i].CurrentRisk;
                row.Cells[8].Value = list[i].CotcatPeople;
                row.Cells[9].Value = list[i].CotcatAsset;
                row.Cells[10].Value = list[i].CotcatEnv;
                row.Cells[11].Value = list[i].CotcatReputation;
                row.Cells[12].Value = list[i].CotcatCombinled;
                row.Cells[13].Value = list[i].ComponentMaterialGrade;
                row.Cells[14].Value = list[i].InitThinningCategory;
                row.Cells[15].Value = list[i].InitEnvCracking;
                row.Cells[16].Value = list[i].InitOtherCategory;
                row.Cells[17].Value = list[i].InitCategory;
                row.Cells[18].Value = list[i].ExtThinningCategory;
                row.Cells[19].Value = list[i].ExtEnvCracking;
                row.Cells[20].Value = list[i].ExtOtherCategory;
                row.Cells[21].Value = list[i].ExtCategory;
                row.Cells[22].Value = list[i].POFCategory;
                row.Cells[23].Value = list[i].CurrentRiskCal;
                row.Cells[24].Value = list[i].FutureRisk;

                dataGridView1.Rows.Add(row);
            }
        }

        public void exportToExcel(String duongdan, String tentap)
        {
            BusRiskSummary bus = new BusRiskSummary();
            List<RiskSummary> list = bus.loads();
            app obj = new app();
            obj.Application.Workbooks.Add(Type.Missing);
            obj.Columns.ColumnWidth = 20;

            obj.Cells[1, "A"] = "Equipment";
            obj.Cells[1, "B"] = "Equipment Description";
            obj.Cells[1, "C"] = "Equipment Type";
            obj.Cells[1, "D"] = "Components";
            obj.Cells[1, "E"] = "Represent.fluid";
            obj.Cells[1, "F"] = "Fluid phase";
            obj.Cells[1, "G"] = "Cofcat.Flammable";
            obj.Cells[1, "H"] = "Current Risk";
            obj.Cells[1, "I"] = "Cofcat.People";
            obj.Cells[1, "J"] = "Cofcat.Asset";
            obj.Cells[1, "K"] = "Cofcat.Env";
            obj.Cells[1, "L"] = "Cofcat.Reputation";
            obj.Cells[1, "M"] = "Cofcat.Combined";
            obj.Cells[1, "N"] = "Component Material Glade";
            obj.Cells[1, "O"] = "InitThinningPOFCatalog";
            obj.Cells[1, "P"] = "InitEnv.Cracking";
            obj.Cells[1, "Q"] = "InitOtherPOFCatalog";
            obj.Cells[1, "R"] = "InitPOFCatelog";
            obj.Cells[1, "S"] = "ExtThinningPOF";
            obj.Cells[1, "T"] = "ExtEnvCrackingProbabilityCatelog";
            obj.Cells[1, "U"] = "ExtOtherPOFCatelog";
            obj.Cells[1, "V"] = "ExtPOFCatelog";
            obj.Cells[1, "W"] = "POFCatelog";
            obj.Cells[1, "X"] = "Current Risk";
            obj.Cells[1, "Y"] = "Future Risk";

            //int row = 2; //start row
            for (int i = 0; i < list.Count; i++)
            {
                BusEquipments buseq = new BusEquipments();
                String Equipment = list[i].ItemNo.ToString();
                String Description = null;
                if (buseq.getdes(Equipment) == null || buseq.getdes(Equipment) == "")
                {
                    Description = "N/A";
                }
                else
                {
                    Description = buseq.getdes(Equipment);
                }
                String Equipment_Type = null;
                if (buseq.gettype(Equipment) == null || buseq.gettype(Equipment) == "")
                {
                    Equipment_Type = "N/A";
                }
                else
                {
                    Equipment_Type = buseq.gettype(Equipment).ToString();
                }
                String Components = list[i].ComName;
                String Represent_fluid = null;
                if (list[i].RepresentFluid == null || list[i].RepresentFluid == "")
                {
                    Represent_fluid = "N/A";
                }
                else
                {
                    Represent_fluid = list[i].RepresentFluid;
                }
                String Fluid_phase = null;
                if (list[i].FluidPhase == null || list[i].FluidPhase == "")
                {
                    Fluid_phase = "N/A";
                }
                else
                {
                    Fluid_phase = list[i].FluidPhase;
                }
                String Cofcat_Flammable = null;
                if (list[i].CotcatFlammable == null || list[i].CotcatFlammable == "")
                {
                    Cofcat_Flammable = "N/A";
                }
                else
                {
                    Cofcat_Flammable = list[i].CotcatFlammable;
                }
                String Current_Risk = null;
                if (list[i].CurrentRisk == null || list[i].CurrentRisk == "")
                {
                    Current_Risk = "N/A";
                }
                else
                {
                    Current_Risk = list[i].CurrentRisk;
                }
                String Cofcat_People = null;
                if (list[i].CotcatPeople == null || list[i].CotcatPeople == "")
                {
                    Cofcat_People = "N/A";
                }
                else
                {
                    Cofcat_People = list[i].CotcatPeople;
                }
                String Cofcat_Asset = null;
                if (list[i].CotcatAsset == null || list[i].CotcatAsset == "")
                {
                    Cofcat_Asset = "N/A";
                }
                else
                {
                    Cofcat_Asset = list[i].CotcatAsset;
                }
                String Cofcat_Env = null;
                if (list[i].CotcatEnv == null || list[i].CotcatEnv == "")
                {
                    Cofcat_Env = "N/A";
                }
                else
                {
                    Cofcat_Env = list[i].CotcatEnv;
                }
                String Cofcat_Reputation = null;
                if (list[i].CotcatReputation == null || list[i].CotcatReputation == "")
                {
                    Cofcat_Reputation = "N/A";
                }
                else
                {
                    Cofcat_Reputation = list[i].CotcatReputation;
                }
                String Cofcat_Combined = null;
                if (list[i].CotcatCombinled == null || list[i].CotcatCombinled == "")
                {
                    Cofcat_Combined = "N/A";
                }
                else
                {
                    Cofcat_Combined = list[i].CotcatCombinled;
                }
                String Component_Material_Glade = null;
                if (list[i].ComponentMaterialGrade == null || list[i].ComponentMaterialGrade == "")
                {
                    Component_Material_Glade = "N/A";
                }
                else
                {
                    Component_Material_Glade = list[i].ComponentMaterialGrade;
                }
                String InitThinningPOFCatalog = null;
                if (list[i].InitThinningCategory == null || list[i].InitThinningCategory == "")
                {
                    InitThinningPOFCatalog = "N/A";
                }
                else
                {
                    InitThinningPOFCatalog = list[i].InitThinningCategory;
                }
                String InitEnv_Cracking = null;
                if (list[i].InitEnvCracking == null || list[i].InitEnvCracking == "")
                {
                    InitEnv_Cracking = "N/A";
                }
                else
                {
                    InitEnv_Cracking = list[i].InitEnvCracking;
                }
                String InitOtherPOFCatalog = null;
                if (list[i].InitOtherCategory == null || list[i].InitOtherCategory == "")
                {
                    InitOtherPOFCatalog = "N/A";
                }
                else
                {
                    InitOtherPOFCatalog = list[i].InitOtherCategory;
                }
                String InitPOFCatelog = null;
                if (list[i].InitCategory == null || list[i].InitCategory == "")
                {
                    InitPOFCatelog = "N/A";
                }
                else
                {
                    InitPOFCatelog = list[i].InitCategory;
                }
                String ExtThinningPOF = null;
                if (list[i].ExtThinningCategory == null || list[i].ExtThinningCategory == "")
                {
                    ExtThinningPOF = "N/A";
                }
                else
                {
                    ExtThinningPOF = list[i].ExtThinningCategory;
                }
                String ExtEnvCrackingProbabilityCatelog = null;
                if (list[i].ExtEnvCracking == null || list[i].ExtEnvCracking == "")
                {
                    ExtEnvCrackingProbabilityCatelog = "N/A";
                }
                else
                {
                    ExtEnvCrackingProbabilityCatelog = list[i].ExtEnvCracking;
                }
                String ExtOtherPOFCatelog = null;
                if (list[i].ExtOtherCategory == null || list[i].ExtOtherCategory == "")
                {
                    ExtOtherPOFCatelog = "N/A";
                }
                else
                {
                    ExtOtherPOFCatelog = list[i].ExtOtherCategory;
                }
                String ExtPOFCatelog = null;
                if (list[i].ExtCategory == null || list[i].ExtCategory == "")
                {
                    ExtPOFCatelog = "N/A";
                }
                else
                {
                    ExtPOFCatelog = list[i].ExtCategory;
                }
                String POFCatelog = null;
                if (list[i].POFCategory == null || list[i].POFCategory == "")
                {
                    POFCatelog = "N/A";
                }
                else
                {
                    POFCatelog = list[i].POFCategory;
                }
                String Current_Risk_Cal = list[i].CurrentRiskCal.ToString();
                Console.WriteLine(list[i].CurrentRiskCal);
                /* if (list[i].CurrentRiskCal.Equals(""))
                 {
                     Current_Risk_Cal = "N/A";
                 }
                 else
                 {
                     Current_Risk_Cal = list[i].CurrentRiskCal;
                 }
                 */
                String Future_Risk = null;
                if (list[i].FutureRisk == null || list[i].FutureRisk == "")
                {
                    Future_Risk = "N/A";
                }
                else
                {
                    Future_Risk = list[i].FutureRisk;
                }
                //obj.Cells[i + 2, 1] = list[i].ItemNo.ToString();
                obj.Cells[i + 2, "A"] = Equipment;
                obj.Cells[i + 2, "B"] = Description;
                obj.Cells[i + 2, "C"] = Equipment_Type;
                obj.Cells[i + 2, "D"] = Components;
                obj.Cells[i + 2, "E"] = Represent_fluid;
                obj.Cells[i + 2, "F"] = Fluid_phase;
                obj.Cells[i + 2, "G"] = Cofcat_Flammable;
                obj.Cells[i + 2, "H"] = Current_Risk;
                obj.Cells[i + 2, "I"] = Cofcat_People;
                obj.Cells[i + 2, "J"] = Cofcat_Asset;
                obj.Cells[i + 2, "K"] = Cofcat_Env;
                obj.Cells[i + 2, "L"] = Cofcat_Reputation;
                obj.Cells[i + 2, "M"] = Cofcat_Combined;
                obj.Cells[i + 2, "N"] = Component_Material_Glade;
                obj.Cells[i + 2, "O"] = InitThinningPOFCatalog;
                obj.Cells[i + 2, "P"] = InitEnv_Cracking;
                obj.Cells[i + 2, "Q"] = InitOtherPOFCatalog;
                obj.Cells[i + 2, "R"] = InitPOFCatelog;
                obj.Cells[i + 2, "S"] = ExtThinningPOF;
                obj.Cells[i + 2, "T"] = ExtEnvCrackingProbabilityCatelog;
                obj.Cells[i + 2, "U"] = ExtOtherPOFCatelog;
                obj.Cells[i + 2, "V"] = ExtPOFCatelog;
                obj.Cells[i + 2, "W"] = POFCatelog;
                obj.Cells[i + 2, "X"] = Current_Risk_Cal;
                obj.Cells[i + 2, "Y"] = Future_Risk;

            }

            obj.ActiveWorkbook.SaveCopyAs(duongdan + tentap + ".xls");
            obj.ActiveWorkbook.Saved = true;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            exportToExcel(@"C:\Users\VuNA\Dropbox\Lab_Associates Team Folder\RBI\Output\", "RiskSummary");
            sendEmail email = new sendEmail();
            email.senEmail();
            WatingForm wait = new WatingForm();
            wait.ShowDialog(this);
        }
    }
}
