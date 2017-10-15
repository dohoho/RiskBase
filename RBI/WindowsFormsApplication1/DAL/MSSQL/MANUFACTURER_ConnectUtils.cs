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
    class MANUFACTURER_ConnectUtils
    {
        public void add(String ManufacturerName)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "GO" +
                        "INSERT INTO [dbo].[MANUFACTURER]" +
                        "([ManufacturerName])" +
                        "VALUES" +
                        "('" + ManufacturerName + "')" +
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
        public void edit(int ManufacturerID, String ManufacturerName)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "GO" +
                        "UPDATE [dbo].[MANUFACTURER]" +
                        "SET [ManufacturerName] = '" + ManufacturerName + "'" +
                        
                        "WHERE [ManufacturerID] = '" + ManufacturerID + "'" +
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
        public void delete(int ManufacturerID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "GO" +
                        "DELETE FROM [dbo].[MANUFACTURER]" +
                        "WHERE [ManufacturerID] = '" + ManufacturerID + "' " +
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
        public List<MANUFACTURER> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<MANUFACTURER> list = new List<MANUFACTURER>();
            MANUFACTURER obj = null;
            String sql = " Use [rbi] Select [ManufacturerID]" +
                          ",[ManufacturerName]" +
                          "From [dbo].[MANUFACTURER] go";
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
                            obj = new MANUFACTURER();
                            obj.ManufacturerID = reader.GetInt32(0);
                            obj.ManufacturerName = reader.GetString(1);
                            

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

