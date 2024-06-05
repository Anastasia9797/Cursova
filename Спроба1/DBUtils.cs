using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Спроба1
{
    class DBUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            string host = "localhost";
            int port = 3306;
            string database = "mydb";
            string username = "monty";
            string password = "some_password1";
            return DBMySQLUtils.GetDBConnection(host, port, database, username, password);
        }
    }
}

