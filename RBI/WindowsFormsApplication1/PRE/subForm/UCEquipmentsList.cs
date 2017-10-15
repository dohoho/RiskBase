using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RBI.BUS;
using RBI.Object;

namespace RBI.PRE.subForm
{
    public partial class UCEquipmentsList : UserControl
    {
        public UCEquipmentsList()
        {
            InitializeComponent();
            getUnitCode();
            load("");
        }
        private void load(String data)
        {
            BusEquipments busEq = new BusEquipments();
            List<Equipment> list;
            if (data.Equals("")||data.Equals("<All>"))
            {
                list =  busEq.loads();
            }
            else
            {
                list = busEq.loads(data);
            }
             
            DataGridViewRow row;
            for(int i = 0; i < list.Count; i++)
            {
                int x, y;
                row = new DataGridViewRow();
                row.CreateCells(dataGridView2);
                row.Cells[0].Value = list[i].ItemNo;
                row.Cells[1].Value = list[i].Name;
                row.Cells[2].Value = list[i].Qty;
                row.Cells[3].Value = list[i].Semi_Quanty;
                if (list[i].Qty.Equals(""))
                {
                    x = 0;
                }
                else
                {
                    x = int.Parse(list[i].Qty);
                }

                if (list[i].Semi_Quanty.Equals(""))
                {
                    y = 0;
                }
                else
                {
                    y = int.Parse(list[i].Semi_Quanty);
                }
                row.Cells[4].Value = x - y;
                row.Cells[5].Value = list[i].ProcessStream;
                row.Cells[6].Value = list[i].Pressure;
                row.Cells[7].Value = list[i].PHA;
                row.Cells[8].Value = list[i].Business;
                row.Cells[9].Value = list[i].ProcessStreamFluid;
                row.Cells[10].Value = list[i].OperatingPressure;
                row.Cells[11].Value = list[i].PHARating;
                row.Cells[12].Value = list[i].BusinessLossValue;
                dataGridView2.Rows.Add(row);
            }
        }
        private void getUnitCode()
        {
            BusEquipForRBI buseq = new BusEquipForRBI();
            List<String> dataCombobox = buseq.getUnitCode();
            for(int i = 0; i< dataCombobox.Count; i++)
            {
                comboBox1.Items.Add(dataCombobox[i]);
            }
            comboBox1.SelectedIndex = 0;
        }
        private void clear()
        {
            dataGridView2.Rows.Clear();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String data = comboBox1.SelectedItem.ToString();
            clear();
            load(data);
        }
    }
}
