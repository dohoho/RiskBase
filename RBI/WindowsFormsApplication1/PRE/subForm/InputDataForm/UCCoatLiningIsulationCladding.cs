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
    public partial class UCCoatLiningIsulationCladding : UserControl
    {
        public UCCoatLiningIsulationCladding()
        {
            InitializeComponent();
        }
        public RW_COATING getData()
        {
            RW_COATING coat = new RW_COATING();
            coat.ExternalCoating = chkExternalCoat.Checked ? 1 : 0;
            coat.ExternalInsulation = chkExternalIsulation.Checked ? 1 : 0;
            coat.InternalCladding = chkInternalCladding.Checked ? 1 : 0;
            coat.InternalCoating = chkInternalCoat.Checked ? 1 : 0;
            coat.ExternalCoatingDate = dateExternalCoating.DateTime;
            coat.ExternalCoatingQuality = cbExternalCoatQuality.Text;
            coat.ExternalInsulationType = cbExternalIsulation.Text;
            coat.InsulationContainsChloride = chkInsulationContainsChlorides.Checked ? 1 : 0;
            coat.InternalLinerCondition = cbInternalLinerCondition.Text;
            coat.InternalLinerType = cbInternalLinerType.Text;
            coat.InternalLining = chkInternalLining.Checked ? 1 : 0;

            coat.CladdingCorrosionRate = txtCladdingCorrosionRate.Text == "" ? 0 : float.Parse(txtCladdingCorrosionRate.Text);
            coat.SupportConfigNotAllowCoatingMaint = chkSupport.Checked ? 1 : 0;
            return coat;
        }
    }
}
