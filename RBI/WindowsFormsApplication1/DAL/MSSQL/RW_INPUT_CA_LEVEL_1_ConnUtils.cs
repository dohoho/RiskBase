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
    class RW_INPUT_CA_LEVEL_1_ConnUtils
    {
        public void Add(String API_FLUID, String SYSTEM, String Release_Duration, String Detection_Type, String Isulation_Type, String Mitigation_System, float Equipment_Cost, float Injure_Cost, float Evironment_Cost, float Toxic_Percent, float Personal_Density, float Material_Cost, float Production_Cost, float Mass_Inventory, float Mass_Component, float Stored_Pressure, float Stored_Temp)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] " +
                        "INSERT INTO [dbo].[RW_INPUT_CA_LEVEL1] " +
                        "([API_FLUID] " +
                        ",[SYSTEM] " +
                        ",[Release_Duration] " +
                        ",[Detection_Type] " +
                        ",[Isulation_Type] " +
                        ",[Mitigation_System] " +
                        ",[Equipment_Cost] " +
                        ",[Injure_Cost] " +
                        ",[Evironment_Cost] " +
                        ",[Toxic_Percent] " +
                        ",[Personal_Density] " +
                        ",[Material_Cost] " +
                        ",[Production_Cost] " +
                        ",[Mass_Inventory] " +
                        ",[Mass_Component] " +
                        ",[Stored_Pressure] " +
                        ",[Stored_Temp]) " +
                        "VALUES " +
                        "('" + API_FLUID + "' " +
                        ",'" + SYSTEM + "' " +
                        ",'" + Release_Duration + "' " +
                        ",'" + Detection_Type + "' " +
                        ",'" + Isulation_Type + "' " +
                        ",'" + Mitigation_System + "'" +
                        ",'" + Equipment_Cost + "'" +
                        ",'" + Injure_Cost + "'" +
                        ",'" + Evironment_Cost + "'" +
                        ",'" + Toxic_Percent + "'" +
                        ",'" + Personal_Density + "'" +
                        ",'" + Material_Cost + "'" +
                        ",'" + Production_Cost + "'" +
                        ",'" + Mass_Inventory + "'" +
                        ",'" + Mass_Component + "'" +
                        ",'" + Stored_Pressure + "'" +
                        ",'" + Stored_Temp + "') ";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("ADD FAIL!", "ERROR!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public void Edit(int ID, String API_FLUID, String SYSTEM, String Release_Duration, String Detection_Type, String Isulation_Type, String Mitigation_System, float Equipment_Cost, float Injure_Cost, float Evironment_Cost, float Toxic_Percent, float Personal_Density, float Material_Cost, float Production_Cost, float Mass_Inventory, float Mass_Component, float Stored_Pressure, float Stored_Temp)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] " +
                        "UPDATE [dbo].[RW_INPUT_CA_LEVEL1] " +
                        "SET [API_FLUID] = '" + API_FLUID + "' " +
                        ",[SYSTEM] = '" + SYSTEM + "' " +
                        ",[Release_Duration] = '" + Release_Duration + "' " +
                        ",[Detection_Type] = '" + Detection_Type + "' " +
                        ",[Isulation_Type] = '" + Isulation_Type + "' " +
                        ",[Mitigation_System] = '" + Mitigation_System + "'" +
                        ",[Equipment_Cost] = '" + Equipment_Cost + "' " +
                        ",[Injure_Cost] = '" + Injure_Cost + "' " +
                        ",[Evironment_Cost] = '" + Evironment_Cost + "' " +
                        ",[Toxic_Percent] = '" + Toxic_Percent + "' " +
                        ",[Personal_Density] = '" + Personal_Density + "' " +
                        ",[Material_Cost] = '" + Material_Cost + "' " +
                        ",[Production_Cost] = '" + Production_Cost + "' " +
                        ",[Mass_Inventory] = '" + Mass_Inventory + "' " +
                        ",[Mass_Component] = '" + Mass_Component + "' " +
                        ",[Stored_Pressure] = '" + Stored_Pressure + "' " +
                        ",[Stored_Temp] = '" + Stored_Temp + "' " +
                        " WHERE [ID] = '" + ID + "' ";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("EDIT FAIL!", "ERROR!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public void Delete(int ID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "DELETE FROM [dbo].[RW_INPUT_CA_LEVEL1]" +
                        "WHERE [ID] = '" + ID + "' ";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("DELETE FAIL!", "ERROR!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public RW_INPUT_CA_LEVEL_1 GetData(int ID)
        {
            RW_INPUT_CA_LEVEL_1 obj = new RW_INPUT_CA_LEVEL_1();
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] SELECT [API_FLUID]" +
                        ",[SYSTEM]" +
                        ",[Release_Duration]" +
                        ",[Detection_Type]" +
                        ",[Isulation_Type]" +
                        ",[Mitigation_System]" +
                        ",[Equipment_Cost]" +
                        ",[Injure_Cost]" +
                        ",[Evironment_Cost]" +
                        ",[Toxic_Percent]" +
                        ",[Personal_Density]" +
                        ",[Material_Cost]" +
                        ",[Production_Cost]" +
                        ",[Mass_Inventory]" +
                        ",[Mass_Component]" +
                        ",[Stored_Pressure]" +
                        ",[Stored_Temp]" +
                        "  FROM [rbi].[dbo].[RW_INPUT_CA_LEVEL1] WHERE [ID] = '" + ID + "'";
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
                            obj.API_FLUID = reader.GetString(0);
                            obj.SYSTEM = reader.GetString(1);
                            obj.Release_Duration = reader.GetString(2);
                            obj.Detection_Type = reader.GetString(0);
                            obj.Isulation_Type = reader.GetString(0);
                            obj.Mitigation_System = reader.GetString(0);
                            obj.Equipment_Cost = (float)reader.GetDouble(0);
                            obj.Injure_Cost = (float)reader.GetDouble(0);
                            obj.Environment_Cost = (float)reader.GetDouble(0);
                            obj.Toxic_Percent = (float)reader.GetDouble(0);
                            obj.Personal_Density = (float)reader.GetDouble(0);
                            obj.Material_Cost = (float)reader.GetDouble(0);
                            obj.Production_Cost = (float)reader.GetDouble(0);
                            obj.Mass_Inventory = (float)reader.GetDouble(0);
                            obj.Mass_Component = (float)reader.GetDouble(0);
                            obj.Stored_Pressure = (float)reader.GetDouble(0);
                            obj.Stored_Temp = (float)reader.GetDouble(0);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("GET DATA FAIL!", "ERROR!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return obj;
        }
    }
}
