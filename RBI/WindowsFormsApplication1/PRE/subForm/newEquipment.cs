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
    public partial class newEquipment : Form
    {
        public newEquipment()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //  dateTimePicker1.Format = DateTimePickerFormat.Custom;
            // dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.comboBox6.SelectedItem = "No";
            this.comboBox7.SelectedItem = "No";
            this.comboBox8.SelectedItem = "No";
            this.comboBox9.SelectedItem = "No";
            this.comboBox10.SelectedItem = "No";
            load();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
        private void load()
        {
            BusEquipForRBI busRBI = new BusEquipForRBI();
            List<String> list = busRBI.getUnitCode();
            for(int i=0; i<list.Count; i++)
            {
                comboBox5.Items.Add(list[i]);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            BusEquipments buseq = new BusEquipments();
            Equipment eq = new Equipment();
            eq.UnitCode = comboBox5.Text;
            eq.ItemNo = textBox1.Text;
            //eq.Type = comboBox2.Text;
            eq.Name = textBox2.Text;
            eq.Quanlitative = comboBox6.Text;
            eq.ProcessStream = comboBox7.Text;
            eq.Pressure = comboBox8.Text;
            eq.PHA = comboBox9.Text;
            eq.Business = comboBox10.Text;
            eq.ProcessStreamFluid = textBox3.Text;
            eq.OperatingPressure = textBox4.Text;
            eq.PHARating = textBox6.Text;
            eq.BusinessLossValue = textBox7.Text;
            //eq.Group = comboBox4.Text;
            //eq.EquipmentDescription = textBox5.Text;
            if (buseq.checkExist(eq))
            {
                buseq.edit(eq, eq.ItemNo);
            }
            else
            {
                buseq.add(eq);
            }    
        }
    }
}
