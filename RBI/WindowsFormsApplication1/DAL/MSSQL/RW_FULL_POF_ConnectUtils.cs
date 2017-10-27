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
    class RW_FULL_POF_ConnectUtils
    {
        public void add(int ID, float ThinningAP1, float ThinningAP2, float ThinningAP3, float SCCAP1, float SCCAP2, float SCCAP3, float ExternalAP1, float ExternalAP2, float ExternalAP3, float BrittleAP1, float BrittleAP2, float BrittleAP3, float HTHA_AP1, float HTHA_AP2, float HTHA_AP3, float FatigueAP1, float FatigueAP2, String FatigueAP3, float FMS, String ThinningType,float GFFTotal,float ThinningLocalAP1, float ThinningLocalAP2, float ThinningLocalAP3,float ThinningGeneralAP1, float ThinningGeneralAP2, float ThinningGeneralAP3,float TotalDFAP1, float TotalDFAP2, float TotalDFAP3,float PoFAP1, float PoFAP2, float PoFAP3,float MatrixPoFAP1, float MatrixPoFAP2, float MatrixPoFAP3, float RLI, float SemiAP1, float SemiAP2, float SemiAP3,String PoFAP1Category, String PoFAP2Category,String PoFAP3Category, float CoFValue,String CoFCategory,float CoFMatrixValue)
                       
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                           "INSERT INTO [dbo].[RW_FULL_POF]" +
                           "([ID]" +
                           ",[ThinningAP1]" +
                           ",[ThinningAP2]" +
                           ",[ThinningAP3]" +
                            ",[SCCAP1]" +
                            ",[SCCAP2]" +
                           ",[SCCAP3]" +
                           ",[ExternalAP1]" +
                           ",[ExternalAP2]" +
                           ",[ExternalAP3]" +
                            ",[BrittleAP1]" +
                            ",[BrittleAP2]" +
                           ",[BrittleAP3]" +
                           ",[HTHA_AP1]" +
                            ",[HTHA_AP2]" +
                            ",[HTHA_AP3]" +
                           ",[FatigueAP1]" +
                           ",[FatigueAP2]" +
                           ",[FatigueAP3]" +
                           ",[FMS]" +
                            ",[ThinningType]" +
                            ",[GFFTotal]"+
                            ",[ThinningLocalAP1]" +
                           ",[ThinningLocalAP2]" +
                           ",[ThinningLocalAP3]" +
                            ",[ThinningGeneralAP1]" +
                            ",[ThinningGeneralAP2]" +
                           ",[ThinningGeneralAP3]" +
                           ",[TotalDFAP1]" +
                           ",[TotalDFAP2]" +
                           ",[TotalDFAP3]" +
                            ",[PoFAP1]" +
                            ",[PoFAP2]" +
                           ",[PoFAP3]" +
                           ",[MatrixPoFAP1]" +
                            ",[MatrixPoFAP2]" +
                            ",[MatrixPoFAP3]" +
                           ",[RLI]" +
                           ",[SemiAP1]" +
                           ",[SemiAP2]" +
                           ",[SemiAP3]" +
                            ",[PoFAP1Category]" +
                           ",[PoFAP2Category]" +
                           ",[PoFAP3Category]" +
                           ",[CoFValue]" +
                           ",[CoFCategory]"+
                           ",[CoFMatrixValue])"+
                           " VALUES" +
                           "(  '" + ID + "'" +
                            ", '" + ThinningAP1 + "'" +
                            ",'" + ThinningAP2 + "'" +
                            "," + ThinningAP3 + "" +
                            ", '" + SCCAP1 + "'" +
                            ", '" + SCCAP2 + "'" +
                           ", '" + SCCAP3 + "'" +
                           ", '" + ExternalAP1 + "'" +
                           ", '" + ExternalAP2 + "'" +
                          ", '" + ExternalAP3 + "'" +
                           ", '" + BrittleAP1 + "'" +
                          ",'" + BrittleAP2+ "'" +
                           ", '" + BrittleAP3 + "'" +
                            ", '" + HTHA_AP1 + "'" +
                            ",'" + HTHA_AP2 + "'" +
                            "," + HTHA_AP3 + "" +
                            ", '" + FatigueAP1 + "'" +
                            ", '" + FatigueAP2 + "'" +
                           ", '" + FatigueAP3 + "'" +
                           ", '" + FMS + "'" +
                           ", '" + ThinningType + "'" +
                          ",'" + GFFTotal + "'" +
                           ", '" + ThinningLocalAP1 + "'" +
                            ",'" + ThinningLocalAP2 + "'" +
                            "," + ThinningLocalAP3 + "" +
                            ", '" + ThinningGeneralAP1 + "'" +
                            ", '" + ThinningGeneralAP2 + "'" +
                           ", '" + ThinningGeneralAP3 + "'" +
                           ", '" + TotalDFAP1 + "'" +
                           ", '" + TotalDFAP2 + "'" +
                          ", '" + TotalDFAP3+ "'" +
                           ", '" + PoFAP1 + "'" +
                          ",'" + PoFAP2+ "'" +
                           ", '" + PoFAP3 + "'" +
                            ", '" + MatrixPoFAP1 + "'" +
                            ",'" + MatrixPoFAP2 + "'" +
                            "," + MatrixPoFAP3 + "" +
                            ", '" + RLI + "'" +
                            ", '" + SemiAP1 + "'" +
                           ", '" + SemiAP2 + "'" +
                           ", '" + SemiAP3 + "'" +
                           ", '" + PoFAP1Category + "'" +
                          ",'" + PoFAP2Category + "'" +
                           ", '" + PoFAP3Category + "'" +
                            ", '" + CoFValue + "'" +
                           ", '" + CoFCategory + "'" +
                           ", '" + CoFMatrixValue + "')";
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

        public void edit(int ID, float ThinningAP1, float ThinningAP2, float ThinningAP3, float SCCAP1, float SCCAP2, float SCCAP3, float ExternalAP1, float ExternalAP2, float ExternalAP3, float BrittleAP1, float BrittleAP2, float BrittleAP3, float HTHA_AP1, float HTHA_AP2, float HTHA_AP3, float FatigueAP1, float FatigueAP2, String FatigueAP3, float FMS, String ThinningType, float GFFTotal, float ThinningLocalAP1, float ThinningLocalAP2, float ThinningLocalAP3, float ThinningGeneralAP1, float ThinningGeneralAP2, float ThinningGeneralAP3, float TotalDFAP1, float TotalDFAP2, float TotalDFAP3, float PoFAP1, float PoFAP2, float PoFAP3, float MatrixPoFAP1, float MatrixPoFAP2, float MatrixPoFAP3, float RLI, float SemiAP1, float SemiAP2, float SemiAP3, String PoFAP1Category, String PoFAP2Category, String PoFAP3Category, float CoFValue, String CoFCategory, float CoFMatrixValue)
                        
        {
            {
                SqlConnection conn = MSSQLDBUtils.GetDBConnection();
                conn.Open();
                String sql = "USE [rbi]" +
                              "UPDATE [dbo].[RW_FULL_POFL] " +
                              "SET[ID] = '" + ID + "'" +
                              ",[ThinningAP1] = '" + ThinningAP1 + "'" +
                              ",[ThinningAP2] = '" + ThinningAP2 + "'" +
                              ",[ThinningAP3] = '" + ThinningAP3 + "'" +
                              ",[SCCAP1] = '" + SCCAP1 + "'" +
                             ",[SCCAP2] = '" + SCCAP2 + "'" +
                             ",[SCCAP3] = '" + SCCAP3 + "'" +
                              ",[ExternalAP1] = '" + ExternalAP1 + "'" +
                              ",[ExternalAP2] = '" + ExternalAP2 + "'" +
                              ",[ExternalAP3] = '" + ExternalAP3 + "'" +
                              ",[BrittleAP1] = '" + BrittleAP1 + "'" +
                             ",[BrittleAP2] = '" + BrittleAP2 + "'" +
                              ",[BrittleAP3]= '" + BrittleAP3 + "'" +
                              ",[HTHA_AP1] = '" + HTHA_AP1 + "'" +
                              ",[HTHA_AP2] = '" + HTHA_AP2 + "'" +
                              ",[HTHA_AP3] = '" + HTHA_AP3 + "'" +
                              ",[FatigueAP1] = '" + FatigueAP1 + "'" +
                              ",[FatigueAP2] = '" + FatigueAP2 + "'" +
                             ",[FatigueAP3] = '" + FatigueAP3 + "'" +
                             ",[FMS] = '" + FMS + "'" +
                              ",[ThinningType] = '" + ThinningType + "'" +
                              ",[GFFTotal] = '" + GFFTotal + "'" +
                              ",[ThinningLocalAP1] = '" + ThinningLocalAP1 + "'" +
                              ",[ThinningLocalAP2] = '" + ThinningLocalAP2 + "'" +
                              ",[ThinningLocalAP3] = '" + ThinningLocalAP3 + "'" +
                             ",[ThinningGeneralAP1] = '" + ThinningGeneralAP1 + "'" +
                             ",[ThinningGeneralAP2] = '" + ThinningGeneralAP2 + "'" +
                              ",[ThinningGeneralAP3] = '" + ThinningGeneralAP3 + "'" +
                              ",[TotalDFAP1] = '" + TotalDFAP1 + "'" +
                              ",[TotalDFAP2] = '" + TotalDFAP2 + "'" +
                              ",[TotalDFAP3] = '" + TotalDFAP3 + "'" +
                             ",[PoFAP1] = '" + PoFAP1 + "'" +
                              ",[PoFAP2]= '" + PoFAP2 + "'" +
                              ",[PoFAP3] = '" + PoFAP3 + "'" +
                              ",[MatrixPoFAP1] = '" + MatrixPoFAP1 + "'" +
                              ",[MatrixPoFAP2] = '" + MatrixPoFAP2 + "'" +
                              ",[MatrixPoFAP3] = '" + MatrixPoFAP3 + "'" +
                              ",[RLI] = '" + RLI + "'" +
                             ",[SemiAP1] = '" + SemiAP1 + "'" +
                             ",[SemiAP2] = '" + SemiAP2 + "'" +
                              ",[SemiAP3] = '" + SemiAP3 + "'" +
                               ",[PoFAP1Category] = '" + PoFAP1Category + "'" +
                              ",[PoFAP2Category] = '" + PoFAP2Category + "'" +
                              ",[PoFAP3Category] = '" + PoFAP3Category + "'" +
                              ",[CoFValue] = '" + CoFValue + "'" +
                             ",[CoFCategory] = '" + CoFCategory + "'" +
                             ",[CoFMatrixValue] = '" + CoFMatrixValue + "'" +                           
                              " WHERE [ID] = '" + ID + "'";
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

        public void delete(int ID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] DELETE FROM [dbo].[RW_FULL_POF] WHERE [ID] = '" + ID + "'";
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
        public List<RW_FULL_POF> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<RW_FULL_POF> list = new List<RW_FULL_POF>();
            RW_FULL_POF obj = null;
            String sql = "Use [rbi] Select [ID]" +
                           ",[ThinningAP1]" +
                           ",[ThinningAP2]" +
                           ",[ThinningAP3]" +
                            ",[SCCAP1]" +
                            ",[SCCAP2]" +
                           ",[SCCAP3]" +
                           ",[ExternalAP1]" +
                           ",[ExternalAP2]" +
                           ",[ExternalAP3]" +
                            ",[BrittleAP1]" +
                            ",[BrittleAP2]" +
                           ",[BrittleAP3]" +
                           ",[HTHA_AP1]" +
                            ",[HTHA_AP2]" +
                            ",[HTHA_AP3]" +
                           ",[FatigueAP1]" +
                           ",[FatigueAP2]" +
                           ",[FatigueAP3]" +
                           ",[FMS]" +
                            ",[ThinningType]" +
                            ",[GFFTotal]" +
                            ",[ThinningLocalAP1]" +
                           ",[ThinningLocalAP2]" +
                           ",[ThinningLocalAP3]" +
                            ",[ThinningGeneralAP1]" +
                            ",[ThinningGeneralAP2]" +
                           ",[ThinningGeneralAP3]" +
                           ",[TotalDFAP1]" +
                           ",[TotalDFAP2]" +
                           ",[TotalDFAP3]" +
                            ",[PoFAP1]" +
                            ",[PoFAP2]" +
                           ",[PoFAP3]" +
                           ",[MatrixPoFAP1]" +
                            ",[MatrixPoFAP2]" +
                            ",[MatrixPoFAP3]" +
                           ",[RLI]" +
                           ",[SemiAP1]" +
                           ",[SemiAP2]" +
                           ",[SemiAP3]" +
                            ",[PoFAP1Category]" +
                           ",[PoFAP2Category]" +
                           ",[PoFAP3Category]" +
                           ",[CoFValue]" +
                           ",[CoFCategory]" +
                           ",[CoFMatrixValue]" +
                          "From [dbo].[RW_FULL_POF]  ";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                using (DbDataReader reader =cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            obj = new RW_FULL_POF();
                            obj.ID = reader.GetInt32(0);
                            if (!reader.IsDBNull(1))
                            {
                                obj.ThinningAP1 = reader.GetFloat(1);
                            }
                            if (!reader.IsDBNull(2))
                            {
                                obj.ThinningAP2 = reader.GetFloat(2);
                            }
                            if (!reader.IsDBNull(3))
                            {
                                obj.ThinningAP3 = reader.GetFloat(3);
                            }
                            if (!reader.IsDBNull(4))
                            {
                                obj.SCCAP1 = reader.GetFloat(4);

                            }
                            if (!reader.IsDBNull(5))
                            {
                                obj.SCCAP2 = reader.GetFloat(5);
                            }
                            if (!reader.IsDBNull(6)){
                                obj.SCCAP3 = reader.GetFloat(6);
                            }
                            if (!reader.IsDBNull(7))
                            {
                                obj.ExternalAP1 = reader.GetFloat(7);

                            }
                            if (!reader.IsDBNull(8))
                            {
                                obj.ExternalAP2 = reader.GetFloat(8);
                            }
                            if (!reader.IsDBNull(9))
                            {
                                obj.ExternalAP3 = reader.GetFloat(9);
                            }
                            if (!reader.IsDBNull(10))
                            {
                                obj.BrittleAP1 = reader.GetFloat(10);
                            }
                            if (!reader.IsDBNull(11))
                            {
                                obj.BrittleAP2 = reader.GetFloat(11);
                            }
                            if (!reader.IsDBNull(12))
                            {
                                obj.BrittleAP3 = reader.GetFloat(12);
                            }
                            if (!reader.IsDBNull(13))
                            {
                                obj.HTHA_AP1 = reader.GetFloat(13);
                            }
                            if (!reader.IsDBNull(14))
                            {
                                obj.HTHA_AP2 = reader.GetFloat(14);

                            }
                            if (!reader.IsDBNull(15))
                            {
                                obj.HTHA_AP3 = reader.GetFloat(15);
                            }
                            if (!reader.IsDBNull(16))
                            {
                                obj.FatigueAP1 = reader.GetFloat(16);
                            }
                            if (!reader.IsDBNull(17))
                            {
                                obj.FatigueAP2 = reader.GetFloat(17);
                            }
                            if (!reader.IsDBNull(18))
                            {
                                obj.FatigueAP3 = reader.GetFloat(18);
                            }
                            if (!reader.IsDBNull(19))
                            {
                                obj.FMS = reader.GetFloat(19);
                            }
                            if (!reader.IsDBNull(20))
                            {
                                obj.ThinningType = reader.GetString(20);
                            }
                            if (!reader.IsDBNull(21))
                            {
                                obj.GFFTotal = reader.GetFloat(21);

                            }
                            if (!reader.IsDBNull(22))
                            {
                                obj.ThinningLocalAP1 = reader.GetFloat(22);
                            }
                            if (!reader.IsDBNull(23))
                            {
                                obj.ThinningLocalAP2 = reader.GetFloat(23);
                            }
                            if (!reader.IsDBNull(24))
                            {
                                obj.ThinningLocalAP3 = reader.GetFloat(24);
                            }
                            if (!reader.IsDBNull(25))
                            {
                                obj.ThinningGeneralAP1 = reader.GetFloat(25);

                            }
                            if (!reader.IsDBNull(26))
                            {
                                obj.ThinningGeneralAP2 = reader.GetFloat(26);
                            }
                            if (!reader.IsDBNull(27))
                            {
                                obj.ThinningGeneralAP3 = reader.GetFloat(27);
                            }
                            if (!reader.IsDBNull(28))
                            {
                                obj.TotalDFAP1 = reader.GetFloat(28);
                            }
                            if (!reader.IsDBNull(29))
                            {
                                obj.TotalDFAP2 = reader.GetFloat(29);
                            }
                            if (!reader.IsDBNull(30))
                            {
                                obj.TotalDFAP3 = reader.GetFloat(30);
                            }
                            if (!reader.IsDBNull(31))
                            {
                                obj.PoFAP1 = reader.GetFloat(31);
                            }
                            if (!reader.IsDBNull(32))
                            {
                                obj.PoFAP2 = reader.GetFloat(32);
                            }
                            if (!reader.IsDBNull(33))
                            {
                                obj.PoFAP3 = reader.GetFloat(33);
                            }
                            if (!reader.IsDBNull(34))
                            {
                                obj.MatrixPoFAP1 = reader.GetFloat(34);
                            }
                            if (!reader.IsDBNull(35))
                            {
                                obj.MatrixPoFAP2 = reader.GetFloat(35);
                            }
                            if (!reader.IsDBNull(36))
                            {
                                obj.MatrixPoFAP3 = reader.GetFloat(36);
                            }
                            if (!reader.IsDBNull(37))
                            {
                                obj.RLI = reader.GetFloat(37);

                            }
                            if (!reader.IsDBNull(38))
                            {
                                obj.SemiAP1 = reader.GetFloat(38);
                            }
                            if (!reader.IsDBNull(39))
                            {
                                obj.SemiAP2 = reader.GetFloat(39);
                            }
                            if (!reader.IsDBNull(40))
                            {
                                obj.SemiAP3 = reader.GetFloat(40);
                            }
                            if (!reader.IsDBNull(41))
                            {
                                obj.PoFAP1Category = reader.GetString(41);
                            }
                            if (!reader.IsDBNull(42))
                            {
                                obj.PoFAP2Category = reader.GetString(42);
                            }
                            if (!reader.IsDBNull(43))
                            {
                                obj.PoFAP3Category = reader.GetString(43);
                            }
                            if (!reader.IsDBNull(44))
                            {
                                obj.CoFValue = reader.GetFloat(44);
                            }
                            if (!reader.IsDBNull(45))
                            {
                                obj.CoFCategory = reader.GetString(45);
                            }
                            if (!reader.IsDBNull(46))
                            {
                                obj.CoFMatrixValue = reader.GetFloat(46);
                            }
                            list.Add(obj);


                        }
                    }

                }

            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString(), "GET DATA FAIL !");
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
