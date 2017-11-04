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
    public partial class UCMaterialTank : UserControl
    {
        string[] itemsSulfurContent = { "High > 0.01%", "Low 0.002 - 0.01%", "Ultra Low < 0.002%" };
        string[] itemsHeatTreatment = {"Annealed", "None", "Normalised Temper", "Quench Temper", "Stress Relieved", "Sub Critical PWHT" };
        string[] itemsPTAMterial = {"321 Stainless Steel",
                                "347 Stainless Steel, Alloy 20, Alloy 625, All austenitic weld overlay",
                                "Regular 300 series Stainless Steels and Alloys 600 and 800",
                                "H Grade 300 series Stainless Steels",
                                "L Grade 300 series Stainless Steels",
                                "Not Applicable"};
        public UCMaterialTank()
        {
            InitializeComponent();
            cbPTAMaterial.Enabled = false;
            addSulfurContent();
            addHeatTreatment();
            addPTAMterial();
        }

        private void addSulfurContent()
        {
            cbSulfurContent.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < itemsSulfurContent.Length; i++ )
            {
                cbSulfurContent.Properties.Items.Add(itemsSulfurContent[i], i, i);
            }
        }
        private void addHeatTreatment()
        {
            cbHeatTreatment.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < itemsHeatTreatment.Length; i++ )
            {
                cbHeatTreatment.Properties.Items.Add(itemsHeatTreatment[i], i, i);
            }
        }
        private void addPTAMterial()
        {
            cbPTAMaterialGrade.Properties.Items.Add("",-1,-1);
            for (int i = 0; i < itemsPTAMterial.Length; i++ )
            {
                cbPTAMaterialGrade.Properties.Items.Add(itemsPTAMterial[i], i, i);
            }
        }
        public RW_MATERIAL getData()
        {
            RW_MATERIAL ma = new RW_MATERIAL();
            ma.ID = 2;
            ma.MaterialName = cbPTAMaterial.Text;
            ma.DesignPressure = txtDesignPressure.Text != "" ? float.Parse(txtDesignPressure.Text) : 0;
            ma.DesignTemperature = txtMaxDesignTemperature.Text != "" ? float.Parse(txtMaxDesignTemperature.Text) : 0;
            ma.MinDesignTemperature = txtMinDesignTemperature.Text != "" ? float.Parse(txtMinDesignTemperature.Text) : 0;
            ma.BrittleFractureThickness = txtBrittleFracture.Text != "" ? float.Parse(txtBrittleFracture.Text) : 0;
            ma.CorrosionAllowance = txtCorrosionAllowance.Text != "" ? float.Parse(txtCorrosionAllowance.Text) : 0;
            ma.SulfurContent = cbSulfurContent.Text;
            ma.HeatTreatment = cbHeatTreatment.Text;
            ma.ReferenceTemperature = txtReferenceTemperature.Text != "" ? float.Parse(txtReferenceTemperature.Text) : 0;
            ma.PTAMaterialCode = cbPTAMaterialGrade.Text;
            ma.IsPTA = chkIsPTASeverity.Checked ? 1 : 0;
            ma.Austenitic = chkAusteniticSteel.Checked ? 1 : 0;
            ma.CarbonLowAlloy = chkCarbonLowAlloySteel.Checked ? 1 : 0;
            ma.NickelBased = chkNickelAlloy.Checked ? 1 : 0;
            ma.ChromeMoreEqual12 = chkChromium.Checked ? 1 : 0;
            ma.AllowableStress = txtAllowableStress.Text != "" ? float.Parse(txtAllowableStress.Text) : 0;
            ma.CostFactor = txtMaterialCostFactor.Text != "" ? float.Parse(txtMaterialCostFactor.Text) : 0;
            return ma;
        }
        public RW_INPUT_CA_LEVEL_1 getDataForCA()
        {
            RW_INPUT_CA_LEVEL_1 ca = new RW_INPUT_CA_LEVEL_1();
            ca.Material_Cost = txtMaterialCostFactor.Text != "" ? float.Parse(txtMaterialCostFactor.Text) : 0;
            return ca;
        }
        
        private void chkIsPTASeverity_CheckedChanged(object sender, EventArgs e)
        {
            cbPTAMaterialGrade.Enabled = chkIsPTASeverity.Checked ? true : false;
        }
        private void keyPressEvent(TextBox textbox, KeyPressEventArgs ev)
        {
            string a = textbox.Text;
            if (!char.IsControl(ev.KeyChar) && !char.IsDigit(ev.KeyChar) && (ev.KeyChar != '.'))
            {
                ev.Handled = true;
            }
            if (a.Contains('.') && ev.KeyChar == '.')
            {
                ev.Handled = true;
            }
        }

        private void txtMaxDesignTemperature_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtMaxDesignTemperature, e);
        }

        private void txtDesignPressure_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtDesignPressure, e);
        }

        private void txtAllowableStress_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtAllowableStress, e);
        }

        private void txtCorrosionAllowance_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtCorrosionAllowance, e);
        }

        private void txtMinDesignTemperature_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtMinDesignTemperature, e);
        }

        private void txtReferenceTemperature_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtReferenceTemperature, e);
        }

        private void txtBrittleFracture_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtBrittleFracture, e);
        }
        private void txtMaterialCostFactor_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtMaterialCostFactor, e);
        }

    }
}
