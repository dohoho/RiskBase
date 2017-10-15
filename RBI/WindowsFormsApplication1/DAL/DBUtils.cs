using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.DAL
{
    class DBUtils
    {
        public static MySqlConnection getDBConnection()
        {
            String host = "localhost";
            String databaseName = "rbi";
            int port = 3306;
            String usr = "root";
            String pw = "root";
            /*
            String host = "192.168.121.1";
            String databaseName = "rbi";
            int port = 3306;
            String usr = "user1";
            String pw = "root";
            */
            return MySQLConnectionUtils.GetDBConnection(host, port, databaseName, usr, pw);

        }
    }
}
