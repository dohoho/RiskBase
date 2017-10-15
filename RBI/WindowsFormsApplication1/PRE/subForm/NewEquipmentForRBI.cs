using RBI.BUS;
using RBI.Object;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RBI.PRE.subForm
{
    public partial class NewEquipmentForRBI : Form
    {
        public NewEquipmentForRBI()
        {
            InitializeComponent();
            load();
        }
        private void load()
        {
            BusEquipForRBI buseq = new BusEquipForRBI();
            List<String> unitcode = buseq.getUnitCode();
            for(int i=0; i< unitcode.Count; i++)
            {
                comboBox1.Items.Add(unitcode[i]);
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EquipmentForRbi eq = new EquipmentForRbi();
            BusEquipForRBI buseq = new BusEquipForRBI();
            eq.UnitCode = textBox1.Text;
            eq.UnitName = textBox3.Text;
            eq.ProcessSystem = textBox2.Text;
            if (!buseq.checkExist(eq))
            {
                buseq.add(eq);
            }
            WatingForm wt = new WatingForm();
            wt.ShowDialog(this);
            this.Close();
        }
    }
}
