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
    public partial class frmEquipment : Form
    {
        SITES_BUS siteBus = new SITES_BUS();
        List<SITES> listSite = new List<SITES>();
        FACILITY_BUS faciBus = new FACILITY_BUS();
        List<FACILITY> listFacility = new List<FACILITY>();
        List<EQUIPMENT_TYPE> equipType = new List<EQUIPMENT_TYPE>();
        EQUIPMENT_TYPE_BUS listEquipType = new EQUIPMENT_TYPE_BUS();
        EQUIPMENT_MASTER_BUS equipMasterBus = new EQUIPMENT_MASTER_BUS();
        //string[] itemsEquipmentType = { "Accumulator", "Air Cooler", "Column", "Vertical Vessel", "Spherical Vessel", "Fired Heater", "Piping", "Pump", "Plate Exchanger", "Shell and Tube Exchanger", "Horizontal Vessel", "Relief Valve", "Tower", "Filter" };

        public frmEquipment()
        {
            InitializeComponent();
            //add site name to combobox
            listSite = siteBus.getData();
            cbSite.Properties.Items.Add("", -1, -1);
            for(int i = 0; i < listSite.Count; i++)
            {
                cbSite.Properties.Items.Add(listSite[i].SiteName, i, i);
            }
            //add facility name to combobox
            cbFacility.Properties.Items.Add("", -1, -1);
            listFacility = faciBus.getDataSource();
            for(int i = 0; i < listFacility.Count; i++)
            {
                cbFacility.Properties.Items.Add(listFacility[i].FacilityName, i, i);
            }
            equipType = listEquipType.getDataSource();
            cbEquipmentType.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < equipType.Count; i++)
            {
                cbEquipmentType.Properties.Items.Add(equipType[i].EquipmentTypeName, i, i);
            }
        }
       
        public EQUIPMENT_MASTER getDataEquipmentMaster()
        {
            EQUIPMENT_MASTER eqMaster = new EQUIPMENT_MASTER();
            foreach(FACILITY f in listFacility)
            {
                if(f.FacilityName == cbFacility.Text)
                {
                    eqMaster.FacilityID = f.FacilityID;
                }
            }
            foreach(SITES s in listSite)
            {
                if(s.SiteName == cbSite.Text)
                {
                    eqMaster.SiteID = s.SiteID;
                }
            }
            foreach(EQUIPMENT_TYPE e in equipType)
            {
                if(e.EquipmentTypeName == cbEquipmentType.Text)
                {
                    eqMaster.EquipmentTypeID = e.EquipmentTypeID;
                }
            }
            eqMaster.EquipmentNumber = txtEquipmentNumber.Text;
            eqMaster.EquipmentName = txtEquipmentName.Text;
            eqMaster.CommissionDate = dateCommission.DateTime;
            eqMaster.PFDNo = txtPDFNo.Text;
            eqMaster.ProcessDescription = txtProcessDescription.Text;
            eqMaster.EquipmentDesc = txtDescription.Text;
            return eqMaster;
        }
        public EQUIPMENT_TYPE getDataEquipmentType()
        {
            EQUIPMENT_TYPE eqType = new EQUIPMENT_TYPE();
            eqType.EquipmentTypeName = cbEquipmentType.Text;
            return eqType;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtEquipmentNumber.Text == "" || cbEquipmentType.Text == "" || dateCommission.DateTime == null) return;
            equipMasterBus.add(getDataEquipmentMaster());
            //EQUIPMENT_MASTER f = getDataEquipmentMaster();
            //Console.WriteLine("VunA" + f.CommissionDate.ToShortDateString());
            RibbonForm1.equipmentName = txtEquipmentName.Text;
            this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtEquipmentNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtEquipmentNumber.Text == "") picEquipNumber.Show();
            else picEquipNumber.Hide();
        }
    }
}
