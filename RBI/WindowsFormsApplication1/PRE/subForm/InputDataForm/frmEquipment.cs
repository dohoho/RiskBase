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
        List<EQUIPMENT_TYPE> listEquipType = new List<EQUIPMENT_TYPE>();
        EQUIPMENT_TYPE_BUS equipType = new EQUIPMENT_TYPE_BUS();
        EQUIPMENT_MASTER_BUS equipMasterBus = new EQUIPMENT_MASTER_BUS();
        List<EQUIPMENT_MASTER> listEquipmentMaster = new List<EQUIPMENT_MASTER>();
        List<DESIGN_CODE> listDesignCode = new List<DESIGN_CODE>();
        DESIGN_CODE_BUS designCode = new DESIGN_CODE_BUS();
        List<MANUFACTURER> listManufacture = new List<MANUFACTURER>();
        MANUFACTURER_BUS manuBus = new MANUFACTURER_BUS();
        public bool ButtonOKCliked { set; get; }
        public frmEquipment()
        {
            InitializeComponent();
            addDatatoControl();
        }
        private void addDatatoControl()
        {
            //add site name to combobox
            listSite = siteBus.getData();
            cbSite.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < listSite.Count; i++)
            {
                cbSite.Properties.Items.Add(listSite[i].SiteName, i, i);
            }
            //add facility name to combobox
            cbFacility.Properties.Items.Add("", -1, -1);
            listFacility = faciBus.getDataSource();
            for (int i = 0; i < listFacility.Count; i++)
            {
                cbFacility.Properties.Items.Add(listFacility[i].FacilityName, i, i);
            }
            //add equipment type
            listEquipType = equipType.getDataSource();
            cbEquipmentType.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < listEquipType.Count; i++)
            {
                cbEquipmentType.Properties.Items.Add(listEquipType[i].EquipmentTypeName, i, i);
            }
            //add manufacturer
            listManufacture = manuBus.getDataSource();
            cbManufacturer.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < listManufacture.Count; i++)
            {
                cbManufacturer.Properties.Items.Add(listManufacture[i].ManufacturerName, i, i);
            }
            //add design code
            listDesignCode = designCode.getDataSource();
            cbDesignCode.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < listDesignCode.Count; i++)
            {
                cbDesignCode.Properties.Items.Add(listDesignCode[i].DesignCode, i, i);
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
            foreach(EQUIPMENT_TYPE e in listEquipType)
            {
                if(e.EquipmentTypeName == cbEquipmentType.Text)
                {
                    eqMaster.EquipmentTypeID = e.EquipmentTypeID;
                }
            }
            foreach(DESIGN_CODE d in listDesignCode)
            {
                if (d.DesignCode == cbDesignCode.Text)
                {
                    eqMaster.DesignCodeID = d.DesignCodeID;
                }
            }
            foreach(MANUFACTURER m in listManufacture)
            {
                if (m.ManufacturerName == cbManufacturer.Text)
                {
                    eqMaster.ManufacturerID = m.ManufacturerID;
                }
            }
            eqMaster.EquipmentNumber = txtEquipmentNumber.Text;
            eqMaster.EquipmentName = txtEquipmentName.Text;
            eqMaster.CommissionDate = dateCommission.DateTime;
            eqMaster.PFDNo = txtPDFNo.Text;
            eqMaster.ProcessDescription = txtProcessDescription.Text;
            eqMaster.EquipmentDesc = txtDescription.Text;
            eqMaster.IsArchived = 1;
            eqMaster.Archived = DateTime.Now;
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
            if (txtEquipmentNumber.Text == "" || cbEquipmentType.Text == "" || dateCommission.DateTime == null || cbDesignCode.Text == "" || cbManufacturer.Text == "") 
                return;
            equipMasterBus.add(getDataEquipmentMaster());
            //listEquipmentMaster = equipMasterBus.getDataSource();
            //foreach(EQUIPMENT_MASTER eq in listEquipmentMaster)
            //{
            //    if(eq.EquipmentName == txtEquipmentName.Text)
            //    {
            //    }
            //}
            ButtonOKCliked = true;
            this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Event of Control
        private void txtEquipmentNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtEquipmentNumber.Text == "") picEquipNumber.Show();
            else picEquipNumber.Hide();
        }

        private void cbEquipmentType_TextChanged(object sender, EventArgs e)
        {
            if (cbEquipmentType.Text == "") picEquipType.Show();
            else picEquipType.Hide();
        }

        private void cbManufacturer_TextChanged(object sender, EventArgs e)
        {
            if (cbManufacturer.Text == "") picManufacturer.Show();
            else picManufacturer.Hide();
        }

        private void dateCommission_TextChanged(object sender, EventArgs e)
        {
            if (dateCommission.DateTime == null) picCommissionDate.Show();
            else picCommissionDate.Hide();
        }

        private void txtEquipmentNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        #endregion
        frmDesignCode design = new frmDesignCode();
        private void btnAddNewDesignCode_Click(object sender, EventArgs e)
        {
            design.ShowDialog();
        }
        private void btnAddSite_Click(object sender, EventArgs e)
        {
            frmNewSite site = new frmNewSite();
            site.ShowDialog();
        }
        private void btnAddFacility_Click(object sender, EventArgs e)
        {
            frmFacility faci = new frmFacility();
            faci.ShowDialog();
        }
        frmNewManufacturer manu = new frmNewManufacturer();
        private void btnManufacturer_Click(object sender, EventArgs e)
        {
            manu.ShowDialog();
        }
        private void cbManufacturer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbManufacturer.Text == "") picManufacturer.Show();
            else picManufacturer.Hide();
        }

        private void cbDesignCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDesignCode.Text == "") picDesignCode.Show();
            else picDesignCode.Hide();
        }
        private void cbDesignCode_Click(object sender, EventArgs e)
        {
            if (design.ButtonOKClicked)
            {
                List<DESIGN_CODE> listDesignCode1 = new List<DESIGN_CODE>();
                DESIGN_CODE_BUS designCode1 = new DESIGN_CODE_BUS();
                listDesignCode1 = designCode1.getDataSource();
                cbDesignCode.Properties.Items.Add("", -1, -1);
                for (int i = 0; i < listDesignCode.Count; i++)
                {
                    cbDesignCode.Properties.Items.Add(listDesignCode1[i].DesignCode, i, i);
                }
            }
        }

        private void cbManufacturer_Click(object sender, EventArgs e)
        {
            if(manu.ButtonOKClicked)
            {
                MANUFACTURER_BUS manuBus = new MANUFACTURER_BUS();
                List<MANUFACTURER> _manu = manuBus.getDataSource();
                cbManufacturer.Properties.Items.Add("", -1, -1);
                for(int i = 0; i < _manu.Count; i++)
                {
                    cbManufacturer.Properties.Items.Add(_manu[i].ManufacturerName, i, i);
                }
            }
        }

    }
}
