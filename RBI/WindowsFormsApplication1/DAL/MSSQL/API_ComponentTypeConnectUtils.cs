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
    class API_ComponentTypeConnectUtils
    {
        public void add(int APIComponentTypeID, String APIComponentTypeName, float GFFSmall, float GFFMedium,
                        float GFFLarge, float GFFRupture, float GFFTotal, float HoleCostSmall, float HoleCostMedium,
                        float HoleCostLarge, float HoleCostRupture, float OutageSmall, float OutageMedium, float OutageLarge,
                        float OutageRupture)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql =   "USE [rbi]"+
                           "INSERT INTO [dbo].[API_COMPONENT_TYPE]"+
                           "([APIComponentTypeID]"+
                           ",[APIComponentTypeName]"+
                           ",[GFFSmall]"+
                           ",[GFFMedium]"+
                           ",[GFFLarge]"+
                           ",[GFFRupture]"+
                           ",[GFFTotal]"+
                           ",[HoleCostSmall]"+
                           ",[HoleCostMedium]"+
                           ",[HoleCostLarge]"+
                           ",[HoleCostRupture]"+
                           ",[OutageSmall]"+
                           ",[OutageMedium]"+
                           ",[OutageLarge]"+
                           ",[OutageRupture])"+
                           " VALUES"+
                           "( '"+APIComponentTypeID+"'"+
                           ", '"+APIComponentTypeName+"'"+
                           ", '"+GFFSmall+"'"+
                           ", '"+GFFMedium+"'"+
                           ", '"+GFFLarge+"'"+
                           ", '"+GFFRupture+"'"+
                           ", '"+GFFTotal+"'"+
                           ", '"+HoleCostSmall+"'"+
                           ", '"+HoleCostMedium+"'"+
                           ", '"+HoleCostLarge+"'"+
                           ", '"+HoleCostRupture+"'"+
                           ", '"+OutageSmall+"'"+
                           ", '"+OutageMedium+"'"+
                           ", '"+OutageLarge+"'"+
                           ", '"+OutageRupture+"')";
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
        public void edit(int APIComponentTypeID, String APIComponentTypeName, float GFFSmall, float GFFMedium,
                       float GFFLarge, float GFFRupture, float GFFTotal, float HoleCostSmall, float HoleCostMedium,
                       float HoleCostLarge, float HoleCostRupture, float OutageSmall, float OutageMedium, float OutageLarge,
                       float OutageRupture)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]"+
                          "UPDATE [dbo].[API_COMPONENT_TYPE] " +
                          "SET[APIComponentTypeID] = '"+APIComponentTypeID+"'" +
                          ",[APIComponentTypeName] = '"+APIComponentTypeName+"'" +
                          ",[GFFSmall] = '"+GFFSmall+"'" +
                          ",[GFFMedium] = '"+GFFMedium+"'" +
                          ",[GFFLarge] = '"+GFFLarge+"'" +
                          ",[GFFRupture] = '"+GFFRupture+"'" +
                          ",[GFFTotal] = '"+GFFTotal+"'" +
                          ",[HoleCostSmall] = '"+HoleCostSmall+"'" +
                          ",[HoleCostMedium] = '"+HoleCostMedium+"'" +
                          ",[HoleCostLarge] = '"+HoleCostLarge+"'" +
                          ",[HoleCostRupture] = '"+HoleCostRupture+"'" +
                          ",[OutageSmall] = '"+OutageSmall+"'" +
                          ",[OutageMedium] = '"+OutageMedium+"'" +
                          ",[OutageLarge] = '"+OutageLarge+"'" +
                          ",[OutageRupture] = '"+OutageRupture+"'" +
                          ",[Modified] = '"+DateTime.Now+"'" +
                          " WHERE [APIComponentTypeID] = '"+APIComponentTypeID+"'";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
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
        public void delete(int APIComponentTypeID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]  go DELETE FROM [dbo].[API_COMPONENT_TYPE] WHERE [dbo].[API_COMPONENT_TYPE] = '" + APIComponentTypeID + "' go ";
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

        // dung file get data
        // dung file get list( data source)
        public API_COMPONENT_TYPE getData(String APIComponentTypeName)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            API_COMPONENT_TYPE obj = new API_COMPONENT_TYPE();
            String sql = " Use [rbi] Select [APIComponentTypeID]"+
                          ",[APIComponentTypeName]" +
                          ",[GFFSmall]" +
                          ",[GFFMedium]" +
                          ",[GFFLarge]" +
                          ",[GFFRupture]" +
                          ",[GFFTotal]" +
                          ",[HoleCostSmall]" +
                          ",[HoleCostMedium]" +
                          ",[HoleCostLarge]" +
                          ",[HoleCostRupture]" +
                          ",[OutageSmall]" +
                          ",[OutageMedium]" +
                          ",[OutageLarge]" +
                          ",[OutageRupture]" +
                          "From [dbo].[API_COMPONENT_TYPE] Where [APIComponentTypeName] ='" + APIComponentTypeName + "' go";
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
                            obj.APIComponentTypeID = reader.GetInt32(0);
                            obj.APIComponentTypeName = APIComponentTypeName;
                            //sua getDouble thanh getFloat
                            obj.GFFSmall = reader.GetFloat(2);
                            obj.GFFMedium = reader.GetFloat(3);
                            obj.GFFLarge = reader.GetFloat(4);
                            obj.GFFRupture = reader.GetFloat(5);
                            obj.GFFTotal = reader.GetFloat(6);
                            obj.HoleCostSmall = reader.GetFloat(7);
                            obj.HoleCostMedium = reader.GetFloat(8);
                            obj.HoleCostLarge = reader.GetFloat(9);
                            obj.HoleCostRupture = reader.GetFloat(10);
                            obj.OutageSmall = reader.GetFloat(11);
                            obj.OutageMedium = reader.GetFloat(12);
                            obj.OutageLarge = reader.GetFloat(13);
                            obj.OutageRupture = reader.GetFloat(14);
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
            return obj;
        }
        public List<API_COMPONENT_TYPE> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<API_COMPONENT_TYPE> list = new List<API_COMPONENT_TYPE>();
            API_COMPONENT_TYPE obj = null;
            String sql = " Use [rbi] Select [APIComponentTypeID]" +
                          ",[APIComponentTypeName]" +
                          ",[GFFSmall]" +
                          ",[GFFMedium]" +
                          ",[GFFLarge]" +
                          ",[GFFRupture]" +
                          ",[GFFTotal" +
                          ",[HoleCostSmall]" +
                          ",[HoleCostMedium]" +
                          ",[HoleCostLarge]" +
                          ",[HoleCostRupture]" +
                          ",[OutageSmall]" +
                          ",[OutageMedium]" +
                          ",[OutageLarge]" +
                          ",[OutageRupture]" +
                          "From [dbo].[API_COMPONENT_TYPE] go";
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
                            obj = new API_COMPONENT_TYPE();
                            obj.APIComponentTypeID = reader.GetInt32(0);
                            obj.APIComponentTypeName = reader.GetString(1);
                            obj.GFFSmall = reader.GetFloat(2);
                            obj.GFFMedium = reader.GetFloat(3);
                            obj.GFFLarge = reader.GetFloat(4);
                            obj.GFFRupture = reader.GetFloat(5);
                            obj.GFFTotal = reader.GetFloat(6);
                            obj.HoleCostSmall = reader.GetFloat(7);
                            obj.HoleCostMedium = reader.GetFloat(8);
                            obj.HoleCostLarge = reader.GetFloat(9);
                            obj.HoleCostRupture = reader.GetFloat(10);
                            obj.OutageSmall = reader.GetFloat(11);
                            obj.OutageMedium = reader.GetFloat(12);
                            obj.OutageLarge = reader.GetFloat(13);
                            obj.OutageRupture = reader.GetFloat(14);
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
