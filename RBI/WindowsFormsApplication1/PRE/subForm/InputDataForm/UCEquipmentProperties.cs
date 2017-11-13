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
using RBI.BUS.BUSMSSQL;
namespace RBI.PRE.subForm.InputDataForm
{
    public partial class UCEquipmentProperties : UserControl
    {
        string[] itemsOnlineMonitoring = {  
                                             "Amine high velocity corrosion - Corrosion coupons",
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
                                            "Sulfuric acid (H2S/H2) corrosion low velocity - Key process parameters"
                                            };
        string[] itemsExternalEnvironment = { "Arid/dry", "Marine", "Severe", "Temperate"};
        string[] itemsThermalHistory = { "None", "Solution Annealed", "Stabilised After Welding", "Stabilised Before Welding" };
        public UCEquipmentProperties()
        {
            InitializeComponent();
            addItemsOnlineMonitoring();
            addItemsExternalEnvironment();
            addItemsThermalHistory();
        }
        public UCEquipmentProperties(int ID)
        {
            InitializeComponent();
            addItemsOnlineMonitoring();
            addItemsExternalEnvironment();
            addItemsThermalHistory();
            ShowDatatoControl(ID);
        }
        public void ShowDatatoControl(int ID)
        {
            RW_EQUIPMENT_BUS eqBus = new RW_EQUIPMENT_BUS();
            List<RW_EQUIPMENT> listEq = eqBus.getDataSource();
            foreach(RW_EQUIPMENT e in listEq)
            {
                if(e.ID == ID)
                {
                    chkAministrativeControl.Checked = e.AdminUpsetManagement == 1 ? true : false;
                    chkHighlyEffectiveInspection.Checked = e.HighlyDeadlegInsp == 1 ? true : false;
                    chkDowntimeProtection.Checked = e.DowntimeProtectionUsed == 1 ? true : false;
                    chkHeatTraced.Checked = e.HeatTraced == 1 ? true : false;
                    chkInterfaceSoilWater.Checked = e.InterfaceSoilWater == 1 ? true : false;
                    chkEquipmentOperatingManyYear.Checked = e.YearLowestExpTemp == 1 ? true : false;
                    chkMaterialExposedFluid.Checked = e.MaterialExposedToClExt == 1 ? true : false;
                    chkPresenceSulphideOperation.Checked = e.PresenceSulphidesO2 == 1 ? true : false;
                    chkContainsDeadlegs.Checked = e.ContainsDeadlegs == 1 ? true : false;
                    chkCylicOperation.Checked = e.CyclicOperation == 1 ? true : false;
                    chkSteamedOutPriorWaterFlushing.Checked = e.SteamOutWaterFlush == 1 ? true : false;
                    chkPWHT.Checked = e.PWHT == 1 ? true : false;
                    chkLinerOnlineMonitoring.Checked = e.LinerOnlineMonitoring == 1 ? true : false;
                    chkPresenceSulphideShutdown.Checked = e.PresenceSulphidesO2Shutdown == 1 ? true : false;
                    txtMinRequiredTemperature.Text = e.MinReqTemperaturePressurisation.ToString();
                    for(int i = 0; i < itemsExternalEnvironment.Length; i++)
                    {

                        if (itemsExternalEnvironment[i] == e.ExternalEnvironment)
                        {
                            cbExternalEnvironment.SelectedIndex = i+1;
                            Console.WriteLine("Exter env " + i);
                        }
                    }
                    for (int j = 0; j < itemsOnlineMonitoring.Length; j++ )
                    {
                        if (itemsOnlineMonitoring[j] == e.OnlineMonitoring)
                        {
                            cbOnlineMonitoring.SelectedIndex = j+1;
                            Console.WriteLine("Online Monitoring " + j);
                        }
                    }
                    for (int i = 0; i < itemsThermalHistory.Length; i++ )
                    {
                        if (itemsThermalHistory[i] == e.ThermalHistory)
                        {
                            cbThermalHistory.SelectedIndex = i + 1;
                            Console.WriteLine("Therminal History " + i);
                        }
                    }
                    
                    
                    
                    //numSystemManagementFactor.Value = e.S
                    txtEquipmentVolume.Text = e.Volume.ToString();
                }
            }
        }
        
        public RW_EQUIPMENT getData()
        {
            RW_EQUIPMENT eq = new RW_EQUIPMENT();
            RW_ASSESSMENT_BUS assBus = new RW_ASSESSMENT_BUS();
            List<RW_ASSESSMENT> listAss = assBus.getDataSource();
            eq.ID = listAss[listAss.Count - 1].ID;
            eq.AdminUpsetManagement = chkAministrativeControl.Checked ? 1 : 0;
            eq.ContainsDeadlegs = chkContainsDeadlegs.Checked ? 1 : 0;
            eq.CyclicOperation = chkCylicOperation.Checked ? 1 : 0;
            eq.HighlyDeadlegInsp = chkHighlyEffectiveInspection.Checked ? 1 : 0;
            eq.DowntimeProtectionUsed = chkDowntimeProtection.Checked ? 1 : 0;
            eq.ExternalEnvironment = cbExternalEnvironment.Text;
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
            //eq.CommissionDate = 
            return eq;
        }
        
        private void txtMinRequiredTemperature_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtMinRequiredTemperature_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!Char.IsDigit(e.KeyChar)&&!Char.IsControl(e.KeyChar))
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
        private void addItemsOnlineMonitoring()
        {
            cbOnlineMonitoring.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < itemsOnlineMonitoring.Length; i++)
            {
                cbOnlineMonitoring.Properties.Items.Add(itemsOnlineMonitoring[i], i, i);
            }
        }
        private void addItemsExternalEnvironment()
        {
            cbExternalEnvironment.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < itemsExternalEnvironment.Length; i++)
            {
                cbExternalEnvironment.Properties.Items.Add(itemsExternalEnvironment[i], i, i);
            }
        }
        private void addItemsThermalHistory()
        {
            cbThermalHistory.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < itemsThermalHistory.Length; i++)
            {
                cbThermalHistory.Properties.Items.Add(itemsThermalHistory[i], i, i);
            }
        }
    }
}
