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
    class SITES_ConnectUtils
    {
        public void add(String SiteName)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                           "INSERT INTO [dbo].[SITES]" +
                           "([SiteName])" +
                           " VALUES" +
                           "(  '" + SiteName + "')";
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
        public void edit(int SiteID,String SiteName)
        {
            {
                SqlConnection conn = MSSQLDBUtils.GetDBConnection();
                conn.Open();
                String sql = "USE [rbi]" +
                              "UPDATE [dbo].[SITES] " +
                              "SET[SiteID] = '" + SiteID + "'" +
                              ",[SiteName] = '" + SiteName + "'" +
                              " WHERE [SiteID] = '" + SiteID + "'";
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = sql;
                    cmd.Connection = conn;
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
        }

        public void delete(int SiteID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] DELETE FROM [dbo].[SITES] WHERE [SiteID] = '" + SiteID + "'";
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

        // dung file get data
        // dung file get list( data source)
        public List<SITES> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<SITES> list = new List<SITES>();
            SITES obj = null;
            String sql = "Use [rbi]" +
                        "SELECT [SiteID]" +
                        ",[SiteName]" +
                        "  FROM [rbi].[dbo].[SITES]";
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
                            obj = new SITES();
                            obj.SiteID = reader.GetInt32(0);
                            obj.SiteName = reader.GetString(1);
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
    
        public String getSiteName(int SiteID)
        {
            String name = "";
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "select SiteName from rbi.dbo.SITES where SiteID = '"+SiteID+"'";
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
        public List<String> getSitesName()
        {
            List<String> name = new List<String>();
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "select SiteName from rbi.dbo.SITES";
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
                            name.Add(reader.GetString(0));
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
