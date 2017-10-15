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
using RBI.DAL;

namespace RBI.PRE.subForm
{
    public partial class UCEqList_DevExpress : UserControl
    {
        public UCEqList_DevExpress()
        {
            InitializeComponent();
            formatGrid();
            loadData();
        }
        private void formatGrid()
        {
            gridView1.Columns.Clear();
            String[] field = {  "UnitCode",
                                "ItemNo",
                                "Name",
                                "Qty",
                                "Semi_Quanty",
                                "Quanlitative",
                                "ProcessStream",
                                "Pressure",
                                "PHA",
                                "Business",
                                "ProcessStreamFluid",
                                "OperatingPressure",
                                "PHARating",
                                "BusinessLossValue"
                                };
            String[] caption = {"Unit Code",
                                "Item No.",
                                "Name",
                                "Qty.",
                                "Semi- Quantitative",
                                "Quanlitative",
                                "Process Stream Okay?",
                                "Pressure < 700 kPa?",
                                "PHA = Low?",
                                "Business Loss <= X",
                                "Pressure Stream Fluid",
                                "Operating Pressure",
                                "PHA Rating",
                                "Business Loss Value"
                                };

            for(int i = 0; i < field.Length; i++)
            {
                DevExpress.XtraGrid.Columns.GridColumn col = new DevExpress.XtraGrid.Columns.GridColumn();
                col.FieldName = field[i];
                col.Caption = caption[i];
                gridView1.Columns.Add(col);
                //gridView1.Columns[i].Width = 100;
                gridView1.Columns[i].Visible = true;
            }
            gridView1.Columns[2].Width = 150;
            gridView1.BestFitColumns();
            // format gird
            gridView1.Columns[1].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            gridView1.Columns[2].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            gridView1.Columns[10].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
        }
        private void loadData()
        {
            BusEquipments eq = new BusEquipments();
            List<Equipment> list = eq.loads();
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
