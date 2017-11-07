using RBI.Object;
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
    class RW_ASSESSMENT_ConnectUtils
    {
        public void add(int EquipmentID, int ComponentID,DateTime AssessmentDate, int AssessmentMethod, int RiskAnalysisPeriod,int IsEquipmentLinked,String RecordType,int ProposalNo,int RevisionNo,int IsRecommend,String ProposalOrRevision,String AdoptedBy,DateTime AdoptedDate, String RecommendedBy,DateTime RecommendedDate, String ProposalName)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        " " +
                        "INSERT INTO [dbo].[RW_ASSESSMENT]" +
                        "([EquipmentID]" +
                        ",[ComponentID]" +
                        ",[AssessmentDate]" +
                        ",[AssessmentMethod]" +
                        ",[RiskAnalysisPeriod]" +
                        ",[IsEquipmentLinked]" +
                        ",[RecordType]" +
                        ",[ProposalNo]" +
                        ",[RevisionNo]" +
                        ",[IsRecommend]" +
                        ",[ProposalOrRevision]" +
                        ",[AdoptedBy]" +
                        ",[AdoptedDate]" +
                        ",[RecommendedBy]" +
                        ",[RecommendedDate]" +
                        ",[ProposalName])"+
                        "VALUES" +
                        "('" + EquipmentID + "'" +
                        ",'" + ComponentID + "'" +
                        ",'" + AssessmentDate + "'" +
                        ",'" + AssessmentMethod + "'" +
                        ",'" + RiskAnalysisPeriod + "'" +
                        ",'" + IsEquipmentLinked + "'" +
                        ",'" + RecordType + "'" +
                        ",'" + ProposalNo + "'" +
                        ",'" + RevisionNo + "'" +
                        ",'" + IsRecommend + "'" +
                        ",'" + ProposalOrRevision + "'" +
                        ",'" + AdoptedBy + "'" +
                        ",'" + AdoptedDate + "'" +
                        ",'" + RecommendedBy + "'" +
                        ",'" + RecommendedDate + "'" +
                        ",'" + ProposalName + "')" +
                        " ";

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
        public void edit(int ID,int EquipmentID, int ComponentID, DateTime AssessmentDate, int AssessmentMethod, int RiskAnalysisPeriod, int IsEquipmentLinked, String RecordType, int ProposalNo, int RevisionNo, int IsRecommend, String ProposalOrRevision, String AdoptedBy, DateTime AdoptedDate, String RecommendedBy, DateTime RecommendedDate, String ProposalName)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        " " +
                        "UPDATE [dbo].[RW_ASSESSMENT]" +
                        "SET [EquipmentID] = '" + EquipmentID + "'" +
                        ",[ComponentID] = '" + ComponentID + "'" +
                        ",[AssessmentDate] = '" + AssessmentDate + "'" +
                        ",[AssessmentMethod] = '" + AssessmentMethod + "'" +
                        ",[RiskAnalysisPeriod] = '" + RiskAnalysisPeriod + "'" +
                        ",[IsEquipmentLinked] = '" + IsEquipmentLinked + "'" +
                        ",[RecordType] = '" + RecordType + "'" +
                        ",[ProposalNo] = '" + ProposalNo + "'" +
                        ",[RevisionNo] = '" + RevisionNo + "'" +
                        ",[IsRecommend] = '" + IsRecommend + "'" +
                        ",[ProposalOrRevision] = '" + ProposalOrRevision + "'" +
                        ",[AdoptedBy] = '" + AdoptedBy + "'" +
                        ",[AdoptedDate] = '" + AdoptedDate + "'" +
                        ",[RecommendedBy] = '" + RecommendedBy + "'" +
                        ",[RecommendedDate] = '" + RecommendedDate + "'" +
                        ",[ProposalName] = '"+ProposalName+"'"+
                        " WHERE [ID] = '" + ID + "'" +
                        " ";
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
                        " " +
                        "DELETE FROM [dbo].[RW_ASSESSMENT]" +
                        "WHERE [ID]  = '" + ID + "' " +
                        " ";
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
        public List<RW_ASSESSMENT> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<RW_ASSESSMENT> list = new List<RW_ASSESSMENT>();
            RW_ASSESSMENT obj = null;
            String sql = " Use [rbi] Select [ID]" +
                          ",[EquipmentID]" +
                          ",[ComponentID]" +
                          ",[AssessmentDate]" +
                          ",[AssessmentMethod]" +
                          ",[RiskAnalysisPeriod]" +
                          ",[IsEquipmentLinked]" +
                          ",[RecordType]" +
                          ",[ProposalNo]" +
                          ",[RevisionNo]" +
                          ",[IsRecommend]" +
                          ",[ProposalOrRevision]" +
                          ",[AdoptedBy]" +
                          ",[AdoptedDate]" +
                          ",[RecommendedBy]" +
                          ",[RecommendedDate]" +
                          ",[ProposalName]" +
                          "From [dbo].[RW_ASSESSMENT]  ";
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
                            obj = new RW_ASSESSMENT();
                            obj.ID = reader.GetInt32(0);
                            obj.EquipmentID = reader.GetInt32(1);
                            obj.ComponentID = reader.GetInt32(2);
                            if(!reader .IsDBNull (3))
                            {
                                obj.AssessmentDate = reader.GetDateTime(3);
                            }
                            if(!reader .IsDBNull (4))
                            {
                                obj.AssessmentMethod = reader.GetInt32(4);
                            }
                            if(!reader .IsDBNull (5))
                            {
                                obj.RiskAnalysisPeriod = reader.GetInt32(5);
                            }
                            obj.IsEquipmentLinked = reader.GetOrdinal("IsEquipmentLinked");
                            if(!reader .IsDBNull (7))
                            {
                                obj.RecordType = reader.GetString(7);
                            }
                            if(!reader .IsDBNull (8))
                            {
                                obj.ProposalNo = reader.GetInt32(8);
                            }
                            if(!reader .IsDBNull (9))
                            {
                                obj.RevisionNo = reader.GetInt32(9);
                            }
                            obj.IsRecommend = reader.GetOrdinal("IsRecommend");
                            if(!reader .IsDBNull (11))
                            {
                                obj.ProposalOrRevision = reader.GetString(11);
                            }
                            if(!reader.IsDBNull (12))
                            {
                                obj.AdoptedBy = reader.GetString(12);
                            }
                            if(!reader .IsDBNull (13))
                            {
                                obj.AdoptedDate = reader.GetDateTime(13);
                            }
                            if(!reader.IsDBNull (14))
                            {
                                obj.RecommendedBy = reader.GetString(14);
                            }
                            if(!reader.IsDBNull (15))
                            {
                                obj.RecommendedDate = reader.GetDateTime(15);
                            }
                            if(!reader.IsDBNull(16))
                            {
                                obj.ProposalName = reader.GetString(16);
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

