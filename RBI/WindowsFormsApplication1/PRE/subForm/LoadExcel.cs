using DevExpress.Spreadsheet;
using DevExpress.XtraSpreadsheet;
using RBI.BUS;
using RBI.BUS.BUSExcel;
using RBI.Object;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RBI.PRE.subForm
{
    public partial class LoadExcel : Form
    {
        public LoadExcel()
        {
            InitializeComponent();
        }
        public void clearData()
        {
            if (spreadsheetControl1.Document.Worksheets.Count > 1)
            {
                for (int i = spreadsheetControl1.Document.Worksheets.Count - 1; i > 0; i--)
                {
                    spreadsheetControl1.Document.Worksheets.RemoveAt(i);
                }
            }
            else
            {

            }
            //spreadsheetControl1 = new SpreadsheetControl();
        }
        String path = null;
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();
                if (op.ShowDialog() == DialogResult.OK)
                {
                    path = op.FileName;
                }
                clearData();

                SpreadsheetControl spc = new SpreadsheetControl();
                spc.LoadDocument(path);
                for (int i = 0; i < spc.Document.Worksheets.Count; i++)
                {
                    DevExpress.Spreadsheet.Worksheet ws;
                    if (spc.Document.Worksheets[i].Name == spreadsheetControl1.Document.Worksheets[0].Name)
                    {
                        spreadsheetControl1.Document.Worksheets.Add("Default");
                        spreadsheetControl1.Document.Worksheets["Default"].CopyFrom(spc.Document.Worksheets[i]);
                    }
                    else
                    {
                        ws = spreadsheetControl1.Document.Worksheets.Add(spc.Document.Worksheets[i].Name);
                        ws.CopyFrom(spc.Document.Worksheets[i]);
                    }
                    //ws.CopyFrom(spc.Document.Worksheets[i]);
                }
                this.spreadsheetControl1.ClearValidationCircles();
                //this.spreadsheetControl1.LoadDocument(wb);
                spreadsheetControl1.Document.Worksheets.RemoveAt(0);
                spc.Dispose();
            }
            catch (Exception)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SaveFileDialog save = new SaveFileDialog();
            //save.Filter = "Excel 2003|*.xls|Excel Workbook|*.xlsx";
            //save.Title = "Save an Excel File";
            //String path = null;
            //if (save.ShowDialog() == DialogResult.OK)
            //{
            //    path = save.FileName;
            //    IWorkbook workbook = spreadsheetControl1.Document;
            //    using (FileStream stream = new FileStream(path,
            //            FileMode.Create, FileAccess.ReadWrite))
            //    {
            //        workbook.SaveDocument(stream, DocumentFormat.OpenXml);
            //    }
            //    MessageBox.Show("Save file done!");
            //}
            Console.Write(path);
            FullplantObjectExcel plant = new FullplantObjectExcel();
            List<FullPlantObject> list = plant.getListPlant(path);
            BusFullPlant bus = new BusFullPlant();
            for (int i = 0; i < list.Count; i++)
            {
                if (!bus.checkExist(list[i]))
                {
                    bus.Add(list[i]);
                }
            }
            this.Close();
        }

        //private void InitializeComponent()
        //{
        //    this.SuspendLayout();
        //    // 
        //    // LoadExcel
        //    // 
        //    this.ClientSize = new System.Drawing.Size(511, 393);
        //    this.Name = "LoadExcel";
        //    this.ResumeLayout(false);

        //}

    }
}
