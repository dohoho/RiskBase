using RBI.Object;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RBI.DAL;
namespace RBI.BUS.BUSExcel
{
    class BusComponentExcel
    {
        Component com;
        Equipment eq;
        ExcelConnect exConn = new ExcelConnect();
        public OleDbConnection getConnect(String path)
        {
            return exConn.connectionExcel(path);
        }

        public List<Equipment> getListEq(String path)
        {
            List<Equipment> list = new List<Equipment>();
            OleDbConnection conn = getConnect(path);
            try
            {
                conn.Open();
                String cmd = "select * from [Data$]";
                OleDbCommand command = new OleDbCommand(cmd, conn);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (!reader[5].ToString().Equals(""))
                    {
                        eq = new Equipment();
                        eq.ItemNo = reader[2].ToString();
                        //eq.EquipmentDescription = reader[3].ToString();
                        //eq.Type = reader[4].ToString();
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
        public List<Component> getListCom(String path)
        {
            List<Component> list = new List<Component>();
            OleDbConnection conn = getConnect(path);
            try
            {
                conn.Open();
                String cmd = "select * from [Data$]";
                OleDbCommand command = new OleDbCommand(cmd, conn);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (!reader[5].ToString().Equals(""))
                    {
                        com = new Component();
                        com.Name = reader[5].ToString();
                        com.Description = reader[6].ToString();
                        com.MOC = reader[7].ToString();
                        com.LinerMOC = reader[8].ToString();
                        com.HeightLength = reader[9].ToString();
                        com.Diameter = reader[10].ToString();
                        com.NorminalThickness = reader[11].ToString();
                        com.CA = reader[12].ToString();
                        com.DesignPressure = reader[13].ToString();
                        com.DesignTemp = reader[14].ToString();

                        list.Add(com);
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
    }
}
