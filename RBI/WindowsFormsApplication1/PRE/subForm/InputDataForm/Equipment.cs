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
    public partial class Equipment : Form
    {
        public Equipment()
        {
            InitializeComponent();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public EQUIPMENT_MASTER getData1()
        {
            EQUIPMENT_MASTER eqMaster = new EQUIPMENT_MASTER();

            eqMaster.EquipmentNumber = txtEquipmentNumber.Text;
            eqMaster.EquipmentName = txtEquipmentName.Text;
            eqMaster.CommissionDate = dateCommission.DateTime;
            eqMaster.PFDNo = txtPDFNo.Text;
            eqMaster.ProcessDescription = txtProcessDescription.Text;
            eqMaster.EquipmentDesc = txtDescription.Text;
            return eqMaster;
        }
        public EQUIPMENT_TYPE getData2()
        {
            EQUIPMENT_TYPE eqType = new EQUIPMENT_TYPE();
            eqType.EquipmentTypeName = cbEquipmentType.Text;
            return eqType;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(txtEquipmentName.Text == "")
            {
                MessageBox.Show("Equipment Name cannot Empty", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            RibbonForm1.equipmentName = txtEquipmentName.Text;
            this.Close();
        }
    }
}
