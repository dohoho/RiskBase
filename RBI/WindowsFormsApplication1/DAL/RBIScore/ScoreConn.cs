using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RBI.DAL.RBIScore
{
    class ScoreConn
    {
        public void updateScore(String table, String question, String score)
        {
            MySqlConnection conn = DBUtils.getDBConnection();
            conn.Open();
            String sql = "UPDATE tbl_rbi_question_score SET score ='" + score + "' WHERE `table` ='" + table + "' AND `No`='" + question + "'";
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public String getScore( String table, String question)
        {
            String data = "";
            MySqlConnection conn = DBUtils.getDBConnection();
            conn.Open();
            String sql = "SELECT score FROM tbl_rbi_question_score WHERE `table`='" + table + "' AND `No` = '" + question + "'";
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
                            data = reader.ToString();
                        }
                    }
                }
                if (data.Equals(""))
                {
                    data = "";
                }
            }
            catch
            {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return data;
        }
    }
}
