using RBI.Object;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using RBI.DAL;

namespace RBI.BUS.BUSExcel
{
    class BusEquipmentForRBIExcel
    {
        EquipmentForRbi eq;
        ExcelConnect exConn = new ExcelConnect();
        public OleDbConnection getConnect( String path)
        {
            return exConn.connectionExcel(path);
        }
        public List<EquipmentForRbi> getListEQForRBI(String path)
        {
            List<EquipmentForRbi> list = new List<EquipmentForRbi>();
            OleDbConnection conn = getConnect(path);
            try
            {
                conn.Open();
                String cmd = "select * from [Totals$]";
                OleDbCommand command = new OleDbCommand(cmd, conn);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    String data = reader[0].ToString();
                    if ((data != "") && (data.All(char.IsDigit)))
                    {
                        eq = new EquipmentForRbi();
                        eq.UnitCode = data;
                        eq.UnitName = reader[1].ToString();
                        eq.ProcessSystem = reader[2].ToString();
                        list.Add(eq);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Please Check Version Excel File Or Fomat", "Error rbi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return list;
        }
        public List<String> getListUnitCode(String path)
        {
            List<String> list = new List<string>();
            OleDbConnection conn = getConnect(path);
            try
            {
                conn.Open();
                String cmd = "select * from [Totals$]";
                OleDbCommand command = new OleDbCommand(cmd, conn);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    String data = reader[0].ToString();
                    if ((data != "") && (data.All(char.IsDigit)))
                    {
                        list.Add(data);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Please Check Version Excel File Or Fomat", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return list;
        }
    }
}
