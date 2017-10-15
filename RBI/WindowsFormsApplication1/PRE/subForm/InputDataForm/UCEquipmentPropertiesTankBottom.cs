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
    public partial class UCEquipmentPropertiesTankBottom : UserControl
    {
        public UCEquipmentPropertiesTankBottom()
        {
            InitializeComponent();
        }
        public RW_EQUIPMENT getData()
        {
            RW_EQUIPMENT eq = new RW_EQUIPMENT();
            eq.AdminUpsetManagement = chkAministrativeControl.Checked ? 1 : 0;
            eq.CyclicOperation = chkCylicOperation.Checked ? 1 : 0;
            eq.HighlyDeadlegInsp = chkHighlyEffectiveInspection.Checked ? 1 : 0;
            eq.DowntimeProtectionUsed = chkDowntimeProtection.Checked ? 1 : 0;
            eq.ExternalEnvironment = cbAdjustmentSettlement.Text;
            eq.HeatTraced = chkHeatTraced.Checked ? 1 : 0;
            eq.InterfaceSoilWater = chkInterfaceSoilWater.Checked ? 1 : 0;
            eq.LinerOnlineMonitoring = chkLinerOnlineMonitoring.Checked ? 1 : 0;
            eq.MaterialExposedToClExt = chkMaterialExposedFluid.Checked ? 1 : 0;
            eq.MinReqTemperaturePressurisation = float.Parse(txtMinRequiredTemperature.Text);
            eq.OnlineMonitoring = cbOnlineMonitoring.Text;
            eq.PresenceSulphidesO2 = chkPresenceSulphideOperation.Checked ? 1 : 0;
            eq.PresenceSulphidesO2Shutdown = chkPresenceSulphideShutdown.Checked ? 1 : 0;
            eq.PressurisationControlled = chkPressurisationControlled.Checked ? 1 : 0;
            eq.PWHT = chkPWHT.Checked ? 1 : 0;
            eq.SteamOutWaterFlush = chkSteamedOutPriorWaterFlushing.Checked ? 1 : 0;
            eq.ManagementFactor = (float)numSystemManagementFactor.Value;
            eq.ThermalHistory = cbThermalHistory.Text;
            eq.YearLowestExpTemp = chkEquipmentOperatingManyYear.Checked ? 1 : 0;
            eq.Volume = float.Parse(txtEquipmentVolume.Text);

            eq.TypeOfSoil = cbTypeSoild.Text;
            eq.EnvironmentSensitivity = cbEnvironmentalSensitivity.Text;
            eq.DistanceToGroundWater = float.Parse(txtDistanceGroundWater.Text);
            eq.AdjustmentSettle = cbAdjustmentSettlement.Text;
            eq.ComponentIsWelded = chkComponentWelded.Checked ? 1 : 0;
            eq.TankIsMaintained = chkTankMaintainedAccordance.Checked ? 1 : 0;
            return eq;
        }
    }
}
