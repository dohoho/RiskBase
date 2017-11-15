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
    class COMPONENT_MASTER_ConnectUtils
    {
        public void add(String ComponentNumber, int EquipmentID, int ComponentTypeID, String ComponentName, String ComponentDesc, int IsEquipment, int IsEquipmentLinked, int APIComponentTypeID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                            "INSERT INTO [dbo].[COMPONENT_MASTER]" +
                            "([ComponentNumber]" +
                            ",[EquipmentID]" +
                            ",[ComponentTypeID]" +
                            ",[ComponentName]" +
                            ",[ComponentDesc]" +
                            ",[IsEquipment]" +
                            ",[IsEquipmentLinked]" +
                            ",[APIComponentTypeID]" +
                            ",[CreatedBy])" +
                            "VALUES" +
                            "('" + ComponentNumber + "'" +
                            ",'" + EquipmentID + "'" +
                            ",'" + ComponentTypeID + "'" +
                            ",'" + ComponentName + "'" +
                            ",'" + ComponentDesc + "'" +
                            ",'" + IsEquipment + "'" +
                            ",'" + IsEquipmentLinked + "'" +
                            ",'" + APIComponentTypeID + "'" +
                            ",'" + Environment.UserName + "')";
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
        public void edit(int ComponentID,String ComponentNumber, int EquipmentID, int ComponentTypeID, String ComponentName, String ComponentDesc, int IsEquipment, int IsEquipmentLinked, int APIComponentTypeID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                            "UPDATE [dbo].[COMPONENT_MASTER]" +
                            "   SET [ComponentNumber] = '" + ComponentNumber + "'" +
                            "      ,[EquipmentID] = '" + ComponentID + "'" +
                            "      ,[ComponentTypeID] = '" + ComponentTypeID + "'" +
                            "      ,[ComponentName] = '" + ComponentName + "'" +
                            "      ,[ComponentDesc] = '" + ComponentDesc + "'" +
                            "      ,[IsEquipment] = '" + IsEquipment + "'" +
                            "      ,[IsEquipmentLinked] = '" + IsEquipmentLinked + "'" +
                            "      ,[APIComponentTypeID] = '" + APIComponentTypeID + "'" +
                            "      ,[Modified] = '" + DateTime.Now + "'" +
                            "      ,[ModifiedBy] = '" + Environment.UserName + "'" +
                            " WHERE [ComponentID] = '" + ComponentID + "'";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString(), "EDIT FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

        }
        public void delete(int ComponentID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] DELETE FROM [dbo].[COMPONENT_MASTER] WHERE [ComponentID] = '" + ComponentID + "'";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString(), "DELETE FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public List<COMPONENT_MASTER> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<COMPONENT_MASTER> list = new List<COMPONENT_MASTER>();
            COMPONENT_MASTER obj = null;
            String sql = "USE [rbi] SELECT [ComponentID]" +
                        ",[ComponentNumber]" +
                        ",[EquipmentID]" +
                        ",[ComponentTypeID]" +
                        ",[ComponentName]" +
                        ",[ComponentDesc]" +
                        ",[IsEquipment]" +
                        ",[IsEquipmentLinked]" +
                        ",[APIComponentTypeID]" +
                        "  FROM [rbi].[dbo].[COMPONENT_MASTER]";
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
                            obj = new COMPONENT_MASTER();
                            obj.ComponentID = reader.GetInt32(0);
                            obj.ComponentNumber = reader.GetString(1);
                            obj.EquipmentID = reader.GetInt32(2);
                            obj.ComponentTypeID = reader.GetInt32(3);
                            obj.ComponentName = reader.GetString(4);
                            obj.ComponentDesc = reader.GetString(5);
                            obj.IsEquipment = reader.GetOrdinal("IsEquipment");
                            obj.IsEquipmentLinked = reader.GetOrdinal("IsEquipmentLinked");
                            obj.APIComponentTypeID = reader.GetInt32(8);
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
        public int getAPIComponentTypeID(int EqID)
        {
            int _ID = 0;
            SqlConnection con = MSSQLDBUtils.GetDBConnection();
            con.Open();
            String sql = "SELECT APIComponentTypeId FROM [rbi].[dbo].[COMPONENT_MASTER] WHERE EquipmentID = '"+EqID+"'";
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
                            _ID = reader.GetInt32(0);
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
            return _ID;
        }
        public String getComponentName(int eqID)
        {
            String comName = "";
            SqlConnection con = MSSQLDBUtils.GetDBConnection();
            con.Open();
            String sql = "select ComponentName from rbi.dbo.COMPONENT_MASTER where EquipmentID = '"+eqID+"'";
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
                            comName = reader.GetString(0);
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
            return comName;
        }
        public COMPONENT_MASTER getData(int comID)
        {
            COMPONENT_MASTER obj = new COMPONENT_MASTER();
            SqlConnection con = MSSQLDBUtils.GetDBConnection();
            con.Open();
            String sql = "select ComponentNumber,ComponentTypeID,ComponentName,ComponentDesc,IsEquipmentLinked,APIComponentTypeID from rbi.dbo.COMPONENT_MASTER where ComponentID = '" + comID + "'";
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
                            obj.ComponentNumber = reader.GetString(0);
                            obj.ComponentTypeID = reader.GetInt32(1);
                            obj.ComponentName = reader.GetString(2);
                            obj.ComponentDesc = reader.GetString(3);
                            obj.IsEquipmentLinked = Convert.ToInt32(reader.GetBoolean(4));
                            obj.APIComponentTypeID = reader.GetInt32(5);
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
            return obj;
        }
    }
}
