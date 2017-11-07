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
    public partial class frmNewComponent : Form
    {
        List<EQUIPMENT_MASTER> listEquipment = new List<EQUIPMENT_MASTER>();
        EQUIPMENT_MASTER_BUS equipmentBus = new EQUIPMENT_MASTER_BUS();
        List<API_COMPONENT_TYPE> listAPIComponent = new List<API_COMPONENT_TYPE>();
        API_COMPONENT_TYPE_BUS API_BUS = new API_COMPONENT_TYPE_BUS();
        List<COMPONENT_TYPE> listComponent = new List<COMPONENT_TYPE>();
        COMPONENT_TYPE__BUS componentBus = new COMPONENT_TYPE__BUS();
        List<DESIGN_CODE> listDesignCode = new List<DESIGN_CODE>();
        DESIGN_CODE_BUS designCodeBus = new DESIGN_CODE_BUS();
        List<SITES> listSite = new List<SITES>();
        SITES_BUS siteBus = new SITES_BUS();
        List<FACILITY> listFacility = new List<FACILITY>();
        FACILITY_BUS facilityBus = new FACILITY_BUS();
        COMPONENT_MASTER_BUS componentMaster_Bus = new COMPONENT_MASTER_BUS();
        public bool ButtonOKClicked { set; get; }
        public frmNewComponent()
        {
            InitializeComponent();
            addDatatoControl();
        }
        private void addDatatoControl()
        {
            //get data for equipment number
            listEquipment = equipmentBus.getDataSource();
            cbEquipmentNumber.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < listEquipment.Count; i++)
            {
                cbEquipmentNumber.Properties.Items.Add(listEquipment[i].EquipmentNumber, i, i);
            }

            //get data for API component
            listAPIComponent = API_BUS.getDataSource();
            cbAPIComponentType.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < listAPIComponent.Count; i++)
            {
                cbAPIComponentType.Properties.Items.Add(listAPIComponent[i].APIComponentTypeName, i, i);
            }
            //get data for component type
            listComponent = componentBus.getDataSource();
            cbComponentType.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < listComponent.Count; i++)
            {
                cbComponentType.Properties.Items.Add(listComponent[i].ComponentTypeName, i, i);
            }
            //get data for site
            listSite = siteBus.getData();
            cbSites.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < listSite.Count; i++)
            {
                cbSites.Properties.Items.Add(listSite[i].SiteName, i, i);
            }
            //get data for Facility
            listFacility = facilityBus.getDataSource();
            cbFacility.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < listFacility.Count; i++)
            {
                cbFacility.Properties.Items.Add(listFacility[i].FacilityName, i, i);
            }

            //Design COde
            listDesignCode = designCodeBus.getDataSource();
            cbDesignCode.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < listDesignCode.Count; i++)
            {
                cbDesignCode.Properties.Items.Add(listDesignCode[i].DesignCode, i, i);
            }
        }
        public COMPONENT_MASTER getDataComponentMaster()
        {
            //cac so ID chua gan
            COMPONENT_MASTER compMaster = new COMPONENT_MASTER();
            compMaster.ComponentName = txtComponentName.Text;
            compMaster.ComponentNumber = txtComponentNumber.Text;
            compMaster.ComponentDesc = txtDescription.Text;
            compMaster.IsEquipmentLinked = Convert.ToInt32(chkLinks.Checked);
            foreach(EQUIPMENT_MASTER e in listEquipment)
            {
                if(e.EquipmentNumber == cbEquipmentNumber.Text)
                {
                    compMaster.EquipmentID = e.EquipmentID;
                }
            }

            foreach(API_COMPONENT_TYPE a in listAPIComponent)
            {
                if(a.APIComponentTypeName == cbAPIComponentType.Text)
                {
                    compMaster.APIComponentTypeID = a.APIComponentTypeID;
                }
            }
            foreach(COMPONENT_TYPE c in listComponent)
            {
                if(c.ComponentTypeName == cbComponentType.Text)
                {
                    compMaster.ComponentTypeID = c.ComponentTypeID;
                }
            }
            return compMaster;
        }
        public API_COMPONENT_TYPE getData1()
        {
            API_COMPONENT_TYPE api = new API_COMPONENT_TYPE();
            api.APIComponentTypeName = cbAPIComponentType.Text;
            return api;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtComponentNumber.Text == "" || cbComponentType.Text == "" || cbAPIComponentType.Text == "")
                return;
            ButtonOKClicked = true;
            componentMaster_Bus.add(getDataComponentMaster());
            this.Close();
        }

        private void txtComponentNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtComponentNumber.Text == "") picComponentNumber.Show();
            else picComponentNumber.Hide();
        }

        private void cbComponentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAPIComponentType.Text == "") picComponentType.Show();
            else picComponentType.Hide();
        }

        private void cbAPIComponentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAPIComponentType.Text == "") picAPIComponent.Show();
            else picAPIComponent.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
