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
    class DESIGN_CODE_ConnectUtils
    {
        public void add(String DesignCode, String DesignCodeApp)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "GO" +
                        "INSERT INTO [dbo].[DESIGN_CODE]" +
                        "([DesignCode]" +
                        ",[DesignCodeApp])" +
                        "VALUES" +
                        "('" + DesignCode + "'" +
                        ",'" + DesignCodeApp + "')" +
                        "GO";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString(), "ADD FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public void edit(int DesignCodeID, String DesignCode, String DesignCodeApp)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "GO" +
                        "UPDATE [dbo].[DESIGN_CODE]" +
                        "SET [DesignCode] = '" + DesignCode + "'" +
                        ",[DesignCodeApp] = '" + DesignCodeApp + "'" +
                        ",[Modified] = '" + DateTime.Now + "'" +
                        "WHERE [DesignCodeID] = '" + DesignCodeID + "'" +
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
                MessageBox.Show(e.ToString(), "EDIT FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public void delete(int DesignCodeID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "GO" +
                        "DELETE FROM [dbo].[DESIGN_CODE]" +
                        "WHERE [DesignCodeID] = '" + DesignCodeID + "'" +
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
                MessageBox.Show(e.ToString(), "DELETE FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public List<DESIGN_CODE> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<DESIGN_CODE> list = new List<DESIGN_CODE>();
            DESIGN_CODE obj = null;
            String sql = " Use [rbi] Select [DesignCodeID]"+
                          ",[DesignCode]"+
                          ",[DesignCodeApp]"+
                          "From [rbi].[dbo].[DESIGN_CODE] go";
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
                            obj = new DESIGN_CODE();
                            obj.DesignCodeID = reader.GetInt32(0);
                            obj.DesignCode = reader.GetString(1);
                            if (!reader.IsDBNull(2))
                            {
                                obj.DesignCodeApp = reader.GetString(2);
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
