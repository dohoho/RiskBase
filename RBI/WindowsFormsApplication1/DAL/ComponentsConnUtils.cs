using MySql.Data.MySqlClient;
using RBI.Object;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RBI.DAL
{
    class ComponentsConnUtils
    {
        Component com = null;
        public void add(String name, String description, String moc, String linerMOC, String heightLength, String diameter, String norminalThickness, String ca, String designPressure, String designTemp, String noEquid, String comType)
        {
            MySqlConnection conn = DBUtils.getDBConnection();
            conn.Open();
            String sql = "INSERT INTO tbl_component VALUES "
                                                + "('" + name + "',"
                                                + "'" + description + "',"
                                                + "'" + moc + "',"
                                                + "'" + linerMOC + "',"
                                                + "'" + heightLength + "',"
                                                + "'" + diameter + "',"
                                                + "'" + norminalThickness + "',"
                                                + "'" + ca + "',"
                                                + "'" + designPressure + "',"
                                                + "'" + designTemp + "',"
                                                + "'" + noEquid +"',"
                                                + "'" + comType +"')";
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Add data failed" + e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public void edit(String name, String description, String moc, String linerMOC, String heightLength, String diameter, String norminalThickness, String ca, String designPressure, String designTemp, String noEq, String comTyle, String olderName, String olderNo)
        {
            MySqlConnection conn = DBUtils.getDBConnection();
            conn.Open();
            String sql = "UPDATE tbl_component SET "
                                                + "componentName = '" + name + "',"
                                                + "componentDescription = '" + description + "',"
                                                + "MOC = '" + moc + "',"
                                                + "LinearMOC = '" + linerMOC + "',"
                                                + "HeightLength = '" + heightLength + "',"
                                                + "Diameter = '" + diameter + "',"
                                                + "NorminalThickness = '" + norminalThickness + "',"
                                                + "CA = '" + ca + "',"
                                                + "DesignPressure = '" + designPressure + "',"
                                                + "DesignTemp = '" + designTemp + "',"
                                                + "NoEquidment = '" + noEq + "',"
                                                + "ComponentType = '" + comTyle + "'"
                                                + " WHERE componentName = '" + olderName + "' AND NoEquidment ='"+olderNo+"'";
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Edit data failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public void delete(String name, String noEq)
        {
            MySqlConnection conn = DBUtils.getDBConnection();
            conn.Open();
            String sql = "DELETE FROM tbl_component WHERE componentName = '" + name + "' AND NoEquidment ='" + noEq + "'";
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Delete data failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public List<Component> loads()
        {
            List<Component> listEq = new List<Component>();
            MySqlConnection conn = DBUtils.getDBConnection();
            conn.Open();
            String sql = "SELECT * FROM tbl_component";
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            com = new Component();
                            com.Name = reader.GetString(0);
                            com.Description = reader.GetString(1);
                            com.MOC = reader.GetString(2);
                            com.LinerMOC = reader.GetString(3);
                            com.HeightLength = reader.GetString(4);
                            com.Diameter = reader.GetString(5);
                            com.NorminalThickness = reader.GetString(6);
                            com.CA = reader.GetString(7);
                            com.DesignPressure= reader.GetString(8);
                            com.DesignTemp = reader.GetString(9);
                            com.NoEquidment = reader.GetString(10);
                            com.ComponentType = reader.GetString(11);
                            listEq.Add(com);
                        }
                    }
                }
            }
            catch 
            {
                MessageBox.Show("Load data failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return listEq;
        }
        public bool checkExist(String componentNames , String noEquidment)
        {
            bool check = false;
            MySqlConnection conn = DBUtils.getDBConnection();
            conn.Open();
            String sql = "SELECT * FROM tbl_component WHERE componentName ='" + componentNames + "' AND NoEquidment = '" + noEquidment + "'";
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                        check = true;
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("Error" +e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return check;

        }
        public double getCA(String componentName, String noEq)
        {
            Component com = new Component();
            MySqlConnection conn = DBUtils.getDBConnection();
            double ca = 0;
            conn.Open();
            String sql = "SELECT CA FROM tbl_component WHERE componentName ='" + componentName + "' AND NoEquidment = '" + noEq + "'";
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if(reader.GetString(0) != "" || !reader.IsDBNull(0))
                                ca = double.Parse(reader.GetString(0));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error" + e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return ca;
        }

        public Component getcom(String componentNames, String noEq)
        {
            Component com = new Component();
            MySqlConnection conn = DBUtils.getDBConnection();
            conn.Open();
            String sql = "SELECT * FROM tbl_component WHERE componentName ='" + componentNames + "' AND NoEquidment ='" + noEq + "'";
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            com.Name = reader.GetString(0);
                            com.Description = reader.GetString(1);
                            com.MOC = reader.GetString(2);
                            com.LinerMOC = reader.GetString(3);
                            com.HeightLength = reader.GetString(4);
                            com.Diameter = reader.GetString(5);
                            com.NorminalThickness = reader.GetString(6);
                            com.CA = reader.GetString(7);
                            com.DesignPressure = reader.GetString(8);
                            com.DesignTemp = reader.GetString(9);
                            com.NoEquidment = reader.GetString(10);
                            com.ComponentType = reader.GetString(11);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error" + e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return com;
        }
    }
}
