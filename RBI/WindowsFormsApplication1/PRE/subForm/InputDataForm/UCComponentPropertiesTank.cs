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
    public partial class UCComponentPropertiesTank : UserControl
    {
        public UCComponentPropertiesTank()
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
        public RW_CA_TANK getDataforTank()
        {
            RW_CA_TANK tank = new RW_CA_TANK();
            tank.TANK_DIAMETER = txtTankDiameter.Text != "" ? float.Parse(txtTankDiameter.Text) : 0;
            tank.PREVENTION_BARRIER = chkPreventionBarrier.Checked == true ? 1 : 0;
            tank.SHELL_COURSE_HEIGHT = txtShellCourseHeight.Text != "" ? float.Parse(txtShellCourseHeight.Text) : 0;
            return tank;
        }
    }
}
