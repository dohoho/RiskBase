using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RBI.Object.ObjectMSSQL;

namespace RBI.PRE.subForm.InputDataForm
{
    public partial class UCEquipmentPropertiesTank : UserControl
    {
        string[] itemsAdjustmentSettlement = { "Recorded settlement exceeds API 653 criteria", "Recorded settlement meets API 653 criteria", "Settlement never evaluated", "Concrete foundation, no settlement" };
        string[] itemsExternalEnvironment = { "Arid/dry", "Marine", "Severe", "Temperate"};
        string[] itemsOnlineMonitoring = {  "Amine high velocity corrosion - Corrosion coupons",
                                            "Amine high velocity corrosion - Electrical resistance probes",
                                            "Amine high velocity corrosion - Key process variable",
                                            "Amine low velocity corrosion - Corrosion coupons",
                                            "Amine low velocity corrosion - Electrical resistance probes",
                                            "Amine low velocity corrosion - Key process variable",
                                            "HCI corrosion - Corrosion coupons",
                                            "HCI corrosion - Electrical resistance probes",
                                            "HCI corrosion - Key process variable",
                                            "HCI corrosion - Key process variable & Electrical resistance probes",
                                            "HF corrosion - Corrosion coupons",
                                            "HF corrosion - Electrical resistance probes",
                                            "HF corrosion - Key process variable",
                                            "High temperature H2S/H2 corrosion - Corrosion coupons",
                                            "High temperature H2S/H2 corrosion - Electrical resistance probes",
                                            "High temperature H2S/H2 corrosion - Key process parameters",
                                            "High temperature Sulfidic / Naphthenic acid corrosion - Corrosion coupons",
                                            "High temperature Sulfidic / Naphthenic acid corrosion - Electrical resistance probes",
                                            "High temperature Sulfidic / Naphthenic acid corrosion - Key process variable",
                                            "No online monitoring",
                                            "Other corrosion - Corrosion coupons",
                                            "Other corrosion - Electrical resistance probes",
                                            "Other corrosion - Key process variable",
                                            "Sour water high velocity corrosion - Corrosion coupons",
                                            "Sour water high velocity corrosion - Electrical resistance probes",
                                            "Sour water high velocity corrosion - Key process variable",
                                            "Sour water low velocity corrosion - Corrosion coupons",
                                            "Sour water low velocity corrosion - Electrical resistance probes",
                                            "Sour water low velocity corrosion - Key process variable",
                                            "Sulfuric acid (H2S/H2) corrosion high velocity - Corrosion coupons",
                                            "Sulfuric acid (H2S/H2) corrosion high velocity - Electrical resistance probes",
                                            "Sulfuric acid (H2S/H2) corrosion high velocity - Key process parameters",
                                            "Sulfuric acid (H2S/H2) corrosion high velocity - Key process parameters & electrical resistance probes",
                                            "Sulfuric acid (H2S/H2) corrosion low velocity - Corrosion coupons",
                                            "Sulfuric acid (H2S/H2) corrosion low velocity - Electrical resistance probes",
                                            "Sulfuric acid (H2S/H2) corrosion low velocity - Key process parameters"};
        string[] itemsThermalHistory = { "None", "Solution Annealed", "Stabilised After Welding", "Stabilised Before Welding" };
        string[] itemsEnvironmental = { "High", "Medium", "Low" };
        public UCEquipmentPropertiesTank()
        {
            InitializeComponent();
            additemsAdjustmentSettlement();
            additemsExternalEnvironment();
            additemsOnlineMonitoring();
            additemsThermalHistory();
            additemsEnvironmental();
        }
        private void additemsAdjustmentSettlement()
        {
            cbAdjustmentSettlement.Properties.Items.Add("", -1, -1);
            for(int i = 0; i < itemsAdjustmentSettlement.Length; i++)
            {
                cbAdjustmentSettlement.Properties.Items.Add(itemsAdjustmentSettlement[i], i, i);
            }
        }
        private void additemsOnlineMonitoring()
        {
            cbOnlineMonitoring.Properties.Items.Add("", -1, -1);
            for(int i = 0 ;  i < itemsOnlineMonitoring.Length; i++)
            {
                cbOnlineMonitoring.Properties.Items.Add(itemsOnlineMonitoring[i], i, i);
            }
        }
        private void additemsExternalEnvironment()
        {
            cbExternalEnviroment.Properties.Items.Add("", -1, -1);
            for(int i = 0; i < itemsExternalEnvironment.Length; i++)
            {
                cbExternalEnviroment.Properties.Items.Add(itemsExternalEnvironment[i], i, i);
            }
        }
        private void additemsThermalHistory()
        {
            cbThermalHistory.Properties.Items.Add("", -1, -1);
            for(int i = 0; i< itemsThermalHistory.Length;i++)
            {
                cbThermalHistory.Properties.Items.Add(itemsThermalHistory[i], i, i);
            }
        }
        private void additemsEnvironmental()
        {
            cbEnvironmentalSensitivity.Properties.Items.Add("", -1, -1);
            for(int i = 0; i < itemsEnvironmental.Length; i++)
            {
                cbEnvironmentalSensitivity.Properties.Items.Add(itemsEnvironmental[i], i, i);
            }
        }
        public RW_EQUIPMENT getData()
        {
            RW_EQUIPMENT eq = new RW_EQUIPMENT();
            eq.ID = 2;
            eq.AdminUpsetManagement = chkAministrativeControl.Checked ? 1 : 0;
            eq.CyclicOperation = chkCylicOperation.Checked ? 1 : 0;
            eq.DowntimeProtectionUsed = chkDowntimeProtection.Checked ? 1 : 0;
            eq.ExternalEnvironment = cbAdjustmentSettlement.Text;
            eq.HeatTraced = chkHeatTraced.Checked ? 1 : 0;
            eq.InterfaceSoilWater = chkInterfaceSoilWater.Checked ? 1 : 0;
            eq.LinerOnlineMonitoring = chkLinerOnlineMonitoring.Checked ? 1 : 0;
            eq.MaterialExposedToClExt = chkMaterialExposedFluid.Checked ? 1 : 0;
            eq.MinReqTemperaturePressurisation = txtMinRequiredTemperature.Text != "" ? float.Parse(txtMinRequiredTemperature.Text) : 0;
            eq.OnlineMonitoring = cbOnlineMonitoring.Text;
            eq.PresenceSulphidesO2 = chkPresenceSulphideOperation.Checked ? 1 : 0;
            eq.PresenceSulphidesO2Shutdown = chkPresenceSulphideShutdown.Checked ? 1 : 0;
            eq.PressurisationControlled = chkPressurisationControlled.Checked ? 1 : 0;
            eq.PWHT = chkPWHT.Checked ? 1 : 0;
            eq.SteamOutWaterFlush = chkSteamedOutPriorWaterFlushing.Checked ? 1 : 0;
            eq.ManagementFactor = (float)numSystemManagementFactor.Value;
            eq.ThermalHistory = cbThermalHistory.Text;
            eq.YearLowestExpTemp = chkEquipmentOperatingManyYear.Checked ? 1 : 0;
            eq.Volume = txtEquipmentVolume.Text != "" ? float.Parse(txtEquipmentVolume.Text) : 0;
            eq.TypeOfSoil = cbTypeSoild.Text;
            eq.EnvironmentSensitivity = cbEnvironmentalSensitivity.Text;
            eq.AdjustmentSettle = cbAdjustmentSettlement.Text;
            eq.ComponentIsWelded = chkComponentWelded.Checked ? 1 : 0;
            eq.TankIsMaintained = chkTankMaintainedAccordance.Checked ? 1 : 0;
            //tank shell
            //tank bottom
            eq.DistanceToGroundWater = txtDistanceGroundWater.Text != "" ? float.Parse(txtDistanceGroundWater.Text) : 0;
            return eq;
        }
        public RW_INPUT_CA_TANK getDataforTank()
        {
            RW_INPUT_CA_TANK tank = new RW_INPUT_CA_TANK();
            tank.Environ_Sensitivity = cbEnvironmentalSensitivity.Text;
            tank.SW = txtDistanceGroundWater.Text != "" ? float.Parse(txtDistanceGroundWater.Text) : 0;
            tank.Soil_Type = cbTypeSoild.Text;
            return tank;
        }

        private void txtDistanceGroundWater_KeyPress(object sender, KeyPressEventArgs e)
        {
            string a = txtDistanceGroundWater.Text;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if (a.Contains('.') && e.KeyChar == '.')
            {
                e.Handled = true;
            }
        }

        private void txtMinRequiredTemperature_KeyPress(object sender, KeyPressEventArgs e)
        {
            string a = txtMinRequiredTemperature.Text;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if (a.Contains('.') && e.KeyChar == '.')
            {
                e.Handled = true;
            }
        }

        private void txtEquipmentVolume_KeyPress(object sender, KeyPressEventArgs e)
        {
            string a = txtEquipmentVolume.Text;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if (a.Contains('.') && e.KeyChar == '.')
            {
                e.Handled = true;
            }
        }
    }
}
