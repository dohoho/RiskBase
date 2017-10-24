using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Office.Interop.Excel;

using System.Data.OleDb;
using System.IO;
using DevExpress.Spreadsheet;
using DevExpress.XtraSpreadsheet;
using RBI.BUS.BUSExcel;
using RBI.Object.ObjectMSSQL;
namespace RBI.PRE.subForm
{
    public partial class ImportExcel : Form
    {
        public ImportExcel()
        {
            InitializeComponent();
        }
        #region Parameter
        DevExpress.XtraSpreadsheet.SpreadsheetControl spreadExcel = new SpreadsheetControl();
        string fileName = null;
        string extension = null;
        string[] sheetEquipment;
        string[] sheetComponent;
        string[] sheetOperatingCondition;
        string[] sheetStream;
        string[] sheetMaterial;
        string[] sheetCoating;
        #endregion
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Excel 2003 (*.xls)|*.xls|Excel Document (*.xlsx)|*.xlsx|All File(*)|*";
            if (op.ShowDialog() == DialogResult.OK)
            {
                txtPathFileExcel.Text = op.FileName;
            }
        }
        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            fileName = Path.GetFileName(txtPathFileExcel.Text);
            extension = Path.GetExtension(fileName);
            if (extension == ".xls")
            {
                spreadExcel.LoadDocument(txtPathFileExcel.Text, DocumentFormat.Xls);
            }
            else if (extension == ".xlsx")
            {
                spreadExcel.LoadDocument(txtPathFileExcel.Text, DocumentFormat.Xlsx);
            }
            else
            {
                MessageBox.Show("This file is not supported! Sorry!", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            pictureBox1.Hide();
            label1.Hide();
            spreadExcel.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(spreadExcel);
            ///panelControl1.Refresh();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            IWorkbook workbook = spreadExcel.Document;
            using (FileStream stream = new FileStream(txtPathFileExcel.Text, FileMode.Create, FileAccess.ReadWrite))
            {
                if (extension == ".xls")
                    workbook.SaveDocument(stream, DocumentFormat.Xls);
                else
                    workbook.SaveDocument(stream, DocumentFormat.Xlsx);
            }
            MessageBox.Show("This file has been saved!", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            readDataFromSheet();
            RibbonForm1.rwcoat1 = getDataCoating();
            RibbonForm1.rwcom1 = getDataComponent();
            RibbonForm1.rweq1 = getDataEquipment();
            RibbonForm1.rwma1 = getDataMaterial();
            RibbonForm1.rwstream_1 = getDataStream();
            RibbonForm1.rwstream_2 = getDataOperating();
            RibbonForm1.ass1 = getAssessmentDate();
            this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void readDataFromSheet()
        {
            IWorkbook workbook = spreadExcel.Document;
            try
            {
                //sheet equipment
                DevExpress.Spreadsheet.Worksheet worksheet0 = workbook.Worksheets[0];
                sheetEquipment = new string[33];
                sheetEquipment[0] = "Sheet Equipment";
                for (int i = 1; i < 33; i++)
                {
                    sheetEquipment[i] = worksheet0.Cells[1, i-1].Value.ToString();
                    Debug.WriteLine("Equipment " + sheetEquipment[i]);
                }
                //sheet component
                DevExpress.Spreadsheet.Worksheet worksheet1 = workbook.Worksheets[1];
                sheetComponent = new string[33];
                sheetComponent[0] = "Sheet Component";
                for (int i = 1; i < 33; i++)
                {
                    sheetComponent[i] = worksheet1.Cells[1, i-1].Value.ToString();
                    Debug.WriteLine("Component " + sheetComponent[i]);
                }
                //sheet operating condition
                DevExpress.Spreadsheet.Worksheet worksheet2 = workbook.Worksheets[2];
                sheetOperatingCondition = new string[19];
                sheetOperatingCondition[0] = "Sheet Operating Condition";
                for (int i = 1; i < 19; i++)
                {
                    sheetOperatingCondition[i] = worksheet2.Cells[1, i-1].Value.ToString();
                    Debug.WriteLine("Operating Condition " + sheetOperatingCondition[i]);
                }
                //sheet Stream
                DevExpress.Spreadsheet.Worksheet worksheet3 = workbook.Worksheets[3];
                sheetStream = new string[23];
                sheetStream[0] = "Sheet Stream";
                for (int i = 1; i < 23; i++)
                {
                    sheetStream[i] = worksheet3.Cells[1, i-1].Value.ToString();
                    Debug.WriteLine("Stream " + sheetStream[i]);
                }
                //sheet Material
                DevExpress.Spreadsheet.Worksheet worksheet4 = workbook.Worksheets[4];
                sheetMaterial = new string[23];
                sheetMaterial[0] = "Sheet Material";
                for (int i = 1; i < 23; i++)
                {
                    sheetMaterial[i] = worksheet4.Cells[1, i-1].Value.ToString();
                    Debug.WriteLine("Material " + sheetMaterial[i]);
                }
                //sheet Coating
                DevExpress.Spreadsheet.Worksheet worksheet5 = workbook.Worksheets[5];
                sheetCoating = new string[16];
                sheetCoating[0] = "Sheet Coating";
                for (int i = 1; i < 16; i++)
                {
                    sheetCoating[i] = worksheet5.Cells[1, i-1].Value.ToString();
                    Debug.WriteLine("Coating " + sheetCoating[i]);
                }

            }
            catch(Exception e)
            {
                MessageBox.Show("Error Read Excel File!" + e.ToString(), "Cortek");
            }
        }
        
        
        public RW_EQUIPMENT getDataEquipment()
        {
            RW_EQUIPMENT eq = new RW_EQUIPMENT();
            eq.AdminUpsetManagement = sheetEquipment[12] == "True" ? 1 : 0;
            eq.ContainsDeadlegs = sheetEquipment[13] == "True" ? 1 : 0;
            eq.CyclicOperation = sheetEquipment[15] == "True" ? 1 : 0;
            eq.HighlyDeadlegInsp = sheetEquipment[14] == "True" ? 1 : 0;
            eq.DowntimeProtectionUsed = sheetEquipment[16] == "True" ? 1 : 0;
            eq.ExternalEnvironment = sheetEquipment[28];
            eq.HeatTraced = sheetEquipment[18] == "True" ? 1 : 0;
            eq.InterfaceSoilWater = sheetEquipment[20] == "True" ? 1 : 0;
            eq.LinerOnlineMonitoring = sheetEquipment[25] == "True" ? 1 : 0;
            eq.MaterialExposedToClExt = sheetEquipment[24] == "True" ? 1 : 0;
            eq.MinReqTemperaturePressurisation = sheetEquipment[22] != "" ? float.Parse(sheetEquipment[22]) : 0;
            eq.OnlineMonitoring = sheetEquipment[30];
            eq.PresenceSulphidesO2 = sheetEquipment[26] == "True" ? 1 : 0;
            eq.PresenceSulphidesO2Shutdown = sheetEquipment[27] == "True" ? 1 : 0;
            eq.PressurisationControlled = sheetEquipment[21] == "True" ? 1 : 0;
            eq.PWHT = sheetEquipment[19] == "True" ? 1 : 0;
            eq.SteamOutWaterFlush = sheetEquipment[17] == "True" ? 1 : 0;
            eq.ManagementFactor = sheetEquipment[32] != "" ? float.Parse(sheetEquipment[32]) : 0;
            eq.ThermalHistory = sheetEquipment[29];
            eq.YearLowestExpTemp = sheetEquipment[23] == "True" ? 1 : 0;
            eq.Volume = sheetEquipment[31] != "" ? float.Parse(sheetEquipment[31]) : 0;
            eq.CommissionDate = Convert.ToDateTime(sheetEquipment[8]);
            Debug.WriteLine("commission date " + eq.CommissionDate);
            return eq;
        }
        public RW_ASSESSMENT getAssessmentDate()
        {
            RW_ASSESSMENT ass = new RW_ASSESSMENT();
            ass.AssessmentDate = Convert.ToDateTime(sheetComponent[8]);
            Debug.WriteLine("assessment date " + ass.AssessmentDate);
            return ass;
        }
        public RW_COMPONENT getDataComponent()
        {
            RW_COMPONENT comp = new RW_COMPONENT();
            comp.NominalDiameter = sheetComponent[10] == "" ? float.Parse(sheetComponent[10]) : 0;
            comp.NominalThickness = sheetComponent[11] == "" ? float.Parse(sheetComponent[11]) : 0;
            comp.CurrentThickness = sheetComponent[12] == "" ? float.Parse(sheetComponent[12]) : 0;
            comp.MinReqThickness = sheetComponent[13] == "" ? float.Parse(sheetComponent[13]) : 0;
            comp.CurrentCorrosionRate = sheetComponent[14] == "" ? float.Parse(sheetComponent[14]) : 0;
            comp.BranchDiameter = sheetComponent[24];
            comp.BranchJointType = sheetComponent[25];
            comp.BrinnelHardness = sheetComponent[21];
            comp.CracksPresent = sheetComponent[17] == "True" ? 1 : 0;
            comp.ComplexityProtrusion = sheetComponent[22];
            return comp;
        }
        public RW_COATING getDataCoating()
        {
            RW_COATING coat = new RW_COATING();
            try
            {
                coat.ExternalCoating = sheetCoating[3] == "True" ? 1 : 0;
                coat.ExternalInsulation = sheetCoating[12] == "True" ? 1 : 0;
                coat.InternalCladding = sheetCoating[7] == "True" ? 1 : 0;
                coat.InternalCoating = sheetCoating[2] == "True" ? 1 : 0;
                coat.ExternalCoatingQuality = sheetCoating[5];
                coat.ExternalInsulationType = sheetCoating[14];
                coat.InsulationContainsChloride = sheetCoating[13] == "True" ? 1 : 0;
                coat.InternalLinerCondition = sheetCoating[11];
                coat.InternalLinerType = sheetCoating[10];
                coat.InternalLining = sheetCoating[9] == "True" ? 1 : 0;
                coat.CladdingCorrosionRate = sheetCoating[8] != "" ? float.Parse(sheetCoating[8]) : 0;
                coat.SupportConfigNotAllowCoatingMaint = sheetCoating[6] == "True" ? 1 : 0;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return coat;
        }
        public RW_STREAM getDataStream()
        {
            RW_STREAM stream = new RW_STREAM();
            stream.AmineSolution = sheetStream[13];
            stream.AqueousOperation = sheetStream[14] == "True" ? 1 : 0;
            stream.AqueousShutdown = sheetStream[15] == "True" ? 1 : 0;
            stream.ToxicConstituent = sheetStream[11] == "True" ? 1 : 0;
            stream.Caustic = sheetStream[20] == "True" ? 1 : 0;
            stream.Chloride = sheetStream[6] != "" ? float.Parse(sheetStream[6]) : 0;
            stream.CO3Concentration = sheetStream[7] != "" ? float.Parse(sheetStream[7]) : 0;
            stream.Cyanide = sheetStream[18] == "True" ? 1 : 0;
            stream.ExposedToGasAmine = sheetStream[10] == "True" ? 1 : 0;
            stream.ExposedToSulphur = sheetStream[21] == "True" ? 1 : 0;
            stream.ExposureToAmine = sheetStream[12];
            stream.H2S = sheetStream[16] == "True" ? 1 : 0;
            stream.H2SInWater = sheetStream[8] != "" ? float.Parse(sheetStream[8]) : 0;
            stream.Hydrogen = sheetStream[19] == "True" ? 1 : 0;
            stream.MaterialExposedToClInt = sheetStream[22] == "True" ? 1 : 0;
            stream.NaOHConcentration = sheetStream[4] != "" ? float.Parse(sheetStream[4]) : 0;
            stream.ReleaseFluidPercentToxic = sheetStream[5] != "" ? float.Parse(sheetStream[5]) : 0;
            stream.WaterpH = sheetStream[9] != "" ? float.Parse(sheetStream[9]) : 0;
            stream.Hydrofluoric = sheetStream[17] == "True" ? 1 : 0;
            return stream;

        }
        public RW_MATERIAL getDataMaterial()
        {
            RW_MATERIAL ma = new RW_MATERIAL();
            ma.MaterialName = sheetMaterial[1];
            ma.DesignPressure = sheetMaterial[2] != "" ? float.Parse(sheetMaterial[2]) : 0;
            ma.DesignTemperature = sheetMaterial[3] != "" ? float.Parse(sheetMaterial[3]) : 0;
            ma.MinDesignTemperature = sheetMaterial[4] != "" ? float.Parse(sheetMaterial[4]) : 0;
            ma.BrittleFractureThickness = sheetMaterial[6] != "" ? float.Parse(sheetMaterial[6]) : 0;
            ma.CorrosionAllowance = sheetMaterial[8] != "" ? float.Parse(sheetMaterial[8]) : 0;
            //if(tankBottom) -> hide txtSigmaPhase
            ma.SigmaPhase = sheetMaterial[9] != "" ? float.Parse(sheetMaterial[8]) : 0;
            ma.SulfurContent = sheetMaterial[15];
            ma.HeatTreatment = sheetMaterial[16];
            ma.ReferenceTemperature = sheetMaterial[5] != "" ? float.Parse(sheetMaterial[5]) : 0;
            ma.PTAMaterialCode = sheetMaterial[20];
            ma.HTHAMaterialCode = sheetMaterial[18];
            ma.IsPTA = sheetMaterial[19] == "True" ? 1 : 0;
            ma.IsHTHA = sheetMaterial[17] == "True" ? 1 : 0;
            ma.Austenitic = sheetMaterial[11] == "True" ? 1 : 0;
            ma.Temper = sheetMaterial[12] == "True" ? 1 : 0;
            ma.CarbonLowAlloy = sheetMaterial[10] == "True" ? 1 : 0;
            ma.NickelBased = sheetMaterial[13] == "True" ? 1 : 0;
            ma.ChromeMoreEqual12 = sheetMaterial[14] == "True" ? 1 : 0;
            ma.AllowableStress = sheetMaterial[7] != "" ? float.Parse(sheetMaterial[7]) : 0;
            //ma.CostFactor = mate[20] != "" ? float.Parse(mate[20]) : 0;
            return ma;
        }
        public RW_STREAM getDataOperating()
        {
            RW_STREAM str = new RW_STREAM();
            str.FlowRate = sheetOperatingCondition[8] != "" ? float.Parse(sheetOperatingCondition[8]) : 0;
            str.MaxOperatingPressure = sheetOperatingCondition[5] != "" ? float.Parse(sheetOperatingCondition[5]) : 0;
            str.MinOperatingPressure = sheetOperatingCondition[6] != "" ? float.Parse(sheetOperatingCondition[6]) : 0;
            str.MaxOperatingTemperature = sheetOperatingCondition[2] != "" ? float.Parse(sheetOperatingCondition[2]) : 0;
            str.MinOperatingTemperature = sheetOperatingCondition[3] != "" ? float.Parse(sheetOperatingCondition[3]) : 0;
            str.CriticalExposureTemperature = sheetOperatingCondition[4] != "" ? float.Parse(sheetOperatingCondition[4]) : 0;
            str.H2SPartialPressure = sheetOperatingCondition[7] != "" ? float.Parse(sheetOperatingCondition[7]) : 0;
            str.CUI_PERCENT_1 = sheetOperatingCondition[9] != "" ? float.Parse(sheetOperatingCondition[9]) : 0;
            str.CUI_PERCENT_2 = sheetOperatingCondition[10] != "" ? float.Parse(sheetOperatingCondition[10]) : 0;
            str.CUI_PERCENT_3 = sheetOperatingCondition[11] != "" ? float.Parse(sheetOperatingCondition[11]) : 0;
            str.CUI_PERCENT_4 = sheetOperatingCondition[12] != "" ? float.Parse(sheetOperatingCondition[12]) : 0;
            str.CUI_PERCENT_5 = sheetOperatingCondition[13] != "" ? float.Parse(sheetOperatingCondition[13]) : 0;
            str.CUI_PERCENT_6 = sheetOperatingCondition[14] != "" ? float.Parse(sheetOperatingCondition[14]) : 0;
            str.CUI_PERCENT_7 = sheetOperatingCondition[15] != "" ? float.Parse(sheetOperatingCondition[15]) : 0;
            str.CUI_PERCENT_8 = sheetOperatingCondition[16] != "" ? float.Parse(sheetOperatingCondition[16]) : 0;
            str.CUI_PERCENT_9 = sheetOperatingCondition[17] != "" ? float.Parse(sheetOperatingCondition[17]) : 0;
            str.CUI_PERCENT_10 = sheetOperatingCondition[18] != "" ? float.Parse(sheetOperatingCondition[18]) : 0;
            return str;
        }
    }
}

