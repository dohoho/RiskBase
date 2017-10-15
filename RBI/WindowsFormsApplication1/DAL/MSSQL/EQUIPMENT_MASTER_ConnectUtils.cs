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
    class EQUIPMENT_MASTER_ConnectUtils
    {
        public void add(String EquipmentNumber,int EquipmentTypeID,String EquipmentName,DateTime CommissionDate,int DesignCodeID,int SiteID,int FacilityID,int ManufacturerID,String PFDNo,String ProcessDescription,string EquipmentDesc,int IsArchived,DateTime Archived,String ArchivedBy)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] " +
                            " GO" +
                            " INSERT INTO[dbo].[EQUIPMENT_MASTER]" +
                            "([EquipmentNumber]" +
                            ",[EquipmentTypeID]" +
                            ",[EquipmentName]" +
                            ",[CommissionDate]" +
                            ",[DesignCodeID]" +
                            ",[SiteID]" +
                            ",[FacilityID]" +
                            ",[ManufacturerID]" +
                            ",[PFDNo]" +
                            ",[ProcessDescription]" +
                            ",[EquipmentDesc]" +
                            ",[IsArchived]" +
                            ",[Archived]" +
                            ",[ArchivedBy])" +
                            "VALUES" +
                            "('" + EquipmentNumber + "'" +
                            ",'" + EquipmentTypeID + "'" +
                            ",'" + EquipmentName + "'" +
                            ",'" + CommissionDate + "'" +
                            ",'" + DesignCodeID + "'" +
                            ",'" + SiteID + "'" +
                            ",'" + FacilityID + "'" +
                            ",'" + ManufacturerID + "'" +
                            ",'" + PFDNo + "'" +
                            ",'" + ProcessDescription + "'" +
                            ",'" + EquipmentDesc + "'" +
                            ",'" + IsArchived + "'" +
                            ",'" + Archived + "'" +
                            ",'" + ArchivedBy + "')" +
                            
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
        public void edit(int EquipmentID,String EquipmentNumber,int EquipmentTypeID,String EquipmentName,DateTime CommissionDate,int DesignCodeID,int SiteID,int FacilityID,int ManufacturerID,String PFDNo,String ProcessDescription,string EquipmentDesc,int IsArchived,DateTime Archived,String ArchivedBy)
            {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                           " GO" +
                           " UPDATE[dbo].[EQUIPMENT_MASTER]" +
                                  "SET[EquipmentID] ='"+EquipmentID+"'" +
                                  ",[EquipmentNumber] = '"+EquipmentNumber+"'" +
                                  ",[EquipmentTypeID] = '"+EquipmentTypeID+"'" +
                                  ",[EquipmentName] = '"+EquipmentName+"'" +
                                  ",[CommissionDate] = '"+CommissionDate+"'" +
                                  ",[DesignCodeID] = '"+DesignCodeID+"'" +
                                  ",[SiteID] = '"+SiteID+"'" +
                                  ",[FacilityID] = '"+FacilityID+"'" +
                                  ",[ManufacturerID] = '"+ManufacturerID+"'" +
                                  ",[PFDNo] = '"+PFDNo+"'" +
                                  ",[ProcessDescription] = '"+ProcessDescription+"'" +
                                  ",[EquipmentDesc] = '"+EquipmentDesc+"'" +
                                  ",[IsArchived] = '"+IsArchived+"'" +
                                  ",[Archived] = '"+Archived+"'" +
                                  ",[ArchivedBy] = '"+ArchivedBy+"'" +
                                 
                                 "WHERE [EquipmentID] ='" + EquipmentID + "'" +
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
        public void delete(int EquipmentID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] DELETE FROM [dbo].[EQUIPMENT_MASTER] where [EquipmentID]='" + EquipmentID + "'";
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
        public List<EQUIPMENT_MASTER> getDataSource()
        {
            List<EQUIPMENT_MASTER> list = new List<EQUIPMENT_MASTER>();
            EQUIPMENT_MASTER obj = null;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = " Use [rbi] go Select [EquipmentID]"+
                          ",[EquipmentNumber]" +
                          ",[EquipmentTypeID]" +
                          ",[EquipmentName]" +
                          ",[CommissionDate]" +
                          ",[DesignCodeID]" +
                          ",[SiteID]" +
                          ",[FacilityID]" +
                          ",[ManufacturerID]" +
                          ",[PFDNo]" +
                          ",[ProcessDescription]" +
                          ",[EquipmentDesc]" +
                          ",[IsArchived]" +
                          ",[Archived]" +
                          ",[ArchivedBy]" +
                          "From [rbi].[dbo].[COMPONENT_TYPE] go";
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
                            obj = new EQUIPMENT_MASTER();
                            obj.EquipmentID = reader.GetInt32(0);
                            obj.EquipmentNumber = reader.GetString(1);
                            obj.EquipmentTypeID = reader.GetInt32(2);
                            obj.EquipmentName = reader.GetString(3);
                            obj.CommissionDate = reader.GetDateTime(4);
                            obj.DesignCodeID = reader.GetInt32(5);
                            obj.SiteID = reader.GetInt32(6);
                            obj.FacilityID = reader.GetInt32(7);
                            obj.ManufacturerID = reader.GetInt32(8);
                            if (!reader.IsDBNull(9))
                            {
                                obj.PFDNo = reader.GetString(9);
                            }
                            if (!reader.IsDBNull(10))
                            {
                                obj.ProcessDescription = reader.GetString(10);
                            }
                            if (!reader.IsDBNull(11))
                            {
                                obj.EquipmentDesc = reader.GetString(11);
                            }
                            obj.IsArchived = reader.GetInt32(12);
                            if (!reader.IsDBNull(13))
                            {
                                obj.Archived = reader.GetDateTime(13);
                            }
                            if (!reader.IsDBNull(14))
                            {
                                obj.ArchivedBy = reader.GetString(14);
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
