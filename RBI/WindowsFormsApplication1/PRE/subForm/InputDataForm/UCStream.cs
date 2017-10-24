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
    public partial class UCStream : UserControl
    {

        string[] itemsExposureAmine = { "High Rich Amine", "Low Lean Amine", "None" };
        string[] itemsAmineSolutionComposition = { "Diethanolamine DEA", "Diglycolamine DGA", "Disopropanolamine DIPA", "Methyldiethanolamine MDEA", "Monoethanolamine MEA", "Sulfinol" };
        public UCStream()
        {
            InitializeComponent();
            addItemsExposureAmine();
            addItemsAmineSolutionComposition();
        }
        private void addItemsExposureAmine()
        {
            cbExposureAmine.Properties.Items.Add("",-1,-1);
            for (int i = 0; i < itemsExposureAmine.Length; i++ )
            {
                cbExposureAmine.Properties.Items.Add(itemsExposureAmine[i], i, i);
            }
        }
        private void addItemsAmineSolutionComposition()
        {
            cbAmineSolutionComposition.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < itemsAmineSolutionComposition.Length; i++ )
            {
                cbAmineSolutionComposition.Properties.Items.Add(itemsAmineSolutionComposition[i], i, i);
            }
        }
        RW_STREAM stream = new RW_STREAM();
        public RW_STREAM getData()
        {
            stream.AmineSolution = cbAmineSolutionComposition.Text;
            stream.AqueousOperation = chkAqueousPhaseDuringOperation.Checked ? 1 : 0;
            stream.AqueousShutdown = chkAqueousPhaseShutdown.Checked ? 1 : 0;
            stream.ToxicConstituent = chkToxicConstituents.Checked ? 1 : 0;
            stream.Caustic = chkEnvironmentContainsCaustic.Checked ? 1 : 0;
            stream.Chloride = txtChlorideIon.Text != "" ? float.Parse(txtChlorideIon.Text) : 0;
            stream.CO3Concentration = txtCO3ConcentrationWater.Text != "" ? float.Parse(txtCO3ConcentrationWater.Text) : 0;
            stream.Cyanide = chkPresenceCyanides.Checked ? 1 : 0;
            stream.ExposedToGasAmine = chkExposedAcidGas.Checked ? 1 : 0;
            stream.ExposedToSulphur = chkExposedSulphurBearing.Checked ? 1 : 0;
            stream.ExposureToAmine = cbExposureAmine.Text;
            stream.H2S = chkEnviromentContainsH2S.Checked ? 1 : 0;
            stream.H2SInWater = txtH2SContentInWater.Text != "" ? float.Parse(txtH2SContentInWater.Text) : 0;
            stream.Hydrogen = chkProcessContainsHydrogen.Checked ? 1 : 0;
            stream.MaterialExposedToClInt = chkChlorine.Checked ? 1 : 0;
            stream.NaOHConcentration = txtNaOHConcentration.Text != "" ? float.Parse(txtNaOHConcentration.Text) : 0;
            stream.ReleaseFluidPercentToxic = txtReleaseFluidPercent.Text != "" ? float.Parse(txtReleaseFluidPercent.Text) : 0;
            stream.WaterpH = txtpHWater.Text != "" ? float.Parse(txtpHWater.Text) : 0;
            stream.Hydrofluoric = chkPresenceHydrofluoricAcid.Checked ? 1 : 0;
            return stream;
        }
    }
}
