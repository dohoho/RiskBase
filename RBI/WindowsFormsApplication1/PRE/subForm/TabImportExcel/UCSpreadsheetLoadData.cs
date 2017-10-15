using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DevExpress.Spreadsheet;
using DevExpress.XtraBars.Ribbon;
namespace RBI.PRE.subForm.TabImportExcel
{
    public partial class UCSpreadsheetLoadData : UserControl
    {
        public UCSpreadsheetLoadData()
        {
            InitializeComponent();
            
        }
        public void loadFileExcel(string path, string extension)
        {
            if (extension == ".xls")
                spreadsheetControl1.LoadDocument(path, DocumentFormat.Xls);
            else
                spreadsheetControl1.LoadDocument(path, DocumentFormat.Xlsx);
        }
        
        public void SaveFile(string path, string extension)
        {
            IWorkbook workbook = spreadsheetControl1.Document;
            using (FileStream stream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
            {
                if(extension == ".xls")
                    workbook.SaveDocument(stream, DocumentFormat.Xls);
                else
                    workbook.SaveDocument(stream, DocumentFormat.Xlsx);
            }
        }
    }
}
