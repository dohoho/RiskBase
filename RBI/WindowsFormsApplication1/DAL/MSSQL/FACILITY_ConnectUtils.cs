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
                            " GO" +
                            " INSERT INTO[dbo].[FACILITY]" +
                            "([SiteID]" +
                            ",[FacilityName]" +
                            ",[ManagementFactor])" +
                            
                            "VALUE" +
                            "('" + SiteID + "'" +
                            ",'" + FacilityName + "'" +
                            ",'" + ManagementFactor + "')" +
                            
                            "GO";
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
                            "GO" +
                            "UPDATE [dbo].[FACILITY]" +
                            "   SET [FacilityID] = '" + FacilityID + "'" +
                            "      ,[SiteID] = '" + SiteID + "'" +
                            "      ,[FacilityName] = '" + FacilityName + "'" +
                            "      ,[ManagementFactor] = '" + ManagementFactor + "'" +
                                 
                            " WHERE [FacilityID] = '" + FacilityID + "'" +
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
                            obj.ManagementFactor = reader.GetDouble(3);
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
                            obj.ManagementFactor = reader.GetDouble(3);
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
    }
}
