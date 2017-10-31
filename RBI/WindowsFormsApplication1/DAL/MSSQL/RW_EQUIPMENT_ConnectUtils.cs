using RBI.Object;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RBI.Object.ObjectMSSQL;
namespace RBI.DAL.MSSQL
{
    class RW_EQUIPMENT_ConnectUtils
    {
        public void add(int ID, DateTime CommissionDate, int AdminUpsetManagement, int ContainsDeadlegs, int CyclicOperation, int HighlyDeadlegInsp, int DowntimeProtectionUsed,String ExternalEnvironment, int HeatTraced, int InterfaceSoilWater, int LinerOnlineMonitoring, int MaterialExposedToClExt, double MinReqTemperaturePressurisation, String OnlineMonitoring, int PresenceSulphidesO2,int PresenceSulphidesO2Shutdown,int PressurisationControlled,int PWHT,int SteamOutWaterFlush,double ManagementFactor, String ThermalHistory,int YearLowestExpTemp, double Volume,String TypeOfSoil,String EnvironmentSensitivity, double DistanceToGroundWater,String AdjustmentSettle,int ComponentIsWelded,int TankIsMaintained)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        " " +
                        "INSERT INTO [dbo].[RW_EQUIPMENT]"+
                        "([ID]" +
                        ",[CommissionDate]" +
                        ",[AdminUpsetManagement]" +
                        ",[ContainsDeadlegs]" +
                        ",[CyclicOperation]" +
                        ",[HighlyDeadlegInsp]" +
                        ",[DowntimeProtectionUsed]" +
                        ",[ExternalEnvironment]" +
                        ",[HeatTraced]" +
                        ",[InterfaceSoilWater]" +
                        ",[LinerOnlineMonitoring]" +
                        ",[MaterialExposedToClExt]" +
                        ",[MinReqTemperaturePressurisation]" +
                        ",[OnlineMonitoring]" +
                        ",[PresenceSulphidesO2]" +
                        ",[PresenceSulphidesO2Shutdown]" +
                        ",[PressurisationControlled]" +
                        ",[PWHT]" +
                        ",[SteamOutWaterFlush]" +
                        ",[ManagementFactor]" +
                        ",[ThermalHistory]" +
                        ",[YearLowestExpTemp]" +
                        ",[Volume]" +
                        ",[TypeOfSoil]" +
                        ",[EnvironmentSensitivity]" +
                        ",[DistanceToGroundWater]" +
                        ",[AdjustmentSettle]" +
                        ",[ComponentIsWelded]" +
                        ",[TankIsMaintained])" +
                        "VALUES" +
                        "('" + ID + "'" +
                        ",'" + CommissionDate + "'" +
                        ",'" + AdminUpsetManagement + "'" +
                        ",'" + ContainsDeadlegs + "'" +
                        ",'" + CyclicOperation + "'" +
                        ",'" + HighlyDeadlegInsp + "'" +
                        ",'" + DowntimeProtectionUsed + "'" +
                        ",'" + ExternalEnvironment + "'" +
                        ",'" + HeatTraced + "'" +
                        ",'" + InterfaceSoilWater + "'" +
                        ",'" + LinerOnlineMonitoring + "'" +
                        ",'" + MaterialExposedToClExt + "'" +
                        ",'" + MinReqTemperaturePressurisation + "'" +
                        ",'" + OnlineMonitoring + "'" +
                        ",'" + PresenceSulphidesO2 + "'" +
                        ",'" + PresenceSulphidesO2Shutdown + "'" +
                        ",'" + PressurisationControlled + "'" +
                        ",'" + PWHT + "'" +
                        ",'" + SteamOutWaterFlush + "'" +
                        ",'" + ManagementFactor + "'" +
                        ",'" + ThermalHistory + "'" +
                        ",'" + YearLowestExpTemp + "'" +
                        ",'" + Volume + "'" +
                        ",'" + TypeOfSoil + "'" +
                        ",'" + EnvironmentSensitivity + "'" +
                        ",'" + DistanceToGroundWater + "'" +
                        ",'" + AdjustmentSettle + "'" +
                        ",'" + ComponentIsWelded + "'" +
                        ",'" + TankIsMaintained + "')" +
                        " ";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "ADD FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public void edit(int ID, int AdminUpsetManagement, int ContainsDeadlegs, int CyclicOperation, int HighlyDeadlegInsp, int DowntimeProtectionUsed, String ExternalEnvironment, int HeatTraced, int InterfaceSoilWater, int LinerOnlineMonitoring, int MaterialExposedToClExt, double MinReqTemperaturePressurisation, String OnlineMonitoring, int PresenceSulphidesO2, int PresenceSulphidesO2Shutdown, int PressurisationControlled, int PWHT, int SteamOutWaterFlush, double ManagementFactor, String ThermalHistory, int YearLowestExpTemp, double Volume, String TypeOfSoil, String EnvironmentSensitivity, double DistanceToGroundWater, String AdjustmentSettle, int ComponentIsWelded, int TankIsMaintained)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] " +
                        " " +
                        "UPDATE [dbo].[RW_EQUIPMENT]" +
                        "SET [ID] = '" + ID + "'" +
                        ",[AdminUpsetManagement] = '" + AdminUpsetManagement + "'" +
                        ",[ContainsDeadlegs] = '" + ContainsDeadlegs + "'" +
                        ",[CyclicOperation] = '" + CyclicOperation + "'" +
                        ",[HighlyDeadlegInsp] = '" + HighlyDeadlegInsp + "'" +
                        ",[DowntimeProtectionUsed] = '" + DowntimeProtectionUsed + "'" +
                        ",[ExternalEnvironment] = '" + ExternalEnvironment + "'" +
                        ",[HeatTraced] = '" + HeatTraced + "'" +
                        ",[InterfaceSoilWater] = '" + InterfaceSoilWater + "'" +
                        ",[LinerOnlineMonitoring] = '" + LinerOnlineMonitoring + "'" +
                        ",[MaterialExposedToClExt] = '" + MaterialExposedToClExt + "'" +
                        ",[MinReqTemperaturePressurisation] = '" + MinReqTemperaturePressurisation + "'" +
                        ",[OnlineMonitoring] = '" + OnlineMonitoring + "'" +
                        ",[PresenceSulphidesO2] = '" + PresenceSulphidesO2 + "'" +
                        ",[PresenceSulphidesO2Shutdown] = '" + PresenceSulphidesO2Shutdown + "'" +
                        ",[PressurisationControlled] = '" + PressurisationControlled + "'" +
                        ",[PWHT] = '" + PWHT + "'" +
                        ",[SteamOutWaterFlush] = '" + SteamOutWaterFlush + "'" +
                        ",[ManagementFactor] = '" + ManagementFactor + "'" +
                        ",[ThermalHistory] = '" + ThermalHistory + "'" +
                        ",[YearLowestExpTemp] = '" + YearLowestExpTemp + "'" +
                        ",[Volume] = '" + Volume + "'" +
                        ",[TypeOfSoil] = '" + TypeOfSoil + "'" +
                        ",[EnvironmentSensitivity] = '" + EnvironmentSensitivity + "'" +
                        ",[DistanceToGroundWater] = '" + DistanceToGroundWater + "'" +
                        ",[AdjustmentSettle] = '" + AdjustmentSettle + "'" +
                        ",[ComponentIsWelded] = '" + ComponentIsWelded + "'" +
                        ",[TankIsMaintained] = '" + TankIsMaintained + "'" +
                     
                        " WHERE [ID] = '" + ID + "'" +
                        " ";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "EDIT FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public void delete(int ID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        " " +
                        "DELETE FROM [dbo].[RW_EQUIPMENT]" +
                        " WHERE [ID] ='" + ID + "'" +
                        " ";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "DELETE FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        // get datasource 
        public List<RW_EQUIPMENT> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<RW_EQUIPMENT> list = new List<RW_EQUIPMENT>();
            RW_EQUIPMENT obj = null;
            String sql = "Use[rbi] Select[ID]" +
                         ",[CommissionDate]" +
                        ",[AdminUpsetManagement]" +
                        ",[ContainsDeadlegs]" +
                        ",[CyclicOperation]" +
                        ",[HighlyDeadlegInsp]" +
                        ",[DowntimeProtectionUsed]" +
                        ",[ExternalEnvironment]" +
                        ",[HeatTraced]" +
                        ",[InterfaceSoilWater]" +
                        ",[LinerOnlineMonitoring]" +
                        ",[MaterialExposedToClExt]" +
                        ",[MinReqTemperaturePressurisation]" +
                        ",[OnlineMonitoring]" +
                        ",[PresenceSulphidesO2]" +
                        ",[PresenceSulphidesO2Shutdown]" +
                        ",[PressurisationControlled]" +
                        ",[PWHT]" +
                        ",[SteamOutWaterFlush]" +
                        ",[ManagementFactor]" +
                        ",[ThermalHistory]" +
                        ",[YearLowestExpTemp]" +
                        ",[Volume]" +
                        ",[TypeOfSoil]" +
                        ",[EnvironmentSensitivity]" +
                        ",[DistanceToGroundWater]" +
                        ",[AdjustmentSettle]" +
                        ",[ComponentIsWelded]" +
                        ",[TankIsMaintained])" +
                          "From [dbo].[RW_EQUIPMENT]  ";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            obj = new RW_EQUIPMENT();
                            obj.ID = reader.GetInt32(0);
                            obj.CommissionDate = reader.GetDateTime(1);
                            obj.AdminUpsetManagement = reader.GetInt32(2);
                            obj.ContainsDeadlegs = reader.GetInt32(3);
                            obj.CyclicOperation = reader.GetInt32(4);
                            obj.HighlyDeadlegInsp = reader.GetInt32(5);
                            obj.DowntimeProtectionUsed = reader.GetInt32(6);
                            if (!reader.IsDBNull(7))
                            {
                                obj.ExternalEnvironment = reader.GetString(7);
                            }
                            obj.HeatTraced = reader.GetInt32(8);
                            obj.InterfaceSoilWater = reader.GetInt32(9);
                            obj.LinerOnlineMonitoring = reader.GetInt32(10);
                            obj.MaterialExposedToClExt = reader.GetInt32(11);
                            if (!reader.IsDBNull(12))
                            {
                                obj.MinReqTemperaturePressurisation = reader.GetFloat(12);
                            }
                            if (!reader.IsDBNull(13))
                            {
                                obj.OnlineMonitoring = reader.GetString(13);
                            }
                            obj.PresenceSulphidesO2 = reader.GetInt32(14);
                            obj.PresenceSulphidesO2Shutdown = reader.GetInt32(15);
                            obj.PressurisationControlled = reader.GetInt32(16);
                            obj.PWHT = reader.GetInt32(17);
                            obj.SteamOutWaterFlush = reader.GetInt32(18);
                            if (!reader.IsDBNull(19))
                            {
                                obj.ManagementFactor = reader.GetFloat(19);
                            }
                            if (!reader.IsDBNull(20))
                            {
                                obj.ThermalHistory = reader.GetString(20);
                            }
                            obj.YearLowestExpTemp = reader.GetInt32(21);
                            if (!reader.IsDBNull(22))
                            {
                                obj.Volume = reader.GetFloat(22);
                            }
                            if (!reader.IsDBNull(23))
                            {
                                obj.TypeOfSoil = reader.GetString(23);
                            }
                            if (!reader.IsDBNull(24))
                            {
                                obj.EnvironmentSensitivity = reader.GetString(24);
                            }
                            if (!reader.IsDBNull(25))
                            {
                                obj.DistanceToGroundWater = reader.GetFloat(25);
                            }
                            if (!reader.IsDBNull(26))
                            {
                                obj.AdjustmentSettle=reader.GetString(26);
                            }
                            obj.ComponentIsWelded = reader.GetInt32(27);
                            obj.TankIsMaintained = reader.GetInt32(28);
                            list.Add(obj);
                        }
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString(), "GET DATA FAIL");
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
