using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RBI.Object;
using RBI.BUS;

namespace RBI.PRE.subForm
{
    public partial class UCFullPlant : UserControl
    {
        public UCFullPlant()
        {
            InitializeComponent();
            load();
        }
        public void load()
        {
            //BusEquipments busEq = new BusEquipments();
            //List<Equipment> list = busEq.loads();
            BusEquipForRBI busEq = new BusEquipForRBI();
            List<EquipmentForRbi> list = busEq.load();
            dataGridView1.DataSource = list;
            dataGridView1.Columns[0].HeaderText = "Unit Code New";
            dataGridView1.Columns[1].HeaderText = "Unit Name New";
            dataGridView1.Columns[2].HeaderText = "Process New";

            dataGridView1.Rows[1].DefaultCellStyle.Font = new Font("Arial", 16);
        }
    }
}
