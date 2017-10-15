using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RBI.Object.ObjectMSSQL;
namespace RBI.PRE.subForm.InputDataForm
{
    public partial class FacilityInput : Form
    {
        public FacilityInput()
        {
            InitializeComponent();
        }

        public FACILITY getData1()
        {
            FACILITY faci = new FACILITY();
            faci.FacilityName = txtFacilityName.Text;
            faci.ManagementFactor = Convert.ToDouble(numManagementSystem.Value);
            return faci;
        }
        public FACILITY_RISK_TARGET getData2()
        {
            FACILITY_RISK_TARGET faciRisk = new FACILITY_RISK_TARGET();
            faciRisk.RiskTarget_CA = Double.Parse(txtArea.Text);
            faciRisk.RiskTarget_FC = Double.Parse(txtFinancial.Text);
            faciRisk.RiskTarget_A = Double.Parse(txtA.Text);
            faciRisk.RiskTarget_B = Double.Parse(txtB.Text);
            faciRisk.RiskTarget_C = Double.Parse(txtC.Text);
            faciRisk.RiskTarget_D = Double.Parse(txtD.Text);
            faciRisk.RiskTarget_E = Double.Parse(txtE.Text);
            return faciRisk;
        }
        string FacilityName = null;
        public string getFacilityName()
        {
            return FacilityName;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtFacilityName.Text == "")
            {
                MessageBox.Show("Facility Name cannot Empty", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FacilityName = txtFacilityName.Text;
            RibbonForm1.facilityName = txtFacilityName.Text;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
