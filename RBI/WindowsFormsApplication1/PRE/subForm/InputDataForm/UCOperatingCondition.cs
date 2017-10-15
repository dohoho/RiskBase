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
            //if(tankbottom) -> hide Operating Hydrogen Partial Pressure
            return str;
        }
    }
}
