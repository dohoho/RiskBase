using MySql.Data.MySqlClient;
using RBI.Object;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RBI.DAL
{
    class EquipmentForRBIConnUtils
    {
        EquipmentForRbi eqRbi = null;
        public void add(String unitCode, String unitName, String processSystem)
        {
            MySqlConnection conn = DBUtils.getDBConnection();
            conn.Open();
            String sql = "INSERT INTO tbl_equipmentforrbi VALUES('"+unitCode+"','"+unitName+"','"+processSystem+"')";
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                MessageBox.Show("Add data failed" + e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public void edit( String unitCode, String unitName, String processSystem, String olderUnitCode)
        {
            MySqlConnection conn = DBUtils.getDBConnection();
            conn.Open();
            String sql = "UPDATE tbl_equipmentforrbi SET UnitCode = '" + unitCode + "' , UnitName = '" + unitName + "', ProcessSystem = '" + processSystem + "' WHERE UnitCode = '" + olderUnitCode + "'";
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Edit data failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public void delete( String unitCode)
        {
            MySqlConnection conn = DBUtils.getDBConnection();
            conn.Open();
            String sql = "DELETE FROM tbl_equipmentforrbi WHERE UnitCode = '" + unitCode + "'";
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Delete data failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public List<EquipmentForRbi> loads()
        {
            List<EquipmentForRbi> listEq = new List<EquipmentForRbi>();
            MySqlConnection conn = DBUtils.getDBConnection();
            conn.Open();
            String sql = "SELECT * FROM tbl_equipmentforrbi";
            try
            {
                EquipmentConnUtils eqcon = new EquipmentConnUtils();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            eqRbi = new EquipmentForRbi();
                            eqRbi.UnitCode = reader.GetString(0);
                            eqRbi.UnitName = reader.GetString(1);
                            eqRbi.ProcessSystem = reader.GetString(2);
                            eqRbi.Qty = eqcon.getTotalQty(eqRbi.UnitCode);
                            eqRbi.Semi = eqcon.getTotalSemi(eqRbi.UnitCode);
                            eqRbi.QuanTyTative = eqRbi.Qty - eqRbi.Semi;

                            listEq.Add(eqRbi);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Load data failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return listEq;
        }

        public bool checkExist(String UnitCode)
        {
            bool check = false;
            MySqlConnection conn = DBUtils.getDBConnection();
            conn.Open();
            String sql = "SELECT * FROM tbl_equipmentforrbi WHERE UnitCode ='" + UnitCode + "'";
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                        check = true;
                }
            }
            catch
            {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return check;
        }
        public List<String> getUnitCode()
        {
            List<String> arr = new List<string>();
            MySqlConnection conn = DBUtils.getDBConnection();
            conn.Open();
            String sql = "SELECT UnitCode FROM tbl_equipmentforrbi";
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            String data = reader.GetString(0);
                            arr.Add(data);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Load data failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return arr;
        }
    }
}
