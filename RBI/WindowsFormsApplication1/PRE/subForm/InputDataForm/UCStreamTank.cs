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
    public partial class UCStreamTank : UserControl
    {
        string[] itemsExposureAmine = { "High Rich Amine", "Low Lean Amine", "None" };
        string[] itemsAmineSolutionComposition = { "Diethanolamine DEA", "Diglycolamine DGA", "Disopropanolamine DIPA", "Methyldiethanolamine MDEA", "Monoethanolamine MEA", "Sulfinol" };
        public UCStreamTank()
        {
            InitializeComponent();
            addItemsExposureAmine();
            addItemsAmineSolutionComposition();
        }

        RW_STREAM stream = new RW_STREAM();
        public RW_STREAM getData1()
        {
            stream.AmineSolution = cbAmineSolutionComposition.Text;
            stream.AqueousOperation = chkAqueousPhaseDuringOperation.Checked ? 1 : 0;
            stream.AqueousShutdown = chkAqueousPhaseShutdown.Checked ? 1 : 0;
            stream.Caustic = chkEnvironmentContainsCaustic.Checked ? 1 : 0;
            stream.Chloride = float.Parse(txtChlorideIon.Text);
            stream.CO3Concentration = float.Parse(txtCO3ConcentrationWater.Text);
            stream.Cyanide = chkPresenceCyanides.Checked ? 1 : 0;
            stream.ExposedToGasAmine = chkExposedAcidGas.Checked ? 1 : 0;
            stream.ExposedToSulphur = chkExposedSulphurBearing.Checked ? 1 : 0;
            stream.ExposureToAmine = cbExposureAmine.Text;
            stream.H2S = chkEnviromentContainsH2S.Checked ? 1 : 0;
            stream.H2SInWater = float.Parse(txtH2SContent.Text);
            stream.Hydrogen = chkPresenceHydrofluoricAcid.Checked ? 1 : 0;
            stream.MaterialExposedToClInt = chkChlorine.Checked ? 1 : 0;
            stream.NaOHConcentration = float.Parse(txtNaOHConcentration.Text);
            stream.ReleaseFluidPercentToxic = float.Parse(txtReleaseFluidPercent.Text);
            stream.WaterpH = float.Parse(txtpHWater.Text);
            //if(tankbottom)
            stream.FluidHeight = float.Parse(txtFluidHeight.Text);
            stream.FluidLeaveDikePercent = float.Parse(txtPercentageLeavingDike.Text);
            stream.FluidLeaveDikeRemainOnSitePercent = float.Parse(txtPercentageLeavingRemainsOnSite.Text);
            stream.FluidGoOffSitePercent = float.Parse(txtPercentageFluidGoingOffsite.Text);
            return stream;
        }
        public RW_STREAM getData2()
        {
            UCOperatingCondition ucOperating = new UCOperatingCondition();
            RW_STREAM temp = new RW_STREAM();
            temp = ucOperating.getData();
            return temp;
        }
        public RW_CA_TANK getDataforTank()
        {
            RW_CA_TANK tank = new RW_CA_TANK();
            tank.P_lvdike = txtPercentageLeavingDike.Text != "" ? float.Parse(txtPercentageLeavingDike.Text) : 0;
            tank.P_offsite = txtPercentageFluidGoingOffsite.Text != "" ? float.Parse(txtPercentageFluidGoingOffsite.Text) : 0;
            tank.P_onsite = txtPercentageLeavingRemainsOnSite.Text != "" ? float.Parse(txtPercentageLeavingRemainsOnSite.Text) : 0;
            tank.FLUID_HEIGHT = txtFluidHeight.Text != "" ? float.Parse(txtFluidHeight.Text) : 0;
            tank.TANK_FLUID = btnEditFluid.Text;
            return tank;
        }
        private void addItemsExposureAmine()
        {
            cbExposureAmine.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < itemsExposureAmine.Length; i++)
            {
                cbExposureAmine.Properties.Items.Add(itemsExposureAmine[i], i, i);
            }
        }
        private void addItemsAmineSolutionComposition()
        {
            cbAmineSolutionComposition.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < itemsAmineSolutionComposition.Length; i++)
            {
                cbAmineSolutionComposition.Properties.Items.Add(itemsAmineSolutionComposition[i], i, i);
            }
        }

        #region KeyPress Event Handle
        private void keyPressEvent(TextBox textbox, KeyPressEventArgs ev)
        {
            string a = textbox.Text;
            if (!char.IsControl(ev.KeyChar) && !char.IsDigit(ev.KeyChar) && (ev.KeyChar != '.') && (ev.KeyChar != '-'))
            {
                ev.Handled = true;
            }
            if (a.Contains('.') && ev.KeyChar == '.')
            {
                ev.Handled = true;
            }
        }

        private void txtNaOHConcentration_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtNaOHConcentration, e);
        }

        private void txtChlorideIon_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtChlorideIon, e);
        }

        private void txtH2SContent_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtH2SContent, e);
        }

        private void txtReleaseFluidPercent_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtReleaseFluidPercent, e);
        }

        private void txtCO3ConcentrationWater_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtCO3ConcentrationWater, e);
        }

        private void txtpHWater_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtpHWater, e);
        }
        private void txtFluidHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtFluidHeight, e);
        }
        private void txtPercentageLeavingRemainsOnSite_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtPercentageLeavingRemainsOnSite, e);
        }
        private void txtPercentageLeavingDike_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtPercentageLeavingDike, e);
        }
        private void txtPercentageFluidGoingOffsite_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtPercentageFluidGoingOffsite, e);
        }
        #endregion
    }
}
