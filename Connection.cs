using System;
using HTTT.QUAN_LY;
using Oracle.ManagedDataAccess.Client;

namespace HTTT
{
    public class DatabaseConnection
    {
        private static string connectionString;

        public static void SetConnectionString(string userConnStr)
        {
            connectionString = userConnStr;
        }

        public DatabaseConnection()
        {       
        }

        public OracleConnection GetConnection()
        {
            return new OracleConnection(connectionString);
        }
    }
}
