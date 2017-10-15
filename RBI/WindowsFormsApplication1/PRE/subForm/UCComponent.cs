using System;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RBI.BUS;
using System.Collections.Generic;
using RBI.Object;

namespace RBI.PRE.subForm
{
    public partial class UCComponent : UserControl
    {
        public UCComponent()
        {
            InitializeComponent();
            load();
        }
        private void load()
        {
            BusComponents bus = new BusComponents();
            List<Component> list = bus.loads();
            DataGridViewRow row;
            for(int i = 0; i< list.Count; i++)
            {
                row = new DataGridViewRow();
                row.CreateCells(dataGridView1);
                row.Cells[0].Value = list[i].Name;
                row.Cells[1].Value = list[i].Description;
                row.Cells[2].Value = list[i].MOC;
                row.Cells[3].Value = list[i].LinerMOC;
                row.Cells[4].Value = list[i].HeightLength;
                row.Cells[5].Value = list[i].Diameter;
                row.Cells[6].Value = list[i].NorminalThickness;
                row.Cells[7].Value = list[i].CA;
                row.Cells[8].Value = list[i].DesignPressure;
                row.Cells[9].Value = list[i].DesignTemp;
                dataGridView1.Rows.Add(row);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
