using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using DevExpress.XtraBars;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Menu;
using DevExpress.Utils.Menu;


using RBI.BUS.Calculator;
using Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;
using RBI.DAL;
using RBI.BUS;
using RBI.Object;
using RBI.BUS.BUSExcel;
using RBI.PRE.subForm;
using RBI.Object.ObjectMSSQL;

using RBI.PRE.subForm.InputDataForm;
using RBI.BUS.BUSMSSQL_CAL;
using RBI.PRE.subForm.OutputDataForm;

using DevExpress.Spreadsheet;
using DevExpress.XtraSpreadsheet;
namespace RBI
{
    public partial class RibbonForm1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public RibbonForm1()
        {
            InitializeComponent();
            
            treeListProject.OptionsBehavior.Editable = false;
        }

        
        TreeListNode siteNode = null;
        TreeListNode facilityNode = null;
        TreeListNode equipmentNode = null;
        TreeListNode componentNode = null;
        TreeListNode recordNode = null;
        public static string siteName = null;
        public static string facilityName = null;
        public static string equipmentName = null;
        public static string componentName = null;
        private void treeListProject_DoubleClick(object sender, EventArgs e)
        {
            TreeList tree = sender as TreeList;
            TreeListHitInfo hi = tree.CalcHitInfo(tree.PointToClient(Control.MousePosition));
            //TreeListHitInfo hi = tree.CalcHitInfo(e.Lo);
            //hi.Column.RowCount
            if (hi.Node != null)
            //if (hi.Node.GetDisplayText(0) == "Record 1")
            {
                addNewTab("Record 1", ass);
                btnSave.Enabled = true;
            }
        }
        private void treeListProject_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            TreeList tree = sender as TreeList;

            if (e.Button == MouseButtons.Right && ModifierKeys == Keys.None

                && tree.State == TreeListState.Regular)
            {



                System.Drawing.Point pt = tree.PointToClient(MousePosition);

                TreeListHitInfo info = tree.CalcHitInfo(pt);

                if (info.HitInfoType == HitInfoType.Cell)
                {

                    //SavedFocused = tree.FocusedNode;

                    tree.FocusedNode = info.Node;

                    //NeedRestoreFocused = true;

                    //popupMenu1.ShowPopup(MousePosition);

                }

            }
        }
        
        private void treeListProject_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                TreeListHitInfo hitInfo = (sender as TreeList).CalcHitInfo(e.Location);
                TreeListNode node = null;
                TreeListMenu menu = new TreeListMenu(sender as TreeList);
                DXMenuItem menuItem = null;
                if (hitInfo.HitInfoType == HitInfoType.Cell)
                {
                    node = hitInfo.Node;
                    try
                    {
                        string hitinfo = hitInfo.Node.GetDisplayText(0);
                        if (hitinfo == siteName)
                            menuItem = new DXMenuItem("Add a New Facility", new EventHandler(_addNewFacilityNode));
                        else if(hitinfo == facilityName)
                            menuItem = new DXMenuItem("Add a New Equipment", new EventHandler(_addNewEquipmentNode));
                        else if(hitinfo == equipmentName)
                            menuItem = new DXMenuItem("Add a New Component", new EventHandler(_addNewComponentNode));
                        else
                            menuItem = new DXMenuItem("Add a New Record", new EventHandler(_addNewRecodeNode));
                    }
                    catch
                    {
                        MessageBox.Show("Fail");
                    }
                }
                if (node == null)
                {
                    menuItem = new DXMenuItem("Add a New Site", new EventHandler(_addNewSiteNode));
                }

                // Create a menu with a 'Delete Node' item.
                //menuItem.Tag = node;
                menu.Items.Add(menuItem);
                // Show the menu.
                menu.Show(e.Location);
            }
            else
                return;
        }
        private void _addNewSiteNode(object sender, EventArgs e)
        {
            addNewSiteNode();
        }
        private void _addNewFacilityNode(object sender, EventArgs e)
        {
            addNewFacilityNode();
        }
        private void _addNewEquipmentNode(object sender, EventArgs e)
        {
            addNewEquipmentNode();
        }
        private void _addNewComponentNode(object sender, EventArgs e)
        {
            addNewComponentNode();
        }
        private void _addNewRecodeNode(object sender, EventArgs e)
        {
            addNewRecodeNode();
        }
        #region Button Event
        RBI.PRE.subForm.InputDataForm.NewSite site;
        private void addNewSiteNode()
        {
            treeListProject.BeginUpdate();
            TreeListColumn col1 = treeListProject.Columns.Add();
            col1.Caption = "List";
            col1.VisibleIndex = 0;
            treeListProject.EndUpdate();
            //treeListProject.BeginUnboundLoad();
            //// Create a root node .
            //TreeListNode parentForRootNodes = null;
            //TreeListNode rootNode = treeListProject.AppendNode(
            //    new object[] { "Alfreds Futterkiste" },
            //    parentForRootNodes);
            //// Create a child of the rootNode
            //treeListProject.AppendNode(new object[] { "Suyama, Michael" }, rootNode);
            //// Creating more nodes
            //// ...
            //treeListProject.EndUnboundLoad();
             site = new PRE.subForm.InputDataForm.NewSite();
            site.ShowDialog();
            treeListProject.BeginUnboundLoad();
            siteNode = treeListProject.AppendNode(
                new object[] { siteName }, siteNode);
            treeListProject.EndUnboundLoad();
        }
        private void btnPlant_ItemClick(object sender, ItemClickEventArgs e)
        {
            addNewSiteNode();
        }
        FacilityInput faci;
        private void addNewFacilityNode()
        {
             faci = new FacilityInput();
            faci.ShowDialog();
            treeListProject.BeginUnboundLoad();
            facilityNode = treeListProject.AppendNode(
                new object[] { facilityName }, siteNode);
            treeListProject.EndUnboundLoad();
        }
        private void btnFacility_ItemClick(object sender, ItemClickEventArgs e)
        {
            addNewFacilityNode();
        }
        RBI.PRE.subForm.InputDataForm.Equipment eq1;
        private void addNewEquipmentNode()
        {
             eq1 = new PRE.subForm.InputDataForm.Equipment();
            eq1.ShowDialog();
            treeListProject.BeginUnboundLoad();
            equipmentNode = treeListProject.AppendNode(
                new object[] { equipmentName }, facilityNode);
            treeListProject.EndUnboundLoad();
        }
        private void btnEquipment_ItemClick(object sender, ItemClickEventArgs e)
        {
            addNewEquipmentNode();
        }
        RBI.PRE.subForm.InputDataForm.NewComponent comp1;
        private void addNewComponentNode()
        {
             comp1 = new PRE.subForm.InputDataForm.NewComponent();
            comp1.ShowDialog();
            treeListProject.BeginUnboundLoad();
            componentNode = treeListProject.AppendNode(
                new object[] { componentName }, equipmentNode);
            imageCollection1.Images.IndexOf(1);
            treeListProject.EndUnboundLoad();
        }
        private void btnComponent_ItemClick(object sender, ItemClickEventArgs e)
        {
            addNewComponentNode();
        }
        private void addNewRecodeNode()
        {
            treeListProject.BeginUnboundLoad();
            recordNode = treeListProject.AppendNode(new object[] { "Record 1" }, componentNode);
            treeListProject.EndUnboundLoad();
        }
        private void btnRecord_ItemClick(object sender, ItemClickEventArgs e)
        {
            addNewRecodeNode();
        }
        private void btnRecalculate_ItemClick(object sender, ItemClickEventArgs e)
        {
            //closeAllTab();
            //Thread cal = new Thread(Calculator);
            //cal.Start();
            //while (cal.IsAlive)
            //{
            //    WatingForm wait = new WatingForm();
            //    wait.process = cal.IsAlive;
            //    wait.ShowDialog();
            //}
            //UCDevexpress risk = new UCDevexpress();
            //addNewTab("Risk Summary", risk);
        }
        private void btnExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult da = MessageBox.Show("Do you want to close program?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (da == DialogResult.Yes)
                System.Windows.Forms.Application.Exit();
            else return;
        }
        private void btnRiskSummary_Click(object sender, EventArgs e)
        {
            //Thread cal = new Thread(Calculator);
            //cal.Start();
            //while (cal.IsAlive)
            //{
            //    WatingForm wait = new WatingForm();
            //    wait.process = cal.IsAlive;
            //    wait.ShowDialog();
            //}
            
            UCAssessmentInfo assessmentInfo = new UCAssessmentInfo();
            //addNewTab("Risk Summary", risk);
            DevExpress.XtraTab.XtraTabPage tabPage = new DevExpress.XtraTab.XtraTabPage();
            
            tabPage.Name = "tabAssessment";
            tabPage.Text = "Assessment Information";
            tabPage.Controls.Add(assessmentInfo);
            assessmentInfo.Dock = DockStyle.Fill;
            xtraTabData.TabPages.Add(tabPage);
            tabPage.Show();
        }
        private void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                //Calculation();
                Calculation_Excel();
            }
            catch
            {
                MessageBox.Show("Chưa tính được", "Cortek RBI");
            }
        }
        UCCoatLiningIsulationCladding coat = new UCCoatLiningIsulationCladding();
        UCAssessmentInfo ass = new UCAssessmentInfo();
        UCComponentProperties comp = new UCComponentProperties();
        UCEquipmentProperties eq = new UCEquipmentProperties();
        UCMaterial ma = new UCMaterial();
        UCOperatingCondition op = new UCOperatingCondition();
        UCStream st = new UCStream();
        UCNoInspection No = new UCNoInspection();
        UCRiskFactor risk = new UCRiskFactor();
        private void navAssessmentInfo_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (xtraTabData.SelectedTabPageIndex == 0) return;
            //kiem tra xem co chua user control nay chua? chua thi add ko thi thoi
            if (xtraTabData.TabPages.TabControl.SelectedTabPage.Controls.Contains(ass)) return;
            xtraTabData.TabPages.TabControl.SelectedTabPage.Controls.Clear();
            xtraTabData.TabPages.TabControl.SelectedTabPage.Controls.Add(ass);
        }

        private void navEquipment_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (xtraTabData.SelectedTabPageIndex == 0) return;
            if (xtraTabData.TabPages.TabControl.SelectedTabPage.Controls.Contains(eq)) return;
            xtraTabData.TabPages.TabControl.SelectedTabPage.Controls.Clear();
            xtraTabData.TabPages.TabControl.SelectedTabPage.Controls.Add(eq);
        }

        private void navComponent_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (xtraTabData.SelectedTabPageIndex == 0) return;
            if (xtraTabData.TabPages.TabControl.SelectedTabPage.Controls.Contains(comp)) return;
            xtraTabData.TabPages.TabControl.SelectedTabPage.Controls.Clear();
            xtraTabData.TabPages.TabControl.SelectedTabPage.Controls.Add(comp);
        }

        private void navOperating_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (xtraTabData.SelectedTabPageIndex == 0) return;
            if (xtraTabData.TabPages.TabControl.SelectedTabPage.Controls.Contains(op)) return;
            xtraTabData.TabPages.TabControl.SelectedTabPage.Controls.Clear();
            xtraTabData.TabPages.TabControl.SelectedTabPage.Controls.Add(op);
        }

        private void navMaterial_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (xtraTabData.SelectedTabPageIndex == 0) return;
            if (xtraTabData.TabPages.TabControl.SelectedTabPage.Controls.Contains(ma)) return;
            xtraTabData.TabPages.TabControl.SelectedTabPage.Controls.Clear();
            xtraTabData.TabPages.TabControl.SelectedTabPage.Controls.Add(ma);
        }

        private void navCoating_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (xtraTabData.SelectedTabPageIndex == 0) return;
            if (xtraTabData.TabPages.TabControl.SelectedTabPage.Controls.Contains(coat)) return;
            xtraTabData.TabPages.TabControl.SelectedTabPage.Controls.Clear();
            xtraTabData.TabPages.TabControl.SelectedTabPage.Controls.Add(coat);
        }

        private void navNoInspection_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (xtraTabData.SelectedTabPageIndex == 0) return;
            if (xtraTabData.TabPages.TabControl.SelectedTabPage.Controls.Contains(No)) return;
            xtraTabData.TabPages.TabControl.SelectedTabPage.Controls.Clear();
            xtraTabData.TabPages.TabControl.SelectedTabPage.Controls.Add(No);
        }

        private void navStream_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (xtraTabData.SelectedTabPageIndex == 0) return;
            if (xtraTabData.TabPages.TabControl.SelectedTabPage.Controls.Contains(st)) return;
            xtraTabData.TabPages.TabControl.SelectedTabPage.Controls.Clear();
            xtraTabData.TabPages.TabControl.SelectedTabPage.Controls.Add(st);
        }
        private void navRiskFactor_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (xtraTabData.SelectedTabPageIndex == 0) return;
            if (xtraTabData.TabPages.TabControl.SelectedTabPage.Controls.Contains(risk)) return;
            xtraTabData.TabPages.TabControl.SelectedTabPage.Controls.Clear();
            xtraTabData.TabPages.TabControl.SelectedTabPage.Controls.Add(risk);
            risk.riskFactor();
        }
        #endregion
        private void xtraTabData_CloseButtonClick(object sender, EventArgs e)
        {
            DevExpress.XtraTab.XtraTabControl tabControl = sender as DevExpress.XtraTab.XtraTabControl;
            DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs arg = e as DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs;
            (arg.Page as DevExpress.XtraTab.XtraTabPage).Dispose();
        }
      
        //UCNoInspection NoInsp = new UCNoInspection();
        //PRE.subForm.InputDataForm.Equipment eqInput = new PRE.subForm.InputDataForm.Equipment();
        private void addNewTab(string tabname, UserControl uc)
        {
            foreach (DevExpress.XtraTab.XtraTabPage tabpage in xtraTabData.TabPages)
            {
                if (tabpage.Text == tabname)
                    return;
            }
            string _tabname = "tab" + tabname.Split(' ');
            DevExpress.XtraTab.XtraTabPage tabPage = new DevExpress.XtraTab.XtraTabPage();
            if (tabPage.Name.Equals(_tabname))
                tabPage.Show();
            else
                tabPage.Name = _tabname;
            tabPage.Text = tabname;
            tabPage.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            if (xtraTabData.TabPages.Contains(tabPage)) return;
            xtraTabData.TabPages.Add(tabPage);
            tabPage.Show();
        }
        //private void Calculation()
        //{
        //    RW_EQUIPMENT rweq = eq.getData();
        //    RW_EQUIPMENT rweq1 = ass.getData1();
        //    RW_COMPONENT rwcom = comp.getData();
        //    RW_MATERIAL rwma = ma.getData();
        //    //can xem lai properties thuoc get stream nao
        //    RW_STREAM rwstream1 = st.getData();
        //    RW_STREAM rwstream2 = op.getData();
        //    RW_COATING rwcoat = coat.getData();
        //    NO_INSPECTION noInsp = NoInsp.getData();
        //    EQUIPMENT_MASTER eqmaster = eqInput.getData1();
        //    EQUIPMENT_TYPE eqType = eqInput.getData2();
        //    MSSQL_DM_CAL cal = new MSSQL_DM_CAL();
        //    //<input thinning>
        //    cal.Diametter = rwcom.NominalDiameter;
        //    cal.NomalThick = rwcom.NominalThickness;
        //    cal.CurrentThick = rwcom.CurrentThickness;
        //    cal.MinThickReq = rwcom.MinReqThickness;
        //    cal.CorrosionRate = rwcom.CurrentCorrosionRate;

        //    cal.ProtectedBarrier = rweq.DowntimeProtectionUsed == 1 ? true : false; //xem lai
        //    cal.CladdingCorrosionRate = rwcoat.CladdingCorrosionRate;
        //    cal.InternalCladding = rwcoat.InternalCladding == 1 ? true : false;
        //    cal.NoINSP_THINNING = noInsp.numThinning;
        //    cal.EFF_THIN = noInsp.effThinning;
        //    cal.OnlineMonitoring = rweq.OnlineMonitoring;
        //    cal.HighlyEffectDeadleg = rweq.HighlyDeadlegInsp == 1 ? true : false;
        //    cal.ContainsDeadlegs = rweq.ContainsDeadlegs == 1 ? true : false;
        //    //tank maintain653 trong Tank
        //    cal.AdjustmentSettle = rweq.AdjustmentSettle;
        //    cal.ComponentIsWeld = rweq.ComponentIsWelded == 1 ? true : false;
        //    //</thinning>

        //    //<input linning>
        //    cal.LinningType = rwcoat.InternalLinerType;
        //    cal.LINNER_ONLINE = rweq.LinerOnlineMonitoring == 1 ? true : false;
        //    cal.LINNER_CONDITION = rwcoat.InternalLinerCondition;
        //    cal.INTERNAL_LINNING = rwcoat.InternalLining == 1 ? true : false;
        //    //Yearinservice hiệu tham số giữa lần tính toán và ngày cài đặt hệ thống

        //    //</input linning>

        //    //<input SCC CAUSTIC>
        //    cal.CAUSTIC_INSP_EFF = noInsp.effCaustic;
        //    cal.CAUSTIC_INSP_NUM = noInsp.numCaustic;
        //    cal.HEAT_TREATMENT = rwma.HeatTreatment;
        //    cal.NaOHConcentration = rwstream1.NaOHConcentration;
        //    cal.HEAT_TRACE = rweq.HeatTraced == 1 ? true : false;
        //    cal.STEAM_OUT = rweq.SteamOutWaterFlush == 1 ? true : false;
        //    //</SCC CAUSTIC>

        //    //<input SSC Amine>
        //    cal.AMINE_INSP_EFF = noInsp.effAmine;
        //    cal.AMINE_INSP_NUM = noInsp.numAmine;
        //    cal.AMINE_EXPOSED = rwstream1.ExposedToGasAmine == 1 ? true : false;
        //    cal.AMINE_SOLUTION = rwstream1.AmineSolution;
        //    //</input SSC Amine>

        //    //<input Sulphide Stress Cracking>
        //    cal.ENVIRONMENT_H2S_CONTENT = rwstream1.H2S == 1 ? true : false;
        //    cal.AQUEOUS_OPERATOR = rwstream1.AqueousOperation == 1 ? true : false;
        //    cal.AQUEOUS_SHUTDOWN = rwstream1.AqueousShutdown == 1 ? true : false;
        //    cal.SULPHIDE_INSP_EFF = noInsp.effSulphide;
        //    cal.SULPHIDE_INSP_NUM = noInsp.numSulphide;
        //    cal.H2SContent = rwstream1.H2SInWater;
        //    cal.PH = rwstream1.WaterpH;
        //    cal.PRESENT_CYANIDE = rwstream1.Cyanide == 1 ? true : false;
        //    cal.BRINNEL_HARDNESS = rwcom.BrinnelHardness;
        //    //</Sulphide Stress Cracking>

        //    //<input HIC/SOHIC-H2S>
        //    cal.SULFUR_INSP_EFF = noInsp.effHICSOHIC_H2S;
        //    cal.SULFUR_INSP_NUM = noInsp.numHICSOHIC_H2S;
        //    cal.SULFUR_CONTENT = rwma.SulfurContent;
        //    //</HIC/SOHIC-H2S>

        //    //<input PTA Cracking>
        //    cal.PTA_SUSCEP = rwma.IsPTA == 1 ? true : false;
        //    cal.NICKEL_ALLOY = rwma.NickelBased == 1 ? true : false;
        //    cal.EXPOSED_SULFUR = rwstream1.ExposedToSulphur == 1 ? true : false;
        //    cal.PTA_INSP_EFF = noInsp.effPTA;
        //    cal.PTA_INSP_NUM = noInsp.numPTA;
        //    cal.ExposedSH2OOperation = rweq.PresenceSulphidesO2 == 1 ? true : false;
        //    cal.ExposedSH2OShutdown = rweq.PresenceSulphidesO2Shutdown == 1 ? true : false;
        //    cal.ThermalHistory = rweq.ThermalHistory;
        //    cal.PTAMaterial = rwma.PTAMaterialCode;
        //    cal.DOWNTIME_PROTECTED = rweq.DowntimeProtectionUsed == 1 ? true : false;
        //    //</PTA Cracking>

        //    //<input CLSCC>
        //    cal.CLSCC_INSP_EFF = noInsp.effCLSCC;
        //    cal.CLSCC_INSP_NUM = noInsp.numCLSCC;
        //    cal.EXTERNAL_EXPOSED_FLUID_MIST = rweq.MaterialExposedToClExt == 1 ? true : false;
        //    cal.INTERNAL_EXPOSED_FLUID_MIST = rwstream1.MaterialExposedToClInt == 1 ? true : false;
        //    cal.CHLORIDE_ION_CONTENT = rwstream1.Chloride;
        //    //</CLSCC>

        //    //<input HSC-HF>
        //    cal.HSC_HF_INSP_EFF = noInsp.effHSC_HF;
        //    cal.HSC_HF_INSP_NUM = noInsp.numHSC_HF;
        //    //</HSC-HF>

        //    //<input External Corrosion>
        //    cal.EXTERNAL_INSP_EFF = noInsp.effExternalCorrosion;
        //    cal.EXTERNAL_INSP_NUM = noInsp.numExternalCorrosion;
        //    //</External Corrosion>

        //    //<input HIC/SOHIC-HF>
        //    cal.HICSOHIC_INSP_EFF = noInsp.effHICSOHIC_HF;
        //    cal.HICSOHIC_INSP_NUM = noInsp.numHICSOHIC_HF;
        //    cal.HF_PRESENT = rwstream1.Hydrofluoric == 1 ? true : false;
        //    //</HIC/SOHIC-HF>

        //    //<input CUI DM>
        //    cal.INTERFACE_SOIL_WATER = rweq.InterfaceSoilWater == 1 ? true : false;
        //    cal.SUPPORT_COATING = rwcoat.SupportConfigNotAllowCoatingMaint == 1 ? true : false;
        //    cal.INSULATION_TYPE = rwcoat.ExternalInsulationType;
        //    cal.CUI_INSP_EFF = noInsp.effCUI;
        //    cal.CUI_INSP_NUM = noInsp.numCUI;
        //    cal.CUI_INSP_DATE = rwcoat.ExternalCoatingDate;
        //    cal.CUI_PERCENT_1 = rwstream2.CUI_PERCENT_1;
        //    cal.CUI_PERCENT_2 = rwstream2.CUI_PERCENT_2;
        //    cal.CUI_PERCENT_3 = rwstream2.CUI_PERCENT_3;
        //    cal.CUI_PERCENT_4 = rwstream2.CUI_PERCENT_4;
        //    cal.CUI_PERCENT_5 = rwstream2.CUI_PERCENT_5;
        //    cal.CUI_PERCENT_6 = rwstream2.CUI_PERCENT_6;
        //    cal.CUI_PERCENT_7 = rwstream2.CUI_PERCENT_7;
        //    cal.CUI_PERCENT_8 = rwstream2.CUI_PERCENT_8;
        //    cal.CUI_PERCENT_9 = rwstream2.CUI_PERCENT_9;
        //    cal.CUI_PERCENT_10 = rwstream2.CUI_PERCENT_10;
        //    //</CUI DM>

        //    //<input External CLSCC>
        //    cal.EXTERN_CLSCC_INSP_EFF = noInsp.effExternal_CLSCC;
        //    cal.EXTERN_CLSCC_INSP_NUM = noInsp.numExternal_CLSCC;
        //    //</External CLSCC>

        //    //<input External CUI CLSCC>
        //    cal.EXTERN_CLSCC_CUI_INSP_EFF = noInsp.effCUI;
        //    cal.EXTERN_CLSCC_CUI_INSP_NUM = noInsp.numCUI;
        //    cal.EXTERNAL_INSULATION = rwcoat.ExternalInsulation == 1 ? true : false;
        //    cal.COMPONENT_INSTALL_DATE = rweq1.CommissionDate;
        //    cal.CRACK_PRESENT = rwcom.CracksPresent == 1 ? true : false;
        //    cal.EXTERNAL_EVIRONMENT = rweq.ExternalEnvironment;
        //    cal.EXTERN_COAT_QUALITY = rwcoat.ExternalCoatingQuality;
        //    cal.PIPING_COMPLEXITY = rwcom.ComplexityProtrusion;
        //    cal.INSULATION_CONDITION = rwcoat.InsulationCondition;
        //    cal.INSULATION_CHLORIDE = rwcoat.InsulationContainsChloride == 1 ? true : false;
        //    //</External CUI CLSCC>

        //    //<input HTHA>
        //    cal.HTHA_EFFECT = noInsp.effHTHA;
        //    cal.HTHA_NUM_INSP = noInsp.numHTHA;
        //    cal.MATERIAL_SUSCEP_HTHA = rwma.IsHTHA == 1 ? true : false;
        //    cal.HTHA_MATERIAL = rwma.HTHAMaterialCode; //check lai
        //    cal.HTHA_PRESSURE = rwstream2.H2SPartialPressure;
        //    cal.CRITICAL_TEMP = rwstream2.CriticalExposureTemperature; //check lai
        //    cal.DAMAGE_FOUND = rwcom.DamageFoundInspection == 1 ? true : false;
        //    //</HTHA>

        //    //<input Brittle>
        //    cal.LOWEST_TEMP = rweq.YearLowestExpTemp == 1 ? true : false;
        //    //</Brittle>

        //    //<input temper Embrittle>
        //    cal.TEMPER_SUSCEP = rwma.Temper == 1 ? true : false;
        //    cal.PWHT = rweq.PWHT == 1 ? true : false;
        //    cal.BRITTLE_THICK = rwma.BrittleFractureThickness;
        //    cal.CARBON_ALLOY = rwma.CarbonLowAlloy == 1 ? true : false;
        //    cal.DELTA_FATT = rwcom.DeltaFATT;
        //    //</Temper Embrittle>

        //    //<input 885>
        //    cal.MAX_OP_TEMP = rwstream2.MaxOperatingTemperature;
        //    cal.MIN_OP_TEMP = rwstream2.MinOperatingTemperature;
        //    cal.MIN_DESIGN_TEMP = rwma.MinDesignTemperature;
        //    cal.REF_TEMP = rwma.ReferenceTemperature;
        //    cal.CHROMIUM_12 = rwma.ChromeMoreEqual12 == 1 ? true : false;
        //    //</885>

        //    //<input Sigma>
        //    cal.AUSTENITIC_STEEL = rwma.Austenitic == 1 ? true : false;
        //    cal.PERCENT_SIGMA = rwma.SigmaPhase;
        //    //</Sigma>

        //    //<input Piping Mechanical>
        //    //cal.EquipmentType = eqType.EquipmentTypeName;
        //    cal.EquipmentType = "Piping";
        //    cal.PREVIOUS_FAIL = rwcom.PreviousFailures;
        //    cal.AMOUNT_SHAKING = rwcom.ShakingAmount;
        //    cal.TIME_SHAKING = rwcom.ShakingTime;
        //    cal.CYLIC_LOAD = rwcom.CyclicLoadingWitin15_25m;
        //    cal.CORRECT_ACTION = rwcom.CorrectiveAction;
        //    cal.NUM_PIPE = rwcom.NumberPipeFittings;
        //    cal.PIPE_CONDITION = rwcom.PipeCondition;
        //    cal.JOINT_TYPE = rwcom.BranchJointType; //check lai
        //    cal.BRANCH_DIAMETER = rwcom.BranchDiameter;
        //    //</Piping Mechanical>

        //    //<goi ham tinh toan DF>
        //    MessageBox.Show("Df_Thinning = " + cal.DF_THIN(10).ToString() +"\n"+
        //     "Df_Linning = " + cal.DF_LINNING(10).ToString()+"\n"+
        //     "Df_Caustic = " + cal.DF_CAUSTIC(10).ToString()+"\n"+
        //     "Df_Amine = " + cal.DF_AMINE(10).ToString() +"\n"+
        //     "Df_Sulphide = " + cal.DF_SULPHIDE(10).ToString() +"\n"+
        //     "Df_PTA = " + cal.DF_PTA(11).ToString() +"\n"+
        //     "Df_PTA = " + cal.DF_PTA(10) +"\n"+
        //     "Df_CLSCC = " + cal.DF_CLSCC(10) +"\n"+
        //     "Df_HSC-HF = " + cal.DF_HSCHF(10) +"\n"+
        //     "Df_HIC/SOHIC-HF = " + cal.DF_HIC_SOHIC_HF(10) +"\n"+
        //     "Df_ExternalCorrosion = " + cal.DF_EXTERNAL_CORROSION(10) +"\n"+
        //     "Df_CUI = " + cal.DF_CUI(10) +"\n"+
        //     "Df_EXTERNAL_CLSCC = " + cal.DF_EXTERN_CLSCC()  +"\n"+
        //     "Df_EXTERNAL_CUI_CLSCC = " + cal.DF_CUI_CLSCC()+"\n"+
        //     "Df_HTHA = " + cal.DF_HTHA(10)+"\n"+
        //     "Df_Brittle = " + cal.DF_BRITTLE()+"\n"+
        //     "Df_Temper_Embrittle = " + cal.DF_TEMP_EMBRITTLE() +"\n"+
        //     "Df_885 = " + cal.DF_885() +"\n"+
        //     "Df_Sigma = " + cal.DF_SIGMA() +"\n"+
        //     "Df_Piping = " + cal.DF_PIPE(), "Damage Factor");
        //    //</ket thuc tinh toan DF>
        //}
        public static RW_EQUIPMENT rweq1;
        public static RW_COMPONENT rwcom1;
        public static RW_COATING rwcoat1;
        public static RW_MATERIAL rwma1;
        public static RW_STREAM rwstream_1;
        public static RW_STREAM rwstream_2;
        public static RW_ASSESSMENT ass1;
        private List<string> riskExcelData = new List<string>();

        private RiskSummary riskExcel = new RiskSummary();
        private void Calculation_Excel()
        {
            //ImportExcel sheet = new ImportExcel();
            //RW_EQUIPMENT rweq = sheet.getDataEquipment();
            //RW_COMPONENT rwcom = sheet.getDataComponent();
            //RW_COATING rwcoat = sheet.getDataCoating();
            MSSQL_DM_CAL cal = new MSSQL_DM_CAL();
            //<input thinning>
            cal.Diametter = rwcom1.NominalDiameter;
            cal.NomalThick = rwcom1.NominalThickness;
            cal.CurrentThick = rwcom1.CurrentThickness;
            cal.MinThickReq = rwcom1.MinReqThickness;
            cal.CorrosionRate = rwcom1.CurrentCorrosionRate;

            cal.ProtectedBarrier = rweq1.DowntimeProtectionUsed == 1 ? true : false; //xem lai
            cal.CladdingCorrosionRate = rwcoat1.CladdingCorrosionRate;
            cal.InternalCladding = rwcoat1.InternalCladding == 1 ? true : false;
            //cal.NoINSP_THINNING = noInsp.numThinning;
            //cal.EFF_THIN = noInsp.effThinning;
            cal.OnlineMonitoring = rweq1.OnlineMonitoring;
            cal.HighlyEffectDeadleg = rweq1.HighlyDeadlegInsp == 1 ? true : false;
            cal.ContainsDeadlegs = rweq1.ContainsDeadlegs == 1 ? true : false;
            //tank maintain653 trong Tank
            cal.AdjustmentSettle = rweq1.AdjustmentSettle;
            cal.ComponentIsWeld = rweq1.ComponentIsWelded == 1 ? true : false;
            //</thinning>

            //<input linning>
            cal.LinningType = rwcoat1.InternalLinerType;
            cal.LINNER_ONLINE = rweq1.LinerOnlineMonitoring == 1 ? true : false;
            cal.LINNER_CONDITION = rwcoat1.InternalLinerCondition;
            cal.INTERNAL_LINNING = rwcoat1.InternalLining == 1 ? true : false;
            cal.YEAR_IN_SERVICE = 10;//Convert.ToInt32(ass1.AssessmentDate - rweq1.CommissionDate);
            //Yearinservice hiệu tham số giữa lần tính toán và ngày cài đặt hệ thống

            //</input linning>

            //<input SCC CAUSTIC>
            //cal.CAUSTIC_INSP_EFF = noInsp.effCaustic;
            //cal.CAUSTIC_INSP_NUM = noInsp.numCaustic;
            cal.HEAT_TREATMENT = rwma1.HeatTreatment;
            cal.NaOHConcentration = rwstream_1.NaOHConcentration;
            cal.HEAT_TRACE = rweq1.HeatTraced == 1 ? true : false;
            cal.STEAM_OUT = rweq1.SteamOutWaterFlush == 1 ? true : false;
            //</SCC CAUSTIC>

            //<input SSC Amine>
            //cal.AMINE_INSP_EFF = noInsp.effAmine;
            //cal.AMINE_INSP_NUM = noInsp.numAmine;
            cal.AMINE_EXPOSED = rwstream_1.ExposedToGasAmine == 1 ? true : false;
            cal.AMINE_SOLUTION = rwstream_1.AmineSolution;
            //</input SSC Amine>

            //<input Sulphide Stress Cracking>
            cal.ENVIRONMENT_H2S_CONTENT = rwstream_1.H2S == 1 ? true : false;
            cal.AQUEOUS_OPERATOR = rwstream_1.AqueousOperation == 1 ? true : false;
            cal.AQUEOUS_SHUTDOWN = rwstream_1.AqueousShutdown == 1 ? true : false;
            //cal.SULPHIDE_INSP_EFF = noInsp.effSulphide;
            //cal.SULPHIDE_INSP_NUM = noInsp.numSulphide;
            cal.H2SContent = rwstream_1.H2SInWater;
            cal.PH = rwstream_1.WaterpH;
            cal.PRESENT_CYANIDE = rwstream_1.Cyanide == 1 ? true : false;
            cal.BRINNEL_HARDNESS = rwcom1.BrinnelHardness;
            //</Sulphide Stress Cracking>

            //<input HIC/SOHIC-H2S>
            //cal.SULFUR_INSP_EFF = noInsp.effHICSOHIC_H2S;
            //cal.SULFUR_INSP_NUM = noInsp.numHICSOHIC_H2S;
            cal.SULFUR_CONTENT = rwma1.SulfurContent;
            //</HIC/SOHIC-H2S>

            //<input PTA Cracking>
            cal.PTA_SUSCEP = rwma1.IsPTA == 1 ? true : false;
            cal.NICKEL_ALLOY = rwma1.NickelBased == 1 ? true : false;
            cal.EXPOSED_SULFUR = rwstream_1.ExposedToSulphur == 1 ? true : false;
            //cal.PTA_INSP_EFF = noInsp.effPTA;
            //cal.PTA_INSP_NUM = noInsp.numPTA;
            cal.ExposedSH2OOperation = rweq1.PresenceSulphidesO2 == 1 ? true : false;
            cal.ExposedSH2OShutdown = rweq1.PresenceSulphidesO2Shutdown == 1 ? true : false;
            cal.ThermalHistory = rweq1.ThermalHistory;
            cal.PTAMaterial = rwma1.PTAMaterialCode;
            cal.DOWNTIME_PROTECTED = rweq1.DowntimeProtectionUsed == 1 ? true : false;
            //</PTA Cracking>

            //<input CLSCC>
            //cal.CLSCC_INSP_EFF = noInsp.effCLSCC;
            //cal.CLSCC_INSP_NUM = noInsp.numCLSCC;
            cal.EXTERNAL_EXPOSED_FLUID_MIST = rweq1.MaterialExposedToClExt == 1 ? true : false;
            cal.INTERNAL_EXPOSED_FLUID_MIST = rwstream_1.MaterialExposedToClInt == 1 ? true : false;
            cal.CHLORIDE_ION_CONTENT = rwstream_1.Chloride;
            //</CLSCC>

            //<input HSC-HF>
            //cal.HSC_HF_INSP_EFF = noInsp.effHSC_HF;
            //cal.HSC_HF_INSP_NUM = noInsp.numHSC_HF;
            //</HSC-HF>

            //<input External Corrosion>
            //cal.EXTERNAL_INSP_EFF = noInsp.effExternalCorrosion;
            //cal.EXTERNAL_INSP_NUM = noInsp.numExternalCorrosion;
            //</External Corrosion>

            //<input HIC/SOHIC-HF>
            //cal.HICSOHIC_INSP_EFF = noInsp.effHICSOHIC_HF;
            //cal.HICSOHIC_INSP_NUM = noInsp.numHICSOHIC_HF;
            cal.HF_PRESENT = rwstream_1.Hydrofluoric == 1 ? true : false;
            //</HIC/SOHIC-HF>

            //<input CUI DM>
            cal.INTERFACE_SOIL_WATER = rweq1.InterfaceSoilWater == 1 ? true : false;
            cal.SUPPORT_COATING = rwcoat1.SupportConfigNotAllowCoatingMaint == 1 ? true : false;
            cal.INSULATION_TYPE = rwcoat1.ExternalInsulationType;
            //cal.CUI_INSP_EFF = noInsp.effCUI;
            //cal.CUI_INSP_NUM = noInsp.numCUI;
            cal.CUI_INSP_DATE = rwcoat1.ExternalCoatingDate;
            cal.CUI_PERCENT_1 = rwstream_2.CUI_PERCENT_1;
            cal.CUI_PERCENT_2 = rwstream_2.CUI_PERCENT_2;
            cal.CUI_PERCENT_3 = rwstream_2.CUI_PERCENT_3;
            cal.CUI_PERCENT_4 = rwstream_2.CUI_PERCENT_4;
            cal.CUI_PERCENT_5 = rwstream_2.CUI_PERCENT_5;
            cal.CUI_PERCENT_6 = rwstream_2.CUI_PERCENT_6;
            cal.CUI_PERCENT_7 = rwstream_2.CUI_PERCENT_7;
            cal.CUI_PERCENT_8 = rwstream_2.CUI_PERCENT_8;
            cal.CUI_PERCENT_9 = rwstream_2.CUI_PERCENT_9;
            cal.CUI_PERCENT_10 = rwstream_2.CUI_PERCENT_10;
            //</CUI DM>

            //<input External CLSCC>
            //cal.EXTERN_CLSCC_INSP_EFF = noInsp.effExternal_CLSCC;
            //cal.EXTERN_CLSCC_INSP_NUM = noInsp.numExternal_CLSCC;
            //</External CLSCC>

            //<input External CUI CLSCC>
            //cal.EXTERN_CLSCC_CUI_INSP_EFF = noInsp.effCUI;
            //cal.EXTERN_CLSCC_CUI_INSP_NUM = noInsp.numCUI;
            cal.EXTERNAL_INSULATION = rwcoat1.ExternalInsulation == 1 ? true : false;
            cal.COMPONENT_INSTALL_DATE = rweq1.CommissionDate;
            cal.CRACK_PRESENT = rwcom1.CracksPresent == 1 ? true : false;
            cal.EXTERNAL_EVIRONMENT = rweq1.ExternalEnvironment;
            cal.EXTERN_COAT_QUALITY = rwcoat1.ExternalCoatingQuality;
            cal.PIPING_COMPLEXITY = rwcom1.ComplexityProtrusion;
            cal.INSULATION_CONDITION = rwcoat1.InsulationCondition;
            cal.INSULATION_CHLORIDE = rwcoat1.InsulationContainsChloride == 1 ? true : false;
            //</External CUI CLSCC>

            //<input HTHA>
            //cal.HTHA_EFFECT = noInsp.effHTHA;
            //cal.HTHA_NUM_INSP = noInsp.numHTHA;
            cal.MATERIAL_SUSCEP_HTHA = rwma1.IsHTHA == 1 ? true : false;
            cal.HTHA_MATERIAL = rwma1.HTHAMaterialCode; //check lai
            cal.HTHA_PRESSURE = rwstream_2.H2SPartialPressure;
            cal.CRITICAL_TEMP = rwstream_2.CriticalExposureTemperature; //check lai
            cal.DAMAGE_FOUND = rwcom1.DamageFoundInspection == 1 ? true : false;
            //</HTHA>

            //<input Brittle>
            cal.LOWEST_TEMP = rweq1.YearLowestExpTemp == 1 ? true : false;
            //</Brittle>

            //<input temper Embrittle>
            cal.TEMPER_SUSCEP = rwma1.Temper == 1 ? true : false;
            cal.PWHT = rweq1.PWHT == 1 ? true : false;
            cal.BRITTLE_THICK = rwma1.BrittleFractureThickness;
            cal.CARBON_ALLOY = rwma1.CarbonLowAlloy == 1 ? true : false;
            cal.DELTA_FATT = rwcom1.DeltaFATT;
            //</Temper Embrittle>

            //<input 885>
            cal.MAX_OP_TEMP = rwstream_2.MaxOperatingTemperature;
            cal.MIN_OP_TEMP = rwstream_2.MinOperatingTemperature;
            cal.MIN_DESIGN_TEMP = rwma1.MinDesignTemperature;
            cal.REF_TEMP = rwma1.ReferenceTemperature;
            cal.CHROMIUM_12 = rwma1.ChromeMoreEqual12 == 1 ? true : false;
            //</885>

            //<input Sigma>
            cal.AUSTENITIC_STEEL = rwma1.Austenitic == 1 ? true : false;
            cal.PERCENT_SIGMA = rwma1.SigmaPhase;
            //</Sigma>

            //<input Piping Mechanical>
            //cal.EquipmentType = eqType.EquipmentTypeName;
            cal.EquipmentType = "Accumulator";
            cal.PREVIOUS_FAIL = rwcom1.PreviousFailures;
            cal.AMOUNT_SHAKING = rwcom1.ShakingAmount;
            cal.TIME_SHAKING = rwcom1.ShakingTime;
            cal.CYLIC_LOAD = rwcom1.CyclicLoadingWitin15_25m;
            cal.CORRECT_ACTION = rwcom1.CorrectiveAction;
            cal.NUM_PIPE = rwcom1.NumberPipeFittings;
            cal.PIPE_CONDITION = rwcom1.PipeCondition;
            cal.JOINT_TYPE = rwcom1.BranchJointType; //check lai
            cal.BRANCH_DIAMETER = rwcom1.BranchDiameter;
            
                MessageBox.Show("Df_Thinning = " + cal.DF_THIN(10).ToString() + "\n" +
                 "Df_Linning = " + cal.DF_LINNING(10).ToString() + "\n" +
                 "Df_Caustic = " + cal.DF_CAUSTIC(10).ToString() + "\n" +
                 "Df_Amine = " + cal.DF_AMINE(10).ToString() + "\n" +
                 "Df_Sulphide = " + cal.DF_SULPHIDE(10).ToString() + "\n" +
                 "Df_PTA = " + cal.DF_PTA(10).ToString() + "\n" +
                 "Df_CLSCC = " + cal.DF_CLSCC(10) + "\n" +
                 "Df_HSC-HF = " + cal.DF_HSCHF(10) + "\n" +
                 "Df_HIC/SOHIC-HF = " + cal.DF_HIC_SOHIC_HF(10) + "\n" +
                 "Df_ExternalCorrosion = " + cal.DF_EXTERNAL_CORROSION(10) + "\n" +
                 "Df_CUI = " + cal.DF_CUI(10) + "\n" +
                 "Df_EXTERNAL_CLSCC = " + cal.DF_EXTERN_CLSCC() + "\n" +
                 "Df_EXTERNAL_CUI_CLSCC = " + cal.DF_CUI_CLSCC() + "\n" +
                 "Df_HTHA = " + cal.DF_HTHA(10) + "\n" +
                 "Df_Brittle = " + cal.DF_BRITTLE() + "\n" +
                 "Df_Temper_Embrittle = " + cal.DF_TEMP_EMBRITTLE() + "\n" +
                 "Df_885 = " + cal.DF_885() + "\n" +
                 "Df_Sigma = " + cal.DF_SIGMA() + "\n" +
                 "Df_Piping = " + cal.DF_PIPE(), "Damage Factor");
              //risk summary
                riskExcel.InitThinningCategory = cal.DF_THIN(10).ToString();
        }
        //<Calculation>
        private String checkCatalog(String a)
        {
            if (a == "Highly Effective")
                return "A";
            else if (a == "Usually Effective")
                return "B";
            else if (a == "Fairly Effective")
                return "C";
            else if (a == "Poorly Effective")
                return "D";
            else
                return "E";
        }
        private int convertType(String a)
        {
            if (a == "C")
                return 3;
            if (a == "B")
                return 2;
            else
                return 1;
        }
        private void Calculator()
        {
            RiskBaseCalculate riskBase = new RiskBaseCalculate();

            // BUS
            BusRiskSummary bus = new BusRiskSummary();
            BusEquipmentTemp busTemp = new BusEquipmentTemp();
            List<EquipmentTemp> list = busTemp.loads();

            List<RiskSummary> listRisk = new List<RiskSummary>();
            RiskSummary risk = new RiskSummary();
            BusComponents busCOm = new BusComponents();
            //Component com;
            RBICalculatorConn rbicon = new RBICalculatorConn();
            consequenceAnalysisLvl1 financial = new consequenceAnalysisLvl1();
            //list.Count
            // Tinh toan
            BusFullPlant busFull = new BusFullPlant();
            List<FullPlantObject> listFull = busFull.load();

            BusRiskDemo riskDemo = new BusRiskDemo();
            for (int i = 0; i < listFull.Count; i++)
            {
                riskBase.equipmentType = listFull[i].EquipType;
                riskBase.componentType = listFull[i].ComponentType;
                riskBase.Fms = listFull[i].Fms;
                riskBase.crackPresent = listFull[i].CrackPresent;
                riskBase.internalLiner = listFull[i].InternalLiner;
                riskBase.thinning = listFull[i].CheckThin;
                riskBase.noInsp = listFull[i].NoInsp;
                riskBase.catalog_thin = checkCatalog(listFull[i].CatalogThin);
                riskBase.age = DateTime.Now.Year - int.Parse(listFull[i].LastIsnpDate.Substring(6, 4));
                riskBase.Trd = listFull[i].NominalThick / 25.4;
                riskBase.haveCladding = listFull[i].Cladding;
                riskBase.Crbm = listFull[i].CorrosionRateMetal * 39.4 / 1000;
                riskBase.Crcm = listFull[i].CorrosionRateCladding * 39.4 / 1000;
                riskBase.T = listFull[i].ThickBaseMetal / 25.4;
                riskBase.Tmin = listFull[i].MinimumThick / 25.4;
                riskBase.CA = listFull[i].CA / 25.4;
                riskBase.Fom_thin = listFull[i].Fom;
                riskBase.Fip = listFull[i].Fip;
                riskBase.Fdl = listFull[i].Fdl;
                riskBase.Fwd = listFull[i].Fwd;
                riskBase.Fam = listFull[i].Fam;
                riskBase.linningType = listFull[i].LinningType;
                riskBase.yearInService = listFull[i].YearInservice;
                riskBase.Fom_lin = listFull[i].Fom;
                riskBase.Flc = listFull[i].Flc;
                riskBase.catalog_caustic = checkCatalog(listFull[i].CatalogCaustic);
                riskBase.level_caust = listFull[i].LevelCaustic;
                riskBase.level_amine = listFull[i].LevelAmine;
                riskBase.catalog_amine = checkCatalog(listFull[i].CatalogAmine);
                riskBase.catalog_sulf = checkCatalog(listFull[i].CatalogSulfide);
                riskBase.pH = listFull[i].pH;
                riskBase.PWHT = listFull[i].NoPWHT;
                riskBase.isPWHT = listFull[i].PWHT;
                riskBase.catalog_hicH2S = checkCatalog(listFull[i].HIC_H2S_Catalog);
                riskBase.ppm_H2S = listFull[i].H2S_ppm;
                riskBase.Risk_target = 100000;
                financial.componentType = riskBase.componentType;
                financial.releasePhase = listFull[i].ReleaseFluid;
                financial.material = listFull[i].MaterialsCA;
                financial.fluid = listFull[i].Fluid;
                financial.fluidPhase = listFull[i].FluidPhase;
                financial.idealGasConstant = "B";
                financial.fluidType = listFull[i].FluidType;
                financial.detectionType = convertType(listFull[i].DetectionType);
                //financial.detectionType = 3;
                //financial.isolationType = 3;
                financial.isolationType = convertType(listFull[i].IsolationType);
                financial.p_s = listFull[i].StoredPressure * 145.0377;
                //financial.p_s = 102;
                financial.p_atm = listFull[i].AtmosphericPressure * 145.0377;
                financial.t_s = listFull[i].StoredTemp * 1.8 + 491.67;
                //financial.t_s = 1764;
                financial.t_atm = listFull[i].AtmosphericTemp * 1.8 + 491.67;
                //financial.t_atm = 540;
                //financial.r_e = 100000;
                financial.r_e = listFull[i].Reynol;
                financial.mass_inv = listFull[i].InventoryTotal;
                //financial.mass_inv = 420000;//15000;// lb
                financial.mass_comp = (listFull[i].Vapor + listFull[i].Liquid) * 2.2;
                //financial.mass_comp = 10000;
                //financial.mitigationSystem = 3;
                financial.mitigationSystem = listFull[i].MitigationSystem;
                //financial.mfrac_tox = 0.3;
                financial.mfrac_tox = listFull[i].ToxicPercent;
                financial.materialType = listFull[i].MaterialsCA;
                //financial.materialType = "Carbon Steel";// "Carbon Steel";
                financial.releaseDuration = listFull[i].ReleaseDuration;
                //financial.releaseDuration = "40";
                //financial.nfntReleaseFluid = "Steam";
                financial.nfntReleaseFluid = listFull[i].NonToxic_NonFlammable;
                financial.outage_mult = listFull[i].OutageMultiplier;
                //financial.outage_mult = 2;
                financial.prodcost = listFull[i].ProductionCost;
                //financial.prodcost = 50000;
                financial.injcost = listFull[i].InjuryCost;
                //financial.injcost = 5000000;
                financial.envcost = listFull[i].EnvCost;
                //financial.envcost = 0;
                //financial.popdens = 0.00006;
                financial.popdens = listFull[i].PersonDensity / 10763910;
                financial.equipcost = listFull[i].EquipmentCost / 10.76;
                riskBase.CoF = financial.fc();

                ///<summary>
                /// xuat ket qua
                ///</summary>
                risk.ComName = listFull[i].SubComponent;
                risk.ItemNo = listFull[i].EquipNum;
                risk.EqDesc = listFull[i].EquipDescrip;
                risk.EqType = listFull[i].EquipType;
                risk.RepresentFluid = listFull[i].RepresentFluid;
                risk.FluidPhase = listFull[i].FluidPhase;
                risk.CotcatFlammable = "" + financial.ca_cmd();
                risk.CurrentRisk = "N/A";
                risk.CotcatPeople = "" + financial.fc_inj();
                risk.CotcatAsset = "" + financial.fc_prod();
                risk.CotcatEnv = "" + financial.fc_environ();
                risk.CotcatReputation = "N/A";
                risk.CotcatCombinled = "" + financial.fc();
                risk.ComponentMaterialGrade = "N/A";
                risk.InitThinningCategory = "" + riskBase.PoF_thin(riskBase.age);
                risk.InitEnvCracking = "" + riskBase.PoF_scc(riskBase.age);
                risk.InitOtherCategory = "" + riskBase.PoF_brit();
                risk.InitCategory = "" + (riskBase.PoF_thin(riskBase.age) + riskBase.PoF_scc(riskBase.age));
                risk.ExtThinningCategory = "N/A";
                risk.ExtEnvCracking = "N/A";
                risk.ExtOtherCategory = "N/A";

                risk.ExtCategory = "" + riskBase.PoF_ext(riskBase.age);
                risk.POFCategory = "" + riskBase.PoF_total(riskBase.age);

                risk.CurrentRiskCal = "" + (riskBase.PoF_total(riskBase.age) * financial.fc());
                risk.FutureRisk = "" + (riskBase.PoF_total(riskBase.age + 1) * financial.fc());

                riskDemo.add(risk);
            }
        }

        private void btnImportExcelData_ItemClick(object sender, ItemClickEventArgs e)
        {
            ImportExcel import = new ImportExcel();
            import.ShowDialog();
        }

        private void barBtnNewEquipment_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void barBtnImportEquipment_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        private void btnImportInspection_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmImportInspection insp = new frmImportInspection();
            insp.ShowDialog();
        }
        
        
        private void createReportExcel()
        {
            try
            {
                
                DevExpress.XtraSpreadsheet.SpreadsheetControl exportData = new SpreadsheetControl();
                exportData.CreateNewDocument();
                IWorkbook workbook = exportData.Document;
                workbook.Worksheets[0].Name = "Process Plant";
                DevExpress.Spreadsheet.Worksheet worksheet = workbook.Worksheets[0];
                string[] header = {"Equipment",	"Equipment Description",	"Equipment Type",	"Components",
                                "Represent.fluid",	"Fluid phase", "Current Risk($/year)",	"Cofcat.Flammable(ft2/failure)",	"Cofcat.People($/failure)",	"Cofcat.Asset($/failure)",
	                                "Cofcat.Env($/failure)",	"Cofcat.Reputation($/failure)",	"Cofcat.Combined($/failure)",
                                "Component Material Glade","InitThinningPOF(failures/year)",	"InitEnv.Cracking(failures/year)",	"InitOtherPOF(failures/year)",	"InitPOF(failures/year)",	"ExtThinningPOF(failures/year)",
	                                "ExtEnvCrackingProbability(failures/year)",	"ExtOtherPOF(failures/year)",	"ExtPOF(failures/year)",	"POF(failures/year)",
	                                "Current Risk($/year)",	"Future Risk($/year)"};
                //Merge Cells
                worksheet.MergeCells(worksheet.Range["A1:D1"]);
                worksheet.MergeCells(worksheet.Range["G1:M1"]);
                worksheet.MergeCells(worksheet.Range["O1:W1"]);
                worksheet.MergeCells(worksheet.Range["X1:Y1"]);

                //Header Name
                worksheet.Import(header, 1, 0, false);
                worksheet.Cells["A1"].Value = "Indentification";
                worksheet.Cells["G1"].Value = "Consequence (COF)";
                worksheet.Cells["O1"].Value = "Probability (POF)";
                worksheet.Cells["X1"].Value = "Risk";

                //Format Cell
                DevExpress.Spreadsheet.Range range1 = worksheet.Range["A2:Y2"];
                Formatting rangeFormat1 = range1.BeginUpdateFormatting();
                rangeFormat1.Alignment.RotationAngle = 90;
                rangeFormat1.Fill.BackgroundColor = Color.Yellow;
                rangeFormat1.Font.FontStyle = SpreadsheetFontStyle.Bold;

                range1.EndUpdateFormatting(rangeFormat1);

                DevExpress.Spreadsheet.Range range2 = worksheet.Range["A1:Y1"];
                Formatting rangeFormat2 = range2.BeginUpdateFormatting();
                rangeFormat2.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
                rangeFormat2.Fill.BackgroundColor = Color.Yellow;
                rangeFormat2.Font.FontStyle = SpreadsheetFontStyle.Bold;
                range2.EndUpdateFormatting(rangeFormat2);
                //Boder
                DevExpress.Spreadsheet.Range range3 = worksheet.Range["A1:Y2"];
                range3.SetInsideBorders(Color.Gray, BorderLineStyle.Thin);
                range3.Borders.SetOutsideBorders(Color.Black, BorderLineStyle.Medium);
                //Write Data to Cells
                worksheet.Cells["A3"].Value = "COMPC";
                worksheet.Cells["B3"].Value = "abc";
                worksheet.Cells["C3"].Value = "Atmospheric Storage Tank";
                worksheet.Cells["D3"].Value = "Boot";
                worksheet.Cells["E3"].Value = "N/A";
                worksheet.Cells["F3"].Value = "Vapor";
                worksheet.Cells["G3"].Value = "N/A";
                worksheet.Cells["H3"].Value = "5.99685679168514";
                worksheet.Cells["I3"].Value = "151756.778709058";
                worksheet.Cells["J3"].Value = "38384.4614594938";
                worksheet.Cells["K3"].Value = "0";
                worksheet.Cells["L3"].Value = "N/A";
                worksheet.Cells["M3"].Value = "225181.193816338";
                worksheet.Cells["N3"].Value = "N/A";
                worksheet.Cells["O3"].Value = "0.054";
                worksheet.Cells["P3"].Value = "0.000880964207316014";
                worksheet.Cells["Q3"].Value = "0";
                worksheet.Cells["R3"].Value = "0.054880964207316";
                worksheet.Cells["S3"].Value = "N/A";
                worksheet.Cells["T3"].Value = "N/A";
                worksheet.Cells["U3"].Value = "N/A";
                worksheet.Cells["V3"].Value = "0";
                worksheet.Cells["W3"].Value = "0.0607882250993909";
                worksheet.Cells["X3"].Value = "13688.3650978571";
                worksheet.Cells["Y3"].Value = "13740.9914000939";
                //worksheet.Cells["O3"].Value = riskExcel.InitThinningCategory;

                using (FileStream stream = new FileStream(@"C:\Users\hoang\Desktop\excel\testExcel.xls", FileMode.Create, FileAccess.ReadWrite))
                {
                    exportData.SaveDocument(stream, DocumentFormat.Xls);
                    MessageBox.Show("Đã lưu file kết quả", "Cortek RBI");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        
        private void barButtonItem17_ItemClick(object sender, ItemClickEventArgs e)
        {
            //SaveFileDialog save = new SaveFileDialog();
            //save.Filter = "Excel Document 2003 (*.xls)|*.xls|Excel Workbook (*.xlsx)|*.xlsx";
            //if(save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    if (save.FileName == "")
            //    {
            //        MessageBox.Show("Enter name Please!", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //    else
            //    {
                        
            //    }
            //}
            createReportExcel();
        }    
    }
}