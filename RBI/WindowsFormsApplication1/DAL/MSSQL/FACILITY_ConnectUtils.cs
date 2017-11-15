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

    class FACILITY_ConnectUtils
    {
        public void add(int SiteID,String FacilityName,float ManagementFactor)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] " +
                            " INSERT INTO[dbo].[FACILITY]" +
                            "([SiteID]" +
                            ",[FacilityName]" +
                            ",[ManagementFactor])" +
                            "VALUES" +
                            "('" + SiteID + "'" +
                            ",'" + FacilityName + "'" +
                            ",'" + ManagementFactor + "')";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
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
        public void edit(int FacilityID,int SiteID,String FacilityName,float ManagementFactor)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                            "UPDATE [dbo].[FACILITY]" +
                            "   SET [FacilityID] = '" + FacilityID + "'" +
                            "      ,[SiteID] = '" + SiteID + "'" +
                            "      ,[FacilityName] = '" + FacilityName + "'" +
                            "      ,[ManagementFactor] = '" + ManagementFactor + "'" +
                            " WHERE [FacilityID] = '" + FacilityID + "'";
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
        public void delete(int FacilityID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] DELETE FROM [dbo].[FACILITY] WHERE [FacilityID] = '" + FacilityID + "'";
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
        public List<FACILITY> getDataSource()
        {
            List<FACILITY> list = new List<FACILITY>();
            FACILITY obj = null;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE[rbi]" +
                        "SELECT [FacilityID]" +
                        ",[SiteID]" +
                        ",[FacilityName]" +
                        ",[ManagementFactor]" +
                        "  FROM [rbi].[dbo].[FACILITY]";
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
                            obj = new FACILITY();
                            obj.FacilityID = reader.GetInt32(0);
                            if (!reader.IsDBNull(1)) { obj.SiteID = reader.GetInt32(1); }
                            obj.FacilityName = reader.GetString(2);
                            obj.ManagementFactor = (float)reader.GetDouble(3);
                            list.Add(obj);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("GET DATA SOURCE FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return list;
        }
        public FACILITY getData(int FacilityID)
        {
            FACILITY obj = new FACILITY();
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE[rbi]" +
                        "SELECT [FacilityID]" +
                        ",[SiteID]" +
                        ",[FacilityName]" +
                        ",[ManagementFactor]" +
                        "  FROM [rbi].[dbo].[FACILITY] WHERE [FacilityID] = '"+FacilityID+"'";
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
                            obj.FacilityID = reader.GetInt32(0);
                            if (!reader.IsDBNull(1)) { obj.SiteID = reader.GetInt32(1); }
                            obj.FacilityName = reader.GetString(2);
                            obj.ManagementFactor = (float)reader.GetDouble(3);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("GET DATA SOURCE FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return obj;
        }
        public float getFMS(int SiteID)
        {
            float FMS = 0;
            SqlConnection con = MSSQLDBUtils.GetDBConnection();
            con.Open();
            String sql = "SELECT ManagementFactor FROM [rbi].[dbo].[FACILITY] WHERE SiteID = '"+SiteID+"'";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = con;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            FMS = (float)reader.GetDouble(0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Get FMS Fail------->" + ex.ToString(), "Get Data Fail");
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return FMS;
        }
        public String getFacilityName(int faciID)
        {
            String name = "";
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "select FacilityName from rbi.dbo.FACILITY where FacilityID = '"+faciID+"'";
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
                            name = reader.GetString(0);
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
            return name;
        }
    }
}
