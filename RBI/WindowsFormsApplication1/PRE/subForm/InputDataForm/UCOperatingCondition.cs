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
    public partial class UCOperatingCondition : UserControl
    {
        public UCOperatingCondition()
        {
            InitializeComponent();
        }

        RW_STREAM str = new RW_STREAM();
        public RW_STREAM getData()
        {
            
            str.FlowRate = txtFlowRate.Text != "" ? float.Parse(txtFlowRate.Text) : 0;
            str.MaxOperatingPressure = txtMaxOperatingPressure.Text != "" ? float.Parse(txtMaxOperatingPressure.Text) : 0;
            str.MinOperatingPressure = txtMinOperatingPressure.Text != "" ? float.Parse(txtMinOperatingPressure.Text) : 0;
            str.MaxOperatingTemperature = txtMaximumOperatingTemp.Text != "" ? float.Parse(txtMaximumOperatingTemp.Text) : 0;
            str.MinOperatingTemperature = txtMinimumOperatingTemp.Text != "" ? float.Parse(txtMinimumOperatingTemp.Text) : 0;
            str.CriticalExposureTemperature = txtCriticalExposure.Text != "" ? float.Parse(txtCriticalExposure.Text) : 0;
            str.H2SPartialPressure = txtOperatingHydrogen.Text != "" ? float.Parse(txtOperatingHydrogen.Text) : 0;
            str.CUI_PERCENT_1 = txtOp12.Text != "" ? float.Parse(txtOp12.Text) : 0;
            str.CUI_PERCENT_2 = txtOp8.Text != "" ? float.Parse(txtOp8.Text) : 0;
            str.CUI_PERCENT_3 = txtOp6.Text != "" ? float.Parse(txtOp6.Text) : 0;
            str.CUI_PERCENT_4 = txtOp32.Text != "" ? float.Parse(txtOp32.Text) : 0;
            str.CUI_PERCENT_5 = txtOp71.Text != "" ? float.Parse(txtOp71.Text) : 0;
            str.CUI_PERCENT_6 = txtOp107.Text != "" ? float.Parse(txtOp107.Text) : 0;
            str.CUI_PERCENT_7 = txtOp121.Text != "" ? float.Parse(txtOp121.Text) : 0;
            str.CUI_PERCENT_8 = txtOp135.Text != "" ? float.Parse(txtOp135.Text) : 0;
            str.CUI_PERCENT_9 = txtOp162.Text != "" ? float.Parse(txtOp162.Text) : 0;
            str.CUI_PERCENT_10 = txtOp176.Text != "" ? float.Parse(txtOp176.Text) : 0;
            return str;
        }
        public RW_INPUT_CA_LEVEL_1 getDataforCA()
        {
            RW_INPUT_CA_LEVEL_1 ca = new RW_INPUT_CA_LEVEL_1();
            ca.Stored_Pressure = txtMinOperatingPressure.Text != "" ? float.Parse(txtMinOperatingPressure.Text) * 6.895f : 0;
            ca.Stored_Temp = txtMinimumOperatingTemp.Text != "" ? float.Parse(txtMinimumOperatingTemp.Text) + 273 : 0;
            return ca;
        }

        #region KeyPress Event Handle
        private void keyPressEvent(TextBox textbox, KeyPressEventArgs ev, bool percent)
        {
            string a = textbox.Text;
            if (!char.IsControl(ev.KeyChar) && !char.IsDigit(ev.KeyChar) && (ev.KeyChar != '.')&&(ev.KeyChar!='-'))
            {
                ev.Handled = true;
            }
            if(a.StartsWith("-") && ev.KeyChar == '-' && !percent)
            {
                ev.Handled = true;
            }
            if (a.Contains('.') && ev.KeyChar == '.')
            {
                ev.Handled = true;
            }
        }
        private void txtMaximumOperatingTemp_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtMaximumOperatingTemp, e, false);
        }

        private void txtMinimumOperatingTemp_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtMinimumOperatingTemp, e, false);
        }

        private void txtOperatingHydrogen_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtOperatingHydrogen, e, false);
        }

        private void txtCriticalExposure_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtCriticalExposure, e, false);
        }

        private void txtMaxOperatingPressure_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtMaximumOperatingTemp, e, false);
        }
        private void txtMinOperatingPressure_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtMinimumOperatingTemp, e, false);
        }

        private void txtFlowRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtFlowRate, e, true);
        }

        private void txtOp12_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtOp12, e, true);
        }

        private void txtOp8_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtOp8, e, true);
        }

        private void txtOp6_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtOp6, e, true);
        }

        private void txtOp32_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtOp32, e, true);
        }
        private void txtOp71_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtOp71, e, true);
        }

        private void txtOp107_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtOp107, e, true);
        }

        private void txtOp121_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtOp121, e, true);
        }

        private void txtOp135_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtOp135, e, true);
        }

        private void txtOp162_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtOp162, e, true);
        }

        private void txtOp176_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtOp176, e, true);
        }
        #endregion
    }
}
