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
    public partial class UCComponentProperties : UserControl
    {
        public UCComponentProperties()
        {
            InitializeComponent();
        }
        public RW_COMPONENT getData()
        {
            RW_COMPONENT comp = new RW_COMPONENT();
            comp.NominalDiameter = txtNominalDiameter.Text != "" ? float.Parse(txtNominalDiameter.Text) : 0;
            comp.NominalThickness = txtNominalThickness.Text != "" ? float.Parse(txtNominalThickness.Text) : 0;
            comp.CurrentThickness = txtCurrentThickness.Text != "" ? float.Parse(txtCurrentThickness.Text) : 0;
            comp.MinReqThickness = txtMinRequiredThickness.Text != "" ? float.Parse(txtMinRequiredThickness.Text) : 0;
            comp.CurrentCorrosionRate = txtCurrentCorrosionRate.Text != "" ? float.Parse(txtCurrentCorrosionRate.Text) : 0;
            comp.BranchDiameter = cbBranchDiameter.Text;
            comp.BranchJointType = cbJointTypeBranch.Text;
            comp.BrinnelHardness = cbMaxBrillnessHardness.Text;
            comp.CracksPresent = chkPresenceCracks.Checked ? 1 : 0;

            return comp;
        }
       
    }
}
