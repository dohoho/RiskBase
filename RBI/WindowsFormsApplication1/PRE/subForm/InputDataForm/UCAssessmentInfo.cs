using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using RBI.Object.ObjectMSSQL;
using RBI.BUS.BUSMSSQL;
namespace RBI.PRE.subForm.InputDataForm
{
    public partial class UCAssessmentInfo : UserControl
    {
        List<COMPONENT_TYPE> listComponentType = new List<COMPONENT_TYPE>();
        COMPONENT_TYPE__BUS componentTypeBus = new COMPONENT_TYPE__BUS();
        
        
        public UCAssessmentInfo()
        {
            InitializeComponent();
            listComponentType = componentTypeBus.getDataSource();
        }
        public UCAssessmentInfo(int id)
        {
            InitializeComponent();
            showDatatoControl(id);
        }
        public String ProposalName;
        public RW_ASSESSMENT getData()
        {
            RW_ASSESSMENT ass = new RW_ASSESSMENT();
            ass.AssessmentDate = dateAssessmentDate.DateTime;
            ass.RiskAnalysisPeriod = txtRiskAnalysisPeriod.Text != "" ? int.Parse(txtRiskAnalysisPeriod.Text) : 0;
            ass.IsEquipmentLinked = chkRiskLinksEquipmentRisk.Checked ? 1 : 0;
            ass.RecordType = cbReportTemplate.Text;
            ass.ProposalName = txtAssessmentName.Text;
            ass.AdoptedDate = DateTime.Now;
            ass.RecommendedDate = DateTime.Now;
            ass.ComponentID = 1;
            ass.EquipmentID = 1;
            return ass;
        }
        public EQUIPMENT_MASTER getEquipmentMaster()
        {
            EQUIPMENT_MASTER eq = new EQUIPMENT_MASTER();
            eq.EquipmentNumber = txtEquipmentNumber.Text;
            //eq.EquipmentDesc = txt
            return eq;
        }
        public RW_EQUIPMENT getData1()
        {
            RW_EQUIPMENT eq = new RW_EQUIPMENT();
            eq.CommissionDate = dateComissionDate.DateTime;
            return eq;
        }
        public void showDatatoControl(int ID)
        {
            EQUIPMENT_TYPE_BUS eqTypeBus = new EQUIPMENT_TYPE_BUS();
            List<EQUIPMENT_TYPE> listEquipmentType = eqTypeBus.getDataSource();
            EQUIPMENT_MASTER_BUS equipmentMasterBus = new EQUIPMENT_MASTER_BUS();
            List<EQUIPMENT_MASTER> listEquipmentMaster = equipmentMasterBus.getDataSource();
            DESIGN_CODE_BUS designCodeBus = new DESIGN_CODE_BUS();
            List<DESIGN_CODE> listDesignCode = designCodeBus.getDataSource();
            SITES_BUS siteBus = new SITES_BUS();
            List<SITES> listSite = siteBus.getData();
            FACILITY_BUS facilityBus = new FACILITY_BUS();
            List<FACILITY> listFacility = facilityBus.getDataSource();
            MANUFACTURER_BUS manuBus = new MANUFACTURER_BUS();
            List<MANUFACTURER> listManu = manuBus.getDataSource();
            RW_ASSESSMENT_BUS rwAssBus = new RW_ASSESSMENT_BUS();
            List<RW_ASSESSMENT> listAssessment = rwAssBus.getDataSource();
            //đổ dữ liệu lên control cho Component
            COMPONENT_MASTER_BUS comMaBus = new COMPONENT_MASTER_BUS();
            List<COMPONENT_MASTER> listComMa = comMaBus.getDataSource();
            COMPONENT_TYPE__BUS comTypeBus = new COMPONENT_TYPE__BUS();
            List<COMPONENT_TYPE> listComponentType = comTypeBus.getDataSource();
            API_COMPONENT_TYPE_BUS apiComponentBus = new API_COMPONENT_TYPE_BUS();
            List<API_COMPONENT_TYPE> listAPICom = apiComponentBus.getDataSource();
            foreach(RW_ASSESSMENT a in listAssessment)
            {
                if(a.ID == ID)
                {
                    txtAssessmentName.Text = a.ProposalName;
                    ProposalName = a.ProposalName;
                    dateAssessmentDate.DateTime = a.AssessmentDate;
                    txtRiskAnalysisPeriod.Text = a.RiskAnalysisPeriod.ToString();
                    foreach (EQUIPMENT_MASTER e in listEquipmentMaster)
                    {
                        if (e.EquipmentID == a.EquipmentID)
                        {
                            txtEquipmentNumber.Text = e.EquipmentNumber;
                            dateComissionDate.DateTime = e.CommissionDate;
                            txtEquipmentName.Text = e.EquipmentName;
                            foreach (EQUIPMENT_TYPE t in listEquipmentType)
                            {
                                if (t.EquipmentTypeID == e.EquipmentTypeID)
                                    txtEquipmentType.Text = t.EquipmentTypeName;
                            }
                            foreach (DESIGN_CODE d in listDesignCode)
                            {
                                if (d.DesignCodeID == e.DesignCodeID)
                                    txtDesignCode.Text = d.DesignCode;
                            }
                            foreach (FACILITY f in listFacility)
                            {
                                if (e.FacilityID == f.FacilityID)
                                    txtFacility.Text = f.FacilityName;
                            }
                            foreach (SITES s in listSite)
                            {
                                if (s.SiteID == e.SiteID)
                                    txtSites.Text = s.SiteName;
                            }
                            foreach (MANUFACTURER m in listManu)
                            {
                                if (m.ManufacturerID == e.ManufacturerID)
                                    txtManufacturer.Text = m.ManufacturerName;
                            }
                        }
                        break;
                    }
                    foreach (COMPONENT_MASTER c in listComMa)
                    {
                        if (c.ComponentID == a.ComponentID)
                        {
                            txtComponentNumber.Text = c.ComponentNumber;
                            foreach (COMPONENT_TYPE t in listComponentType)
                            {
                                if (c.ComponentTypeID == t.ComponentTypeID)
                                {
                                    txtComponentType.Text = t.ComponentTypeName;
                                }
                            }
                            txtComponentName.Text = c.ComponentName;
                            foreach (API_COMPONENT_TYPE a1 in listAPICom)
                            {
                                if (a1.APIComponentTypeID == c.APIComponentTypeID)
                                {
                                    txtAPIComponentType.Text = a1.APIComponentTypeName;
                                }
                            }
                        }
                        break;
                    }
                    
            }
            //foreach (RW_ASSESSMENT a in listAssessment)
            //{
            //    if (a.ID == assID)
            //    {
            //        txtAssessmentName.Text = a.ProposalName;
            //    }
            //}
            //đổ dữ liệu lên control cho Equipment
            

            }
            
            
        }
    }
}
