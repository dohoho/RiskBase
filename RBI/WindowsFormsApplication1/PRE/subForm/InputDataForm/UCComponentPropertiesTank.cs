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
        private void keyPressEvent(TextBox textbox, KeyPressEventArgs ev)
        {
            string a = textbox.Text;
            if (!char.IsControl(ev.KeyChar) && !char.IsDigit(ev.KeyChar) && (ev.KeyChar != '.'))
            {
                ev.Handled = true;
            }
            if (a.Contains('.') && ev.KeyChar == '.')
            {
                ev.Handled = true;
            }
        }

        private void txtTankDiameter_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtTankDiameter, e);
        }

        private void txtCurrentThickness_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtCurrentThickness, e);
        }

        private void txtCurrentCorrosionRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtCurrentCorrosionRate, e);
        }

        private void txtShellCourseHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtShellCourseHeight, e);
        }

        private void txtNominalThickness_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtNominalThickness, e);
        }

        private void txtMinRequiredThickness_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtMinRequiredThickness, e);
        }

        private void txtNumberInsp_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtNumberInsp, e);
        }

    }
}
