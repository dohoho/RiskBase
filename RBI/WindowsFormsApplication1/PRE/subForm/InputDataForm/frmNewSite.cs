using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using RBI.BUS.BUSMSSQL;
using RBI.Object.ObjectMSSQL;

namespace RBI.PRE.subForm.InputDataForm
{
    public partial class frmNewSite : Form
    {
        SITES_BUS siteBus = new SITES_BUS();
        List<SITES> listSite = new List<SITES>();
        public bool ButtonOKClicked { set; get; }
        public string siteName { set; get; }
        public frmNewSite()
        {
            InitializeComponent();
        }
        public SITES getData()
        {
            SITES site = new SITES();
            site.SiteName = txtSiteName.Text;
            return site;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            listSite = siteBus.getData();
            foreach (SITES site in listSite)
            {
                if (site.SiteName == txtSiteName.Text)
                {
                    MessageBox.Show("Site name already exists!", "Cortek RBI");
                    return;
                }
            }
            siteBus.add(getData());
            ButtonOKClicked = true;
            //siteName = txtSiteName.Text;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSiteName_TextChanged(object sender, EventArgs e)
        {
            if (txtSiteName.Text == "") btnOK.Enabled = false;
            else btnOK.Enabled = true;
        }

    }
}
