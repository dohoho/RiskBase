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
namespace RBI.PRE.subForm
{
    public partial class ImportExcel : Form
    {
        public ImportExcel()
        {
            InitializeComponent();
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
        DevExpress.XtraSpreadsheet.SpreadsheetControl spreadExcel = new SpreadsheetControl();
        private void readDataFromSheet()
        {
            IWorkbook workbook = spreadExcel.Document;
            DevExpress.Spreadsheet.Worksheet worksheet = workbook.Worksheets[0]; //co 32 cell
            try
            {
                string[] cellEquipmentSheet = new string[32];
                //hang truoc cot sau
                for (int i = 0; i < 32; i++)
                {
                    cellEquipmentSheet[i] = worksheet.Cells[1, i].Value.ToString();
                    Debug.WriteLine("cell[" + i.ToString() + "]" + cellEquipmentSheet[i]);
                }
                //MessageBox.Show(worksheet.Cells[1, 0].Value.ToString());
            }
            catch
            {
                MessageBox.Show("Error");
            }

        }
        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            fileName = Path.GetFileName(txtPathFileExcel.Text);
            extension = Path.GetExtension(fileName);
            if (extension == ".xls")
            {
                spreadExcel.LoadDocument(txtPathFileExcel.Text, DocumentFormat.Xls);
            }
            else if (extension == ".xlsx")
            {
                spreadExcel.LoadDocument(txtPathFileExcel.Text, DocumentFormat.Xlsx);
            }
            else
            {
                MessageBox.Show("This file is not supported! Sorry!", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            pictureBox1.Hide();
            label1.Hide();
            spreadExcel.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(spreadExcel);
            ///panelControl1.Refresh();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            IWorkbook workbook = spreadExcel.Document;
            using (FileStream stream = new FileStream(txtPathFileExcel.Text, FileMode.Create, FileAccess.ReadWrite))
            {
                if (extension == ".xls")
                    workbook.SaveDocument(stream, DocumentFormat.Xls);
                else
                    workbook.SaveDocument(stream, DocumentFormat.Xlsx);
            }
                MessageBox.Show("This file has been saved!", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            readDataFromSheet();
        }

       
    }
}

