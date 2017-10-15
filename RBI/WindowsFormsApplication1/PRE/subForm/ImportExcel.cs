using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Office.Interop.Excel;

using System.Data.OleDb;
using System.IO;
using DevExpress.Spreadsheet;
using DevExpress.XtraSpreadsheet;
using RBI.BUS.BUSExcel;
using RBI.PRE.subForm.TabImportExcel;
namespace RBI.PRE.subForm
{
    public partial class ImportExcel : Form
    {
        //UCEquipmentTab tabEq = new UCEquipmentTab();
        //UCComponentTab tabComp = new UCComponentTab();
        //UCOperatingConditionTab tabOp = new UCOperatingConditionTab();
        //UCStreamTab tabStr = new UCStreamTab();
        //UCMaterialTab tabMa = new UCMaterialTab();
        //UCCoatingCladdingLiningInsulationTab tabCo = new UCCoatingCladdingLiningInsulationTab();
        UCSpreadsheetLoadData tableExcel = new UCSpreadsheetLoadData();
        public ImportExcel()
        {
            InitializeComponent();
            
            tableExcel.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(tableExcel);
            //tabEq.Dock = DockStyle.Fill;
            //tabEquipment.Controls.Add(tabEq);
           
            //tabComp.Dock = DockStyle.Fill;
            //tabComponent.Controls.Add(tabComp);

            
            //tabOp.Dock = DockStyle.Fill;
            //tabOperating.Controls.Add(tabOp);

            
            //tabStr.Dock = DockStyle.Fill;
            //tabStream.Controls.Add(tabStr);

            
            //tabMa.Dock = DockStyle.Fill;
            //tabMaterial.Controls.Add(tabMa);

            
            //tabCo.Dock = DockStyle.Fill;
            //tabCoating.Controls.Add(tabCo);
        }
        string fileName = null;
        string extension = null;
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "All File(*)|*";
            if (op.ShowDialog() == DialogResult.OK)
            {
                txtPathFileExcel.Text = op.FileName;
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            
            fileName = Path.GetFileName(txtPathFileExcel.Text);
            extension = Path.GetExtension(fileName);
            if(extension == ".xls")
                tableExcel.loadFileExcel(txtPathFileExcel.Text, ".xls");
            else
                tableExcel.loadFileExcel(txtPathFileExcel.Text, ".xlsx");
            panelControl1.Refresh();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            tableExcel.SaveFile(txtPathFileExcel.Text, extension);
                MessageBox.Show("Save File Succesfully", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

       
    }
}

