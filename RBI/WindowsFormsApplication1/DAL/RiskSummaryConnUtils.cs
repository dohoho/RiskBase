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
    class RiskSummaryConnUtils
    {
        RiskSummary risk = null;
        public void add(String comName,
                        String itemNo,
                        String representFluid,
                        String fluidPhase,
                        String cotcatFlammable,
                        String currentRisk,
                        String cotcatPeople,
                        String cotcatAsset,
                        String cotcatEnv,
                        String cotcatReputation,
                        String cotcatCombinled,
                        String componentMaterialGrade,
                        String initThinningCategory,
                        String initEnvCracking,
                        String initOtherCategory,
                        String initCategory,
                        String extThinningCategory,
                        String extEnvCracking,
                        String extOtherCategory,
                        String extCategory,
                        String pofCategory,
                        String currentRiskCal,
                        String futureRisk)
        {
            MySqlConnection conn = DBUtils.getDBConnection();
            conn.Open();
            String sql = "INSERT INTO tbl_risksummary VALUES"
                                                    + "('" + representFluid + "',"
                                                    + "'" + fluidPhase + "',"
                                                    + "'" + cotcatFlammable + "',"
                                                    + "'" + currentRisk + "',"
                                                    + "'" + cotcatPeople + "',"
                                                    + "'" + cotcatAsset + "',"
                                                    + "'" + cotcatEnv + "',"
                                                    + "'" + cotcatReputation + "',"
                                                    + "'" + cotcatCombinled + "',"
                                                    + "'" + componentMaterialGrade + "',"
                                                    + "'" + initThinningCategory + "',"
                                                    + "'" + initEnvCracking + "',"
                                                    + "'" + initOtherCategory + "',"
                                                    + "'" + initCategory + "',"
                                                    + "'" + extThinningCategory + "',"
                                                    + "'" + extEnvCracking + "',"
                                                    + "'" + extOtherCategory + "',"
                                                    + "'" + extCategory + "',"
                                                    + "'" + pofCategory + "',"
                                                    + "'" + currentRiskCal + "',"
                                                    + "'" + futureRisk + "',"
                                                    + "'" + comName + "',"
                                                    + "'" + itemNo + "') ";
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
        public void edit(String comName,
                        String itemNo,
                        String representFluid,
                        String fluidPhase,
                        String cotcatFlammable,
                        String currentRisk,
                        String cotcatPeople,
                        String cotcatAsset,
                        String cotcatEnv,
                        String cotcatReputation,
                        String cotcatCombinled,
                        String componentMaterialGrade,
                        String initThinningCategory,
                        String initEnvCracking,
                        String initOtherCategory,
                        String initCategory,
                        String extThinningCategory,
                        String extEnvCracking,
                        String extOtherCategory,
                        String extCategory,
                        String pofCategory,
                        String currentRiskCal,
                        String futureRisk
                       )
        {
            MySqlConnection conn = DBUtils.getDBConnection();
            conn.Open();
            String sql = "UPDATE tbl_risksummary SET "
                                            + "RepresentFluid = '" + representFluid + "',"
                                            + "FluidPhase = '" + fluidPhase + "',"
                                            + "CotcatFlammable = '" + cotcatFlammable + "',"
                                            + "CurrentRisk = '" + currentRisk + "',"
                                            + "CotcatPeople = '" + cotcatPeople + "',"
                                            + "CotcatAsset = '" + cotcatAsset + "',"
                                            + "CotcatEnv = '" + cotcatEnv + "',"
                                            + "CotcatReputation = '" + cotcatReputation + "',"
                                            + "CotcatCombinled = '" + cotcatCombinled + "',"
                                            + "ComponentMaterialGrade = '" + componentMaterialGrade + "',"
                                            + "InitThinningCategory = '" + initThinningCategory + "',"
                                            + "InitEnvCracking = '" + initEnvCracking + "',"
                                            + "InitOtherCategory = '" + initOtherCategory + "',"
                                            + "InitCategory = '" + initCategory + "',"
                                            + "ExtThinningCategory = '" + extThinningCategory + "',"
                                            + "ExtEnvCracking = '" + extEnvCracking + "',"
                                            + "ExtOtherCategory = '" + extOtherCategory + "',"
                                            + "ExtCategory = '" + extCategory + "',"
                                            + "POFCategory = '" + pofCategory + "',"
                                            + "CurrentRiskCal = '" + currentRiskCal + "',"
                                            + "FutureRisk = '" + futureRisk + "',"
                                            + " WHERE tbl_component_componentName = '" + comName + "' AND tbl_equipmentlist_ItemNo = '" + itemNo + "'";
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch
            {
               // MessageBox.Show("Edit data failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public void delete(String comName, String itemNo)
        {
            MySqlConnection conn = DBUtils.getDBConnection();
            conn.Open();
            String sql = "DELETE FROM tbl_risksummary WHERE tbl_component_componentName = '" + comName + "' AND tbl_equipmentlist_ItemNo = '" + itemNo + "'";
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Delete data failed" + e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public List<RiskSummary> loads()
        {
            List<RiskSummary> listEq = new List<RiskSummary>();
            MySqlConnection conn = DBUtils.getDBConnection();
            conn.Open();
            String sql = "SELECT * FROM tbl_risksummary";
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
                            risk = new RiskSummary();
                            risk.RepresentFluid = reader.GetString(0);
                            risk.FluidPhase = reader.GetString(1);
                            risk.CotcatFlammable = reader.GetString(2);
                            risk.CurrentRisk = reader.GetString(3);
                            risk.CotcatPeople = reader.GetString(4);
                            risk.CotcatAsset = reader.GetString(5);
                            risk.CotcatEnv = reader.GetString(6);
                            risk.CotcatReputation = reader.GetString(7);
                            risk.CotcatCombinled = reader.GetString(8);
                            risk.ComponentMaterialGrade = reader.GetString(9);
                            risk.InitThinningCategory = reader.GetString(10);
                            risk.InitEnvCracking = reader.GetString(11);
                            risk.InitOtherCategory = reader.GetString(12);
                            risk.InitCategory = reader.GetString(13);
                            risk.ExtThinningCategory = reader.GetString(14);
                            risk.ExtEnvCracking = reader.GetString(15);
                            risk.ExtOtherCategory = reader.GetString(16);
                            risk.ExtCategory = reader.GetString(17);
                            risk.POFCategory = reader.GetString(18);
                            risk.CurrentRiskCal = reader.GetString(19);
                            risk.FutureRisk = reader.GetString(20);
                            risk.ComName = reader.GetString(21);
                            risk.ItemNo = reader.GetString(22);

                            listEq.Add(risk);
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

        public bool checkExist(String comName, String itemNo)
        {
            bool check = false;
            MySqlConnection conn = DBUtils.getDBConnection();
            conn.Open();
            String sql = "SELECT * FROM tbl_risksummary WHERE tbl_component_componentName = '" + comName + "' AND tbl_equipmentlist_ItemNo = '" + itemNo + "'";
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
    }
}
