using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RBI.PRE.subForm
{
    public partial class UCRisksummery : UserControl
    {
        public UCRisksummery()
        {
            InitializeComponent();
            radioButton1.Checked = true;

            subUCequipment subEq = new subUCequipment();
            subEq.Dock = DockStyle.Fill;
            groupBox2.Controls.Add(subEq);
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            groupBox2.Controls.Clear();
            // add UCcontrol to GroupBox
            subUCequipment subEq = new subUCequipment();
            subEq.Dock = DockStyle.Fill;
            groupBox2.Controls.Add(subEq);
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            groupBox2.Controls.Clear();
            //add component to groupbox
            subUCcomponent subCo = new subUCcomponent();
            subCo.Dock = DockStyle.Fill;
            groupBox2.Controls.Add(subCo);
        }
    }
}
