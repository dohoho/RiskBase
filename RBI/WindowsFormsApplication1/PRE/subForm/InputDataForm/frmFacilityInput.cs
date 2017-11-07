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
using RBI.BUS.BUSMSSQL;
namespace RBI.PRE.subForm.InputDataForm
{
    public partial class frmFacilityInput : Form
    {
        public bool ButtonOKClicked { set; get; }
        FACILITY_RISK_TARGET_BUS facilityRisk = new FACILITY_RISK_TARGET_BUS();
        FACILITY_BUS facility = new FACILITY_BUS();
        SITES_BUS siteBus = new SITES_BUS();
        List<SITES> listSite = new List<SITES>();
        public frmFacilityInput()
        {
            InitializeComponent();
            listSite = siteBus.getData();
            cbSites.Properties.Items.Add("", -1, -1);
            for(int i = 0; i < listSite.Count; i++)
            {
                cbSites.Properties.Items.Add(listSite[i].SiteName, i, i);
            }
        }

        public FACILITY getFacilityName()
        {
            FACILITY faci = new FACILITY();
            foreach(SITES s in listSite)
            {
                if(s.SiteName == cbSites.Text)
                {
                    faci.SiteID = s.SiteID;
                }
            }
            faci.FacilityName = txtFacilityName.Text;
            faci.ManagementFactor = float.Parse(numManagementSystem.Value.ToString());
            return faci;
        }
        public FACILITY_RISK_TARGET getRiskTarget()
        {
            FACILITY_RISK_TARGET faciRisk = new FACILITY_RISK_TARGET();
            List<FACILITY> fa = new List<FACILITY>();
            foreach(FACILITY f in fa)
            {
                if(f.FacilityName == txtFacilityName.Text)
                {
                    faciRisk.FacilityID = f.FacilityID;
                }
            }
            faciRisk.RiskTarget_CA = float.Parse(txtArea.Text);
            faciRisk.RiskTarget_FC = float.Parse(txtFinancial.Text);
            faciRisk.RiskTarget_A = float.Parse(txtA.Text);
            faciRisk.RiskTarget_B = float.Parse(txtB.Text);
            faciRisk.RiskTarget_C = float.Parse(txtC.Text);
            faciRisk.RiskTarget_D = float.Parse(txtD.Text);
            faciRisk.RiskTarget_E = float.Parse(txtE.Text);
            return faciRisk;
        }
        
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtFacilityName.Text == "" || txtArea.Text == "" || txtFinancial.Text == "" || cbSites.Text == "") return;
            List<FACILITY> listFa = facility.getDataSource();
            foreach (FACILITY fa in listFa)
            {
                if (fa.FacilityName == txtFacilityName.Text)
                {
                    MessageBox.Show("Facility already exists", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            facility.add(getFacilityName());
            facilityRisk.add(getRiskTarget());
            ButtonOKClicked = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFacilityName_TextChanged(object sender, EventArgs e)
        {
            if (txtFacilityName.Text != "") pictureBox1.Hide();
            else pictureBox1.Show();
        }

        private void txtArea_TextChanged(object sender, EventArgs e)
        {
            if (txtArea.Text == "") pictureBox3.Show();
            else pictureBox3.Hide();
        }

        private void txtFinancial_TextChanged(object sender, EventArgs e)
        {
            if (txtFinancial.Text == "") pictureBox4.Show();
            else pictureBox4.Hide();
        }

        private void cbSites_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSites.Text == "") pictureBox2.Show();
            else pictureBox2.Hide();
        }

        private void txtArea_KeyPress(object sender, KeyPressEventArgs e)
        {
            string a = txtArea.Text;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if (a.Contains('.') && e.KeyChar == '.')
            {
                e.Handled = true;
            }
        }

        private void txtFinancial_KeyPress(object sender, KeyPressEventArgs e)
        {
            string a = txtFinancial.Text;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if (a.Contains('.') && e.KeyChar == '.')
            {
                e.Handled = true;
            }
        }

    }
}
