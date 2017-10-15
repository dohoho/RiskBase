using RBI.BUS;
using RBI.BUS.BUSXML;
using RBI.Object;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RBI.PRE.subForm
{
    public partial class NewPlant : Form
    {
        public NewPlant()
        {
            InitializeComponent();
            loadCombobox();
        }
        private void loadCombobox()
        {
            ReadXML readXML = new ReadXML();
            BusEquipForRBI buseq = new BusEquipForRBI();
            // componet
            List<String> component = readXML.getListComponet();
            for(int i = 0; i < component.Count; i++)
            {
                cbbComponent.Items.Add(component[i]);
            }
            // operaState
            List<String> operaState = readXML.getListOpState();
            for(int i =0; i < operaState.Count; i++)
            {
                cbbOperatingType.Items.Add(operaState[i]);
            }
            // Contaminants
            List<String> contaminants = readXML.getListContaminants();
            for(int i=0; i< contaminants.Count; i++)
            {
                cbbContaminants.Items.Add(contaminants[i]);
            }
            //insp tech
            List<String> tech = readXML.getListTechnique();
            for(int i=0; i< tech.Count; i++)
            {
                cbbInspTech.Items.Add(tech[i]);
            }
            //
            List<String> unitcode = buseq.getUnitCode();
            for (int i = 0; i < unitcode.Count; i++)
            {
                cbbUnit.Items.Add(unitcode[i]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            EquipmentTemp eq = new EquipmentTemp();
            eq.Plant = cbbPlant.Text;
            eq.ItemNo = cbbEquipment.Text;
            eq.ComName = cbbComponent.Text;

            eq.OperingPressInlet = txtOperingPressInlet.Text;
            eq.OperingPressOutlet = txtOperingPressOutlet.Text;
            eq.OperTempInlet = txtOperTempInlet.Text;
            eq.OperTempOutlet = txtOperTempOutlet.Text;

            eq.TestPress = txtTestPress.Text;
            eq.LDTBXHCovered = cbbLDTBXHCovered.Text;
            eq.InsulatedType = txtInsulation.Text;
            eq.InventoryTotal = txtInventoryTotal.Text;
            eq.FrequentFeedChanged = cbbFrequent.Text;
            eq.CathodicProtection = cbbCathodic.Text;
            eq.EquipCount = txtEquipCount.Text;
            eq.EnvRating = txtEnvRating.Text;
            eq.VaporDensity = txtVaporDensity.Text;
            eq.HMBPFDNum = txtHMBPFDNum.Text;

            eq.MDMT = txtMDMT.Text;
            eq.Insulated = cbbInsulated.Text;
            eq.OperatingState = cbbOperatingType.Text;
            eq.ConfidentInStreamAnalysis = cbbConfidentStream.Text;
            eq.MajorChemicals = txtMajor.Text;
            eq.CorrosionMonitoring = cbbCorrosionMonitoring.Text;
            eq.HAZOPRating = txtHAZOP.Text;
            eq.InspTechUsed = cbbInspTech.Text;
            eq.LiquipDensity = txtLiquip.Text;
            eq.PIDNum = txtPIDNum.Text;

            eq.InService = cbbInservice.Text;
            eq.PWHT = cbbPWHT.Text;
            eq.InventoryLiquip = txtInventoryLiquip.Text;
            eq.VaporDensity = cbbVaporDensity.Text;
            eq.Contaminants = cbbContaminants.Text;
            eq.OHCalibUptodate = cbbOH.Text;
            eq.PersonalDensity = txtPersonelDensity.Text;
            eq.EquipModification = txtEquipModifications.Text;
            eq.Vapor = txtVapor.Text;
            eq.Service = txtService.Text;

            eq.ServiceDate = dateService.Text;
            eq.LastInternalInspectionDate = dateInspection.Text;
            eq.InventoryVapor = txtInventoryVapor.Text;
            eq.CorrosionInhibitor = cbbCorrosion.Text;
            eq.OnLineMonitoring = cbbOnlineMonitoring.Text;
            eq.DistFromFacility = txtDistFrom.Text;
            eq.MitigationEquip = txtMigitation.Text;
            eq.InspectionFinding = txtInspectionFindings.Text;
            eq.Liquip = txtLiquip.Text;
            eq.HMBStream = txtHMBStream.Text;

            BusEquipmentTemp busTemp = new BusEquipmentTemp();
            if(!busTemp.checkExist(cbbPlant.Text, cbbEquipment.Text, cbbComponent.Text))
            {
                busTemp.add(eq);
            }  
        }
    }
}
