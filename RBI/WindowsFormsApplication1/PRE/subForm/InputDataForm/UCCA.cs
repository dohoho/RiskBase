using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RBI.Object.ObjectMSSQL_CAL;
using RBI.BUS.BUSMSSQL_CAL;
using RBI.Object.ObjectMSSQL;
namespace RBI.PRE.subForm.InputDataForm
{
    public partial class UCCA : UserControl
    {
        BUS_TOXIC bus = new BUS_TOXIC();
        MSSQL_CA_CAL BUS_CA = new MSSQL_CA_CAL();
        string[] itemsFluid = {"Acid","AlCl3","C1-C2","C13-C16","C17-C25","C25+","C3-C4","C5", "C6-C8","C9-C12","CO","DEE","EE","EEA","EG","EO","H2","H2S","HCl","HF","Methanol","Nitric Acid","NO2","Phosgene","PO","Pyrophoric","Steam","Styrene","TDI","Water"};
        string[] itemsFluidPhase = { "Liquid", "Vapor", "Two-phase" };
        string[] itemsDetectionType = { "A", "B", "C" };
        string[] itemsMittigationSystem = {"Fire water deluge system and monitors", "Fire water monitors only", "Foam spray system","Inventory blowdown, couple with isolation system classification B or higher"};
        string[] itemsFrammable = { "C1-C2", "C3-C4", "C5", "C6-C8", "C9-C12", "C13-C16", "C17-C25", "C25+", "H2", "H2S", "HF", "CO", "DEE", "Methanol", "PO", "Styrene", "Aromatics", "EEA", "EE", "EG", "EO" };
        string[] itemsToxic = { "H2S", "HF", "CO", "HCl", "Nitric Acid", "AlCl3", "NO2", "Phosgene", "TDI", "PO", "EE", "EO", "Ammonia", "Chlorine" };
        string[] itemsNoneTF = { "Steam", "Acid", "Caustic" };
        string[] itemsIsulationType = { "A", "B", "C" };
        List<String> timeDuration;
        string ReleasePhase;
        public RW_CA getData()
        {
            RW_CA ca = new RW_CA();
            ca.Fluid = cbFluid.Text;
            ca.FluidPhase = cbFluidPhase.Text;
            ca.EquipmentCost = txtEquipmentCost.Text != "" ? float.Parse(txtEquipmentCost.Text) : 0;
            ca.ProductionCost = txtProductionCost.Text != "" ? float.Parse(txtProductionCost.Text) : 0;
            ca.InjureCost = txtInjureCost.Text != "" ? float.Parse(txtInjureCost.Text) : 0;
            ca.EnvironmentCost = txtEnvironmentCost.Text != "" ? float.Parse(txtEnvironmentCost.Text) : 0;
            ca.DetectionType = cbDetectionType.Text;
            ca.IsulationType = cbIsulationType.Text;
            ca.MassInvert = txtMassInvert.Text != "" ? float.Parse(txtMassInvert.Text) : 0;
            ca.MassComponent = txtMassComponent.Text != "" ? float.Parse(txtMassComponent.Text) : 0;
            ca.MittigationSystem = cbMittigationSystem.Text;
            ca.ToxicPercent = txtToxicPercent.Text != "" ? float.Parse(txtToxicPercent.Text) : 0;
            ca.ReleaseDuration = cbReleaseDuration.Text;
            ca.PersonDensity = txtPersonDensity.Text != "" ? float.Parse(txtPersonDensity.Text) : 0;
            //ca.StoredPressure = txtStoredPressure.Text != "" ? float.Parse(txtStoredPressure.Text) : 0;
            ca.AtmosphericPressure = 101;//txtAtmosphericPressure.Text != "" ? float.Parse(txtAtmosphericPressure.Text) : 0;
            //ca.StoredTemp = txtStoredTemp.Text != "" ? float.Parse(txtStoredTemp.Text) : 0;
            //ca.AtmosphereTemperature = 27;//txtAtmosphereTemp.Text != "" ? float.Parse(txtAtmosphereTemp.Text) : 0;
            return ca;
        }
        public UCCA()
        {
            InitializeComponent();
            additemsFluid();
            additemsFluidPhase();
            additemsDetectionType();
            additemsMittigationSystem();
            additemsIsulationType();
        }
        private void additemsIsulationType()
        {
            cbIsulationType.Properties.Items.Add("", -1, -1);
            for(int i = 0; i < itemsIsulationType.Length; i++)
            {
                cbIsulationType.Properties.Items.Add(itemsIsulationType[i], i, i);
            }
        }
        private void additemsFluid()
        {
            cbFluid.Properties.Items.Add("", -1, -1);
            for(int i = 0; i < itemsFluid.Length; i++)
            {
                cbFluid.Properties.Items.Add(itemsFluid[i], i, i);
            }
        }
        private void additemsFluidPhase()
        {
            cbFluidPhase.Properties.Items.Add("", -1, -1);
            for(int i = 0; i < itemsFluidPhase.Length; i++)
            {
                cbFluidPhase.Properties.Items.Add(itemsFluidPhase[i], i, i);
            }
        }
        private void additemsDetectionType()
        {
            cbDetectionType.Properties.Items.Add("", -1, -1);
            for(int i = 0; i < itemsDetectionType.Length; i++)
            {
                cbDetectionType.Properties.Items.Add(itemsDetectionType[i], i, i);
            }
        }
        private void additemsMittigationSystem()
        {
            cbMittigationSystem.Properties.Items.Add("", -1, -1);
            for(int i = 0; i < itemsMittigationSystem.Length; i++)
            {
                cbMittigationSystem.Properties.Items.Add(itemsMittigationSystem[i], i, i);
            }
        }
        private void clearData()
        {
            cbReleaseDuration.Properties.Items.Clear();
        }
        private void cbFluid_SelectedIndexChanged(object sender, EventArgs e)
        {
            timeDuration = new List<string>();
            List<TOXIC_511_512> list511 = bus.getList511_512();
            List<TOXIC_513> list513 = bus.getList513();
            if (cbFluidPhase.Text == "Vapor" || cbFluidPhase.Text == "Powder")
            {
                ReleasePhase = "Gas";
            }
            else if (cbFluidPhase.Text == "Liquid")
            {
                ReleasePhase = "Liquid";
            }
            else
            {
                ReleasePhase = "";
            }
            if (cbFluid.Text == "H2S" || cbFluid.Text == "HF" || cbFluid.Text == "Ammonia" || cbFluid.Text == "Chlorine")
            {
                for (int i = 0; i < list511.Count; i++)
                {
                    if (cbFluid.Text == list511[i].ToxicName)
                    {
                        timeDuration.Add(list511[i].ReleaseDuration);
                    }
                }
            }
            else
            {
                for (int i = 0; i < list513.Count; i++)
                {
                    if (cbFluid.Text == list513[i].TOXIC_NAME && ReleasePhase == list513[i].TOXIC_TYPE)
                    {
                        timeDuration.Add(list513[i].DURATION);
                    }
                }
            }
            if (timeDuration.Count != 0)
            {
                txtToxicPercent.Enabled = true;
            }
            else
            {
                txtToxicPercent.Enabled = false;
            }
            clearData();
            cbReleaseDuration.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < timeDuration.Count; i++)
            {
                cbReleaseDuration.Properties.Items.Add(timeDuration[i], i, i);
            }
        }
        private void cbFluidPhase_SelectedIndexChanged(object sender, EventArgs e)
        {
            timeDuration = new List<string>();
            List<TOXIC_511_512> list511 = bus.getList511_512();
            List<TOXIC_513> list513 = bus.getList513();
            if (cbFluidPhase.Text == "Vapor")
            {
                ReleasePhase = "Gas";
            }
            else if (cbFluidPhase.Text == "Liquid" || cbFluidPhase.Text == "Powder")
            {
                ReleasePhase = "Liquid";
            }
            else
            {
                ReleasePhase = "";
            }
            if (cbFluid.Text == "H2S" || cbFluid.Text == "HF" || cbFluid.Text == "Ammonia" || cbFluid.Text == "Chlorine")
            {
                for (int i = 0; i < list511.Count; i++)
                {
                    if (cbFluid.Text == list511[i].ToxicName)
                    {
                        timeDuration.Add(list511[i].ReleaseDuration);
                    }
                }
            }
            else
            {
                for (int i = 0; i < list513.Count; i++)
                {
                    if (cbFluid.Text == list513[i].TOXIC_NAME && ReleasePhase == list513[i].TOXIC_TYPE)
                    {
                        timeDuration.Add(list513[i].DURATION);
                    }
                }
            }
            if (timeDuration.Count != 0)
            {
                txtToxicPercent.Enabled = true;
            }
            else
            {
                txtToxicPercent.Enabled = false;
            }
            clearData();
            cbReleaseDuration.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < timeDuration.Count; i++)
            {
                cbReleaseDuration.Properties.Items.Add(timeDuration[i], i, i);
            }
        }
        private void btnCAL_Click(object sender, EventArgs e)
        {
            MSSQL_CA_CAL CA_CAL = new MSSQL_CA_CAL();
            CA_CAL.TANK_DIAMETER = 1000;
            CA_CAL.API_COMPONENT_TYPE_NAME = "DRUM";
            CA_CAL.FLUID = cbFluid.Text;
            CA_CAL.FLUID_PHASE = cbFluidPhase.Text;

            try
            {
                //CA_CAL.MATERIAL_COST = float.Parse(txtMaterialCost.Text);
            }
            catch
            {
                CA_CAL.MATERIAL_COST = 0;
            }
            try
            {
                CA_CAL.EQUIPMENT_COST = float.Parse(txtEquipmentCost.Text);
            }
            catch
            {
                CA_CAL.EQUIPMENT_COST = 0;
            }
            try
            {
                CA_CAL.PRODUCTION_COST = float.Parse(txtProductionCost.Text);
            }
            catch
            {
                CA_CAL.PRODUCTION_COST = 0;
            }
            try
            {
                CA_CAL.INJURE_COST = float.Parse(txtInjureCost.Text);
            }
            catch
            {
                CA_CAL.INJURE_COST = 0;
            }
            try
            {
                CA_CAL.ENVIRON_COST = float.Parse(txtEnvironmentCost.Text);
            }
            catch
            {
                CA_CAL.ENVIRON_COST = 0;
            }
            CA_CAL.DETECTION_TYPE = cbDetectionType.Text;
            CA_CAL.ISULATION_TYPE = cbIsulationType.Text;
            try
            {
                CA_CAL.MASS_INVERT = float.Parse(txtMassInvert.Text);
            }
            catch
            {
                CA_CAL.MASS_INVERT = 0;
            }
            try
            {
                CA_CAL.MASS_COMPONENT = float.Parse(txtMassComponent.Text);
            }
            catch
            {
                CA_CAL.MASS_COMPONENT = 0;
            }
            CA_CAL.MITIGATION_SYSTEM = cbMittigationSystem.Text;
            CA_CAL.RELEASE_DURATION = cbReleaseDuration.Text;
            try
            {
                CA_CAL.TOXIC_PERCENT = float.Parse(txtToxicPercent.Text) / 100;
            }
            catch
            {
                CA_CAL.TOXIC_PERCENT = 0;
            }
            try
            {
                CA_CAL.PERSON_DENSITY = float.Parse(txtPersonDensity.Text);
            }
            catch
            {
                CA_CAL.PERSON_DENSITY = 0;
            }
            //try
            //{
            //    CA_CAL.STORED_PRESSURE = float.Parse(txtStoredPressure.Text);
            //}
            //catch
            //{
            //    CA_CAL.STORED_PRESSURE = 0;
            //}
            //try
            //{
            //    CA_CAL.ATMOSPHERIC_PRESSURE = float.Parse(txtAtmosphericPressure.Text);
            //}
            //catch
            //{
            //    CA_CAL.ATMOSPHERIC_PRESSURE = 0;
            //}
            //try
            //{
            //    CA_CAL.STORED_TEMP = float.Parse(txtStoredTemp.Text);
            //}
            //catch
            //{
            //    CA_CAL.STORED_TEMP = 0;
            //}
            MessageBox.Show("Consequence Level 1!" +
                            "\nCA Toxic(m2):" + CA_CAL.ca_inj_tox() +
                            "\nCA cmd (m2) :" + CA_CAL.ca_cmd() +
                            "\nCA injure (m2):" + CA_CAL.ca_inj() +
                            "\nFC cmd ($):" + CA_CAL.fc_cmd() +
                            "\nFC affa($):" + CA_CAL.fc_affa() +
                            "\nFC prod ($):" + CA_CAL.fc_prod() +
                            "\nFC inj ($):" + CA_CAL.fc_inj() +
                            "\nFC environ ($):" + CA_CAL.fc_environ() +
                            "\nFC total ($):" + CA_CAL.fc(), "TEST CA");
        }


       
        //du lieu cho Release Duration anh Vu viet
        /*
         * Khi nhap du lieu chu y cac diem sau:
         * 1. du lieu ap suat cua RW la Psi , du lieu ta can la kPa: 1Psi = 6.895 kPa( nen dat trong form nay)
         * 2. Cac du lieu ve khi quyen co the bo qua: P_atm = 101 kPa, T_atm = 27*C( nen ap truc tiep, trong form nay)
         * 3. Nhiet do tinh theo do K nen( co the xu ly trong CODE tinh CA): AIT, STORAGE_TEMP
         * 4. Nen Suy nghi co nen them 2 muc khac cho Toxic va NoneFlameNoneToxic hay k?( neu them thi cong them cac gia tri % khac de tinh)
         * 
         * */
    }
}
