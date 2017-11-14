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
    public partial class UCCoatLiningIsulationCladding : UserControl
    {
        public UCCoatLiningIsulationCladding()
        {
            InitializeComponent();
        }
        public UCCoatLiningIsulationCladding(int ID)
        {
            InitializeComponent();
            ShowDatatoControl(ID);
        }
        public void ShowDatatoControl(int ID)
        {
            RW_COATING_BUS BUS = new RW_COATING_BUS();
            RW_COATING coat = BUS.getData(ID);
            String[] extQuality = { "No coating or poor quality", "Medium coating quality", "High coating quality" };
            String[] inType = { "Organic", "Castable refractory", "Strip lined alloy", "Castable refractory severe condition", "Glass lined", "Acid Brick", "Fibreglass" };
            String[] inCon = { "Good", "Average", "Poor", "Unknown" };
            String[] extType = { "Foam Glass", "Pearlite", "Fibreglass", "Mineral Wool", "Calcium Silicate", "Asbestos" };
            String[] isuCon = { "Above average", "Average", "Below average" };
            if (coat.ExternalCoating == 1)
                chkExternalCoat.Checked = true;
            else
                chkExternalCoat.Checked = false;

            if (coat.ExternalInsulation == 1)
                chkExternalIsulation.Checked = true;
            else
                chkExternalIsulation.Checked = false;

            if (coat.InternalCladding == 1)
                chkInternalCladding.Checked = true;
            else
                chkInternalCladding.Checked = false;

            if (coat.InternalCoating == 1)
                chkInternalCoat.Checked = true;
            else
                chkInternalCoat.Checked = false;

            if (coat.InternalLining == 1)
                chkInternalLining.Checked = true;
            else
                chkInternalLining.Checked = false;

            dateExternalCoating.DateTime = coat.ExternalCoatingDate;


            for (int i = 0; i < extQuality.Length; i++)
            {
                if (coat.ExternalCoatingQuality == extQuality[i])
                {
                    cbExternalCoatQuality.SelectedIndex = i;
                    break;
                }
            }
            for (int i = 0; i < extType.Length; i++)
            {
                if (coat.ExternalInsulationType == extType[i])
                {
                    cbExternalIsulation.SelectedIndex = i + 1;
                    break;
                }
            }
            for (int i = 0; i < inCon.Length; i++)
            {
                if (coat.InternalLinerCondition == inCon[i])
                {
                    cbInternalLinerCondition.SelectedIndex = i + 1;
                    break;
                }
            }

            if (coat.InsulationContainsChloride == 1)
                chkInsulationContainsChlorides.Checked = true;
            else
                chkInsulationContainsChlorides.Checked = false;

            for (int i = 0; i < inType.Length; i++)
            {
                if (coat.InternalLinerType == inType[i])
                {
                    cbInternalLinerType.SelectedIndex = i + 1;
                    break;
                }
            }

            txtCladdingCorrosionRate.Text = coat.CladdingCorrosionRate.ToString();

            if (coat.SupportConfigNotAllowCoatingMaint == 1)
                chkSupport.Checked = true;
            else
                chkSupport.Checked = false;

            for (int i = 0; i < isuCon.Length; i++)
            {
                if (coat.InsulationCondition == isuCon[i])
                {
                    cbIsulationCondition.SelectedIndex = i + 1;
                    break;
                }
            }
        }
        public RW_COATING getData(int ID)
        {
            RW_COATING coat = new RW_COATING();
            coat.ID = ID;
            coat.ExternalCoating = chkExternalCoat.Checked ? 1 : 0;
            coat.ExternalInsulation = chkExternalIsulation.Checked ? 1 : 0;
            coat.InternalCladding = chkInternalCladding.Checked ? 1 : 0;
            coat.InternalCoating = chkInternalCoat.Checked ? 1 : 0;
            coat.InternalLining = chkInternalLining.Checked ? 1 : 0;
            coat.ExternalCoatingDate = dateExternalCoating.DateTime;
            coat.ExternalCoatingQuality = cbExternalCoatQuality.Text;
            coat.ExternalInsulationType = cbExternalIsulation.Text;
            coat.InternalLinerCondition = cbInternalLinerCondition.Text;
            coat.InsulationContainsChloride = chkInsulationContainsChlorides.Checked ? 1 : 0;
            coat.InternalLinerType = cbInternalLinerType.Text;
            coat.CladdingCorrosionRate = txtCladdingCorrosionRate.Text == "" ? 0 : float.Parse(txtCladdingCorrosionRate.Text);
            coat.SupportConfigNotAllowCoatingMaint = chkSupport.Checked ? 1 : 0;
            coat.InsulationCondition = cbIsulationCondition.Text;
            return coat;
        }

        private void chkInternalLining_CheckedChanged(object sender, EventArgs e)
        {
            if(chkInternalLining.Checked)
            {
                cbInternalLinerType.Enabled = true;
                cbInternalLinerCondition.Enabled = true;
            }
            else
            {
                cbInternalLinerType.Enabled = false;
                cbInternalLinerCondition.Enabled = false;
            }
        }

        private void chkExternalIsulation_CheckedChanged(object sender, EventArgs e)
        {
            if(chkExternalIsulation.Checked)
            {
                cbIsulationCondition.Enabled = true;
                cbExternalIsulation.Enabled = true;
            }
            else
            {
                cbIsulationCondition.Enabled = false;
                cbExternalIsulation.Enabled = false;
            }
        }

        private void chkExternalCoat_CheckedChanged(object sender, EventArgs e)
        {
            if(chkExternalCoat.Checked)
            {
                cbExternalCoatQuality.Enabled = true;
                dateExternalCoating.Enabled = true;
            }
            else
            {
                cbExternalCoatQuality.Enabled = false;
                dateExternalCoating.Enabled = false;
            }
        }
    }
}
