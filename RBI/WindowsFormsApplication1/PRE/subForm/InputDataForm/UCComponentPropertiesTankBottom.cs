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
    public partial class UCComponentPropertiesTankBottom : UserControl
    {
        public UCComponentPropertiesTankBottom()
        {
            InitializeComponent();
        }
        public RW_COMPONENT getData()
        {
            RW_COMPONENT comp = new RW_COMPONENT();
            comp.NominalDiameter = float.Parse(txtTankDiameter.Text);  //check lai xem co bien Tank Diameter ko
            comp.NominalThickness = float.Parse(txtNominalThickness.Text);
            comp.CurrentThickness = float.Parse(txtCurrentThickness.Text);
            comp.MinReqThickness = float.Parse(txtMinRequiredThickness.Text);
            comp.CurrentCorrosionRate = float.Parse(txtCurrentCorrosionRate.Text);
            comp.BrinnelHardness = cbMaxBrillnessHardness.Text;

            comp.ReleasePreventionBarrier = chkPreventionBarrier.Checked ? 1 : 0;
            comp.SeverityOfVibration = cbSeverityVibration.Text;
            comp.ConcreteFoundation = chkConcreteAsphalt.Checked ? 1 : 0;
            return comp;
        }
       
    }
}
