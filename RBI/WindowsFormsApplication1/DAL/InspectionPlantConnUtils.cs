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
    class InspectionPlantConnUtils
    {
        InspectionPlant insp = null;
        public void add(String itemNo,
                        String damageMechanism,
                        String method,
                        String coverage,
                        String availability,
                        String lastInspectionDate,
                        String inspectionInterval,
                        String dueDate,
                        String system)
        {
            MySqlConnection conn = DBUtils.getDBConnection();
            conn.Open();
            String sql = "INSERT INTO tbl_equipmentforrbi VALUES "
                                                        +"('"+ system +"',"
                                                        +"'"+ damageMechanism+"',"
                                                        +"'"+ method+"',"
                                                        +"'"+ coverage+"',"
                                                        +"'"+ availability+"',"
                                                        +"'"+ lastInspectionDate+"',"
                                                        +"'"+ inspectionInterval+"',"
                                                        +"'"+ dueDate+"',"
                                                        +"'"+ itemNo+"')";
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Add data failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public void edit(String itemNo,
                        String damageMechanism,
                        String method,
                        String coverage,
                        String availability,
                        String lastInspectionDate,
                        String inspectionInterval,
                        String dueDate,
                        String system,
                        String olderDamageMechanism,
                        String olderMethod,
                        String olderItemNo)
        {
            MySqlConnection conn = DBUtils.getDBConnection();
            conn.Open();
            String sql = "UPDATE tbl_inspectionplan SET "
                                                    + "System = '" + system + "',"
                                                    + "DamageMechanism = '" + damageMechanism + "',"
                                                    + "Method = '" + method + "',"
                                                    + "Coverage = '" + coverage + "',"
                                                    + "Availability = '" + availability + "',"
                                                    + "LastInspectionDate = '" + lastInspectionDate +"',"
                                                    +"InspectionInterval = '"+ inspectionInterval +"',"
                                                    +"DueDate = '"+ dueDate +"',"
                                                    +"tbl_equipmentlist_ItemNo = '"+ itemNo +"'"
                                                    +" WHERE DamageMechanism = '"+ olderDamageMechanism + "' AND Method = '"+ olderMethod + "' AND tbl_equipmentlist_ItemNo = '"+ olderItemNo + "' ";
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
        public void delete(String damageMechanism, String method, String itemNo)
        {
            MySqlConnection conn = DBUtils.getDBConnection();
            conn.Open();
            String sql = "DELETE FROM tbl_inspectionplan WHERE  DamageMechanism = '" + damageMechanism + "' AND Method = '" + method + "' AND tbl_equipmentlist_ItemNo = '" + itemNo + "' ";
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

        public List<InspectionPlant> loads()
        {
            List<InspectionPlant> listEq = new List<InspectionPlant>();
            MySqlConnection conn = DBUtils.getDBConnection();
            conn.Open();
            String sql = "SELECT * FROM tbl_inspectionplan";
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
                            insp = new InspectionPlant();
                            insp.System = reader.GetString(0);
                            insp.DamageMechanism = reader.GetString(1);
                            insp.Method = reader.GetString(2);
                            insp.Coverage = reader.GetString(3);
                            insp.Availability = reader.GetString(4);
                            insp.LastInspectionDate = reader.GetString(5);
                            insp.InspectionInterval = reader.GetString(6);
                            insp.DueDate = reader.GetString(7);
                            insp.ItemNo = reader.GetString(8);
                            listEq.Add(insp);
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
    }
}
