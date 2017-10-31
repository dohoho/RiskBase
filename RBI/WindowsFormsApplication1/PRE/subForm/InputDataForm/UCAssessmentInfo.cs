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
        List<EQUIPMENT_MASTER> listEquipment = new List<EQUIPMENT_MASTER>();
        EQUIPMENT_MASTER_BUS equipmentBus = new EQUIPMENT_MASTER_BUS();

        public UCAssessmentInfo()
        {
            InitializeComponent();
            listComponentType = componentTypeBus.getDataSource();
        }
        public RW_ASSESSMENT getData()
        {
            RW_ASSESSMENT ass = new RW_ASSESSMENT();
            ass.AssessmentDate = dateAssessmentDate.DateTime;
            ass.AssessmentMethod = cbAsssessmentMethod.SelectedIndex;
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
        public RW_EQUIPMENT getData1()
        {
            RW_EQUIPMENT eq = new RW_EQUIPMENT();
            eq.CommissionDate = dateComissionDate.DateTime;
            return eq;
        }
    }
}
