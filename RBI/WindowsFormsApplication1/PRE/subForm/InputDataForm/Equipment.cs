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
            addEquipmentType();
        }
        private void addEquipmentType()
        {
            cbEquipmentType.Properties.Items.Add("Accumulator");
            cbEquipmentType.Properties.Items.Add("Air Cooler");
            cbEquipmentType.Properties.Items.Add("Column");
            cbEquipmentType.Properties.Items.Add("Filter");
            cbEquipmentType.Properties.Items.Add("Fired Heater");
            cbEquipmentType.Properties.Items.Add("Horizontal Vessel");
            cbEquipmentType.Properties.Items.Add("Piping");
            cbEquipmentType.Properties.Items.Add("Plate Exchanger");
            cbEquipmentType.Properties.Items.Add("Pump");
            cbEquipmentType.Properties.Items.Add("Relief Valve");
            cbEquipmentType.Properties.Items.Add("Shell and Tube Exchanger");
            cbEquipmentType.Properties.Items.Add("Sphercal Vessel");
            cbEquipmentType.Properties.Items.Add("Tank");
            cbEquipmentType.Properties.Items.Add("Tower");
            cbEquipmentType.Properties.Items.Add("Vertical Vessel");
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
