using RBI.Object.ObjectMSSQL;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RBI.DAL.MSSQL
{
    class RW_COMPONENT_ConnectUtils
    {
        public void add(int ID, float NominalDiameter, float NominalThickness, float CurrentThickness, float MinReqThickness, float CurrentCorrosionRate, String BranchDiameter, String BranchJointType, String BrinnelHardness, int ChemicalInjection, int HighlyInjectionInsp, String ComplexityProtrusion, String CorrectiveAction, int CracksPresent, String CyclicLoadingWitin15_25m, int DamageFoundInspection, float DeltaFATT, String NumberPipeFittings, String PipeCondition, String PreviousFailures, String ShakingAmount, int ShakingDetected, String ShakingTime, int TrampElements, float ShellHeight, int ReleasePreventionBarrier, int ConcreteFoundation, String SeverityOfVibration)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "GO" +
                        "INSERT INTO [dbo].[RW_COMPONENT]" +
                        "([ID]" +
                        ",[NominalDiameter]" +
                        ",[NominalThickness]" +
                        ",[CurrentThickness]" +
                        ",[MinReqThickness]" +
                        ",[CurrentCorrosionRate]" +
                        ",[BranchDiameter]" +
                        ",[BranchJointType]" +
                        ",[BrinnelHardness]" +
                        ",[ChemicalInjection]" +
                        ",[HighlyInjectionInsp]" +
                        ",[ComplexityProtrusion]" +
                        ",[CorrectiveAction]" +
                        ",[CracksPresent]" +
                        ",[CyclicLoadingWitin15_25m]" +
                        ",[DamageFoundInspection]" +
                        ",[DeltaFATT]" +
                        ",[NumberPipeFittings]" +
                        ",[PipeCondition]" +
                        ",[PreviousFailures]" +
                        ",[ShakingAmount]" +
                        ",[ShakingDetected]" +
                        ",[ShakingTime]" +
                        ",[TrampElements]" +
                        ",[ShellHeight]" +
                        ",[ReleasePreventionBarrier]" +
                        ",[ConcreteFoundation]" +
                        ",[SeverityOfVibration])" +
                        "VALUES" +
                        "('" + ID + "'" +
                        ",'" + NominalDiameter + "'" +
                        ",'" + NominalThickness + "'" +
                        ",'" + CurrentThickness + "'" +
                        ",'" + MinReqThickness + "'" +
                        ",'" + CurrentCorrosionRate + "'" +
                        ",'" + BranchDiameter + "'" +
                        ",'" + BranchJointType + "'" +
                        ",'" + BrinnelHardness + "'" +
                        ",'" + ChemicalInjection + "'" +
                        ",'" + HighlyInjectionInsp + "'" +
                        ",'" + ComplexityProtrusion + "'" +
                        ",'" + CorrectiveAction + "'" +
                        ",'" + CracksPresent + "'" +
                        ",'" + CyclicLoadingWitin15_25m + "'" +
                        ",'" + DamageFoundInspection + "'" +
                        ",'" + DeltaFATT + "'" +
                        ",'" + NumberPipeFittings + "'" +
                        ",'" + PipeCondition + "'" +
                        ",'" + PreviousFailures + "'" +
                        ",'" + ShakingAmount + "'" +
                        ",'" + ShakingDetected + "'" +
                        ",'" + ShakingTime + "'" +
                        ",'" + TrampElements + "'" +
                        ",'" + ShellHeight + "'" +
                        ",'" + ReleasePreventionBarrier + "'" +
                        ",'" + ConcreteFoundation + "'" +
                        ",'" + SeverityOfVibration + "')" +
                        "GO";
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
        public void edit(int ID, float NominalDiameter, float NominalThickness, float CurrentThickness, float MinReqThickness, float CurrentCorrosionRate, String BranchDiameter, String BranchJointType, String BrinnelHardness, int ChemicalInjection, int HighlyInjectionInsp, String ComplexityProtrusion, String CorrectiveAction, int CracksPresent, String CyclicLoadingWitin15_25m, int DamageFoundInspection, float DeltaFATT, String NumberPipeFittings, String PipeCondition, String PreviousFailures, String ShakingAmount, int ShakingDetected, String ShakingTime, int TrampElements, float ShellHeight, int ReleasePreventionBarrier, int ConcreteFoundation, String SeverityOfVibration)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "GO" +
                        "UPDATE [dbo].[RW_COMPONENT]" +
                        "SET [ID] = '" + ID + "'" +
                        "[NominalDiameter] = '" + NominalDiameter + "'" +
                        "[NominalThickness] = '" + NominalThickness + "'" +
                        "[CurrentThickness] = '" + CurrentThickness + "'" +
                        "[MinReqThickness] = '" + MinReqThickness + "'" +
                        "[CurrentCorrosionRate] = '" + CurrentCorrosionRate + "'" +
                        "[BranchDiameter] = '" + BranchDiameter + "'" +
                        "[BranchJointType] = '" + BranchJointType + "'" +
                        "[BrinnelHardness] = '" + BrinnelHardness + "'" +
                        "[ChemicalInjection] = '" + ChemicalInjection + "'" +
                        "[HighlyInjectionInsp] = '" + HighlyInjectionInsp + "'" +
                        "[ComplexityProtrusion] = '" + ComplexityProtrusion + "'" +
                        "[CorrectiveAction] = '" + CorrectiveAction + "'" +
                        "[CracksPresent] = '" + CracksPresent + "'" +
                        "[CyclicLoadingWitin15_25m] = '" + CyclicLoadingWitin15_25m + "'" +
                        "[DamageFoundInspection] = '" + DamageFoundInspection + "'" +
                        "[DeltaFATT] = '" + DeltaFATT + "'" +
                        "[NumberPipeFittings] = '" + NumberPipeFittings + "'" +
                        "[PipeCondition] = '" + PipeCondition + "'" +
                        "[PreviousFailures] = '" + PreviousFailures + "'" +
                        "[ShakingAmount] = '" + ShakingAmount + "'" +
                        "[ShakingDetected] = '" + ShakingDetected + "'" +
                        "[ShakingTime] = '" + ShakingTime + "'" +
                        "[TrampElements] = '" + TrampElements + "'" +
                        "[ShellHeight] = '" + ShellHeight + "'" +
                        "[ReleasePreventionBarrier] = '" + ReleasePreventionBarrier + "'" +
                        "[ConcreteFoundation] = '" + ConcreteFoundation + "'" +
                        "[SeverityOfVibration] = '" + SeverityOfVibration + "'" +
                        
                        " WHERE [ID] = '" + ID + "'" +
                        "GO";
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
                        "GO" +
                        "DELETE FROM [dbo].[RW_COMPONENT]" +
                        "WHERE [ID]  = '" + ID + "' " +
                        "GO";
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
        public List<RW_COMPONENT> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<RW_COMPONENT> list = new List<RW_COMPONENT>();
            RW_COMPONENT obj = null;
            String sql = " Use [rbi] Select [ID]" +
                          ",[NominalDiameter]" +
                          ",[NominalThickness]" +
                          ",[CurrentThickness]" +
                          ",[MinReqThickness]" +
                          ",[CurrentCorrosionRate]" +
                          ",[BranchDiameter]" +
                          ",[BranchJointType]" +
                          ",[BrinnelHardness]" +
                          ",[ChemicalInjection]" +
                          ",[HighlyInjectionInsp]" +
                          ",[ComplexityProtrusion]" +
                          ",[CorrectiveAction]" +
                          ",[CracksPresent]" +
                          ",[CyclicLoadingWitin15_25m]" +
                          ",[DamageFoundInspection]" +
                          ",[DeltaFATT]" +
                          ",[NumberPipeFittings]" +
                          ",[PipeCondition]" +
                          ",[PreviousFailures]" +
                          ",[ShakingAmount]" +
                          ",[ShakingDetected]" +
                          ",[ShakingTime]" +
                          ",[TrampElements]" +
                          ",[ShellHeight]" +
                          ",[ReleasePreventionBarrier]" +
                          ",[ConcreteFoundation]" +
                          ",[SeverityOfVibration]" +
                          "From [dbo].[RW_COMPONENT] go";
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
                            obj = new RW_COMPONENT();
                            obj.ID = reader.GetInt32(0);
                            if (!reader.IsDBNull(1))
                            {
                                obj.NominalDiameter = reader.GetFloat(1);
                            }
                            if (!reader.IsDBNull(2))
                            {
                                obj.NominalThickness = reader.GetFloat(2);
                            }
                            if (!reader.IsDBNull(3))
                            {
                                obj.CurrentThickness = reader.GetFloat(3);
                            }
                            if (!reader.IsDBNull(4))
                            {
                                obj.MinReqThickness = reader.GetFloat(4);
                            }
                            if (!reader.IsDBNull(5))
                            {
                                obj.CurrentCorrosionRate = reader.GetFloat(5);
                            }
                            if (!reader.IsDBNull(6))
                            {
                                obj.BranchDiameter = reader.GetString(6);
                            }
                            if (!reader.IsDBNull(7))
                            {
                                obj.BranchJointType = reader.GetString(7);
                            }
                            if (!reader.IsDBNull(8))
                            {
                                obj.BrinnelHardness = reader.GetString(8);
                            }

                            obj.ChemicalInjection = reader.GetInt32(9);
                            obj.HighlyInjectionInsp = reader.GetInt32(10);
                            if(!reader .IsDBNull (11))
                            {
                                obj.ComplexityProtrusion = reader.GetString(11);
                            }
                            if (!reader.IsDBNull(12))
                            {
                                obj.CorrectiveAction = reader.GetString(12);
                            }
                            obj.CracksPresent = reader.GetInt32(13);
                            if(!reader .IsDBNull (14))
                            {
                                obj.CyclicLoadingWitin15_25m = reader.GetString(14);
                            }
                            obj.DamageFoundInspection = reader.GetInt32(15);
                            if (!reader.IsDBNull(16))
                            {
                                obj.DeltaFATT = reader.GetFloat(16);
                            }
                            if (!reader.IsDBNull(17))
                            {
                                obj.NumberPipeFittings = reader.GetString(17);
                            }
                            if (!reader.IsDBNull(18))
                            {
                                obj.PipeCondition = reader.GetString(18);
                            }
                            if (!reader.IsDBNull(19))
                            {
                                obj.PreviousFailures = reader.GetString(19);
                            }
                            if (!reader.IsDBNull(20))
                            {
                                obj.ShakingAmount = reader.GetString(20);
                            }
                            obj.ShakingDetected = reader.GetInt32(21);
                            if (!reader.IsDBNull(20))
                            {
                                obj.ShakingTime = reader.GetString(22);
                            }
                            obj.TrampElements = reader.GetInt32(23);
                            if(!reader .IsDBNull (24))
                            {
                                obj.ShellHeight = reader.GetFloat(24);
                            }
                            obj.ReleasePreventionBarrier = reader.GetInt32(25);
                            obj.ConcreteFoundation = reader.GetInt32(26);
                            if(!reader .IsDBNull (27))
                            {
                                obj.SeverityOfVibration = reader.GetString(27);
                            }
                           list.Add(obj);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "GET DATA FAIL!");
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


