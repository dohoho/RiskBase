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
using RBI.DAL.MSSQL;
namespace RBI.PRE.subForm.InputDataForm
{
    public partial class NewSite : Form
    {
        public NewSite()
        {
            InitializeComponent();
        }
        public SITES setData()
        {
            SITES site = new SITES();
            site.SiteName = txtSiteName.Text;
            return site;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtSiteName.Text == "")
            {
                MessageBox.Show("Site Name cannot Empty", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            RibbonForm1.siteName = txtSiteName.Text;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
