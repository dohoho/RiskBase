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
    public partial class UCStreamTankBottom : UserControl
    {
        public UCStreamTankBottom()
        {
            InitializeComponent();
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
    }
}
