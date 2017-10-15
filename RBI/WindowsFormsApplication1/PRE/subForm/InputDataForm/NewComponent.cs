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
    public partial class NewComponent : Form
    {
        public NewComponent()
        {
            InitializeComponent();
        }

        public COMPONENT_MASTER getData()
        {
            //cac so ID chua gan
            COMPONENT_MASTER compMaster = new COMPONENT_MASTER();

            compMaster.ComponentName = txtComponentName.Text;
            compMaster.ComponentNumber = txtComponentNumber.Text;
            compMaster.ComponentDesc = txtDescription.Text;
            compMaster.IsEquipmentLinked = Convert.ToInt32(chkLinks.Checked);
            return compMaster;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(txtComponentName.Text == "")
            {
                MessageBox.Show("Component Name cannot empty!", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            RibbonForm1.componentName = txtComponentName.Text;
            this.Close();
        }
    }
}
