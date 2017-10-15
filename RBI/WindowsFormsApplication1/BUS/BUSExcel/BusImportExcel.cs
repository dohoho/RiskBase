using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;
using RBI.DAL;
namespace RBI.BUS.BUSExcel
{
    class BusImportExcel
    {
        ExcelConnect importConn = new ExcelConnect();
       
        public System.Data.DataTable getDataSheet(string path, string sheet)
        {
            OleDbConnection conn = importConn.connectionExcel(path);
            System.Data.DataTable dt = new System.Data.DataTable();
            try
            {
                conn.Open();
                string cmd = "select * from [" + sheet + "$]";
                OleDbCommand command = new OleDbCommand(cmd, conn);
                OleDbDataAdapter adap = new OleDbDataAdapter(cmd, importConn.getStringConnect());
                adap.Fill(dt);
            }
            catch
            {
                MessageBox.Show("Error when read Excel file", "Warning");
            }
            finally
            {
                conn.Dispose();
                conn.Close();
            }
            return dt;
        }
    }
}
