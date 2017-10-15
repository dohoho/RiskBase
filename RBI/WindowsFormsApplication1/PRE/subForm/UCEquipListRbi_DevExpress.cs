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
using DevExpress.XtraGrid.Views.Grid;
//using RBI.Properties;

namespace RBI.PRE.subForm
{
    public partial class UCEquipListRbi_DevExpress : UserControl
    {
        public UCEquipListRbi_DevExpress()
        {
            InitializeComponent();
            Format_Grid();
            loadData()
;        }
        private void Format_Grid()
        {
            gridView1.Columns.Clear();
            String[] fields = { "UnitCode",
                                "UnitName",
                                "ProcessSystem",
                                "Qty",
                                "Semi",
                                "QuanTyTative"};
            String[] caption = {"Unit Code",
                                "Unit Name",
                                "Process System",
                                "Qty.",
                                "Semi - Quantitative",
                                "Quanlitative" };
            for (int i = 0; i < fields.Length; i++)
            {
                DevExpress.XtraGrid.Columns.GridColumn col = new DevExpress.XtraGrid.Columns.GridColumn();
                col.FieldName = fields[i];
                col.Caption = caption[i];
                gridView1.Columns.Add(col);
                //gridView1.Columns[i].Width = 100;
                gridView1.Columns[i].Visible = true;
            }
            gridView1.Columns[1].Width = 250;
            gridView1.BestFitColumns();

            // grid format data
            //col.AppearanceCell.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Columns[1].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
        }
        private void loadData()
        {
            BusEquipForRBI buseq = new BusEquipForRBI();
            List<EquipmentForRbi> list = buseq.load();
            gridControl1.DataSource = list;
        }

        private void gridView1_RowCellDefaultAlignment(object sender, DevExpress.XtraGrid.Views.Base.RowCellAlignmentEventArgs e)
        {
            GridView Xgv = sender as GridView;
            DataRow dtRow = Xgv.GetDataRow(e.RowHandle);
            e.HorzAlignment = DevExpress.Utils.HorzAlignment.Center;
        }
    }
}
