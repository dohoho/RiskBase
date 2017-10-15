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
    public partial class UCEquipmentForRBI : UserControl
    {
        public UCEquipmentForRBI()
        {
            InitializeComponent();
            load();
        }
        private void load()
        {
            BusEquipments busEQ = new BusEquipments();
            BusEquipForRBI busEq = new BusEquipForRBI();
            List<EquipmentForRbi> listEq = busEq.load();
            DataGridViewRow row;
            for( int i = 0; i < listEq.Count; i++)
            {
                row = new DataGridViewRow();
                row.CreateCells(dataGridView1);
                row.Cells[0].Value = listEq[i].UnitCode;
                row.Cells[1].Value = listEq[i].UnitName;
                row.Cells[2].Value = listEq[i].ProcessSystem;
                row.Cells[3].Value = busEQ.getQty(listEq[i].UnitCode);
                row.Cells[4].Value = busEQ.getSemi(listEq[i].UnitCode);
                row.Cells[5].Value = busEQ.getQty(listEq[i].UnitCode) - busEQ.getSemi(listEq[i].UnitCode);
                dataGridView1.Rows.Add(row);
            }
            //dataGridView1.DataSource = listEq;
        }

        private DataTable toDataTable( List<EquipmentForRbi> list)
        {
            DataTable dt = new DataTable();

            return dt;
        }
    }
}
