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
    class EquipmentTempConnUtils
    {
        EquipmentTemp eqTemp = null;
        public void add(String itemNo,
                        String comName,
                        String plant,
                        String operingPressInlet,
                        String operTempInlet,
                        String operingPressOutlet,
                        String operTempOutlet,
                        String testPress,
                        String mdmt,
                        String inService,
                        String serviceDate,
                        String lastInternalInspectionDate,
                        String ldtbxhCovered,
                        String insulated,
                        String pwht,
                        String insulatedType,
                        String operatingState,
                        String inventoryLiquip,
                        String inventoryVapor,
                        String inventoryTotal,
                        String confidentInStreamAnalysis,
                        String vaporDensityAir,
                        String corrosionInhibitor,
                        String frequentFeedChanged,
                        String majorChemicals,
                        String contaminants,
                        String onLineMonitoring,
                        String cathodicProtection,
                        String corrosionMonitoring,
                        String ohCalibUptodate,
                        String distFromFacility,
                        String equipCount,
                        String hazopRating,
                        String personalDensity,
                        String mitigationEquip,
                        String envRating,
                        String inspTechUsed,
                        String equipModification,
                        String inspectionFinding,
                        String vaporDensity,
                        String liquipDensity,
                        String vapor,
                        String liquip,
                        String hmbpfdNum,
                        String pidNum,
                        String service,
                        String hmbStream,
                        int count)
        {
            MySqlConnection conn = DBUtils.getDBConnection();
            conn.Open();
            String sql = "INSERT INTO tbl_equipmenttemp VALUES "+
                            "('"+count+"',"+
                            "'"+plant+"',"+
                            "'"+ operingPressInlet+"',"+
                            "'"+operTempInlet+"',"+
                            "'"+ operingPressOutlet+"',"+
                            "'"+ operTempOutlet+"',"+
                            "'"+ testPress+"',"+
                            "'"+ mdmt+"',"+
                            "'"+ inService+"',"+
                            "'"+ serviceDate+"',"+
                            "'"+ lastInternalInspectionDate+"',"+
                            "'"+ ldtbxhCovered+"',"+
                            "'"+ insulated+"',"+
                            "'"+ pwht+"',"+
                            "'"+ insulatedType+"',"+
                            "'"+ operatingState+"',"+
                            "'"+ inventoryLiquip+"',"+
                            "'"+ inventoryVapor+"',"+
                            "'"+ inventoryTotal+"',"+
                            "'"+ confidentInStreamAnalysis+"',"+
                            "'"+ vaporDensityAir+"',"+
                            "'"+ corrosionInhibitor+"',"+
                            "'"+ frequentFeedChanged+"',"+
                            "'"+ majorChemicals+"',"+
                            "'"+ contaminants+"',"+
                            "'"+ onLineMonitoring+"',"+
                            "'"+ cathodicProtection+"',"+
                            "'"+ corrosionMonitoring+"',"+
                            "'"+ ohCalibUptodate+"',"+
                            "'"+ distFromFacility+"',"+
                            "'"+ equipCount+"',"+
                            "'"+ hazopRating+"',"+
                            "'"+ personalDensity+"',"+
                            "'"+ mitigationEquip+"',"+
                            "'"+ envRating+"',"+
                            "'"+ inspTechUsed+"',"+
                            "'"+ equipModification+"',"+
                            "'"+ inspectionFinding+"',"+
                            "'"+ vaporDensity+"',"+
                            "'"+ liquipDensity+"',"+
                            "'"+ vapor+"',"+
                            "'"+ liquip+"',"+
                            "'"+ hmbpfdNum+"',"+
                            "'"+ pidNum+"',"+
                            "'"+ service+"',"+
                            "'"+ hmbStream+"',"+
                            "'"+ itemNo+"',"+
                            "'"+ comName+"'); ";

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Add data failed"+e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public void edit(String itemNo,
                        String comName,
                        String plant,
                        String operingPressInlet,
                        String operTempInlet,
                        String operingPressOutlet,
                        String operTempOutlet,
                        String testPress,
                        String mdmt,
                        String inService,
                        String serviceDate,
                        String lastInternalInspectionDate,
                        String ldtbxhCovered,
                        String insulated,
                        String pwht,
                        String insulatedType,
                        String operatingState,
                        String inventoryLiquip,
                        String inventoryVapor,
                        String inventoryTotal,
                        String confidentInStreamAnalysis,
                        String vaporDensityAir,
                        String corrosionInhibitor,
                        String frequentFeedChanged,
                        String majorChemicals,
                        String contaminants,
                        String onLineMonitoring,
                        String cathodicProtection,
                        String corrosionMonitoring,
                        String ohCalibUptodate,
                        String distFromFacility,
                        String equipCount,
                        String hazopRating,
                        String personalDensity,
                        String mitigationEquip,
                        String envRating,
                        String inspTechUsed,
                        String equipModification,
                        String inspectionFinding,
                        String vaporDensity,
                        String liquipDensity,
                        String vapor,
                        String liquip,
                        String hmbpfdNum,
                        String pidNum,
                        String service,
                        String hmbStream,
                        int count)
        {
            MySqlConnection conn = DBUtils.getDBConnection();
            conn.Open();
            String sql = "UPDATE tbl_equipmenttemp SET "
                                                        + "Plant = '" + plant + "',"
                                                        + "OperingPressInlet = '" + operingPressInlet + "',"
                                                        + "OperTempInlet = '" + operTempInlet + "',"
                                                        + "OperingPressOutlet = '" + operingPressOutlet + "=,"
                                                        + "OperTempOutlet = '" + operTempOutlet + "',"
                                                        + "TestPress = '" + testPress + "',"
                                                        + "MDMT = '" + mdmt + "',"
                                                        + "InService = '" + inService + "',"
                                                        + "ServiceDate = '" + serviceDate + "',"
                                                        + "LastInternalInspectionDate = '" + lastInternalInspectionDate + "',"
                                                        + "LDTBXHCovered = '" + ldtbxhCovered + "',"
                                                        + "Insulated = '" + insulated + "',"
                                                        + "PWHT = '" + pwht + "',"
                                                        + "InsulatedType = '" + insulatedType + "',"
                                                        + "OperatingState = '" + operatingState + "',"
                                                        + "InventoryLiquip = '" + inventoryLiquip + "',"
                                                        + "InventoryVapor = '" + inventoryVapor + "',"
                                                        + "InventoryTotal = '" + inventoryTotal + "',"
                                                        + "ConfidentInStreamAnalysis = '" + confidentInStreamAnalysis + "',"
                                                        + "VaporDensityAir = '" + vaporDensityAir + "',"
                                                        + "CorrosionInhibitor = '" + corrosionInhibitor + "',"
                                                        + "FrequentFeedChanged = '" + frequentFeedChanged + "',"
                                                        + "MajorChemicals = '" + majorChemicals + "',"
                                                        + "Contaminants = '" + contaminants + "',"
                                                        + "OnLineMonitoring = '" + onLineMonitoring + "',"
                                                        + "CathodicProtection = '" + cathodicProtection + "',"
                                                        + "CorrosionMonitoring = '" + corrosionMonitoring + "',"
                                                        + "OHCalibUptodate = '" + ohCalibUptodate + "',"
                                                        + "DistFromFacility = '" + distFromFacility + "',"
                                                        + "EquipCount = '" + equipCount + "',"
                                                        + "HAZOPRating = '" + hazopRating + "',"
                                                        + "PersonalDensity = '" + personalDensity + "',"
                                                        + "MitigationEquip = '" + mitigationEquip + "',"
                                                        + "EnvRating = '" + envRating + "',"
                                                        + "InspTechUsed = '" + inspTechUsed + "',"
                                                        + "EquipModification = '" + equipModification + "',"
                                                        + "InspectionFinding = '" + inspectionFinding + "',"
                                                        + "VaporDensity = '" + vaporDensity + "',"
                                                        + "LiquipDensity = '" + liquipDensity + "',"
                                                        + "Vapor = '" + vapor + "',"
                                                        + "Liquip = '" + liquip + "',"
                                                        + "HMBPFDNum = '" + hmbpfdNum + "',"
                                                        + "PIDNum = '" + pidNum + "',"
                                                        + "Service = '" + service + "',"
                                                        + "HMBStream = '" + hmbStream + "',"
                                                        + "tbl_equipmentlist_ItemNo = '" + itemNo + "',"
                                                        + "tbl_component_componentName = '" + comName + "'"
                                                        + " WHERE STT = '" + count  + "' ";
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
        public void delete(int count)
        {
            MySqlConnection conn = DBUtils.getDBConnection();
            conn.Open();
            String sql = "DELETE FROM tbl_equipmenttemp WHERE STT = '" + count + "'";
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

        public List<EquipmentTemp> loads()
        {
            List<EquipmentTemp> listEq = new List<EquipmentTemp>();
            MySqlConnection conn = DBUtils.getDBConnection();
            conn.Open();
            String sql = "SELECT * FROM tbl_equipmenttemp";
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
                            eqTemp = new EquipmentTemp();
                            eqTemp.Count = int.Parse(reader.GetString(0));
                            eqTemp.Plant = reader.GetString(1);
                            eqTemp.OperingPressInlet = reader.GetString(2);
                            eqTemp.OperTempInlet = reader.GetString(3);
                            eqTemp.OperingPressOutlet = reader.GetString(4);
                            eqTemp.OperTempOutlet = reader.GetString(5);
                            eqTemp.TestPress = reader.GetString(6);
                            eqTemp.MDMT = reader.GetString(7);
                            eqTemp.InService = reader.GetString(8);
                            eqTemp.ServiceDate = reader.GetString(9);
                            eqTemp.LastInternalInspectionDate = reader.GetString(10);
                            eqTemp.LDTBXHCovered = reader.GetString(11);
                            eqTemp.Insulated = reader.GetString(12);
                            eqTemp.PWHT = reader.GetString(13);
                            eqTemp.InsulatedType = reader.GetString(14);
                            eqTemp.OperatingState = reader.GetString(15);
                            eqTemp.InventoryLiquip = reader.GetString(16);
                            eqTemp.InventoryVapor = reader.GetString(17);
                            eqTemp.InventoryTotal = reader.GetString(18);
                            eqTemp.ConfidentInStreamAnalysis = reader.GetString(19);
                            eqTemp.VaporDensityAir = reader.GetString(20);
                            eqTemp.CorrosionInhibitor = reader.GetString(21);
                            eqTemp.FrequentFeedChanged = reader.GetString(22);
                            eqTemp.MajorChemicals = reader.GetString(23);
                            eqTemp.Contaminants = reader.GetString(24);
                            eqTemp.OnLineMonitoring = reader.GetString(25);
                            eqTemp.CathodicProtection = reader.GetString(26);
                            eqTemp.CorrosionMonitoring = reader.GetString(27);
                            eqTemp.OHCalibUptodate = reader.GetString(28);
                            eqTemp.DistFromFacility = reader.GetString(29);
                            eqTemp.EquipCount = reader.GetString(30);
                            eqTemp.HAZOPRating = reader.GetString(31);
                            eqTemp.PersonalDensity = reader.GetString(32);
                            eqTemp.MitigationEquip = reader.GetString(33);
                            eqTemp.EnvRating = reader.GetString(34);
                            eqTemp.InspTechUsed = reader.GetString(35);
                            eqTemp.EquipModification = reader.GetString(36);
                            eqTemp.InspectionFinding = reader.GetString(37);
                            eqTemp.VaporDensity = reader.GetString(38);
                            eqTemp.LiquipDensity = reader.GetString(39);
                            eqTemp.Vapor = reader.GetString(40);
                            eqTemp.Liquip = reader.GetString(41);
                            eqTemp.HMBPFDNum = reader.GetString(42);
                            eqTemp.PIDNum = reader.GetString(43);
                            eqTemp.Service = reader.GetString(44);
                            eqTemp.HMBStream = reader.GetString(45);
                            eqTemp.ItemNo = reader.GetString(46);
                            eqTemp.ComName = reader.GetString(47);

                            listEq.Add(eqTemp);
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

        public bool checkExist(int count)
        {
            bool check = false;
            MySqlConnection conn = DBUtils.getDBConnection();
            conn.Open();
            String sql = "SELECT * FROM tbl_equipmenttemp WHERE STT='" + count + "'";
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
            catch(Exception e)
            {
                MessageBox.Show("Error" + e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return check;
        }
        public bool checkExist(String Plant, String itemNo, String comNa)
        {
            bool check = false;
            MySqlConnection conn = DBUtils.getDBConnection();
            conn.Open();
            String sql = "SELECT * FROM tbl_equipmenttemp WHERE Plant ='" + Plant + "' AND tbl_component_componentName ='" + comNa + "' AND tbl_equipmentlist_ItemNo ='" + itemNo + "' ";
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
            catch (Exception e)
            {
                MessageBox.Show("Error" + e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return check;
        }
        public int getMax()
        {
            
            MySqlConnection conn = DBUtils.getDBConnection();
            List<String> list = new List<String>();
            conn.Open();
            String sql = "SELECT STT FROM tbl_equipmenttemp";
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
                            list.Add(reader.GetString(0));
                        }
                        
                    }
                 }
                
            }
            catch (Exception e)
            {
                MessageBox.Show("Error"+e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            if (list.Count > 0)
            {
                return int.Parse(list[list.Count -1]);
            }
            else
                return 0;
            
        }
        public double getMass(String itemNo, String componentName)
        {
            MySqlConnection conn = DBUtils.getDBConnection();
            conn.Open();
            double total = 0;
            String sql = "SELECT Vapor,Liquip FROM tbl_equipmenttemp WHERE tbl_component_componentName = '" + componentName + "' AND tbl_equipmentlist_ItemNo = '" + itemNo + "'";
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                double x = 0;
                double y = 0;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (reader.GetString(0).Equals(""))
                                x = 0;
                            else
                                x = double.Parse(reader.GetString(0));
                            if (reader.GetString(1).Equals(""))
                                y = 0;
                            else
                                y = double.Parse(reader.GetString(1));
                            total = x + y;
                        }
                    }
                }
            }catch(Exception e)
            {
                MessageBox.Show("Error" + e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return total;
        }
    }
}
