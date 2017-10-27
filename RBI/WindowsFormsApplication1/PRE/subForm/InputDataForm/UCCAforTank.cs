using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RBI.BUS.BUSMSSQL_CAL;
using RBI.Object.ObjectMSSQL;
namespace RBI.PRE.subForm.InputDataForm
{
    public partial class UCCAforTank : UserControl
    {
        string[] itemsFluidPhase = { "Liquid", "Vapor" };
        string[] itemsDetectionType = { "A", "B", "C" };
        string[] itemsIsulationType = { "A", "B", "C" };
        string[] itemsMittigationSystem = { "Fire water deluge system and monitors", "Fire water monitors only", "Foam spray system", "Inventory blowdown, couple with isolation system classification B or higher" };
        public UCCAforTank()
        {
            InitializeComponent();
            additemsDetectionType();
            additemsFluidPhase();
            additemsIsulation();
            additemsMittigationSystem();
        }
        public RW_CA getData()
        {
            RW_CA ca = new RW_CA();
            ca.FluidPhase = cbFluidPhase.Text;
            ca.ProductionCost = txtProductionCost.Text != "" ? float.Parse(txtProductionCost.Text) : 0;
            ca.DetectionType = cbDetectionType.Text;
            ca.IsulationType = cbIsulationType.Text;
            ca.MassInvert = txtMassInvert.Text != "" ? float.Parse(txtMassInvert.Text) : 0;
            ca.MassComponent = txtMassComponent.Text != "" ? float.Parse(txtMassComponent.Text) : 0;
            ca.MittigationSystem = cbMittigationSystem.Text;
            return ca;
        }
        private void additemsIsulation()
        {
            cbIsulationType.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < itemsIsulationType.Length; i++)
            {
                cbIsulationType.Properties.Items.Add(itemsIsulationType[i], i, i);
            }
        }
        private void additemsFluidPhase()
        {
            cbFluidPhase.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < itemsFluidPhase.Length; i++)
            {
                cbFluidPhase.Properties.Items.Add(itemsFluidPhase[i], i, i);
            }
        }
        private void additemsDetectionType()
        {
            cbDetectionType.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < itemsDetectionType.Length; i++)
            {
                cbDetectionType.Properties.Items.Add(itemsDetectionType[i], i, i);
            }
        }
        private void additemsMittigationSystem()
        {
            cbMittigationSystem.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < itemsMittigationSystem.Length; i++)
            {
                cbMittigationSystem.Properties.Items.Add(itemsMittigationSystem[i], i, i);
            }
        }

        private void btnCal_Click(object sender, EventArgs e)
        {
            MSSQL_CA_CAL CA = new MSSQL_CA_CAL();
            CA.FLUID_HEIGHT = 12;
            // CA.SHELL_COURSE_HEIGHT = 10;
            CA.TANK_DIAMETER = 12;
            CA.PREVENTION_BARRIER = true;
            CA.EnvironSensitivity = "Medium";
            CA.P_lvdike = 3;
            CA.P_offsite = 4;
            CA.P_onsite = 3;
            CA.Swg = 5;
            CA.Soil_type = "Clay";
            CA.TANK_FLUID = "Light Diesel Oil";
            CA.FLUID = "C9-C12";
            CA.FLUID_PHASE = cbFluidPhase.Text;
            //CA.MATERIAL_COST = float.Parse(txtMaterialCost.Text);
            //CA.PRODUCTION_COST = float.Parse(txtProductionCost.Text);

            //CA.DETECTION_TYPE = cbDetectionType.Text;
            //CA.ISULATION_TYPE = cbIsulationType.Text;
            //CA.MASS_INVERT = float.Parse(txtMassInvert.Text);
            //CA.MASS_COMPONENT = float.Parse(txtMassComponent.Text);
            //CA.MITIGATION_SYSTEM = cbMitigation.Text;

            //CA.STORED_PRESSURE = float.Parse(txtStoredPressure.Text);
            //CA.STORED_TEMP = float.Parse(txtStoredTemp.Text);
            //CA.ATMOSPHERIC_PRESSURE = float.Parse(txtAtmosphericPressure.Text);
            CA.API_COMPONENT_TYPE_NAME = "TANKBOTTOM";
            MessageBox.Show("CA TANK BOTTOM!" +
                            "\nFC Environ:" + CA.FC_environ_bottom() +
                            "\nFC cmd:" + CA.FC_cmd_bottom() +
                            "\nFC Prod:" + CA.fc_prod()
                            );

        }
    }
}
