using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RBI.Object.ObjectMSSQL;

namespace RBI.PRE.subForm.InputDataForm
{
    public partial class Facility : Form
    {
        public Facility()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FacilityInput faci = new FacilityInput();
            faci.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //public FACILITY getData()
        //{
        //    FACILITY fa = new FACILITY();
        //    fa.FacilityName = txt
        //}
    }
}
